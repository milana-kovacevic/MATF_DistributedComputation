﻿using ControlNode.Abstraction.Models;

namespace ControlNode.Abstraction.Models
{
    /// <summary>
    /// Extension methods for Job and its related objects.
    /// </summary>
    public static class JobExtension
    {
        public static bool IsActive(this JobResult jobResult)
        {
            return jobResult.State == JobState.Pending
                || jobResult.State == JobState.Queued
                || jobResult.State == JobState.InProgress;
        }
        public static bool IsFinalState(this JobState state)
        {
            return state == JobState.Succeeded
                || state == JobState.Failed;
        }
    }
}
