namespace Authentication.Sandbox;

public class PemRSAHandler
{
    public static RSA ReadRsaPkcs8PrivateKeyFromFile(string path, string password)
    {
        string privateKeyPem = File.ReadAllText(path);
        return CreateRsaPrivateFromPem(privateKeyPem, password);
    }

    private static RSA CreateRsaPrivateFromPem(string pem, string password)
    {
        pem = pem.Replace("-----BEGIN ENCRYPTED PRIVATE KEY-----", string.Empty)
                 .Replace("-----END ENCRYPTED PRIVATE KEY-----", string.Empty)
                 .Replace("\r", string.Empty)
                 .Replace("\n", string.Empty);

        byte[] keyBytes = Convert.FromBase64String(pem);

        RSA rsa = RSA.Create();
        rsa.ImportEncryptedPkcs8PrivateKey(password, keyBytes, out _);
        return rsa;
    }

    public static RSA ReadRsaPkcs8PublicKeyFromFile(string path)
    {
        string publicKeyPem = File.ReadAllText(path);
        return CreateRsaPublicFromPem(publicKeyPem);
    }

    private static RSA CreateRsaPublicFromPem(string pem)
    {
        pem = pem.Replace("-----BEGIN PUBLIC KEY-----", string.Empty)
                 .Replace("-----END PUBLIC KEY-----", string.Empty)
                 .Replace("\r", string.Empty)
                 .Replace("\n", string.Empty);

        byte[] keyBytes = Convert.FromBase64String(pem);

        RSA rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(keyBytes, out _);
        return rsa;
    }
}