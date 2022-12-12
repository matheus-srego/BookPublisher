using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(Login login);
    }
}