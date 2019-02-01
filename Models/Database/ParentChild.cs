namespace WebApp1.Models.Database
{
    public class ParentChild
    {
        public int ParentId { get; set; }
        public Category Parent { get; set; }
        public int ChildId { get; set; }
        public Category Child { get; set; }
    }
}