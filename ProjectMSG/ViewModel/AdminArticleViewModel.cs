using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;

namespace ProjectMSG.ViewModel
{
    public class AdminArticleViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminArticleViewModel(PageService pageService, MessageBus messageBus)
        {
            this.pageService = pageService;
            this.messageBus = messageBus;

            this.messageBus.Receive<SectionToArticle>(this, async message =>
            {
                getSectionId = message.Id;
                GetSetctionName = $"Раздел: {message.Name}";
                await Task.Run(GetArticle);
            });
        }

        #region Properties

        private readonly PageService pageService;
        private readonly MessageBus messageBus;

        private AddArticleDialog addArticleDialog;
        private EditArticleDialog editArticleDialog;

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
            get => SelectArticle.ArticleName;
            set
            {
                SelectArticle.ArticleName = value;
                NotifyPropertyChanged();
            }
        }

        public string ArticleText
        {
            get => SelectArticle.ArticleText;
            set
            {
                SelectArticle.ArticleText = value;
                NotifyPropertyChanged();
            }
        }

        private List<Article> articles;

        public List<Article> Articles
        {
            get => articles;
            set
            {
                articles = value;
                NotifyPropertyChanged();
            }
        }

        private int getSectionId;
        private string getSetctionName;

        public string GetSetctionName
        {
            get => getSetctionName;
            set
            {
                getSetctionName = value;
                NotifyPropertyChanged();
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
                return goToTest ??= new RelayCommand(async obj =>
                {
                    if (SelectArticle != null)
                    {
                        pageService.ChangePage(new AdminTest());
                        await messageBus.SendTo<AdminTestViewModel>(new SectionToArticle(ArticleId, ArticleName));
                    }
                });
            }
        }

        private RelayCommand back;

        public RelayCommand Back
        {
            get { return back ??= new RelayCommand(obj => { pageService.ChangePage(new AdminSection()); }); }
        }

        private RelayCommand addArticle;

        public RelayCommand AddArticleCommand
        {
            get
            {
                return addArticle ??= new RelayCommand(async obj =>
                {
                    addArticleDialog = new AddArticleDialog();
                    if (addArticleDialog.ShowDialog() == true)
                    {
                        articleNameAdd = addArticleDialog.ArticleName;
                        articleTextAdd = addArticleDialog.ArticleText;
                        articlePhotoAdd = new List<Photo>();
                        articlePhotoAdd = addArticleDialog.ArticleImage;
                        await Task.Run(AddArticle);
                    }
                });
            }
        }

        private RelayCommand delArticle;

        public RelayCommand DelArticleCommand
        {
            get
            {
                return delArticle ??= new RelayCommand(async obj =>
                {
                    if (SelectArticle != null)
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить статью?", "Удаление статьи",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                            return;
                        await Task.Run(DelArticle);
                    }
                    else
                    {
                        MessageBox.Show("Выберите статью для удаления!", "Удаление статьи", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                });
            }
        }

        private RelayCommand editArticle;

        public RelayCommand EditArticleCommand
        {
            get
            {
                return editArticle ??= new RelayCommand(async obj =>
                {
                    if (SelectArticle != null)
                    {
                        articlePhotoDel = new List<Photo>();
                        await Task.Run(GetPhoto);
                        editArticleDialog = new EditArticleDialog(ArticleName, ArticleText, articlePhotoAdd);
                        if (editArticleDialog.ShowDialog() == true)
                        {
                            articleNameAdd = editArticleDialog.ArticleName;
                            articleTextAdd = editArticleDialog.ArticleText;
                            articlePhotoAdd = new List<Photo>();
                            articlePhotoAdd = editArticleDialog.ArticleImage;
                            await Task.Run(EditArticle);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите раздел для редактирования!", "Редактирование раздела",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                });
            }
        }

        #endregion

        #region Methods

        private async Task GetArticle()
        {
            await using (var db = new MSGCoreContext())
            {
                Articles = await db.Article.Where(p => p.SectionId == getSectionId).ToListAsync();
            }
        }

        private async Task AddArticle()
        {
            await using (var db = new MSGCoreContext())
            {
                var add = new Article
                {
                    ArticleName = articleNameAdd,
                    ArticleText = articleTextAdd,
                    SectionId = getSectionId
                };
                await db.Article.AddAsync(add);
                await db.SaveChangesAsync();

                var last = db.Article.ToList().Last();
                var lastArticle = last.ArticleId;
                var lastArticleName = last.ArticleName;
                for (var i = 0; i < articlePhotoAdd.Count; i++)
                {
                    var addArticlePhoto = new Photo
                    {
                        ArticleId = lastArticle,
                        ArticlePhoto = articlePhotoAdd[i].ArticlePhoto
                    };
                    db.Photo.Add(addArticlePhoto);
                }

                await db.SaveChangesAsync();

                var addTest = new Test
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
            await using (var db = new MSGCoreContext())
            {
                var del = new Article
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

                for (var i = 0; i < articlePhotoAdd.Count; i++)
                {
                    var addArticlePhoto = new Photo
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
            await using (var db = new MSGCoreContext())
            {
                articlePhotoAdd = await db.Photo.Where(p => p.ArticleId == ArticleId).ToListAsync();
                articlePhotoDel = await db.Photo.Where(p => p.ArticleId == ArticleId).ToListAsync();
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