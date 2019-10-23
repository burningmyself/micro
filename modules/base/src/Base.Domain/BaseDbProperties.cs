namespace Base
{
    public static class BaseDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Base";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Base";
    }
}
