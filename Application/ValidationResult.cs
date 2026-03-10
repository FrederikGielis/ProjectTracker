namespace ProjectTracker.Application;

public class ValidationResult
{
    public bool IsValid => Errors.Count == 0;
    public Dictionary<string, string> Errors { get; } = new();

    public void AddError(string field, string message)
    {
        Errors[field] = message;
    }
}
