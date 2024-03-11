namespace Core.Security.JWT;
public class TokenOptions
{
    public string Audience { get; set; } // Kullanıcı kitlesi (Kimler kullanabilir)
    public string Issuer { get; set; } // imzalayan (Kim tarafından imzalandı)
    public int AccessTokenExpiration { get; set; } // Erişim süresi (Dakika cinsinden)
    public string SecurityKey { get; set; } // Güvenlik anahtarı (Şifreleme ve doğrulama için)
    public int RefreshTokenTTL { get; set; } // Yenileme anahtarı süresi (Dakika cinsinden)

    public TokenOptions()
    {
        Audience = string.Empty;
        Issuer = string.Empty;
        SecurityKey = string.Empty;
    }

    public TokenOptions(string audience, string issuer, int accessTokenExpiration, string securityKey, int refreshTokenTTL)
    {
        Audience = audience;
        Issuer = issuer;
        AccessTokenExpiration = accessTokenExpiration;
        SecurityKey = securityKey;
        RefreshTokenTTL = refreshTokenTTL;
    }

}
