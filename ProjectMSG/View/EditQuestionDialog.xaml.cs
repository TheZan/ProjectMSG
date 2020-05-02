using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectMSG.Model;

namespace ProjectMSG.View
{
    /// <summary>
    /// Логика взаимодействия для EditQuestionDialog.xaml
    /// </summary>
    public partial class EditQuestionDialog : Window
    {
        private List<AddQuestionDialog.AnswerListClass> answerListCorrect = new List<AddQuestionDialog.AnswerListClass>();
        private int answerListId = 0;
        private List<Answer> answers = new List<Answer>();
        private List<CorrectAnswer> correctAnswers = new List<CorrectAnswer>();

        public EditQuestionDialog(List<Answer> answers, List<CorrectAnswer> correctAnswers, string answerTxt)
        {
            InitializeComponent();
            this.answers = answers;
            this.correctAnswers = correctAnswers;
            QuestionText.Text = answerTxt;

            foreach (var answer in this.answers)
            {
                if (answer.AnswerId == correctAnswers.Select(p => p.AnswerId).FirstOrDefault())
                {
                    answerListCorrect.Add(new AddQuestionDialog.AnswerListClass()
                    {
                        AnswerText = answer.AnswerText,
                        AnswerId = answerListId++,
                        AnswerCorrect = true
                    });
                }
                else
                {
                    answerListCorrect.Add(new AddQuestionDialog.AnswerListClass()
                    {
                        AnswerText = answer.AnswerText,
                        AnswerId = answerListId++
                    });
                }
            }

            AnswerList.ItemsSource = answerListCorrect;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            bool correct = false;

            foreach (var isChecked in answerListCorrect)
            {
                if (isChecked.AnswerCorrect == true)
                {
                    correct = true;
                }
            }

            if (AnswerList.ItemsSource != null && QuestionText.Text != "" && correct == true)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Информация");
            }
        }

        public string GetQuestionText
        {
            get { return QuestionText.Text; }
        }

        public List<AddQuestionDialog.AnswerListClass> GetAnswer
        {
            get { return answerListCorrect; }
        }

        private void AddAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            if (Answer.Text != "")
            {
                answerListCorrect.Add(new AddQuestionDialog.AnswerListClass()
                {
                    AnswerText = Answer.Text,
                    AnswerId = answerListId++
                });
                AnswerList.ItemsSource = null;
                AnswerList.ItemsSource = answerListCorrect;
            }
            Answer.Clear();
        }

        private void DelAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            answerListCorrect.Remove(answerListCorrect.FirstOrDefault(p => p.AnswerId == answerListId));
            AnswerList.ItemsSource = null;
            AnswerList.ItemsSource = answerListCorrect;
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem lbi = sender as ListBoxItem;
            if (lbi != null)
            {
                AddQuestionDialog.AnswerListClass fam = lbi.DataContext as AddQuestionDialog.AnswerListClass;
                if (fam != null)
                {
                    int answerId = fam.AnswerId;
                    answerListId = answerId;
                }
            }
        }
    }
}
