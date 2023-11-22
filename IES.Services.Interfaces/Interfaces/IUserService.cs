using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IES.Domain.Entities.Models;
using IES.Services.DTO.DTO;

namespace IES.Services.Interfaces.Interfaces
{
    public interface IUserService
    {
        Task<object> SignUp(UserDTO userDTO);
        Task<object> SignIn(UserDTO userDTO);
        Task<String> ChangePassword(string email, string oldPassword, string newPassword);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<string> DeleteUser(string userId);
        //public List<Deal> GetByUserId(int Id);
    }
}
