using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectMSG.ViewModel
{
    public class AdminArticleViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminArticleViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;

            _messageBus.Receive<SectionToArticle>(this, async message =>
            {
                GetSectionId = message.Id;
                GetSetctionName = $"Раздел: {message.Name}";
                await Task.Run(GetArticle);
            });
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        AddArticleDialog addArticleDialog;
        EditArticleDialog editArticleDialog;

        private Article selectArticle = new Article();
        public Article SelectArticle
        {
            get
            {
                return selectArticle;
            }
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
                return SelectArticle.ArticleName;
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
                return SelectArticle.ArticleText;
            }
            set
            {
                SelectArticle.ArticleText = value;
                NotifyPropertyChanged("ArticleText");
            }
        }

        public int SectionId
        {
            get
            {
                return SelectArticle.SectionId;
            }
            set
            {
                SelectArticle.SectionId = value;
                NotifyPropertyChanged("SectionId");
            }
        }

        private List<Article> articles;
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

        private int GetSectionId;
        private string getSetctionName;
        public string GetSetctionName
        {
            get
            {
                return getSetctionName;
            }
            set
            {
                getSetctionName = value;
                NotifyPropertyChanged("GetSetctionName");
            }
        }

        private string articleNameAdd;
        private string articleTextAdd;
        private List<Photo> articlePhotoAdd;
        private IList<Photo> articlePhotoDel;

        #endregion

        #region Command

        private RelayCommand goToTest;

        public RelayCommand GoToTest
        {
            get
            {
                return goToTest ??
                  (goToTest = new RelayCommand(async obj =>
                  {
                      if (SelectArticle != null)
                      {
                          _pageService.ChangePage(new AdminTest());
                          await _messageBus.SendTo<AdminTestViewModel>(new SectionToArticle(ArticleId, ArticleName));
                      }
                  }));
            }
        }

        private RelayCommand back;

        public RelayCommand Back
        {
            get
            {
                return back ??
                  (back = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new AdminSection());
                  }));
            }
        }

        private RelayCommand addArticle;

        public RelayCommand AddArticleCommand
        {
            get
            {
                return addArticle ??
                  (addArticle = new RelayCommand(async obj =>
                  {
                      addArticleDialog = new AddArticleDialog();
                      if (addArticleDialog.ShowDialog() == true)
                      {
                          articleNameAdd = addArticleDialog.ArticleName;
                          articleTextAdd = addArticleDialog.ArticleText;
                          articlePhotoAdd = new List<Photo>();
                          articlePhotoAdd = addArticleDialog.ArticleImage;
                          await Task.Run(() => AddArticle());
                      }
                  }));
            }
        }

        private RelayCommand delArticle;

        public RelayCommand DelArticleCommand
        {
            get
            {
                return delArticle ??
                  (delArticle = new RelayCommand(async obj =>
                  {
                      if (SelectArticle != null)
                      {
                          if (MessageBox.Show("Вы действительно хотите удалить статью?", "Удаление статьи", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                          {
                              return;
                          }
                          else
                          {
                              await Task.Run(() => DelArticle());
                          }
                      }
                      else
                      {
                          MessageBox.Show("Выберите статью для удаления!", "Удаление статьи", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                  }));
            }
        }

        private RelayCommand editArticle;

        public RelayCommand EditArticleCommand
        {
            get
            {
                return editArticle ??
                  (editArticle = new RelayCommand(async obj =>
                  {
                      if (SelectArticle != null)
                      {
                          articlePhotoDel = new List<Photo>();
                          await Task.Run(() => GetPhoto());
                          editArticleDialog = new EditArticleDialog(ArticleName, ArticleText, articlePhotoAdd);
                          if (editArticleDialog.ShowDialog() == true)
                          {
                              articleNameAdd = editArticleDialog.ArticleName;
                              articleTextAdd = editArticleDialog.ArticleText;
                              articlePhotoAdd = new List<Photo>();
                              articlePhotoAdd = editArticleDialog.ArticleImage;
                              await Task.Run(() => EditArticle());
                          }
                      }
                      else
                      {
                          MessageBox.Show("Выберите раздел для редактирования!", "Редактирование раздела", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                  }));
            }
        }

        #endregion

        #region Methods

        private async Task GetArticle()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                Articles = await db.Article.Where(p => p.SectionId == GetSectionId).ToListAsync();
            }
        }

        private async Task AddArticle()
        {

            using (MSGCoreContext db = new MSGCoreContext())
            {
                Article add = new Article
                {
                    ArticleName = articleNameAdd,
                    ArticleText = articleTextAdd,
                    SectionId = GetSectionId
                };
                await db.Article.AddAsync(add);
                await db.SaveChangesAsync();

                var last = db.Article.ToList().Last();
                int lastArticle = last.ArticleId;
                string lastArticleName = last.ArticleName;
                for (int i = 0; i < articlePhotoAdd.Count; i++)
                {
                    Photo addArticlePhoto = new Photo
                    {
                        ArticleId = lastArticle,
                        ArticlePhoto = articlePhotoAdd[i].ArticlePhoto
                    };
                    db.Photo.Add(addArticlePhoto);
                }
                await db.SaveChangesAsync();

                Test addTest = new Test
                {
                    TestName = lastArticleName,
                    ArticleId = lastArticle
                };
                await db.Test.AddAsync(addTest);
                await db.SaveChangesAsync();

                await GetArticle();
            }
        }

        private async Task DelArticle()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                Article del = new Article
                {
                    ArticleId = ArticleId
                };
                db.Article.Attach(del);
                db.Article.Remove(del);
                await db.SaveChangesAsync();
                await GetArticle();
            }
            SelectArticle = null;
        }

        private async Task EditArticle()
        {

            await using (var db = new MSGCoreContext())
            {
                var editArticle = await db.Article.Where(p => p.ArticleId == ArticleId).FirstOrDefaultAsync();
                editArticle.ArticleName = articleNameAdd;
                editArticle.ArticleText = articleTextAdd;
                await db.SaveChangesAsync();

                db.Photo.RemoveRange(articlePhotoDel);
                await db.SaveChangesAsync();

                for (int i = 0; i < articlePhotoAdd.Count; i++)
                {
                    Photo addArticlePhoto = new Photo
                    {
                        ArticleId = ArticleId,
                        ArticlePhoto = articlePhotoAdd[i].ArticlePhoto
                    };
                    db.Photo.Add(addArticlePhoto);
                }
                await db.SaveChangesAsync();

                await GetArticle();
            }
            SelectArticle = null;
        }

        private async Task GetPhoto()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                articlePhotoAdd = await db.Photo.Where(p => p.ArticleId == ArticleId).ToListAsync();
                articlePhotoDel = await db.Photo.Where(p => p.ArticleId == ArticleId).ToListAsync();
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
