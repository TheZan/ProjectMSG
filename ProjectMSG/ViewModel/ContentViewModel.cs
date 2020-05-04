using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;

namespace ProjectMSG.ViewModel
{
    public class ContentViewModel : BindableBase, INotifyPropertyChanged
    {
        public ContentViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;

            _messageBus.Receive<TextMessage>(this, async message => { GetUserId = Convert.ToInt32(message.Text); });

            Task.Run(GetSection);
        }

        #region Methods

        private async Task GetSection()
        {
            await using (var db = new MSGCoreContext())
            {
                Sections = await db.Section.ToListAsync();
                Articles = await db.Article.ToListAsync();
                PhotosMain = await db.Photo.ToListAsync();
                var firstArticleId = Articles.Select(p => p.ArticleId).FirstOrDefault();
                Photos = await db.Photo.Where(p => p.ArticleId == firstArticleId).ToListAsync();
            }
        }

        #endregion

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

        private int getUserId;

        public int GetUserId
        {
            get => getUserId;
            set
            {
                getUserId = value;
                NotifyPropertyChanged();
            }
        }

        private Article selectArticle = new Article();

        public Article SelectArticle
        {
            get => selectArticle;
            set
            {
                selectArticle = value;
                NotifyPropertyChanged();
            }
        }

        public int ArticleId
        {
            get => SelectArticle.ArticleId;
            set
            {
                SelectArticle.ArticleId = value;
                NotifyPropertyChanged();
            }
        }

        public string ArticleName
        {
            get
            {
                if (selectArticle.ArticleId == 0)
                    return Articles.Select(p => p.ArticleName).FirstOrDefault();
                return SelectArticle.ArticleName;
            }
            set
            {
                SelectArticle.ArticleName = value;
                NotifyPropertyChanged();
            }
        }

        public string ArticleText
        {
            get
            {
                if (selectArticle.ArticleId == 0)
                    return Articles.Select(p => p.ArticleText).FirstOrDefault();
                return SelectArticle.ArticleText;
            }
            set
            {
                SelectArticle.ArticleText = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<Photo> Photos
        {
            get => SelectArticle.Photo;
            set
            {
                SelectArticle.Photo = value;
                NotifyPropertyChanged();
            }
        }

        private ICollection<Photo> PhotosMain = new List<Photo>();

        private List<Section> sections = new List<Section>();

        public List<Section> Sections
        {
            get => sections;
            set
            {
                sections = value;
                NotifyPropertyChanged();
            }
        }

        private List<Article> articles = new List<Article>();

        public List<Article> Articles
        {
            get => articles;
            set
            {
                articles = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        private RelayCommand selectContent;

        public RelayCommand SelectContent
        {
            get { return selectContent ??= new RelayCommand(obj => { _pageService.ChangePage(new Content()); }); }
        }

        private RelayCommand selectTesting;

        public RelayCommand SelectTesting
        {
            get { return selectTesting ??= new RelayCommand(obj => { _pageService.ChangePage(new Testing()); }); }
        }

        private RelayCommand selectProfile;

        public RelayCommand SelectProfile
        {
            get
            {
                return selectProfile ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new Profile());
                    _messageBus.SendTo<ProfileViewModel>(new TextMessage(GetUserId.ToString()));
                });
            }
        }

        #endregion

        #region ProperyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}