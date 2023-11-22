using IES.Domain.Interfaces.UnitOfWork;
using IES.Education.API.Models;
using IES.Services.DTO.DTO;
using IES.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastMapper;


namespace IES.Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<string> Create(RoleViewModel roleViewModel)
        {
            return await _roleService.Create(TypeAdapter.Adapt<RoleDTO>(roleViewModel));
        }

        [HttpPut]
        [Route("AddToRole")]
        public async Task<string> AddToRole(string roleId, string userId)
        {
            return await _roleService.AddToRole(roleId, userId);
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<string> Delete(string roleId)
        {
            return await _roleService.DeleteRole(roleId);
        }
    }
}

