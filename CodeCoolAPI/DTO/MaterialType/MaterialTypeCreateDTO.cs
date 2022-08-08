namespace CodeCoolAPI.DTO.MaterialType
{
    public class MaterialTypeCreateDTO
    {
        [Required]
        [MaxLength(20)]
        public string? Type { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
