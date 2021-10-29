using HrApi.Data.Models;
using HrApi.Data.Repositories;
using HrApi.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrApi.BussinessLogic.Services.Interfaces
{
    public class ImageService:IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task AddImage(Image image)
        {
            if (image == null ) throw new Exception();
            await _imageRepository.PostImage(image);


        }
        public async Task<Image> GetImage(int id)
        {
            return  await _imageRepository.GetImage(id);

        }
    }
}
