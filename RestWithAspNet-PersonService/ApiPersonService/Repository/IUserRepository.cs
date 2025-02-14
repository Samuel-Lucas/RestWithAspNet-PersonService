using ApiPersonService.Data.VO;
using ApiPersonService.Model;

namespace ApiPersonService.Repository;

public interface IUserRepository
{
    User ValidateCredentials(UserVO user);
}