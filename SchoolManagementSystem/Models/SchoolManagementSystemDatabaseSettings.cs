namespace SchoolManagementSystem.Models
{
    public class SchoolManagementSystemDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string SubjetColletionName { get; set; } = null!;
        public string StudentColletionName { get; set; } = null!;
        public string TeacherColletionName { get; set; } = null!;
        public string AssessmentColletionName { get; set; } = null!;
    }
}
