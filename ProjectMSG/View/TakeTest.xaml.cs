using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectMSG.Model;

namespace ProjectMSG.View
{
    /// <summary>
    ///     Логика взаимодействия для TakeTest.xaml
    /// </summary>
    public partial class TakeTest : Window
    {
        private readonly MSGCoreContext db = new MSGCoreContext();
        private int numberQuestion, i;
        private readonly int testId;
        private readonly int userId;
        private readonly List<Question> questions;

        public TakeTest(int testid, int userId)
        {
            InitializeComponent();

            testId = testid;
            this.userId = userId;

            questions = db.Question.Where(p => p.TestId == testId).ToList();

            GetAnswer(i);
        }

        private void GetAnswer(int questionNumber)
        {
            numberQuestion = questions[questionNumber].QuestionId;
            GroupTitle.Text = questions.Where(p => p.QuestionId == numberQuestion).Select(p => p.QuestionText)
                .FirstOrDefault();
            AnswerBox.ItemsSource = db.Answer.Where(p => p.QuestionId == numberQuestion).ToList();
            i++;
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            var lbi = sender as ListBoxItem;
            if (lbi != null)
            {
                var fam = lbi.DataContext as Answer;
                if (fam != null)
                {
                    var answerId = fam.AnswerId;
                    var correctAnswerId = db.CorrectAnswer.Where(p => p.QuestionId == numberQuestion)
                        .Select(p => p.AnswerId).FirstOrDefault();

                    if (i <= db.Question.Where(p => p.TestId == testId).Count())
                    {
                        if (answerId == correctAnswerId)
                            try
                            {
                                GetAnswer(i);
                                MessageError.Visibility = Visibility.Collapsed;
                            }
                            catch
                            {
                                GetResult();
                            }
                        else
                            MessageError.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        GetResult();
                    }
                }
            }
        }

        private void GetResult()
        {
            var resultTest = db.Result.Where(p => p.UserId == userId && p.TestId == testId).Any();
            if (resultTest)
            {
                DialogEnd.IsOpen = true;
            }
            else
            {
                DialogEnd.IsOpen = true;
                var finishTest = new Result
                {
                    TestId = testId,
                    UserId = userId
                };
                db.Result.Add(finishTest);
                db.SaveChanges();
            }
        }

        private void GoFinish_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}