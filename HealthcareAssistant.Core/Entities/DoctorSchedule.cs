using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareAssistant.Core.Entities;

public class DoctorSchedule
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public DateTime AvailableDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public bool IsBooked { get; set; }

    public Doctor? Doctor { get; set; }
}
