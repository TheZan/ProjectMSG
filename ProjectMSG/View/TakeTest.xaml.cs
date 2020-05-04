using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using ProjectMSG.Message;
using ProjectMSG.Model;
using ProjectMSG.ViewModel;

namespace ProjectMSG.View
{
    /// <summary>
    /// Логика взаимодействия для TakeTest.xaml
    /// </summary>
    public partial class TakeTest : Window
    {
        private MSGCoreContext db = new MSGCoreContext();
        List<Question> questions;
        private int numberQuestion, i = 0, testId, userId;

        public TakeTest(int testid, int userId)
        {
            InitializeComponent();

            this.testId = testid;
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
            ListBoxItem lbi = sender as ListBoxItem;
            if (lbi != null)
            {
                Answer fam = lbi.DataContext as Answer;
                if (fam != null)
                {
                    int answerId = fam.AnswerId;
                    int correctAnswerId = db.CorrectAnswer.Where(p => p.QuestionId == numberQuestion).Select(p => p.AnswerId).FirstOrDefault();

                    if (i <= db.Question.Where(p => p.TestId == testId).Count())
                    {
                        if (answerId == correctAnswerId)
                        {
                            try
                            {
                                GetAnswer(i);
                                MessageError.Visibility = Visibility.Collapsed;
                            }
                            catch
                            {
                                GetResult();
                            }
                        }
                        else
                        {
                            MessageError.Visibility = Visibility.Visible;
                        }
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
                Result finishTest = new Result
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
            this.DialogResult = true;
        }
    }
}
