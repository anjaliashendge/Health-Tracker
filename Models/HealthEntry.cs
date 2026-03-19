using System;

namespace HealthTracker.Models
{
    public class HealthEntry
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double SleepHours { get; set; }

        public double WaterLiters { get; set; }

        public int ExerciseMinutes { get; set; }
    }
}