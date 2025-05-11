using System;

namespace UserService.Domain.Entity;

public class EOTP
{
    public Guid Id { get; set; }
    public OTPType OTPType { get; set; } //screen type
    public int FailCount { get; set; }
    public int AttemptCount { get; set; }
    public DateTime ExpiryTime { get; set; }
    public Guid UserId { get; set; }
    public string OtpValue { get; set; }
}
public enum OTPType
{
    Authentication
}