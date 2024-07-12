string tokenJWT = string.Empty;

using (RSA privateKey = PemRSAHandler.ReadRsaPkcs8PrivateKeyFromFile("private_key.pem", "TestingAsymmetric"))
{
    tokenJWT = JwtGenerator.GenerateToken(privateKey);

    Console.WriteLine("Authenticated! Here's your token:\n" + tokenJWT);
};

using (RSA publicKey = PemRSAHandler.ReadRsaPkcs8PublicKeyFromFile("public_key.pem"))
{
    (bool jwtIsValid, string message) = JwtValidator.ValidateToken(tokenJWT, publicKey);

    Console.WriteLine("Here's a validation test:\n" + 
        "IsValid? : " + jwtIsValid + "\n" + 
        "ValidationMessage : " + message);
};
