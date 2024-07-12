namespace Authentication.Sandbox;
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
                IssuerSigningKey = new RsaSecurityKey(publicKey)
                {
                    KeyId = JwtGenerator.Kid
                },
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = JwtGenerator.Issuer,
                ValidAudience = JwtGenerator.Audience,
            }, out SecurityToken validatedToken);

            return (true, "Valid!");
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}