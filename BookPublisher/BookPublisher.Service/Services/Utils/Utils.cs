using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BookPublisher.Domain.Constants;
using BookPublisher.Domain.Enums;
using BookPublisher.Domain.Models;

namespace BookPublisher.Service.Services.Utils
{
    public static class Utils
    {
        public static UserType TypeExist(string userType)
        {
            var typeExist = System.Enum.TryParse<UserType>(userType, out UserType type);
            if(!typeExist)
                throw new ArgumentException(EXCEPTIONS.MESSAGE_USER_TYPE_NOT_EXIST);

            return type;
        }

        public static User UserHasInformation(User? user)
        {
            if(IsNotNull(user))
                return user;
            else
                throw new ArgumentException(EXCEPTIONS.MESSAGE_USER_NOT_HAVE_INFORMATION);
        }

        public static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
    }
}