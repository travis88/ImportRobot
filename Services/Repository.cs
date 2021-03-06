using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ImportRobot.Entities;
using SixLabors.ImageSharp;
using ImportRobot.Models;

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
        
        /// <summary>
        /// Трансилитерирует алиасы для новостей
        /// </summary>
        /// <param name="domain"></param>
        public void UpdateMaterialsAliases(string domain)
        {
            var materials = _db.MainMaterials
                .Where(w => w.FSite.Equals(domain));
            
            if (materials == null) return;

            foreach (var m in materials)
            {
                m.CAlias = Transliteration.Translit(m.CAlias);
            }
        }

        /// <summary>
        /// Транслитерирует алиасы для календаря
        /// </summary>
        /// <param name="domain"></param>
        public void UpdateCalendarAliases(string domain)
        {
            var calendars = _db.MainCalendar
                .Where(w => w.FSite.Equals(domain));
            
            if (calendars == null) return;

            foreach (var c in calendars)
            {
                c.CAlias = Transliteration.Translit(c.CAlias);
            }
        }

        /// <summary>
        /// Транслитерирует алиасы для памятных дней
        /// </summary>
        /// <param name="domain"></param>
        public void UpdateMemoryAliases(string domain)
        {
            var memories = _db.MainMemory
                .Where(w => w.FSite.Equals(domain));

            if (memories == null) return;

            foreach (var m in memories)
            {
                m.CAlias = Transliteration.Translit(m.CAlias);
            }
        }

        /// <summary>
        /// Транслитерирует алиасы для закондательства
        /// </summary>
        /// <param name="domain"></param>
        public void UpdateLawsAliases(string domain)
        {
            var laws = _db.CmsLaws
                .Where(w => w.FSite.Equals(domain));

            if (laws == null) return;

            foreach (var l in laws)
            {
                string group = Transliteration.Translit(l.FGroup).ToLower();
                if (!string.IsNullOrEmpty(l.CNumber))
                    l.CAlias = group + Transliteration.Translit(l.CNumber).Replace("/", "");
                else
                {
                    string title = l.CTitle;
                    if (title.Length > 30)
                        title = title.Substring(0, 30);

                    l.CAlias = group + "-" + Transliteration.Translit(title).Replace("/", "").Replace(" ", "-").ToLower();
                }
            }
        }

        /// <summary>
        /// Переносит старые фотографии на новый диск
        /// </summary>
        public void TakeOldPhotoAlbums(string domain)
        {
            // допустимые разрешения
            string[] allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" }; 
            
            // кол-во фотографий
            int allPhotosCount = 0;

            // кол-во фотоальбомов
            int allPhotoAlbumsCount = 0;

            var albums = _db.MainPhotoAlbums
                .Where(w => w.FSite.Equals(domain));

            if (albums == null) return;

            foreach (var a in albums)
            {
                string directory = null;

                directory = a.COldUrl;
                if (!string.IsNullOrEmpty(directory))
                {
                    directory = directory.Replace("/", @"\")
                                        .Replace(@"\UserFiles", @"\\gov2\g$")
                                        .Replace(@"\ContentOld", @"\\gov2\h$");
                        
                    string directorPath = directory;
                    if (Directory.Exists(directorPath))
                    {
                        DirectoryInfo di = new DirectoryInfo(directorPath);
                        FileInfo[] fi = di.GetFiles();
                        string year = a.DDate.ToString("yyyy");
                        string month = a.DDate.ToString("MM");
                        string day = a.DDate.ToString("dd");
                        string userFiles = Program.Configuration.GetSection("root").ToString(); 
                        string photoDir = Program.Configuration.GetSection("photo").ToString();
                        string pathToApp = Program.Configuration.GetSection("pathToApp").ToString();

                        // путь для сохранения фотографий
                        string savePath = userFiles + domain + photoDir
                                        + year + "_" + month + "/" + day + "/" + a.Id + "/"; 
                            
                        if (!Directory.Exists(savePath))
                        {
                            DirectoryInfo _di = Directory.CreateDirectory(pathToApp + savePath);
                        }

                        int count = 0;
                        foreach (var img in fi)
                        {
                            if (allowedExtensions.Contains(img.Extension))
                            {
                                count++;
                                if (!img.Name.ToLower().Contains("_preview"))
                                {
                                    // превью
                                    using (Image<Rgba32> _imgPrev = Image.Load(img.FullName))
                                    {
                                        _imgPrev.Mutate(x => x
                                            .Resize(120, 120));
                                        _imgPrev.Save(pathToApp + savePath + "prev_" + count.ToString() + img.Extension); // automatic encoder selected based on extension.
                                    }

                                    // изображение
                                    using (Image<Rgba32> _imgReal = Image.Load(img.FullName))
                                    {
                                        _imgReal.Mutate(x => x
                                            .Resize(120, 120));
                                        _imgReal.Save(pathToApp + savePath + count.ToString() + img.Extension); // automatic encoder selected based on extension.
                                    }

                                    // сохраняем фотку по новому пути
                                    var photo = new MainPhotos 
                                    {
                                        Id = Guid.NewGuid(),
                                        AlbumId = a.Id,
                                        CTitle = count.ToString() + img.Extension,
                                        DDate = img.LastWriteTime,
                                        CPreview = pathToApp + savePath + "prev_" + count.ToString() + img.Extension,
                                        CPhoto = pathToApp + savePath + count.ToString() + img.Extension
                                    };
                                    allPhotosCount += SavePhotoToAlbum(photo);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Прикрепляет фото к альбому
        public int SavePhotoToAlbum(MainPhotos photo)
        {
            _db.MainPhotos.Add(photo);
            return this.Save();
        }
    }
}