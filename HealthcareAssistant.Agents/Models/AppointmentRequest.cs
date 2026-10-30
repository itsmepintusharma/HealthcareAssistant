using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Agents.Models
{
    public class AppointmentRequest
    {
        public int PatientId { get; set; }

        public string Specialization { get; set; } = "";

        public DateTime AppointmentDate { get; set; }
    }
}
