using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.Application.DTOs.DashboardStats
{
    public class DashboardStatsDto
    {
        public int Patients { get; set; }

        public int Doctors { get; set; }

        public int Appointments { get; set; }

        public int Conversations { get; set; }
    }
}
