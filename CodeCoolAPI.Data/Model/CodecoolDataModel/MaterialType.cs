namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class MaterialType
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Type { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}