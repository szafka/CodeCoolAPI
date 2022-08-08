namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
