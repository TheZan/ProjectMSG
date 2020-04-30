using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Event;
using ProjectMSG.Message;
using ProjectMSG.Model;
using ProjectMSG.Service;
using ProjectMSG.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectMSG.ViewModel
{
    public class AdminSectionViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminSectionViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;

            Task.Run(() => GetSection());
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        AddSectionDialog addSectionDialog;
        EditSectionDialog editSectionDialog;

        private string sectionNameAdd;
        private string sectionNameEdit;

        private Section selectSection = new Section();
        public Section SelectSection
        {
            get
            {
                return selectSection;
            }
            set
            {
                selectSection = value;
                NotifyPropertyChanged("SelectSection");
            }
        }

        public int SectionId
        {
            get
            {
                return SelectSection.SectionId;
            }
            set
            {
                SelectSection.SectionId = value;
                NotifyPropertyChanged("SectionId");
            }
        }

        public string SectionName
        {
            get
            {
                return SelectSection.SectionName;
            }
            set
            {
                SelectSection.SectionName = value;
                NotifyPropertyChanged("SectionName");
            }
        }

        private List<Section> sections;
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

        #endregion

        #region Command

        private RelayCommand back;

        public RelayCommand Back
        {
            get
            {
                return back ??
                  (back = new RelayCommand(obj =>
                  {
                      _pageService.ChangePage(new Admin());
                  }));
            }
        }

        private RelayCommand addSection;

        public RelayCommand AddSectionCommand
        {
            get
            {
                return addSection ??
                  (addSection = new RelayCommand(async obj =>
                  {
                      addSectionDialog = new AddSectionDialog();
                      if (addSectionDialog.ShowDialog() == true)
                      {
                          sectionNameAdd = addSectionDialog.GetSectionName;
                          await Task.Run(() => AddSection());
                      }
                  }));
            }
        }

        private RelayCommand delSection;

        public RelayCommand DelSectionCommand
        {
            get
            {
                return delSection ??
                  (delSection = new RelayCommand(async obj =>
                  {
                      if (SelectSection != null)
                      {
                          if (MessageBox.Show("Вы действительно хотите удалить раздел?", "Удаление раздела", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                          {
                              return;
                          }
                          else
                          {
                              await Task.Run(() => DelSection());
                          }
                      }
                      else
                      {
                          MessageBox.Show("Выберите раздел для удаления!", "Удаление раздела", MessageBoxButton.OK, MessageBoxImage.Warning);
                      }
                  }));
            }
        }

        private RelayCommand editSection;

        public RelayCommand EditSectionCommand
        {
            get
            {
                return editSection ??
                  (editSection = new RelayCommand(async obj =>
                  {
                      if(SelectSection != null)
                      {
                          editSectionDialog = new EditSectionDialog(SectionName);
                          if (editSectionDialog.ShowDialog() == true)
                          {
                              sectionNameEdit = editSectionDialog.GetSectionName;
                              await Task.Run(() => EditSection());
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

        private async Task GetSection()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                Sections = await db.Section.ToListAsync();
            }
        }

        private async Task AddSection()
        {

            using (MSGCoreContext db = new MSGCoreContext())
            {
                Section add = new Section
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
            using (MSGCoreContext db = new MSGCoreContext())
            {
                Section del = new Section
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

            using (MSGCoreContext db = new MSGCoreContext())
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
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
