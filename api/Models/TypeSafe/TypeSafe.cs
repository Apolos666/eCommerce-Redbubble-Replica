namespace api.Models.TypeSafe;

public class TypeSafe
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Contributor = "Contributor";
    }

    public static class Controller
    {
        public const string Student = "Student";
        public const string Teacher = "Teacher";
        public const string Module = "Module";
        public const string ClassRoom = "ClassRoom";
    }

    public static class Permissions
    {
        public const int None = 0;
        public const int Read = 1;
        public const int Write = 2;
        public const int Update = 3;
        public const int Patch = 4;
        public const int Delete = 5;
    }

    public static class Policies
    {
        public const string ReadPolicy = "ReadPolicy";
        public const string ReadAndWritePolicy = "AddAndReadPolicy";
        public const string FullControlPolicy = "FullControlPolicy";

        public const string GenericPolicy = "GenericPolicy";
    }
}