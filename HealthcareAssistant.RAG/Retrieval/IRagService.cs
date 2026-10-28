using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAssistant.RAG.Retrieval;

public interface IRagService
{
    Task<string> SearchAsync(
        string query);
}
