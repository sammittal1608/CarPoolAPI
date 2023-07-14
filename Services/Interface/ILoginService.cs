using Models;
namespace Services.Interface
{
    public interface ILoginService
    {
        //public void GetUserDetails(User userdetails);
        User Register(Credentials signUp);
        User SignIn(Credentials signin);
    }
}
