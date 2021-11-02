using HrApi.Data.Models;
using System.Threading.Tasks;

namespace HrApi.Data.Repositories.Interfaces
{
    public interface IImageRepository
    {
         Task<int> PostImage(Image image);
         Task<Image> GetImage(int id);
    }
}
