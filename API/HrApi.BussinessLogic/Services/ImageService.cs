using HrApi.Data.Models;
using HrApi.Data.Repositories;
using HrApi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrApi.BussinessLogic.Services.Interfaces
{
    public class ImageService:IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public void AddImage(Image image)
        {
            if (image == null ) throw new Exception();
            _imageRepository.PostImage(image);


        }
        public Image GetImage(int id)
        {
            return _imageRepository.GetImage(id).Result;

        }
    }
}
