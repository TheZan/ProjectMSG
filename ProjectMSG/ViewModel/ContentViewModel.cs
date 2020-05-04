using DevExpress.Mvvm;
using ProjectMSG.Message;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Model;
using Section = ProjectMSG.Model.Section;

namespace ProjectMSG.ViewModel
{
    public class ContentViewModel : BindableBase, INotifyPropertyChanged
    {
        public ContentViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;

            _messageBus.Receive<TextMessage>(this, async message =>
            {
                GetUserId = Convert.ToInt32(message.Text);
            });

            Task.Run(GetSection);
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        private int getUserId;

        public int GetUserId
        {
            get
            {
                return getUserId;
            }
            set
            {
                getUserId = value;
                NotifyPropertyChanged("GetUserId");
            }
        }

        private Article selectArticle = new Article();
        public Article SelectArticle
        {
            get { return selectArticle; }
            set
            {
                selectArticle = value;
                NotifyPropertyChanged("SelectArticle");
            }
        }

        public int ArticleId
        {
            get
            {
                return SelectArticle.ArticleId;
            }
            set
            {
                SelectArticle.ArticleId = value;
                NotifyPropertyChanged("ArticleId");
            }
        }

        public string ArticleName
        {
            get
            {
                if (selectArticle.ArticleId == 0)
                {
                    return Articles.Select(p => p.ArticleName).FirstOrDefault();
                }
                else
                {
                    return SelectArticle.ArticleName;
                }
            }
            set
            {
                SelectArticle.ArticleName = value;
                NotifyPropertyChanged("ArticleName");
            }
        }
        
        public string ArticleText
        {
            get
            {
                if (selectArticle.ArticleId == 0)
                {
                    return Articles.Select(p => p.ArticleText).FirstOrDefault();
                }
                else
                {
                    return SelectArticle.ArticleText;
                }
            }
            set
            {
                SelectArticle.ArticleText = value;
                NotifyPropertyChanged("ArticleText");
            }
        }

        public ICollection<Photo> Photos
        {
            get { return SelectArticle.Photo; }
            set
            {
                SelectArticle.Photo = value;
                NotifyPropertyChanged("Photos");
            }
        }

        private ICollection<Photo> PhotosMain = new List<Photo>();

        private List<Section> sections = new List<Section>();

        public List<Section> Sections
        {
            get
            {
                return sections;
            }
            set
            {
                sections = value;
                NotifyPropertyChanged("Sections");
            }
        }

        private List<Article> articles = new List<Article>();

        public List<Article> Articles
        {
            get
            {
                return articles;
            }
            set
            {
                articles = value;
                NotifyPropertyChanged("Articles");
            }
        }

        #endregion

        #region Command

        private RelayCommand selectContent;

        public RelayCommand SelectContent
        {
            get
            {
                return selectContent ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new Content());
                });
            }
        }

        private RelayCommand selectTesting;

        public RelayCommand SelectTesting
        {
            get
            {
                return selectTesting ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new Testing());
                });
            }
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

        #region Methods

        private async Task GetSection()
        {
            await using (MSGCoreContext db = new MSGCoreContext())
            {
                Sections = await db.Section.ToListAsync();
                Articles = await db.Article.ToListAsync();
                PhotosMain = await db.Photo.ToListAsync();
                int firstArticleId = Articles.Select(p => p.ArticleId).FirstOrDefault();
                Photos = await db.Photo.Where(p => p.ArticleId == firstArticleId).ToListAsync();
            }
        }

        #endregion

        #region ProperyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
