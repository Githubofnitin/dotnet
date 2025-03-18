public class User
{
    public string Username { get; set; }
    public string HashedPassword { get; set; }

    // Register a new user by hashing their password
    public void Register(string password)
    {
        this.HashedPassword = HashPassword(password);
    }

    // Authenticate user by comparing the hashed password
    public bool Authenticate(string inputPassword)
    {
        return VerifyPassword(inputPassword, this.HashedPassword);
    }

    // Hash password using SHA-256
    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    // Verify password by comparing hashes
    private bool VerifyPassword(string inputPassword, string storedHashedPassword)
    {
        string hashedInputPassword = HashPassword(inputPassword);
        return hashedInputPassword == storedHashedPassword;
    }
}
public class DataEncryption
{
    private static readonly string Key = "this_is_a_secret_key";
    private static readonly string Iv = "this_is_iv_123456";

    // Encrypt sensitive data
    public static string Encrypt(string data)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = Encoding.UTF8.GetBytes(Iv);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(data);
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    // Decrypt encrypted data
    public static string Decrypt(string encryptedData)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(Key);
            aesAlg.IV = Encoding.UTF8.GetBytes(Iv);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedData)))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                return srDecrypt.ReadToEnd();
            }
        }
    }
}

public class LoggerService
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public static void LogError(Exception ex)
    {
        Logger.Error(ex, "An error occurred");
    }

    public static void LogInfo(string message)
    {
        Logger.Info(message);
    }
}

public class Application
{
    public static void Main()
    {
        try
        {
            var user = new User();
            user.Register("SecurePassword123");

            Console.WriteLine("User registered!");

            bool isAuthenticated = user.Authenticate("SecurePassword123");

            if (isAuthenticated)
            {
                Console.WriteLine("User authenticated!");
            }
            else
            {
                Console.WriteLine("Authentication failed.");
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError(ex);
        }
    }
}

public class UserTests
{
    [Fact]
    public void Test_RegisterAndAuthenticate_Success()
    {
        var user = new User();
        user.Register("SecurePassword123");

        bool result = user.Authenticate("SecurePassword123");

        Assert.True(result);
    }

    [Fact]
    public void Test_EncryptionAndDecryption()
    {
        string originalData = "Sensitive User Data";
        string encryptedData = DataEncryption.Encrypt(originalData);
        string decryptedData = DataEncryption.Decrypt(encryptedData);

        Assert.Equal(originalData, decryptedData);
    }
}
