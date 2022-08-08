namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Location { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public MaterialType MaterialType { get; set; }
        public int TypeId { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}