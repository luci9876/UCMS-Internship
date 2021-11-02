using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Services.Interfaces
{
    public interface IMail
    {
         Task SendWelcomeMail(String email, byte[] url, String firstname, String lastname);
    }
}
