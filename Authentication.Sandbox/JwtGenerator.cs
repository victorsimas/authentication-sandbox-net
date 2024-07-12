namespace Authentication.Sandbox;
public class JwtGenerator
{
    public const string Issuer = "https://some-auth.domain.com.br";
    public const string Audience = "https://some.domain.com.br";
    public const string Kid = "TestingSignatureKey";

    public static string GenerateToken(RSA privateKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        JwtSecurityToken token = new(
            Issuer,
            Audience,
            CreateClaims(),
            expires: DateTime.UtcNow.AddYears(10),
            signingCredentials: new SigningCredentials(
                new RsaSecurityKey(privateKey)
                {
                    KeyId = Kid
                }, SecurityAlgorithms.RsaSha256));

        return tokenHandler.WriteToken(token);
    }

    private static IEnumerable<Claim> CreateClaims()
    {
        IEnumerable<Claim> claims =
        [
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserIdentity", "Joshep Edward")
        ];

        return claims;
    }
}