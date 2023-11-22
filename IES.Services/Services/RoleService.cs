using FastMapper;
using IES.Domain.Entities.Models;
using IES.Domain.Interfaces.UnitOfWork;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Services.Services
{
    public class RoleService: IRoleService
    {
        
        public IUnitOfWork unitOfWork;
        public RoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> Create(RoleDTO role)
        {
            await unitOfWork.IdentityRoleManager.CreateAsync(TypeAdapter.Adapt<Role>(role));
            return "UserCreated";
        }

        public async Task<string> AddToRole(string roleId, string userId)
        {
            var role = await unitOfWork.IdentityRoleManager.FindByIdAsync(roleId);
            var user = await unitOfWork.IdentityUserManager.FindByIdAsync(userId);
            await unitOfWork.IdentityUserManager.AddToRoleAsync(user, role.Name);
            unitOfWork.Commit();
            return "User Added to role "+ role.Name.ToString();
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
            return await unitOfWork.IdentityRoleManager.Roles.ToListAsync();
        }

        public async Task<string> DeleteRole(string roleId)
        {
            var role = await unitOfWork.IdentityRoleManager.FindByIdAsync(roleId);
            await unitOfWork.IdentityRoleManager.DeleteAsync(role);
            unitOfWork.Commit();
            return "Role "+role.Name.ToString()+" deleted";
        }
    }
}
