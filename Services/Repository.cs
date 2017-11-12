using System.Linq;
using System.Threading.Tasks;
using ImportRobot.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImportRobot.Services
{
    /// <summary>
    /// Имплементация интерфейса для работы с бд
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// Контекст
        /// </summary>
        private CapDbContext _db;

        public Repository(CapDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Сохраняет изменения в бд
        /// </summary>
        /// <returns></returns>
        public int Save() => _db.SaveChanges();

        /// <summary>
        /// Возвращается список разрешённых доменных имён
        /// (проверка на корректность введённого сайта)
        /// </summary>
        /// <returns></returns>
        public string[] GetCorrectDomains()
        {
            var result = _db.MainSites.Select(s => s.CDomain);
            return result.Any() ? result.ToArray() : null;
        }

        /// <summary>
        /// Заменяем устаревшие пути к папкам
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        public string ReplaceIt(string change)
        {
            return change.Replace("../", "/")
                         .Replace("~/", "/")
                         .Replace("/Content/", "/ContentOld/");
        }

        /// <summary>
        /// Обновляет изображение к новости
        /// </summary>
        /// <param name="domain">Домен</param>
        public void UpdateMaterialsPhoto(string domain)
        {
            var materials = _db.MainMaterials
                .Where(w => w.FSite.Equals(domain))
                .Where(w => !string.IsNullOrEmpty(w.CPhoto));
            
            if (materials == null) return;

            foreach (var m in materials)
            {
                m.CPhoto = this.ReplaceIt(m.CPhoto);
            }
        }

        /// <summary>
        /// Обновляет прикреплённые файлы в законодательстве 
        /// </summary>
        /// <param name="domain">Домен</param>
        public void UpdateLawsAttachedFile(string domain)
        {
            var laws = _db.CmsLaws
                .Where(w => w.FSite.Equals(domain))
                .Where(w => !string.IsNullOrEmpty(w.CUrl));

            if (laws == null) return;

            foreach (var l in laws)
            {
                l.CUrl = this.ReplaceIt(l.CUrl);
            }
        }

        /// <summary>
        /// Обновляет фотоальбомы
        /// </summary>
        /// <param name="domain"></param>
        public void UpdatePhotoAlbums(string domain)
        {
            var photoAlbums = _db.MainPhotoAlbums
                .Where(w => w.FSite.Equals(domain));
            
            if (photoAlbums == null) return;

            foreach (var p in photoAlbums)
            {
                p.CPreview = this.ReplaceIt(p.CPreview);
                p.COldUrl = this.ReplaceIt(p.COldUrl);
            }
        }

        /// <summary>
        /// Обновляет видеозаписи
        /// </summary>
        /// <param name="domain"></param>
        public void UpdateVideo(string domain)
        {
            var videos = _db.MainVideo
                .Where(w => w.FSite.Equals(domain));
            
            if (videos == null) return;

            foreach (var v in videos)
            {
                v.CVideo = this.ReplaceIt(v.CVideo);
                v.CPreview = this.ReplaceIt(v.CPreview);
                v.BFinal = true;
                v.NWidth = 854;
                v.NHeight = 480;
            }
        }
    }
}