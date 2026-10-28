namespace HealthcareAssistant.RAG.Retrieval;

public class RagService : IRagService
{
    public async Task<string> SearchAsync(string query)
    {
        query = query.ToLower();

        var documentsPath =
            Path.Combine(
                Directory.GetCurrentDirectory(),
                "Documents");

        if (query.Contains("kidney") ||
            query.Contains("ckd"))
        {
            return await File.ReadAllTextAsync(
                Path.Combine(
                    documentsPath,
                    "ckd.txt"));
        }

        if (query.Contains("diabetes"))
        {
            return await File.ReadAllTextAsync(
                Path.Combine(
                    documentsPath,
                    "diabetes.txt"));
        }

        if (query.Contains("hypertension"))
        {
            return await File.ReadAllTextAsync(
                Path.Combine(
                    documentsPath,
                    "hypertension.txt"));
        }

        return "No medical information found.";
    }
}