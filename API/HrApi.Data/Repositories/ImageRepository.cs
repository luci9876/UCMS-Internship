using HrApi.Data.Models;
using HrApi.Data.Repositories.Interfaces;
using HrApi.Models;
using HrApi.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrApi.Data.Repositories
{
    public class ImageRepository: GenericRepository<Image>,IImageRepository
    {
       
        public ImageRepository(HrContext dBContext) : base(dBContext)
        {
           
        }

        public HrContext HrContext
        {
            get { return Context; }
        }
        public async Task PostImage(Image image)
        {
            await HrContext.Images.AddAsync(image);
            await HrContext.SaveChangesAsync();
           

        }
        public async Task<Image> GetImage(int id)
        {
            return await HrContext.Images.FindAsync(id);
        }
    }
}
