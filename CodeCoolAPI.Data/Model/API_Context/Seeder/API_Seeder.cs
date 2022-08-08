using System.Security.Cryptography;
using System.Text;

namespace CodeCoolAPI.Data.Model.API_Context.Seeder
{
    public static class API_Seeder
    {
        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            //Material type seeder
            var materialTypeList = new List<MaterialType>();
            materialTypeList.Add(new MaterialType { TypeId = 1, Type = "Pdf file", Description = "Outline of definition in .pdf type file" });
            materialTypeList.Add(new MaterialType { TypeId = 2, Type = "Ebook", Description = "Ebook-materil with lectures read by the author" });
            materialTypeList.Add(new MaterialType { TypeId = 3, Type = "Video", Description = "Video-tutorial with developed step-by-step examples" });
            materialTypeList.Add(new MaterialType { TypeId = 4, Type = "WorkBook", Description = "WorkBook with definitions, samples, excersices, answers" });
            modelBuilder.Entity<MaterialType>().HasData(materialTypeList);
            //

            //Admin Credentials
            CreatePassword("admin", out byte[] passwordHash, out byte[] passwordSalt);
            var credentials = new CredentialsContainer("admin", "admin")
            {
                CredentialsId = new Guid("ac0b5af3-7368-414a-b40c-ccb9c97adeae"),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            modelBuilder.Entity<CredentialsContainer>().HasData(credentials);
        }

        public static void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
