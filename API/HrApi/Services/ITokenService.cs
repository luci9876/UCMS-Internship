using HrApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Services
{
    public interface ITokenService
    {
        public Task<string> CreateToken(LoginDto loginDto);
    }
}
