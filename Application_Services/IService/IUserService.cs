using Common_API.Request;
using Common_API.Respone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application_Services
{
    public interface IUserService
    {
        Task<APIResponse<string>> Authenticate(APIUserLoginRequest request);
        Task<APIResponse<bool>> Register(APIUserRegisterRequest request);
        Task<APIResponse<bool>> Update(Guid Id, APIUserUpdateRequest request);
        Task<APIResponse<bool>> Remove(Guid Id);
        
    }
}
