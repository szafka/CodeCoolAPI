namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class MaterialType
    {
        [Key]
        public int TypeId { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}