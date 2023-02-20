namespace LoginAuth.Models
{
    public interface IUser
    {
        ICollection<User> GetUsers();
        void Adduser(User user);


    }
}
