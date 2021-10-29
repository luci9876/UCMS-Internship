using HrApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrApi.BussinessLogic.Services.Interfaces
{
  public interface IImageService
    {
        Task AddImage(Image image);
        Task<Image> GetImage(int id);
    }
}
