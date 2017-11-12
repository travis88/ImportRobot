using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainSites
    {
        public MainSites()
        {
            CmsLaws = new HashSet<CmsLaws>();
            CmsPageViews = new HashSet<CmsPageViews>();
            CmsPageViewsModules = new HashSet<CmsPageViewsModules>();
            CmsSectionsGroupItems = new HashSet<CmsSectionsGroupItems>();
            CmsSiteDecor = new HashSet<CmsSiteDecor>();
            CmsSiteFrontSection = new HashSet<CmsSiteFrontSection>();
            CmsSiteGeneral = new HashSet<CmsSiteGeneral>();
            CmsUsersSiteLink = new HashSet<CmsUsersSiteLink>();
            ImportPlaceCard = new HashSet<ImportPlaceCard>();
            MainActivities = new HashSet<MainActivities>();
            MainBanners = new HashSet<MainBanners>();
            MainCalendar = new HashSet<MainCalendar>();
            MainEvents = new HashSet<MainEvents>();
            MainMailing = new HashSet<MainMailing>();
            MainMaterials = new HashSet<MainMaterials>();
            MainMemory = new HashSet<MainMemory>();
            MainOrganization = new HashSet<MainOrganization>();
            MainPerson = new HashSet<MainPerson>();
            MainPhotoAlbums = new HashSet<MainPhotoAlbums>();
            MainPlaceCard = new HashSet<MainPlaceCard>();
            MainReviews = new HashSet<MainReviews>();
            MainSiteMap = new HashSet<MainSiteMap>();
            MainSitesDomainList = new HashSet<MainSitesDomainList>();
            MainSlider = new HashSet<MainSlider>();
            MainStructure = new HashSet<MainStructure>();
            MainSubscrip = new HashSet<MainSubscrip>();
            MainTenders = new HashSet<MainTenders>();
            MainVacancy = new HashSet<MainVacancy>();
            MainVideo = new HashSet<MainVideo>();
            MainVote = new HashSet<MainVote>();
        }

        public Guid Id { get; set; }
        public string CName { get; set; }
        public string CNameLong { get; set; }
        public string CDomain { get; set; }
        public Guid? FSiteTemplateId { get; set; }
        public string CTypeBlock { get; set; }
        public string CJsMain { get; set; }
        public string CCssAdd { get; set; }
        public string CCssMain { get; set; }
        public string CAdress { get; set; }
        public string CPhone { get; set; }
        public string CFax { get; set; }
        public string CEmail { get; set; }
        public string CSite { get; set; }
        public string CWorktime { get; set; }
        public string CLogo { get; set; }
        public string CScripts { get; set; }
        public string CAdmEmail { get; set; }
        public string CAdmPhone { get; set; }
        public double? CCoordX { get; set; }
        public double? CCoordY { get; set; }
        public short? FGosuslugiId { get; set; }
        public string CKeyw { get; set; }
        public string CDesc { get; set; }
        public string CPhotoTop { get; set; }
        public bool? BOnHeader { get; set; }
        public string CDopInfo { get; set; }
        public string CMonday { get; set; }
        public string CTuesday { get; set; }
        public string CWednesday { get; set; }
        public string CThursday { get; set; }
        public string CFriday { get; set; }
        public string CSaturday { get; set; }
        public string CSunday { get; set; }
        public int? NOldId { get; set; }
        public string CGeneralInfo { get; set; }
        public string CSocVk { get; set; }
        public string CSocOk { get; set; }
        public string CSocFb { get; set; }
        public string CSocTw { get; set; }
        public string CSocYoutube { get; set; }
        public string CSitetype { get; set; }
        public string CSocIn { get; set; }
        public string CSocRt { get; set; }
        public string COldSite { get; set; }
        public string CTelegramChanel { get; set; }
        public string CTelegramChatId { get; set; }
        public string CVideoLogin { get; set; }
        public string CVideoPassword { get; set; }
        public string CNameDop { get; set; }
        public string CEmailSendError { get; set; }

        public CmsSiteTemplates FSiteTemplate { get; set; }
        public ICollection<CmsLaws> CmsLaws { get; set; }
        public ICollection<CmsPageViews> CmsPageViews { get; set; }
        public ICollection<CmsPageViewsModules> CmsPageViewsModules { get; set; }
        public ICollection<CmsSectionsGroupItems> CmsSectionsGroupItems { get; set; }
        public ICollection<CmsSiteDecor> CmsSiteDecor { get; set; }
        public ICollection<CmsSiteFrontSection> CmsSiteFrontSection { get; set; }
        public ICollection<CmsSiteGeneral> CmsSiteGeneral { get; set; }
        public ICollection<CmsUsersSiteLink> CmsUsersSiteLink { get; set; }
        public ICollection<ImportPlaceCard> ImportPlaceCard { get; set; }
        public ICollection<MainActivities> MainActivities { get; set; }
        public ICollection<MainBanners> MainBanners { get; set; }
        public ICollection<MainCalendar> MainCalendar { get; set; }
        public ICollection<MainEvents> MainEvents { get; set; }
        public ICollection<MainMailing> MainMailing { get; set; }
        public ICollection<MainMaterials> MainMaterials { get; set; }
        public ICollection<MainMemory> MainMemory { get; set; }
        public ICollection<MainOrganization> MainOrganization { get; set; }
        public ICollection<MainPerson> MainPerson { get; set; }
        public ICollection<MainPhotoAlbums> MainPhotoAlbums { get; set; }
        public ICollection<MainPlaceCard> MainPlaceCard { get; set; }
        public ICollection<MainReviews> MainReviews { get; set; }
        public ICollection<MainSiteMap> MainSiteMap { get; set; }
        public ICollection<MainSitesDomainList> MainSitesDomainList { get; set; }
        public ICollection<MainSlider> MainSlider { get; set; }
        public ICollection<MainStructure> MainStructure { get; set; }
        public ICollection<MainSubscrip> MainSubscrip { get; set; }
        public ICollection<MainTenders> MainTenders { get; set; }
        public ICollection<MainVacancy> MainVacancy { get; set; }
        public ICollection<MainVideo> MainVideo { get; set; }
        public ICollection<MainVote> MainVote { get; set; }
    }
}
