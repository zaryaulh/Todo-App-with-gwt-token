namespace Integrify.Application.Todo
{
    public interface IUserRegistrationRepo
    {
        void Register(Guid userId,string email,string pass, DateTime createdOn, DateTime updatedOn);
        void Commit();
    }
}