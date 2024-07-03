using System.IO;

public class PemRSAHandler
{
    public static RSA ReadRSAPrivateKeyFromPemFile(string path)
    {
        string privateKeyPem = File.ReadAllText(path);
        return CreateRsaPrivateFromPem(privateKeyPem);
    }

    private static RSA CreateRsaPrivateFromPem(string pem)
    {
        pem = pem.Replace("-----BEGIN RSA PRIVATE KEY-----", string.Empty)
                 .Replace("-----END RSA PRIVATE KEY-----", string.Empty)
                 .Replace("\r", string.Empty)
                 .Replace("\n", string.Empty);

        byte[] keyBytes = Convert.FromBase64String(pem);

        RSA rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(keyBytes, out _);
        return rsa;
    }

    public static RSA ReadRSAPublicKeyFromPemFile(string path)
    {
        string publicKeyPem = File.ReadAllText(path);
        return CreateRsaPublicFromPem(publicKeyPem);
    }

    private static RSA CreateRsaPublicFromPem(string pem)
    {
        pem = pem.Replace("-----BEGIN RSA PUBLIC KEY-----", string.Empty)
                 .Replace("-----END RSA PUBLIC KEY-----", string.Empty)
                 .Replace("\r", string.Empty)
                 .Replace("\n", string.Empty);

        byte[] keyBytes = Convert.FromBase64String(pem);

        RSA rsa = RSA.Create();
        rsa.ImportRSAPublicKey(keyBytes, out _);
        return rsa;
    }
}