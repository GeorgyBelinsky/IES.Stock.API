using IES.Services.DTO.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.Interfaces
{
    public interface IRoleService
    {
        Task<string> Create(RoleDTO role);
        Task<string> AddToRole(string roleId, string userId);
        Task<List<IdentityRole>> GetRoles();
        Task<string> DeleteRole(string roleId);
    }
}
