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
using static ProjectMSG.View.AddQuestionDialog;

namespace ProjectMSG.ViewModel
{
    public class AdminTestViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminTestViewModel(PageService pageService, EventBus eventBus, MessageBus messageBus)
        {
            _pageService = pageService;
            _eventBus = eventBus;
            _messageBus = messageBus;

            _messageBus.Receive<SectionToArticle>(this, async message =>
            {
                getArticleId = message.Id;
                GetArticleName = $"Тест: {message.Name}";
                await Task.Run(() => GetQuestion());
            });
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly EventBus _eventBus;
        private readonly MessageBus _messageBus;

        private AddQuestionDialog addQuestionDialog;

        private int getArticleId;
        private string getArticleName;
        public string GetArticleName
        {
            get
            {
                return getArticleName;
            }
            set
            {
                getArticleName = value;
                NotifyPropertyChanged("GetArticleName");
            }
        }

        private Question selectQuestion = new Question();
        public Question SelectQuestion
        {
            get
            {
                return selectQuestion;
            }
            set
            {
                selectQuestion = value;
                NotifyPropertyChanged("SelectQuestion");
            }
        }

        public int QuestionId
        {
            get
            {
                return SelectQuestion.QuestionId;
            }
            set
            {
                SelectQuestion.QuestionId = value;
                NotifyPropertyChanged("QuestionId");
            }
        }

        public string QuestionText
        {
            get
            {
                return SelectQuestion.QuestionText;
            }
            set
            {
                SelectQuestion.QuestionText = value;
                NotifyPropertyChanged("QuestionText");
            }
        }

        private List<Question> questions;
        public List<Question> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
                NotifyPropertyChanged("Questions");
            }
        }

        private string questionTextGet;
        private List<AnswerListClass> questionAnswer;
        private int testId;

        #endregion

        #region Command

        private RelayCommand back;

        public RelayCommand Back
        {
            get
            {
                return back ??= new RelayCommand(obj =>
                {
                    _pageService.ChangePage(new AdminArticle());
                });
            }
        }

        private RelayCommand addQuestion;

        public RelayCommand AddQuestionCommand
        {
            get
            {
                return addQuestion ??= new RelayCommand(async obj =>
                {
                    addQuestionDialog = new AddQuestionDialog();
                    if (addQuestionDialog.ShowDialog() == true)
                    {
                        questionAnswer = new List<AnswerListClass>();
                        questionAnswer = addQuestionDialog.GetAnswer;
                        questionTextGet = addQuestionDialog.GetQuestionText;
                        await Task.Run(AddQuestion);
                    }
                });
            }
        }

        //private RelayCommand delSection;

        //public RelayCommand DelSectionCommand
        //{
        //    get
        //    {
        //        return delSection ??
        //          (delSection = new RelayCommand(async obj =>
        //          {
        //              if (SelectSection != null)
        //              {
        //                  if (MessageBox.Show("Вы действительно хотите удалить раздел?", "Удаление раздела", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
        //                  {
        //                      return;
        //                  }
        //                  else
        //                  {
        //                      await Task.Run(() => DelSection());
        //                  }
        //              }
        //              else
        //              {
        //                  MessageBox.Show("Выберите раздел для удаления!", "Удаление раздела", MessageBoxButton.OK, MessageBoxImage.Warning);
        //              }
        //          }));
        //    }
        //}

        //private RelayCommand editSection;

        //public RelayCommand EditSectionCommand
        //{
        //    get
        //    {
        //        return editSection ??
        //          (editSection = new RelayCommand(async obj =>
        //          {
        //              if (SelectSection != null)
        //              {
        //                  editSectionDialog = new EditSectionDialog(SectionName);
        //                  if (editSectionDialog.ShowDialog() == true)
        //                  {
        //                      sectionNameEdit = editSectionDialog.GetSectionName;
        //                      await Task.Run(() => EditSection());
        //                  }
        //              }
        //              else
        //              {
        //                  MessageBox.Show("Выберите раздел для редактирования!", "Редактирование раздела", MessageBoxButton.OK, MessageBoxImage.Warning);
        //              }
        //          }));
        //    }
        //}

        #endregion

        #region Methods

        private async Task GetQuestion()
        {
            using (MSGCoreContext db = new MSGCoreContext())
            {
                testId = await db.Test.Where(p => p.ArticleId == getArticleId).Select(p => p.TestId).FirstOrDefaultAsync();
                Questions = await db.Question.Where(p => p.TestId == testId).ToListAsync();
            }
        }

        private async Task AddQuestion()
        {

            await using (MSGCoreContext db = new MSGCoreContext())
            {
                Question add = new Question
                {
                    QuestionText = questionTextGet,
                    TestId = testId
                };
                await db.Question.AddAsync(add);
                await db.SaveChangesAsync();

                var lastQuestion = db.Question.ToList().Last();
                int lastId = lastQuestion.QuestionId;
                foreach (var t in questionAnswer)
                {
                    Answer addAnswer = new Answer
                    {
                        AnswerText = t.AnswerText,
                        QuestionId = lastId
                    };
                    db.Answer.Add(addAnswer);
                }
                await db.SaveChangesAsync();

                string correctText = "";
                foreach (var correct in questionAnswer)
                {
                    if (correct.AnswerCorrect == true)
                    {
                        correctText = correct.AnswerText;
                    }
                }

                var correctId = await db.Answer.Where(p => p.AnswerText == correctText).Select(p => p.AnswerId)
                    .FirstOrDefaultAsync();

                CorrectAnswer addCorrectAnswer = new CorrectAnswer
                {
                    AnswerId = correctId,
                    QuestionId = lastId
                };
                await db.CorrectAnswer.AddAsync(addCorrectAnswer);
                await db.SaveChangesAsync();

                await GetQuestion();
            }
        }

        //private async Task DelSection()
        //{
        //    using (MSGCoreContext db = new MSGCoreContext())
        //    {
        //        Section del = new Section
        //        {
        //            SectionId = SectionId
        //        };
        //        db.Section.Attach(del);
        //        db.Section.Remove(del);
        //        await db.SaveChangesAsync();
        //        await GetSection();
        //    }
        //    SelectSection = null;
        //}

        //private async Task EditSection()
        //{

        //    using (MSGCoreContext db = new MSGCoreContext())
        //    {
        //        var editSection = await db.Section.Where(p => p.SectionId == SectionId).FirstOrDefaultAsync();
        //        editSection.SectionName = sectionNameEdit;
        //        await db.SaveChangesAsync();
        //        await GetSection();
        //    }
        //    SelectSection = null;
        //}

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
