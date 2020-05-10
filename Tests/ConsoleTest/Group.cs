namespace ConsoleTest
{
    internal class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString() => $"[{Id}]{Name}";
    }
}
