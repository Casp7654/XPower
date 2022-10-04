namespace XPowerApi.Interfaces
{
    public interface IPasswordHasher
    {
        /// <summary>
        /// Generates a new random salt.
        /// </summary>
        /// <returns>Byte array representing the salt.</returns>
        public byte[] GenerateSalt();

        /// <summary>
        /// Converts salt to string
        /// </summary>
        /// <param name="salt">The byte array representing salt.</param>
        /// <returns>A string representing the salt.</returns>
        public string SaltToString(byte[] salt);

        /// <summary>
        /// Hash the given password with the given salt.
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <param name="salt">The salt used to encrypt.</param>
        /// <returns>The hashed password in string</returns>
        public string HashPassword(string password, byte[] salt);
    }
}