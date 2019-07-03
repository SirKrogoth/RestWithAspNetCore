using RestWithAspNetCoreCorrect.Model;

namespace RestWithAspNetCoreCorrect.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
