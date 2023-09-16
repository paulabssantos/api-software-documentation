public class CreateRequirementsFactory
{
    public void SetSequential<T>(int sequential, List<T> requirements) where T : Requirements
    {
        requirements.ForEach(requirements =>
        {
            sequential = sequential + 1;
            requirements.Sequential = sequential;
        });
    }

    public void SetProjectId<T>(int ProjectId, List<T> requirements) where T : Requirements
    {
        requirements.ForEach(requirements =>
        {
            requirements.ProjectId = ProjectId;
        });
    }
}