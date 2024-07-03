public class JwtValidator
{
    public static (bool, string) ValidateToken(string token, RSA publicKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new RsaSecurityKey(publicKey),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = "testing.com.br",
                ValidAudience = "testing2.com.br",
            }, out SecurityToken validatedToken);

            return (true, "Válido!");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}