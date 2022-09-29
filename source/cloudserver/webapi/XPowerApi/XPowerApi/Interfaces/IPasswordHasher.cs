namespace XPowerApi.Interfaces
{
    public interface IPasswordHasher
    {
        public byte[] GenerateSalt();
        public string SaltToString(byte[] salt);
        public string HashPassword(string password, byte[] salt);
    }
}