namespace NoteVaultSecureAPI.Models
{
public class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public ICollection<Note> Notes { get; set; }
}
}