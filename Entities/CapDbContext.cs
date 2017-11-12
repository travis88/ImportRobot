using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ImportRobot.Entities
{
    public partial class CapDbContext : DbContext
    {
        public virtual DbSet<CmsFrontSection> CmsFrontSection { get; set; }
        public virtual DbSet<CmsLaws> CmsLaws { get; set; }
        public virtual DbSet<CmsLog> CmsLog { get; set; }
        public virtual DbSet<CmsLogActionName> CmsLogActionName { get; set; }
        public virtual DbSet<CmsMenu> CmsMenu { get; set; }
        public virtual DbSet<CmsPageViews> CmsPageViews { get; set; }
        public virtual DbSet<CmsPageViewsModules> CmsPageViewsModules { get; set; }
        public virtual DbSet<CmsResolutions> CmsResolutions { get; set; }
        public virtual DbSet<CmsResolutionsTemplates> CmsResolutionsTemplates { get; set; }
        public virtual DbSet<CmsSectionsGroup> CmsSectionsGroup { get; set; }
        public virtual DbSet<CmsSectionsGroupItems> CmsSectionsGroupItems { get; set; }
        public virtual DbSet<CmsSiteDecor> CmsSiteDecor { get; set; }
        public virtual DbSet<CmsSiteDecoreTemplates> CmsSiteDecoreTemplates { get; set; }
        public virtual DbSet<CmsSiteFrontSection> CmsSiteFrontSection { get; set; }
        public virtual DbSet<CmsSiteGeneral> CmsSiteGeneral { get; set; }
        public virtual DbSet<CmsSiteModules> CmsSiteModules { get; set; }
        public virtual DbSet<CmsSiteTemplates> CmsSiteTemplates { get; set; }
        public virtual DbSet<CmsUsers> CmsUsers { get; set; }
        public virtual DbSet<CmsUsersGroup> CmsUsersGroup { get; set; }
        public virtual DbSet<CmsUsersSiteLink> CmsUsersSiteLink { get; set; }
        public virtual DbSet<ImportPlaceCard> ImportPlaceCard { get; set; }
        public virtual DbSet<ImportRss> ImportRss { get; set; }
        public virtual DbSet<MainActivities> MainActivities { get; set; }
        public virtual DbSet<MainActivitiesLaws> MainActivitiesLaws { get; set; }
        public virtual DbSet<MainActivitiesMaterials> MainActivitiesMaterials { get; set; }
        public virtual DbSet<MainBanners> MainBanners { get; set; }
        public virtual DbSet<MainCalendar> MainCalendar { get; set; }
        public virtual DbSet<MainDocuments> MainDocuments { get; set; }
        public virtual DbSet<MainEvents> MainEvents { get; set; }
        public virtual DbSet<MainMailing> MainMailing { get; set; }
        public virtual DbSet<MainMaterials> MainMaterials { get; set; }
        public virtual DbSet<MainMemory> MainMemory { get; set; }
        public virtual DbSet<MainOrganization> MainOrganization { get; set; }
        public virtual DbSet<MainPerson> MainPerson { get; set; }
        public virtual DbSet<MainPhotoAlbums> MainPhotoAlbums { get; set; }
        public virtual DbSet<MainPhotos> MainPhotos { get; set; }
        public virtual DbSet<MainPlaceCard> MainPlaceCard { get; set; }
        public virtual DbSet<MainRedirect> MainRedirect { get; set; }
        public virtual DbSet<MainReviews> MainReviews { get; set; }
        public virtual DbSet<MainSettings> MainSettings { get; set; }
        public virtual DbSet<MainSiteMap> MainSiteMap { get; set; }
        public virtual DbSet<MainSites> MainSites { get; set; }
        public virtual DbSet<MainSitesDomainList> MainSitesDomainList { get; set; }
        public virtual DbSet<MainSlider> MainSlider { get; set; }
        public virtual DbSet<MainStructure> MainStructure { get; set; }
        public virtual DbSet<MainSubscrip> MainSubscrip { get; set; }
        public virtual DbSet<MainTenders> MainTenders { get; set; }
        public virtual DbSet<MainVacancy> MainVacancy { get; set; }
        public virtual DbSet<MainVideo> MainVideo { get; set; }
        public virtual DbSet<MainVote> MainVote { get; set; }
        public virtual DbSet<MainVoteAnswers> MainVoteAnswers { get; set; }
        public virtual DbSet<SsNumbers> SsNumbers { get; set; }

        // Unable to generate entity type for table 'portal.import_materials'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_memory'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.main_sitemap_menu'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_sitemap'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_person'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.main_vote_users_backup'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_video'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_calendar'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.main_vote_users'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_structure'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.cms_sections_sites'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_laws'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_photo_albums'. Please see the warning messages.
        // Unable to generate entity type for table 'portal.import_vacancy'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Program.Configuration.GetConnectionString("pgConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CmsFrontSection>(entity =>
            {
                entity.HasKey(e => e.CAlias);

                entity.ToTable("cms_front_section", "portal");

                entity.Property(e => e.CAlias)
                    .HasColumnName("c_alias")
                    .ValueGeneratedNever();

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name");

                entity.Property(e => e.FDefaultView).HasColumnName("f_default_view");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.FDefaultViewNavigation)
                    .WithMany(p => p.CmsFrontSection)
                    .HasForeignKey(d => d.FDefaultView)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cms_front_section_cms_page_views");
            });

            modelBuilder.Entity<CmsLaws>(entity =>
            {
                entity.ToTable("cms_laws", "portal");

                entity.HasIndex(e => e.FSite)
                    .HasName("fki_cms_laws_site");

                entity.HasIndex(e => new { e.FSite, e.FGroup, e.BDisabled })
                    .HasName("fki_cms_laws_site_group_disabled");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDatePubl)
                    .HasColumnName("c_date_publ")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CDopText).HasColumnName("c_dop_text");

                entity.Property(e => e.CGrLaw).HasColumnName("c_gr_law");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CLogo).HasColumnName("c_logo");

                entity.Property(e => e.CNumber).HasColumnName("c_number");

                entity.Property(e => e.CNumberMinust).HasColumnName("c_number_minust");

                entity.Property(e => e.CSource).HasColumnName("c_source");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DDateMinust)
                    .HasColumnName("d_date_minust")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FGroup).HasColumnName("f_group");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NDay)
                    .IsRequired()
                    .HasColumnName("n_day");

                entity.Property(e => e.NMonth)
                    .IsRequired()
                    .HasColumnName("n_month");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NYear)
                    .IsRequired()
                    .HasColumnName("n_year");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.CmsLaws)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_cms_laws_main_sites");
            });

            modelBuilder.Entity<CmsLog>(entity =>
            {
                entity.ToTable("cms_log", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CAction)
                    .IsRequired()
                    .HasColumnName("c_action")
                    .HasColumnType("varchar");

                entity.Property(e => e.CIp)
                    .HasColumnName("c_ip")
                    .HasColumnType("varchar");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FPageId).HasColumnName("f_page_id");

                entity.Property(e => e.FUserId).HasColumnName("f_user_id");
            });

            modelBuilder.Entity<CmsLogActionName>(entity =>
            {
                entity.HasKey(e => e.Action);

                entity.ToTable("cms_log_action_name", "portal");

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("varchar")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasColumnName("action_name")
                    .HasColumnType("varchar");
            });

            modelBuilder.Entity<CmsMenu>(entity =>
            {
                entity.ToTable("cms_menu", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CAlias)
                    .HasColumnName("c_alias")
                    .HasColumnType("varchar");

                entity.Property(e => e.CClass)
                    .HasColumnName("c_class")
                    .HasColumnType("varchar");

                entity.Property(e => e.CDesc)
                    .HasColumnName("c_desc")
                    .HasColumnType("varchar");

                entity.Property(e => e.CGroup)
                    .HasColumnName("c_group")
                    .HasColumnType("varchar");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title")
                    .HasColumnType("varchar");

                entity.Property(e => e.CUrl)
                    .IsRequired()
                    .HasColumnName("c_url")
                    .HasColumnType("varchar");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");
            });

            modelBuilder.Entity<CmsPageViews>(entity =>
            {
                entity.ToTable("cms_page_views", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BReadOnly)
                    .HasColumnName("b_read_only")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CAlias).HasColumnName("c_alias");

                entity.Property(e => e.CLayout).HasColumnName("c_layout");

                entity.Property(e => e.CMarkupType).HasColumnName("c_markup_type");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl)
                    .IsRequired()
                    .HasColumnName("c_url");

                entity.Property(e => e.FPageType).HasColumnName("f_page_type");

                entity.Property(e => e.FSiteId).HasColumnName("f_site_id");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");

                entity.HasOne(d => d.FPageTypeNavigation)
                    .WithMany(p => p.CmsPageViews)
                    .HasForeignKey(d => d.FPageType)
                    .HasConstraintName("fk_cms_page_views_cms_front_section");

                entity.HasOne(d => d.FSite)
                    .WithMany(p => p.CmsPageViews)
                    .HasForeignKey(d => d.FSiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_cms_page_views_main_sites");
            });

            modelBuilder.Entity<CmsPageViewsModules>(entity =>
            {
                entity.ToTable("cms_page_views_modules", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.FModuleId).HasColumnName("f_module_id");

                entity.Property(e => e.FSiteId)
                    .IsRequired()
                    .HasColumnName("f_site_id");

                entity.HasOne(d => d.FSite)
                    .WithMany(p => p.CmsPageViewsModules)
                    .HasForeignKey(d => d.FSiteId)
                    .HasConstraintName("fk_cms_page_views_modules_main_sites");
            });

            modelBuilder.Entity<CmsResolutions>(entity =>
            {
                entity.ToTable("cms_resolutions", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('portal.cms_resolutions_id_seq'::regclass)");

                entity.Property(e => e.BChange)
                    .HasColumnName("b_change")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BDelete)
                    .HasColumnName("b_delete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BImportent)
                    .HasColumnName("b_importent")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BRead)
                    .HasColumnName("b_read")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BWrite)
                    .HasColumnName("b_write")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CMenuId).HasColumnName("c_menu_id");

                entity.Property(e => e.CUserId).HasColumnName("c_user_id");

                entity.HasOne(d => d.CMenu)
                    .WithMany(p => p.CmsResolutions)
                    .HasForeignKey(d => d.CMenuId)
                    .HasConstraintName("fk_cms_resolutions_cms_menu");

                entity.HasOne(d => d.CUser)
                    .WithMany(p => p.CmsResolutions)
                    .HasForeignKey(d => d.CUserId)
                    .HasConstraintName("fk_cms_resolutions_cms_users");
            });

            modelBuilder.Entity<CmsResolutionsTemplates>(entity =>
            {
                entity.ToTable("cms_resolutions_templates", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('portal.cms_resolutions_templates_id_seq'::regclass)");

                entity.Property(e => e.BChange)
                    .HasColumnName("b_change")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BDelete)
                    .HasColumnName("b_delete")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BRead)
                    .HasColumnName("b_read")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BWrite)
                    .HasColumnName("b_write")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.FMenuId).HasColumnName("f_menu_id");

                entity.Property(e => e.FUserGroupId)
                    .IsRequired()
                    .HasColumnName("f_user_group_id");

                entity.HasOne(d => d.FMenu)
                    .WithMany(p => p.CmsResolutionsTemplates)
                    .HasForeignKey(d => d.FMenuId)
                    .HasConstraintName("fk_cms_resolutions_templates_cms_menu");

                entity.HasOne(d => d.FUserGroup)
                    .WithMany(p => p.CmsResolutionsTemplates)
                    .HasForeignKey(d => d.FUserGroupId)
                    .HasConstraintName("fk_cms_resolutions_templates_cms_users_group");
            });

            modelBuilder.Entity<CmsSectionsGroup>(entity =>
            {
                entity.ToTable("cms_sections_group", "portal");

                entity.HasIndex(e => new { e.CAlias, e.CSectionId })
                    .HasName("cms_sections_group_c_alias_c_section_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BFiltr)
                    .HasColumnName("b_filtr")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.BReadonly)
                    .HasColumnName("b_readonly")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CSectionId)
                    .IsRequired()
                    .HasColumnName("c_section_id");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");
            });

            modelBuilder.Entity<CmsSectionsGroupItems>(entity =>
            {
                entity.ToTable("cms_sections_group_items", "portal");

                entity.HasIndex(e => new { e.FSiteId, e.FSectionId })
                    .HasName("fki_section_gr_items_site_section");

                entity.HasIndex(e => new { e.FSiteId, e.FSectionId, e.FGroupId, e.CAlias })
                    .HasName("fki_section_group_items_site_section_group_alias");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CLogo).HasColumnName("c_logo");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.FGroupId)
                    .IsRequired()
                    .HasColumnName("f_group_id");

                entity.Property(e => e.FSectionId)
                    .IsRequired()
                    .HasColumnName("f_section_id");

                entity.Property(e => e.FSiteId).HasColumnName("f_site_id");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");

                entity.HasOne(d => d.FSite)
                    .WithMany(p => p.CmsSectionsGroupItems)
                    .HasForeignKey(d => d.FSiteId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_cms_sections_group_items_main_sites");

                entity.HasOne(d => d.F)
                    .WithMany(p => p.CmsSectionsGroupItems)
                    .HasPrincipalKey(p => new { p.CAlias, p.CSectionId })
                    .HasForeignKey(d => new { d.FGroupId, d.FSectionId })
                    .HasConstraintName("fk_cms_sections_group_items_cms_sections_group");
            });

            modelBuilder.Entity<CmsSiteDecor>(entity =>
            {
                entity.HasKey(e => new { e.FSiteId, e.CKey });

                entity.ToTable("cms_site_decor", "portal");

                entity.Property(e => e.FSiteId).HasColumnName("f_site_id");

                entity.Property(e => e.CKey).HasColumnName("c_key");

                entity.Property(e => e.CValue).HasColumnName("c_value");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.HasOne(d => d.FSite)
                    .WithMany(p => p.CmsSiteDecor)
                    .HasForeignKey(d => d.FSiteId)
                    .HasConstraintName("fk_cms_site_decor_main_sites");
            });

            modelBuilder.Entity<CmsSiteDecoreTemplates>(entity =>
            {
                entity.HasKey(e => new { e.TemplateId, e.CKey });

                entity.ToTable("cms_site_decore_templates", "portal");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.Property(e => e.CKey).HasColumnName("c_key");

                entity.Property(e => e.CValue).HasColumnName("c_value");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.CmsSiteDecoreTemplates)
                    .HasForeignKey(d => d.TemplateId)
                    .HasConstraintName("fk_cms_site_decore_templates_cms_site_templates");
            });

            modelBuilder.Entity<CmsSiteFrontSection>(entity =>
            {
                entity.ToTable("cms_site_front_section", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.FFrontSection)
                    .IsRequired()
                    .HasColumnName("f_front_section");

                entity.Property(e => e.FPageView).HasColumnName("f_page_view");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.FFrontSectionNavigation)
                    .WithMany(p => p.CmsSiteFrontSection)
                    .HasForeignKey(d => d.FFrontSection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cms_site_front_section_cms_front_section");

                entity.HasOne(d => d.FPageViewNavigation)
                    .WithMany(p => p.CmsSiteFrontSection)
                    .HasForeignKey(d => d.FPageView)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cms_site_front_section_cms_page_views");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.CmsSiteFrontSection)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_cms_site_front_section_main_sites");
            });

            modelBuilder.Entity<CmsSiteGeneral>(entity =>
            {
                entity.ToTable("cms_site_general", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CNumber).HasColumnName("c_number");

                entity.Property(e => e.CPartial)
                    .IsRequired()
                    .HasColumnName("c_partial");

                entity.Property(e => e.CPreview).HasColumnName("c_preview");

                entity.Property(e => e.CRubric).HasColumnName("c_rubric");

                entity.Property(e => e.CSize).HasColumnName("c_size");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle).HasColumnName("c_title");

                entity.Property(e => e.CType).HasColumnName("c_type");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NColumn).HasColumnName("n_column");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.CmsSiteGeneral)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_cms_site_general_main_sites");
            });

            modelBuilder.Entity<CmsSiteModules>(entity =>
            {
                entity.HasKey(e => e.CAlias);

                entity.ToTable("cms_site_modules", "portal");

                entity.Property(e => e.CAlias)
                    .HasColumnName("c_alias")
                    .ValueGeneratedNever();

                entity.Property(e => e.BFourth)
                    .HasColumnName("b_fourth")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BFull)
                    .HasColumnName("b_full")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BHalf)
                    .HasColumnName("b_half")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BThird)
                    .HasColumnName("b_third")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BThreeFourth)
                    .HasColumnName("b_three_fourth")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BTwoThird)
                    .HasColumnName("b_two_third")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name");

                entity.Property(e => e.CPreview).HasColumnName("c_preview");

                entity.Property(e => e.CTypeModul).HasColumnName("c_type_modul");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");
            });

            modelBuilder.Entity<CmsSiteTemplates>(entity =>
            {
                entity.ToTable("cms_site_templates", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CContactsView).HasColumnName("c_contacts_view");

                entity.Property(e => e.CCssAdd).HasColumnName("c_css_add");

                entity.Property(e => e.CCssMain).HasColumnName("c_css_main");

                entity.Property(e => e.CJsMain).HasColumnName("c_js_main");

                entity.Property(e => e.CNewsListView).HasColumnName("c_news_list_view");

                entity.Property(e => e.CPageView).HasColumnName("c_page_view");

                entity.Property(e => e.CPreview).HasColumnName("c_preview");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");
            });

            modelBuilder.Entity<CmsUsers>(entity =>
            {
                entity.ToTable("cms_users", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDeleted)
                    .HasColumnName("b_deleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BSex).HasColumnName("b_sex");

                entity.Property(e => e.CAdres)
                    .HasColumnName("c_adres")
                    .HasColumnType("varchar");

                entity.Property(e => e.CContacts).HasColumnName("c_contacts");

                entity.Property(e => e.CDesc)
                    .HasColumnName("c_desc")
                    .HasColumnType("varchar");

                entity.Property(e => e.CEmail)
                    .HasColumnName("c_email")
                    .HasColumnType("varchar");

                entity.Property(e => e.CHash)
                    .HasColumnName("c_hash")
                    .HasColumnType("varchar");

                entity.Property(e => e.CKeyw)
                    .HasColumnName("c_keyw")
                    .HasColumnType("varchar");

                entity.Property(e => e.CMobile)
                    .HasColumnName("c_mobile")
                    .HasColumnType("varchar");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name")
                    .HasColumnType("varchar");

                entity.Property(e => e.CPatronymic)
                    .HasColumnName("c_patronymic")
                    .HasColumnType("varchar");

                entity.Property(e => e.CPhone)
                    .HasColumnName("c_phone")
                    .HasColumnType("varchar");

                entity.Property(e => e.CPhoto)
                    .HasColumnName("c_photo")
                    .HasColumnType("varchar");

                entity.Property(e => e.CPost)
                    .HasColumnName("c_post")
                    .HasColumnType("varchar");

                entity.Property(e => e.CSalt)
                    .HasColumnName("c_salt")
                    .HasColumnType("varchar");

                entity.Property(e => e.CSurname)
                    .IsRequired()
                    .HasColumnName("c_surname")
                    .HasColumnType("varchar");

                entity.Property(e => e.DBirthday).HasColumnName("d_birthday");

                entity.Property(e => e.FGroup)
                    .IsRequired()
                    .HasColumnName("f_group")
                    .HasColumnType("varchar");

                entity.HasOne(d => d.FGroupNavigation)
                    .WithMany(p => p.CmsUsers)
                    .HasForeignKey(d => d.FGroup)
                    .HasConstraintName("fk_cms_users_users_group");
            });

            modelBuilder.Entity<CmsUsersGroup>(entity =>
            {
                entity.HasKey(e => e.CAlias);

                entity.ToTable("cms_users_group", "portal");

                entity.Property(e => e.CAlias)
                    .HasColumnName("c_alias")
                    .ValueGeneratedNever();

                entity.Property(e => e.CGroupName)
                    .IsRequired()
                    .HasColumnName("c_group_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");
            });

            modelBuilder.Entity<CmsUsersSiteLink>(entity =>
            {
                entity.HasKey(e => new { e.FSiteId, e.FUserId });

                entity.ToTable("cms_users_site_link", "portal");

                entity.Property(e => e.FSiteId).HasColumnName("f_site_id");

                entity.Property(e => e.FUserId).HasColumnName("f_user_id");

                entity.HasOne(d => d.FSite)
                    .WithMany(p => p.CmsUsersSiteLink)
                    .HasForeignKey(d => d.FSiteId)
                    .HasConstraintName("fk_cms_user_site_link_main_sites");

                entity.HasOne(d => d.FUser)
                    .WithMany(p => p.CmsUsersSiteLink)
                    .HasForeignKey(d => d.FUserId)
                    .HasConstraintName("fk_cms_user_site_link_cms_users");
            });

            modelBuilder.Entity<ImportPlaceCard>(entity =>
            {
                entity.ToTable("import_place_card", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BNew)
                    .HasColumnName("b_new")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CPlace).HasColumnName("c_place");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.CUrlName).HasColumnName("c_url_name");

                entity.Property(e => e.CVideo).HasColumnName("c_video");

                entity.Property(e => e.DDateEnd)
                    .HasColumnName("d_date_end")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DDateStart)
                    .HasColumnName("d_date_start")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NDay)
                    .IsRequired()
                    .HasColumnName("n_day");

                entity.Property(e => e.NEipskId).HasColumnName("n_eipsk_id");

                entity.Property(e => e.NMonth)
                    .IsRequired()
                    .HasColumnName("n_month");

                entity.Property(e => e.NYear)
                    .IsRequired()
                    .HasColumnName("n_year");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.ImportPlaceCard)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_import_place_card_main_sites");
            });

            modelBuilder.Entity<ImportRss>(entity =>
            {
                entity.ToTable("import_rss", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl)
                    .IsRequired()
                    .HasColumnName("c_url");

                entity.Property(e => e.DDateCreated)
                    .HasColumnName("d_date_created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");
            });

            modelBuilder.Entity<MainActivities>(entity =>
            {
                entity.ToTable("main_activities", "portal");

                entity.HasIndex(e => new { e.FSite, e.CPath })
                    .HasName("fki_main_activities_site_path");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BShowAsFilter)
                    .HasColumnName("b_show_as_filter")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CLogo).HasColumnName("c_logo");

                entity.Property(e => e.CPath)
                    .IsRequired()
                    .HasColumnName("c_path");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.FSite).HasColumnName("f_site");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainActivities)
                    .HasForeignKey(d => d.FSite)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_main_main_activities_main_sites");
            });

            modelBuilder.Entity<MainActivitiesLaws>(entity =>
            {
                entity.HasKey(e => new { e.IdActivities, e.IdLaws });

                entity.ToTable("main_activities_laws", "portal");

                entity.Property(e => e.IdActivities).HasColumnName("id_activities");

                entity.Property(e => e.IdLaws).HasColumnName("id_laws");

                entity.HasOne(d => d.IdActivitiesNavigation)
                    .WithMany(p => p.MainActivitiesLaws)
                    .HasForeignKey(d => d.IdActivities)
                    .HasConstraintName("fk_activities_law");

                entity.HasOne(d => d.IdLawsNavigation)
                    .WithMany(p => p.MainActivitiesLaws)
                    .HasForeignKey(d => d.IdLaws)
                    .HasConstraintName("fk_law_ac");
            });

            modelBuilder.Entity<MainActivitiesMaterials>(entity =>
            {
                entity.HasKey(e => new { e.IdActivities, e.IdMaterials });

                entity.ToTable("main_activities_materials", "portal");

                entity.HasIndex(e => e.IdActivities)
                    .HasName("fki_main_activmaterials_idact");

                entity.HasIndex(e => e.IdMaterials)
                    .HasName("fki_main_activmaterials_idmat");

                entity.Property(e => e.IdActivities).HasColumnName("id_activities");

                entity.Property(e => e.IdMaterials).HasColumnName("id_materials");

                entity.HasOne(d => d.IdActivitiesNavigation)
                    .WithMany(p => p.MainActivitiesMaterials)
                    .HasForeignKey(d => d.IdActivities)
                    .HasConstraintName("fk_activities");

                entity.HasOne(d => d.IdMaterialsNavigation)
                    .WithMany(p => p.MainActivitiesMaterials)
                    .HasForeignKey(d => d.IdMaterials)
                    .HasConstraintName("fk_materials");
            });

            modelBuilder.Entity<MainBanners>(entity =>
            {
                entity.ToTable("main_banners", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BTarget)
                    .HasColumnName("b_target")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.CUrlText).HasColumnName("c_url_text");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DDateEnd).HasColumnName("d_date_end");

                entity.Property(e => e.FSection).HasColumnName("f_section");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.FType).HasColumnName("f_type");

                entity.Property(e => e.NClicks)
                    .HasColumnName("n_clicks")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.NVisits)
                    .HasColumnName("n_visits")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UidSection)
                    .HasColumnName("uid_section")
                    .ForNpgsqlHasComment("Гуид секции");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainBanners)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_banners_main_sites");

                entity.HasOne(d => d.UidSectionNavigation)
                    .WithMany(p => p.MainBanners)
                    .HasForeignKey(d => d.UidSection)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_banners_section_group_items");
            });

            modelBuilder.Entity<MainCalendar>(entity =>
            {
                entity.ToTable("main_calendar", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.COrganizer).HasColumnName("c_organizer");

                entity.Property(e => e.CPhoto)
                    .HasColumnName("c_photo")
                    .HasColumnType("varchar");

                entity.Property(e => e.CPlace).HasColumnName("c_place");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.DDateEnd).HasColumnName("d_date_end");

                entity.Property(e => e.DDateStart).HasColumnName("d_date_start");

                entity.Property(e => e.FEvent).HasColumnName("f_event");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NDay)
                    .IsRequired()
                    .HasColumnName("n_day");

                entity.Property(e => e.NMonth)
                    .IsRequired()
                    .HasColumnName("n_month");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NYear)
                    .IsRequired()
                    .HasColumnName("n_year");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainCalendar)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_calendar_main_sites");
            });

            modelBuilder.Entity<MainDocuments>(entity =>
            {
                entity.ToTable("main_documents", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CFilePath).HasColumnName("c_file_path");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.DDateCreate)
                    .HasColumnName("d_date_create")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.IdPage).HasColumnName("id_page");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<MainEvents>(entity =>
            {
                entity.ToTable("main_events", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CPreview).HasColumnName("c_preview");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CType).HasColumnName("c_type");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NDay)
                    .HasColumnName("n_day")
                    .HasColumnType("char(10)");

                entity.Property(e => e.NMonth)
                    .HasColumnName("n_month")
                    .HasColumnType("char(10)");

                entity.Property(e => e.NYear)
                    .HasColumnName("n_year")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainEvents)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_events_main_sites");
            });

            modelBuilder.Entity<MainMailing>(entity =>
            {
                entity.ToTable("main_mailing", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CThema).HasColumnName("c_thema");

                entity.Property(e => e.DDateCreate).HasColumnName("d_date_create");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainMailing)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_mailing_main_sites");
            });

            modelBuilder.Entity<MainMaterials>(entity =>
            {
                entity.ToTable("main_materials", "portal");

                entity.HasIndex(e => e.BDisabled)
                    .HasName("fki_main_materials_disabled");

                entity.HasIndex(e => e.DDate)
                    .HasName("fki_main_materials_d_date");

                entity.HasIndex(e => e.FSite)
                    .HasName("fki_main_materials_archiv_f_site");

                entity.HasIndex(e => e.FType)
                    .HasName("fki_main_materials_f_type");

                entity.HasIndex(e => new { e.CAlias, e.NYear, e.NMonth, e.NDay })
                    .HasName("fki_main_materials_archiv_alias_year_month_day");

                entity.HasIndex(e => new { e.FSite, e.FType, e.DDate, e.BDisabled })
                    .HasName("fki_main_materials_site_type_date_disabled");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BImportant)
                    .HasColumnName("b_important")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BYandex)
                    .HasColumnName("b_yandex")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.CUrlName).HasColumnName("c_url_name");

                entity.Property(e => e.CVideo).HasColumnName("c_video");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FCategory).HasColumnName("f_category");

                entity.Property(e => e.FEvent).HasColumnName("f_event");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.FType).HasColumnName("f_type");

                entity.Property(e => e.NDay).HasColumnName("n_day");

                entity.Property(e => e.NMonth).HasColumnName("n_month");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NYear).HasColumnName("n_year");

                entity.HasOne(d => d.FEventNavigation)
                    .WithMany(p => p.MainMaterials)
                    .HasForeignKey(d => d.FEvent)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_main_materials_main_events");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainMaterials)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_materials_main_sites");
            });

            modelBuilder.Entity<MainMemory>(entity =>
            {
                entity.ToTable("main_memory", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BRepeat)
                    .HasColumnName("b_repeat")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias).HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite).HasColumnName("f_site");

                entity.Property(e => e.NDay).HasColumnName("n_day");

                entity.Property(e => e.NMonth).HasColumnName("n_month");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NYear).HasColumnName("n_year");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainMemory)
                    .HasForeignKey(d => d.FSite)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_main_memory_main_sites");
            });

            modelBuilder.Entity<MainOrganization>(entity =>
            {
                entity.ToTable("main_organization", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAddres).HasColumnName("c_addres");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CCoordX).HasColumnName("c_coord_x");

                entity.Property(e => e.CCoordY).HasColumnName("c_coord_y");

                entity.Property(e => e.CEmail).HasColumnName("c_email");

                entity.Property(e => e.CFax).HasColumnName("c_fax");

                entity.Property(e => e.CPhone).HasColumnName("c_phone");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CWeb).HasColumnName("c_web");

                entity.Property(e => e.CWork).HasColumnName("c_work");

                entity.Property(e => e.FDistrict).HasColumnName("f_district");

                entity.Property(e => e.FSite).HasColumnName("f_site");

                entity.Property(e => e.FType)
                    .IsRequired()
                    .HasColumnName("f_type");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("0")
                    .ForNpgsqlHasComment("Пермит");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainOrganization)
                    .HasForeignKey(d => d.FSite)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_main_organization_main_sites");
            });

            modelBuilder.Entity<MainPerson>(entity =>
            {
                entity.ToTable("main_person", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BHeadOfDepart)
                    .HasColumnName("b_head_of_depart")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BLeader)
                    .HasColumnName("b_leader")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAdres).HasColumnName("c_adres");

                entity.Property(e => e.CAuthor).HasColumnName("c_author");

                entity.Property(e => e.CAward).HasColumnName("c_award");

                entity.Property(e => e.CCareer).HasColumnName("c_career");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CEducation).HasColumnName("c_education");

                entity.Property(e => e.CEmail).HasColumnName("c_email");

                entity.Property(e => e.CHistory).HasColumnName("c_history");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name");

                entity.Property(e => e.CPhone).HasColumnName("c_phone");

                entity.Property(e => e.CPhoneHome).HasColumnName("c_phone_home");

                entity.Property(e => e.CPhoneIntern).HasColumnName("c_phone_intern");

                entity.Property(e => e.CPhoneMobile).HasColumnName("c_phone_mobile");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CPost).HasColumnName("c_post");

                entity.Property(e => e.CQuote).HasColumnName("c_quote");

                entity.Property(e => e.CRegulations).HasColumnName("c_regulations");

                entity.Property(e => e.DBirthDay).HasColumnName("d_birth_day");

                entity.Property(e => e.DInauguration).HasColumnName("d_inauguration");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.FStructure).HasColumnName("f_structure");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainPerson)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_person_main_sites");
            });

            modelBuilder.Entity<MainPhotoAlbums>(entity =>
            {
                entity.ToTable("main_photo_albums", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BGallery)
                    .HasColumnName("b_gallery")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAuthor).HasColumnName("c_author");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.COldUrl).HasColumnName("c_old_url");

                entity.Property(e => e.CPreview).HasColumnName("c_preview");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainPhotoAlbums)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_photo_albums_main_sites");
            });

            modelBuilder.Entity<MainPhotos>(entity =>
            {
                entity.ToTable("main_photos", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.CPhoto)
                    .IsRequired()
                    .HasColumnName("c_photo");

                entity.Property(e => e.CPreview)
                    .IsRequired()
                    .HasColumnName("c_preview");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.MainPhotos)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("fk_main_photos_main_photo_albums");
            });

            modelBuilder.Entity<MainPlaceCard>(entity =>
            {
                entity.ToTable("main_place_card", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled).HasColumnName("b_disabled");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CPlace).HasColumnName("c_place");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.CUrlName).HasColumnName("c_url_name");

                entity.Property(e => e.CVideo).HasColumnName("c_video");

                entity.Property(e => e.DDateEnd).HasColumnName("d_date_end");

                entity.Property(e => e.DDateStart).HasColumnName("d_date_start");

                entity.Property(e => e.FEvent).HasColumnName("f_event");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NDay)
                    .IsRequired()
                    .HasColumnName("n_day");

                entity.Property(e => e.NEipskId).HasColumnName("n_eipsk_id");

                entity.Property(e => e.NMonth)
                    .IsRequired()
                    .HasColumnName("n_month");

                entity.Property(e => e.NYear)
                    .IsRequired()
                    .HasColumnName("n_year");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainPlaceCard)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_place_card_main_sites");
            });

            modelBuilder.Entity<MainRedirect>(entity =>
            {
                entity.ToTable("main_redirect", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('portal.main_redirect_id_seq'::regclass)");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CLink)
                    .IsRequired()
                    .HasColumnName("c_link");
            });

            modelBuilder.Entity<MainReviews>(entity =>
            {
                entity.ToTable("main_reviews", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisable)
                    .HasColumnName("b_disable")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BNew)
                    .HasColumnName("b_new")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CAnswer).HasColumnName("c_answer");

                entity.Property(e => e.CAnswerType).HasColumnName("c_answer_type");

                entity.Property(e => e.CCategory).HasColumnName("c_category");

                entity.Property(e => e.CDopAdres).HasColumnName("c_dop_adres");

                entity.Property(e => e.CDopContacts).HasColumnName("c_dop_contacts");

                entity.Property(e => e.CEmail).HasColumnName("c_email");

                entity.Property(e => e.CFile).HasColumnName("c_file");

                entity.Property(e => e.CIp).HasColumnName("c_ip");

                entity.Property(e => e.CName).HasColumnName("c_name");

                entity.Property(e => e.CQuestioner).HasColumnName("c_questioner");

                entity.Property(e => e.CText)
                    .IsRequired()
                    .HasColumnName("c_text");

                entity.Property(e => e.CType).HasColumnName("c_type");

                entity.Property(e => e.DDate).HasColumnName("d_date");

                entity.Property(e => e.FGroup).HasColumnName("f_group");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.FType).HasColumnName("f_type");

                entity.HasOne(d => d.FGroupNavigation)
                    .WithMany(p => p.MainReviews)
                    .HasForeignKey(d => d.FGroup)
                    .HasConstraintName("fk_main_reviews_cms_section_group");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainReviews)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_reviews_main_sites");

                entity.HasOne(d => d.FTypeNavigation)
                    .WithMany(p => p.MainReviews)
                    .HasForeignKey(d => d.FType)
                    .HasConstraintName("fk_main_reviews_cms_section_group_items");
            });

            modelBuilder.Entity<MainSettings>(entity =>
            {
                entity.HasKey(e => e.CGuid);

                entity.ToTable("main_settings", "portal");

                entity.Property(e => e.CGuid)
                    .HasColumnName("c_guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BSsl)
                    .HasColumnName("b_ssl")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAdres).HasColumnName("c_adres");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CFax).HasColumnName("c_fax");

                entity.Property(e => e.CInfo).HasColumnName("c_info");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CMail).HasColumnName("c_mail");

                entity.Property(e => e.CMailFrom).HasColumnName("c_mail_from");

                entity.Property(e => e.CMailFromAlias).HasColumnName("c_mail_from_alias");

                entity.Property(e => e.CMailPass).HasColumnName("c_mail_pass");

                entity.Property(e => e.CMailServer).HasColumnName("c_mail_server");

                entity.Property(e => e.CMailTo).HasColumnName("c_mail_to");

                entity.Property(e => e.CPhone).HasColumnName("c_phone");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.CWorkMode).HasColumnName("c_work_mode");

                entity.Property(e => e.FCoordX).HasColumnName("f_coord_x");

                entity.Property(e => e.FCoordY).HasColumnName("f_coord_y");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('portal.main_settings_id_seq'::regclass)");

                entity.Property(e => e.NMailPort).HasColumnName("n_mail_port");
            });

            modelBuilder.Entity<MainSiteMap>(entity =>
            {
                entity.ToTable("main_site_map", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDeleteble)
                    .HasColumnName("b_deleteble")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CAlias)
                    .IsRequired()
                    .HasColumnName("c_alias");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CFile).HasColumnName("c_file");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CLogo).HasColumnName("c_logo");

                entity.Property(e => e.CPath)
                    .IsRequired()
                    .HasColumnName("c_path");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.CViewName).HasColumnName("c_view_name");

                entity.Property(e => e.FMenu).HasColumnName("f_menu");

                entity.Property(e => e.FSite).HasColumnName("f_site");

                entity.Property(e => e.FViewId).HasColumnName("f_view_id");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainSiteMap)
                    .HasForeignKey(d => d.FSite)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_site_map_to_site");
            });

            modelBuilder.Entity<MainSites>(entity =>
            {
                entity.HasKey(e => e.CDomain);

                entity.ToTable("main_sites", "portal");

                entity.Property(e => e.CDomain)
                    .HasColumnName("c_domain")
                    .ValueGeneratedNever();

                entity.Property(e => e.BOnHeader)
                    .HasColumnName("b_on_header")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.CAdmEmail).HasColumnName("c_adm_email");

                entity.Property(e => e.CAdmPhone).HasColumnName("c_adm_phone");

                entity.Property(e => e.CAdress).HasColumnName("c_adress");

                entity.Property(e => e.CCoordX).HasColumnName("c_coord_x");

                entity.Property(e => e.CCoordY).HasColumnName("c_coord_y");

                entity.Property(e => e.CCssAdd).HasColumnName("c_css_add");

                entity.Property(e => e.CCssMain).HasColumnName("c_css_main");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CDopInfo).HasColumnName("c_dop_info");

                entity.Property(e => e.CEmail).HasColumnName("c_email");

                entity.Property(e => e.CEmailSendError).HasColumnName("C_EmailSendError");

                entity.Property(e => e.CFax).HasColumnName("c_fax");

                entity.Property(e => e.CFriday).HasColumnName("c_friday");

                entity.Property(e => e.CGeneralInfo).HasColumnName("c_general_info");

                entity.Property(e => e.CJsMain).HasColumnName("c_js_main");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CLogo).HasColumnName("c_logo");

                entity.Property(e => e.CMonday).HasColumnName("c_monday");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("c_name");

                entity.Property(e => e.CNameDop).HasColumnName("c_name_dop");

                entity.Property(e => e.CNameLong).HasColumnName("c_name_long");

                entity.Property(e => e.COldSite).HasColumnName("c_old_site");

                entity.Property(e => e.CPhone).HasColumnName("c_phone");

                entity.Property(e => e.CPhotoTop).HasColumnName("c_photo_top");

                entity.Property(e => e.CSaturday).HasColumnName("c_saturday");

                entity.Property(e => e.CScripts).HasColumnName("c_scripts");

                entity.Property(e => e.CSite).HasColumnName("c_site");

                entity.Property(e => e.CSitetype).HasColumnName("c_sitetype");

                entity.Property(e => e.CSocFb).HasColumnName("c_soc_fb");

                entity.Property(e => e.CSocIn).HasColumnName("c_soc_in");

                entity.Property(e => e.CSocOk).HasColumnName("c_soc_ok");

                entity.Property(e => e.CSocRt).HasColumnName("c_soc_rt");

                entity.Property(e => e.CSocTw).HasColumnName("c_soc_tw");

                entity.Property(e => e.CSocVk).HasColumnName("c_soc_vk");

                entity.Property(e => e.CSocYoutube).HasColumnName("c_soc_youtube");

                entity.Property(e => e.CSunday).HasColumnName("c_sunday");

                entity.Property(e => e.CTelegramChanel).HasColumnName("c_telegram_chanel");

                entity.Property(e => e.CTelegramChatId).HasColumnName("c_telegram_chat_id");

                entity.Property(e => e.CThursday).HasColumnName("c_thursday");

                entity.Property(e => e.CTuesday).HasColumnName("c_tuesday");

                entity.Property(e => e.CTypeBlock).HasColumnName("c_type_block");

                entity.Property(e => e.CVideoLogin)
                    .HasColumnName("c_video_login")
                    .ForNpgsqlHasComment("логин для входа на video.cap.ru");

                entity.Property(e => e.CVideoPassword)
                    .HasColumnName("c_video_password")
                    .ForNpgsqlHasComment("пароль для входа на video.cap.ru");

                entity.Property(e => e.CWednesday).HasColumnName("c_wednesday");

                entity.Property(e => e.CWorktime).HasColumnName("c_worktime");

                entity.Property(e => e.FGosuslugiId).HasColumnName("f_gosuslugi_id");

                entity.Property(e => e.FSiteTemplateId).HasColumnName("f_site_template_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.HasOne(d => d.FSiteTemplate)
                    .WithMany(p => p.MainSites)
                    .HasForeignKey(d => d.FSiteTemplateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_main_sites_cms_site_templates");
            });

            modelBuilder.Entity<MainSitesDomainList>(entity =>
            {
                entity.HasKey(e => e.CDomain);

                entity.ToTable("main_sites_domain_list", "portal");

                entity.Property(e => e.CDomain)
                    .HasColumnName("c_domain")
                    .ValueGeneratedNever();

                entity.Property(e => e.FSiteId)
                    .IsRequired()
                    .HasColumnName("f_site_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasDefaultValueSql("nextval('portal.main_sites_domain_list_num_seq'::regclass)");

                entity.HasOne(d => d.FSite)
                    .WithMany(p => p.MainSitesDomainList)
                    .HasForeignKey(d => d.FSiteId)
                    .HasConstraintName("fk_main_sites_domain_list_main_sites");
            });

            modelBuilder.Entity<MainSlider>(entity =>
            {
                entity.ToTable("main_slider", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BTarget)
                    .HasColumnName("b_target")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CPhoto).HasColumnName("c_photo");

                entity.Property(e => e.CTitle).HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.DDate)
                    .HasColumnName("d_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainSlider)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_slider_main_sites");
            });

            modelBuilder.Entity<MainStructure>(entity =>
            {
                entity.ToTable("main_structure", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle).HasColumnName("c_title");

                entity.Property(e => e.CUrl).HasColumnName("c_url");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NPermit).HasColumnName("n_permit");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainStructure)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_structure_main_sites");
            });

            modelBuilder.Entity<MainSubscrip>(entity =>
            {
                entity.HasKey(e => new { e.FSite, e.CEmail });

                entity.ToTable("main_subscrip", "portal");

                entity.Property(e => e.FSite).HasColumnName("f_site");

                entity.Property(e => e.CEmail).HasColumnName("c_email");

                entity.Property(e => e.DDateCreate).HasColumnName("d_date_create");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainSubscrip)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_subscrip_main_sites");
            });

            modelBuilder.Entity<MainTenders>(entity =>
            {
                entity.ToTable("main_tenders", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CKeyw).HasColumnName("c_keyw");

                entity.Property(e => e.CNumber)
                    .IsRequired()
                    .HasColumnName("c_number");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.CTitle)
                    .IsRequired()
                    .HasColumnName("c_title");

                entity.Property(e => e.DDateCreate).HasColumnName("d_date_create");

                entity.Property(e => e.DDateEnd).HasColumnName("d_date_end");

                entity.Property(e => e.DDateStart).HasColumnName("d_date_start");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.FStage)
                    .IsRequired()
                    .HasColumnName("f_stage");

                entity.Property(e => e.FType)
                    .IsRequired()
                    .HasColumnName("f_type");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainTenders)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_tenders_main_sites");
            });

            modelBuilder.Entity<MainVacancy>(entity =>
            {
                entity.ToTable("main_vacancy", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CDescription).HasColumnName("c_description");

                entity.Property(e => e.CEducation).HasColumnName("c_education");

                entity.Property(e => e.CExperience).HasColumnName("c_experience");

                entity.Property(e => e.CPay).HasColumnName("c_pay");

                entity.Property(e => e.CPosition)
                    .IsRequired()
                    .HasColumnName("c_position");

                entity.Property(e => e.CProfession).HasColumnName("c_profession");

                entity.Property(e => e.DKonkursDate)
                    .HasColumnName("d_konkurs_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DPublicationDate)
                    .HasColumnName("d_publication_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainVacancy)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_vacancy_main_sites");
            });

            modelBuilder.Entity<MainVideo>(entity =>
            {
                entity.ToTable("main_video", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BFinal)
                    .HasColumnName("b_final")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BMediaGallery)
                    .HasColumnName("b_media_gallery")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CDesc).HasColumnName("c_desc");

                entity.Property(e => e.CDopVideo).HasColumnName("c_dop_video");

                entity.Property(e => e.CLogConvert).HasColumnName("c_log_convert");

                entity.Property(e => e.COriginal).HasColumnName("c_original");

                entity.Property(e => e.CPreview).HasColumnName("c_preview");

                entity.Property(e => e.CSecondsProcessed).HasColumnName("c_seconds_processed");

                entity.Property(e => e.CTitle).HasColumnName("c_title");

                entity.Property(e => e.CVideo).HasColumnName("c_video");

                entity.Property(e => e.CVideoOgv).HasColumnName("c_video_ogv");

                entity.Property(e => e.DDate).HasColumnName("d_date");

                entity.Property(e => e.FSite).HasColumnName("f_site");

                entity.Property(e => e.NHeight).HasColumnName("n_height");

                entity.Property(e => e.NOldId).HasColumnName("n_old_id");

                entity.Property(e => e.NWidth).HasColumnName("n_width");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainVideo)
                    .HasForeignKey(d => d.FSite)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_main_video_main_sites");
            });

            modelBuilder.Entity<MainVote>(entity =>
            {
                entity.ToTable("main_vote", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BDisabled)
                    .HasColumnName("b_disabled")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.BHisAnswer)
                    .HasColumnName("b_his_answer")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BType)
                    .HasColumnName("b_type")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CHeader)
                    .IsRequired()
                    .HasColumnName("c_header");

                entity.Property(e => e.CText).HasColumnName("c_text");

                entity.Property(e => e.DDateEnd).HasColumnName("d_date_end");

                entity.Property(e => e.DDateStart).HasColumnName("d_date_start");

                entity.Property(e => e.FSite)
                    .IsRequired()
                    .HasColumnName("f_site");

                entity.HasOne(d => d.FSiteNavigation)
                    .WithMany(p => p.MainVote)
                    .HasForeignKey(d => d.FSite)
                    .HasConstraintName("fk_main_vote_main_sites");
            });

            modelBuilder.Entity<MainVoteAnswers>(entity =>
            {
                entity.ToTable("main_vote_answers", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("portal.newguid()");

                entity.Property(e => e.BHisOption)
                    .HasColumnName("b_his_option")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.CIdVote).HasColumnName("c_id_vote");

                entity.Property(e => e.CVariant)
                    .IsRequired()
                    .HasColumnName("c_variant");

                entity.Property(e => e.NPermit)
                    .HasColumnName("n_permit")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.CIdVoteNavigation)
                    .WithMany(p => p.MainVoteAnswers)
                    .HasForeignKey(d => d.CIdVote)
                    .HasConstraintName("fk_main_vote_answers_main_vote");
            });

            modelBuilder.Entity<SsNumbers>(entity =>
            {
                entity.ToTable("ss_numbers", "portal");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.HasSequence("cms_resolutions_id_seq");

            modelBuilder.HasSequence("cms_resolutions_templates_id_seq");

            modelBuilder.HasSequence("main_redirect_id_seq");

            modelBuilder.HasSequence("main_settings_id_seq");

            modelBuilder.HasSequence("main_sites_domain_list_num_seq");
        }
    }
}
