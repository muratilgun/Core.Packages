using Core.Persistence.Repositories;

namespace Core.Security.Entities;
public class OtpAuthenticator : Entity<Guid>
{
    public Guid UserId { get; set; }
    public byte[] Secret { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; } = null!; 

    public OtpAuthenticator()
    {
        Secret = Array.Empty<byte>();
    }

    public OtpAuthenticator(Guid userId, byte[] secret,bool isVerified)
    {
        UserId = userId;
        Secret = secret;
        IsVerified = isVerified;
    }

    public OtpAuthenticator(Guid id, Guid userId, byte[] secret, bool isVerified) : base(id)
    {
        UserId = userId;
        Secret = secret;
        IsVerified = isVerified;
    }
}
