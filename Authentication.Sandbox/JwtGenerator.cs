namespace Authentication.Sandbox;
public class JwtGenerator
{
    public static string GenerateToken(RSA privateKey)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        JwtSecurityToken token = new(
            "testing.com.br",
            "testing2.com.br",
            CreateClaims(),
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: new SigningCredentials(
                new RsaSecurityKey(privateKey)
                {
                    KeyId = "TestSigning"
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