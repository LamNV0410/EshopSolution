using Common.ExtentionMethods;
using Common_API.Request;
using Common_API.Respone;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;

namespace Application_Services.Service
{
    public class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        /// <summary>
        /// Login Authenticate
        /// </summary>
        /// <param name="request">user name and Password</param>
        /// <returns> value </returns>
        public async Task<APIResponse<string>> Authenticate(APIUserLoginRequest request)
        {
            string userName = request.UserName;
            AppUser user = null;
            bool flag = false;
            user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                flag = false;
            }
            else
            {
                SignInResult result = await _signInManager
                    .PasswordSignInAsync(request.UserName, request.Password, request.IsRememberMe, true);
                if (!result.Succeeded)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            if (!flag)
            {
                return new APIResponse<string>()
                {
                    Message = "User name or Password is correct !",
                    ResponseBody = null
                };
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new APIResponse<string>()
            {
                Message = null,
                ResponseBody = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        /// <summary>
        /// Register User 
        /// </summary>
        /// <param name="request">Information user regist</param>
        /// <returns>True / false</returns>
        public async Task<APIResponse<bool>> Register(APIUserRegisterRequest request)
        {
            string userName = request.UserName;
            AppUser userIsExsit = await _userManager.FindByNameAsync(userName);
            if (userIsExsit == null)
            {
                // TODO : validate Email  --- Send code for Email
                AppUser userRegist = new AppUser()
                {
                    UserName = request.UserName,
                    Dob = request.DateOfBirth,
                    FirstName = request.FirstName,
                    LastName = request.FirstName,
                    Email = request.Email,
                };

                IdentityResult result = await _userManager.CreateAsync(userRegist, request.Password);
                if (result.Succeeded)
                {
                    return new APIResponse<bool>()
                    {
                        Message = "Register Success",
                        ResponseBody = true
                    };
                }
                else
                {
                    return new APIResponse<bool>()
                    {
                        Message = "Register false ! Please contact development",
                        ResponseBody = false
                    };
                }
            }

            return new APIResponse<bool>()
            {
                Message = "The acount is Exist",
                ResponseBody = false
            };
        }

        public async Task<APIResponse<bool>> Remove(Guid Id)
        {
            AppUser userRemove = await _userManager.FindByIdAsync(Id.ToString());
            if (userRemove != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(userRemove);

                if (result.Succeeded)
                {
                    return new APIResponse<bool>()
                    {
                        Message = "Delete User Is Success",
                        ResponseBody = true
                    };
                }

                else
                {
                    return new APIResponse<bool>()
                    {
                        Message = "Delete User Is not Success",
                        ResponseBody = false
                    };
                }
            }

            return new APIResponse<bool>()
            {
                Message = "User Is not Exist",
                ResponseBody = false
            };
        }

        public async Task<APIResponse<bool>> Update(Guid Id, APIUserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != Id))
            {
                return new APIResponse<bool>("Email is Exist");
            }
            var user = await _userManager.FindByIdAsync(Id.ToString());
            user.Dob = request.DateOfBirth;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new APIResponse<bool>()
                {
                    Message = "Update is success",
                    ResponseBody = true
                };
            }
            return new APIResponse<bool>()
            {
                Message = "Update is not success",
                ResponseBody = false
            };
        }
    }
}
