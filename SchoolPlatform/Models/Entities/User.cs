using View.Models.Enums;

namespace View.Models.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public int EntityId { get; set; }
}