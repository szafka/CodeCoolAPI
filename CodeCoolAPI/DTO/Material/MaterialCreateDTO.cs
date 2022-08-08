namespace CodeCoolAPI.DTO.Material
{
    public class MaterialCreateDTO
    {
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
        public int AuthorId { get; set; }
        public int TypeId { get; set; }
    }
}
