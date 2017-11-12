using System.Threading.Tasks;

namespace ImportRobot.Services
{

    /// <summary>
    /// Интерфейс для работы с бд
    /// </summary>
    public interface IRepository
    {
        int GetMaterialsCount();
    }
}