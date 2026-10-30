using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Application.DTOs.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Status { get; set; } = "";
    }
}
