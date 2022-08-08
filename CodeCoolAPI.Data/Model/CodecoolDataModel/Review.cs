namespace CodeCoolAPI.Data.Model.CodecoolDataModel
{
    public class Review
    {
        public int ReviewId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Material Material { get; set; }
        public int MaterialId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int Rate { get; set; }
    }
}