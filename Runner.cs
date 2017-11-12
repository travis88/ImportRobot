using System;
using System.Linq;
using ImportRobot.Entities;
using ImportRobot.Services;
using Microsoft.Extensions.Logging;

namespace ImportRobot
{
    public class Runner 
    {
        private readonly ILogger<Runner> _logger;
        private IRepository _repo = new Repository(new CapDbContext());

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Вызывает методы для выполнения основной части логики
        /// </summary>
        public void DoAction()
        {
            Console.WriteLine("Import old sites cap.ru UTILITY");
            string domain = null;

            // проверим на допустимое доменное имя введённую строку
            string[] correctDomains = _repo.GetCorrectDomains();
            do 
            {
                Console.WriteLine("Enter a domain name:");
                domain = Console.ReadLine();
                // domain = "minzdrav"; 

            } while(!correctDomains.Contains(domain));

            Materials(domain);
            Laws(domain);
            PhotoAlbums(domain);
        }

        /// <summary>
        /// Обновляет данные в таблице portal.main_materials
        /// </summary>
        /// <param name="domain"></param>
        private void Materials(string domain)
        {
            try
            {
                _repo.UpdateMaterialsPhoto(domain);
                int count = _repo.Save();
                if (count >= 0)
                {
                    _logger.LogDebug($"{count} photos in main_materials updated for {domain}"); 
                }
            }
            catch (Exception e) 
            {
                _logger.LogError(e.ToString());
            }
        }

        /// <summary>
        /// Обновляет данные в таблице portal.cms_laws
        /// </summary>
        /// <param name="domain"></param>
        private void Laws(string domain)
        {
            try 
            {
                _repo.UpdateLawsAttachedFile(domain);
                int count = _repo.Save();
                if (count >= 0)
                {
                    _logger.LogDebug($"{count} files in cms_laws updated for {domain}"); 
                }
            }
            catch (Exception e) 
            {
                _logger.LogError(e.ToString());
            }
        }

        /// <summary>
        /// Обновляет данные в таблице portal.main_photo_albums
        /// </summary>
        /// <param name="domain"></param>
        private void PhotoAlbums(string domain)
        {
            try 
            {
                _repo.UpdatePhotoAlbums(domain);
                int count = _repo.Save();
                if (count >= 0)
                {
                    _logger.LogDebug($"{count} records in main_photo_albums updated for {domain}"); 
                }
            }
            catch (Exception e) 
            {
                _logger.LogError(e.ToString());
            }
        }

        /// <summary>
        /// Обновляет данные в таблице portal.main_video 
        /// </summary>
        /// <param name="domain"></param>
        private void Video(string domain)
        {
            try 
            {
                _repo.UpdateVideo(domain);
                int count = _repo.Save();
                if (count >= 0)
                {
                    _logger.LogDebug($"{count} records in main_video updated for {domain}"); 
                }
            }
            catch (Exception e) 
            {
                _logger.LogError(e.ToString());
            }
        }
    }
}