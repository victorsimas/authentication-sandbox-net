RSA privateKey = PemRSAHandler.ReadRSAPrivateKeyFromPemFile("private_key.pem");
RSA publicKey = PemRSAHandler.ReadRSAPublicKeyFromPemFile("public_key.pem");

(bool resultado, string mensagem) = GerarEValidarToken(privateKey, publicKey);

Console.WriteLine("\n Assinatura Privada e Validacao Publica : " + resultado + " " + mensagem);

static (bool, string) GerarEValidarToken(RSA signingKey, RSA validationKey)
{
    string tokenJWT = JwtGenerator.GenerateToken(signingKey);

    return JwtValidator.ValidateToken(tokenJWT, validationKey);
}
