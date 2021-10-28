using HrApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApi.BussinessLogic.Services.Interfaces
{
  public interface IImageService
    {
        void AddImage(Image image);
        Image GetImage(int id);
    }
}
