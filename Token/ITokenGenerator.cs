namespace AIR_RESERVATION_SYSTEM_API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(string name, string pass);
    }
}
