namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
