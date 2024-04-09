namespace Core.Singleton;

public class Singleton
{
    private static Singleton _instance = null;
    private static object locker = new object();
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public Boolean IsBeneficiary { get; set; }
    public string? Email { get; set; }
    public string? UserPassword { get; set; }
    public string? Details { get; set; }
    public int? AvatarId { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }

    private Singleton()
    {
    }

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            lock (locker)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
        }

        return _instance;
    }
}