using ApiPersonService.Data.VO;

namespace ApiPersonService.Business;

public interface ILoginBusiness
{
    TokenVO ValidateCredentials(UserVO user);
    TokenVO ValidateCredentials(TokenVO token);
}