namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class MaterialType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}