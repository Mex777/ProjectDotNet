namespace SayIt.Helpers;

using System;
using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    private const int SaltSize = 16; // 16 bytes for the salt
    private const int HashSize = 20; // 20 bytes for the PBKDF2 hash
    private const int Iterations = 10000; // Number of PBKDF2 iterations

    public static string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

        // Hash the password using PBKDF2
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Combine salt and hash and convert to Base64
        byte[] combinedSaltAndHash = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, combinedSaltAndHash, 0, SaltSize);
        Array.Copy(hash, 0, combinedSaltAndHash, SaltSize, HashSize);

        return Convert.ToBase64String(combinedSaltAndHash);
    }

    public static bool VerifyPassword(string inputPassword, string storedCombinedSaltAndHash)
    {
        // Convert stored combined salt and hash from Base64
        byte[] combinedSaltAndHash = Convert.FromBase64String(storedCombinedSaltAndHash);

        // Extract salt and hash from the combined value
        byte[] salt = new byte[SaltSize];
        byte[] storedHashBytes = new byte[HashSize];
        Array.Copy(combinedSaltAndHash, 0, salt, 0, SaltSize);
        Array.Copy(combinedSaltAndHash, SaltSize, storedHashBytes, 0, HashSize);

        // Hash the input password with the stored salt
        var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, Iterations);
        byte[] newHash = pbkdf2.GetBytes(HashSize);

        // Compare the stored hash with the newly computed hash
        for (int i = 0; i < HashSize; i++)
        {
            if (storedHashBytes[i] != newHash[i])
            {
                return false;
            }
        }

        return true;
    }
}
