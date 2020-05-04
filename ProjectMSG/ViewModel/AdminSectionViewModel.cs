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
    public class AdminSectionViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminSectionViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;

            Task.Run(GetSection);
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

        private AddSectionDialog addSectionDialog;
        private EditSectionDialog editSectionDialog;

        private string sectionNameAdd;
        private string sectionNameEdit;

        private Section selectSection = new Section();

        public Section SelectSection
        {
            get => selectSection;
            set
            {
                selectSection = value;
                NotifyPropertyChanged();
            }
        }

        public int SectionId
        {
            get => SelectSection.SectionId;
            set
            {
                SelectSection.SectionId = value;
                NotifyPropertyChanged();
            }
        }

        public string SectionName
        {
            get => SelectSection.SectionName;
            set
            {
                SelectSection.SectionName = value;
                NotifyPropertyChanged();
            }
        }

        private List<Section> sections;

        public List<Section> Sections
        {
            get => sections;
            set
            {
                sections = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        private RelayCommand back;

        public RelayCommand Back
        {
            get { return back ??= new RelayCommand(obj => { _pageService.ChangePage(new Admin()); }); }
        }

        private RelayCommand goToArticle;

        public RelayCommand GoToArticle
        {
            get
            {
                return goToArticle ??= new RelayCommand(async obj =>
                {
                    if (SelectSection != null)
                    {
                        _pageService.ChangePage(new AdminArticle());
                        await _messageBus.SendTo<AdminArticleViewModel>(new SectionToArticle(SectionId, SectionName));
                    }
                });
            }
        }

        private RelayCommand addSection;

        public RelayCommand AddSectionCommand
        {
            get
            {
                return addSection ??= new RelayCommand(async obj =>
                {
                    addSectionDialog = new AddSectionDialog();
                    if (addSectionDialog.ShowDialog() == true)
                    {
                        sectionNameAdd = addSectionDialog.GetSectionName;
                        await Task.Run(AddSection);
                    }
                });
            }
        }

        private RelayCommand delSection;

        public RelayCommand DelSectionCommand
        {
            get
            {
                return delSection ??= new RelayCommand(async obj =>
                {
                    if (SelectSection != null)
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить раздел?", "Удаление раздела",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                            return;
                        await Task.Run(DelSection);
                    }
                    else
                    {
                        MessageBox.Show("Выберите раздел для удаления!", "Удаление раздела", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                });
            }
        }

        private RelayCommand editSection;

        public RelayCommand EditSectionCommand
        {
            get
            {
                return editSection ??= new RelayCommand(async obj =>
                {
                    if (SelectSection != null)
                    {
                        editSectionDialog = new EditSectionDialog(SectionName);
                        if (editSectionDialog.ShowDialog() == true)
                        {
                            sectionNameEdit = editSectionDialog.GetSectionName;
                            await Task.Run(EditSection);
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

        private async Task GetSection()
        {
            await using (var db = new MSGCoreContext())
            {
                Sections = await db.Section.ToListAsync();
            }
        }

        private async Task AddSection()
        {
            await using (MSGCoreContext db = new MSGCoreContext())
            {
                var add = new Section
                {
                    SectionName = sectionNameAdd
                };
                await db.Section.AddAsync(add);
                await db.SaveChangesAsync();
                await GetSection();
            }
        }

        private async Task DelSection()
        {
            await using (var db = new MSGCoreContext())
            {
                var del = new Section
                {
                    SectionId = SectionId
                };
                db.Section.Attach(del);
                db.Section.Remove(del);
                await db.SaveChangesAsync();
                await GetSection();
            }

            SelectSection = null;
        }

        private async Task EditSection()
        {
            await using (var db = new MSGCoreContext())
            {
                var editSection = await db.Section.Where(p => p.SectionId == SectionId).FirstOrDefaultAsync();
                editSection.SectionName = sectionNameEdit;
                await db.SaveChangesAsync();
                await GetSection();
            }

            SelectSection = null;
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