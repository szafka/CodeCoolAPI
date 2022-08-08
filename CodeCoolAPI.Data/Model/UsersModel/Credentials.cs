namespace CodeCoolAPI.Data.Model.UsersModel
{
    public class CredentialsContainer
    {
        [Key]
        public Guid CredentialsId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public CredentialsContainer(string login, string password)
        {
            Login = login;
            Password = password;

        }
        public override bool Equals(object? obj)
        {
            return obj is CredentialsContainer container &&
                   CredentialsId.Equals(container.CredentialsId);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(CredentialsId, Login, Password);
        }
    }
}
