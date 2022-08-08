using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public int Rate { get; set; }
    }
}