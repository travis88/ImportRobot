using System.Threading.Tasks;

namespace ImportRobot.Services
{

    /// <summary>
    /// Интерфейс для работы с бд
    /// </summary>
    public interface IRepository
    {
        int Save();

        string[] GetCorrectDomains();

        string ReplaceIt(string change);

        void UpdateMaterialsPhoto(string domain);

        void UpdateLawsAttachedFile(string domain);

        void UpdatePhotoAlbums(string domain);

        void UpdateVideo(string domain);
    }
}