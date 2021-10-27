using System;
using System.Collections.Generic;
using System.Text;

namespace HrApi.Data.Repositories.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
