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
using static ProjectMSG.View.AddQuestionDialog;

namespace ProjectMSG.ViewModel
{
    public class AdminTestViewModel : BindableBase, INotifyPropertyChanged
    {
        public AdminTestViewModel(PageService pageService, MessageBus messageBus)
        {
            _pageService = pageService;
            _messageBus = messageBus;

            _messageBus.Receive<SectionToArticle>(this, async message =>
            {
                getArticleId = message.Id;
                GetArticleName = $"Тест: {message.Name}";
                await Task.Run(GetQuestion);
            });
        }

        #region Properties

        private readonly PageService _pageService;
        private readonly MessageBus _messageBus;

        private AddQuestionDialog addQuestionDialog;
        private EditQuestionDialog editQuestionDialog;

        private int getArticleId;
        private string getArticleName;

        public string GetArticleName
        {
            get => getArticleName;
            set
            {
                getArticleName = value;
                NotifyPropertyChanged();
            }
        }

        private Question selectQuestion = new Question();

        public Question SelectQuestion
        {
            get => selectQuestion;
            set
            {
                selectQuestion = value;
                NotifyPropertyChanged();
            }
        }

        public int QuestionId
        {
            get => SelectQuestion.QuestionId;
            set
            {
                SelectQuestion.QuestionId = value;
                NotifyPropertyChanged();
            }
        }

        public string QuestionText
        {
            get => SelectQuestion.QuestionText;
            set
            {
                SelectQuestion.QuestionText = value;
                NotifyPropertyChanged();
            }
        }

        private List<Question> questions;

        public List<Question> Questions
        {
            get => questions;
            set
            {
                questions = value;
                NotifyPropertyChanged();
            }
        }

        private string questionTextGet;
        private List<AnswerListClass> questionAnswer;
        private int testId;
        private string questionText;
        private List<Answer> listAnswers;
        private List<CorrectAnswer> correctAnswers;

        #endregion

        #region Command

        private RelayCommand back;

        public RelayCommand Back
        {
            get { return back ??= new RelayCommand(obj => { _pageService.ChangePage(new AdminArticle()); }); }
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

        private RelayCommand delQuestion;

        public RelayCommand DelQuestionCommand
        {
            get
            {
                return delQuestion ??= new RelayCommand(async obj =>
                {
                    if (SelectQuestion != null)
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить вопрос?", "Удаление вопроса",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                            return;
                        await Task.Run(DelQuestion);
                    }
                    else
                    {
                        MessageBox.Show("Выберите вопрос для удаления!", "Удаление вопроса", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                });
            }
        }

        private RelayCommand editQuestion;

        public RelayCommand EditQuestionCommand
        {
            get
            {
                return editQuestion ??= new RelayCommand(async obj =>
                {
                    if (SelectQuestion != null)
                    {
                        correctAnswers = new List<CorrectAnswer>();
                        listAnswers = new List<Answer>();
                        await Task.Run(GetAnswerAndCorrect);
                        editQuestionDialog = new EditQuestionDialog(listAnswers, correctAnswers, QuestionText);
                        if (editQuestionDialog.ShowDialog() == true)
                        {
                            questionAnswer = new List<AnswerListClass>();
                            questionAnswer = editQuestionDialog.GetAnswer;
                            questionTextGet = editQuestionDialog.GetQuestionText;
                            await Task.Run(EditQuestion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите вопрос для редактирования!", "Редактирование вопроса",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                });
            }
        }

        #endregion

        #region Methods

        private async Task GetQuestion()
        {
            await using (var db = new MSGCoreContext())
            {
                testId = await db.Test.Where(p => p.ArticleId == getArticleId).Select(p => p.TestId)
                    .FirstOrDefaultAsync();
                Questions = await db.Question.Where(p => p.TestId == testId).ToListAsync();
            }
        }

        private async Task AddQuestion()
        {
            await using (var db = new MSGCoreContext())
            {
                var add = new Question
                {
                    QuestionText = questionTextGet,
                    TestId = testId
                };
                await db.Question.AddAsync(add);
                await db.SaveChangesAsync();

                var lastQuestion = db.Question.ToList().Last();
                var lastId = lastQuestion.QuestionId;
                foreach (var t in questionAnswer)
                {
                    var addAnswer = new Answer
                    {
                        AnswerText = t.AnswerText,
                        QuestionId = lastId
                    };
                    db.Answer.Add(addAnswer);
                }

                await db.SaveChangesAsync();

                var correctText = "";
                foreach (var correct in questionAnswer)
                    if (correct.AnswerCorrect)
                        correctText = correct.AnswerText;

                var correctId = await db.Answer.Where(p => p.AnswerText == correctText).Select(p => p.AnswerId)
                    .FirstOrDefaultAsync();

                var addCorrectAnswer = new CorrectAnswer
                {
                    AnswerId = correctId,
                    QuestionId = lastId
                };
                await db.CorrectAnswer.AddAsync(addCorrectAnswer);
                await db.SaveChangesAsync();

                await GetQuestion();
            }
        }

        private async Task DelQuestion()
        {
            await using (var db = new MSGCoreContext())
            {
                var del = new Question
                {
                    QuestionId = QuestionId
                };
                db.Question.Attach(del);
                db.Question.Remove(del);
                await db.SaveChangesAsync();
                await GetQuestion();
            }

            SelectQuestion = null;
        }

        private async Task EditQuestion()
        {
            await using (var db = new MSGCoreContext())
            {
                var editQuestion = await db.Question.Where(p => p.QuestionId == QuestionId).FirstOrDefaultAsync();
                editQuestion.QuestionText = questionTextGet;
                await db.SaveChangesAsync();

                db.CorrectAnswer.RemoveRange(correctAnswers);
                await db.SaveChangesAsync();

                db.Answer.RemoveRange(listAnswers);
                await db.SaveChangesAsync();

                var lastQuestion = db.Question.ToList().Last();
                var lastId = lastQuestion.QuestionId;
                foreach (var t in questionAnswer)
                {
                    var addAnswer = new Answer
                    {
                        AnswerText = t.AnswerText,
                        QuestionId = lastId
                    };
                    db.Answer.Add(addAnswer);
                }

                await db.SaveChangesAsync();

                var correctText = "";
                foreach (var correct in questionAnswer)
                    if (correct.AnswerCorrect)
                        correctText = correct.AnswerText;

                var correctId = await db.Answer.Where(p => p.AnswerText == correctText).Select(p => p.AnswerId)
                    .FirstOrDefaultAsync();

                var addCorrectAnswer = new CorrectAnswer
                {
                    AnswerId = correctId,
                    QuestionId = lastId
                };
                await db.CorrectAnswer.AddAsync(addCorrectAnswer);
                await db.SaveChangesAsync();

                await GetQuestion();
            }

            SelectQuestion = null;
        }

        private async Task GetAnswerAndCorrect()
        {
            await using (var db = new MSGCoreContext())
            {
                listAnswers = await db.Answer.Where(p => p.QuestionId == QuestionId).ToListAsync();
                correctAnswers = await db.CorrectAnswer.Where(p => p.QuestionId == QuestionId).ToListAsync();
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