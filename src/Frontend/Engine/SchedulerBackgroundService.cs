﻿using Frontend.Models;
using System.Threading.Tasks;

namespace Frontend.Engine
{
    /// <summary>
    /// Scheduler background service inherits IHostedService. As the name says, it runs in a background of an application.
    /// Purpose of the scheduler is to monitor on the queued jobs in JobManager, and to schedule them.
    /// </summary>
    public class SchedulerBackgroundService : BackgroundService
    {
        private readonly ILogger<SchedulerBackgroundService> _logger;
        private readonly JobQueue _jobQueue;
        private readonly IScheduler _scheduler;

        public SchedulerBackgroundService(
            ILogger<SchedulerBackgroundService> logger,
            JobQueue jobQueue,
            IScheduler scheduler)
        {
            this._logger = logger;
            this._jobQueue = jobQueue;
            this._scheduler = scheduler; 
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken) => Task.Run(async () =>
        {
            _logger.LogInformation("Scheduler Background Service loop is running.");

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    // Fetch next job from the queue.
                    // This is blocking call. Wait here until there is job in a queue to be picked up.
                    var jobToBeScheduled = _jobQueue.DequeueJob();
                    if (jobToBeScheduled == null)
                    {
                        _logger.LogWarning("jobToBeScheduled is null. This should never happen.");
                        continue;
                    }

                    // Check if the job is canceled in the meantime.
                    if (jobToBeScheduled.State == JobState.Cancelled)
                    {
                        _logger.LogWarning($"Job {jobToBeScheduled.Id} is canceled. Skipping scheduling.");
                        continue;
                    }

                    // Schedule job.
                    _logger.LogInformation($"Scheduling job with id {jobToBeScheduled.Id}.");
                    await this._scheduler.ScheduleJobAsync(jobToBeScheduled);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Unhandled exception occurred.");
                }
            }

            _logger.LogInformation("Scheduler Background Service loop is canceled.");

            return Task.CompletedTask;
        });
    }
}