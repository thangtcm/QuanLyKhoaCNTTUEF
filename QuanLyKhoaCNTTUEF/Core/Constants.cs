namespace QuanLyKhoaCNTTUEF.Core
{
    public static class Constants
    {
        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string Manager = "Manager";
            public const string Teacher = "Teacher";
            public const string Staff = "Staff";
            public const string Student = "Student";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireManager = "RequireManager";
            public const string RequireTeacher = "RequireTeacher";
            public const string RequireStaff = "RequireStaff";
        }
    }
}
