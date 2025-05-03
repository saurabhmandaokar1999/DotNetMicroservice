using PlatformServicesApi.Models;

namespace PlatformServicesApi.Data
{
    public interface IPlatformRepo
    {
        bool saveChanges();
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void CreatePlatform(Platform plat);

    }
}
