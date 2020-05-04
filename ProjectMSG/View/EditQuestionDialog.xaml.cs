using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjectMSG.Model;

namespace ProjectMSG.View
{
    /// <summary>
    ///     Логика взаимодействия для EditQuestionDialog.xaml
    /// </summary>
    public partial class EditQuestionDialog : Window
    {
        private int answerListId;
        private readonly List<Answer> answers = new List<Answer>();
        private List<CorrectAnswer> correctAnswers = new List<CorrectAnswer>();

        public EditQuestionDialog(List<Answer> answers, List<CorrectAnswer> correctAnswers, string answerTxt)
        {
            InitializeComponent();
            this.answers = answers;
            this.correctAnswers = correctAnswers;
            QuestionText.Text = answerTxt;

            foreach (var answer in this.answers)
                if (answer.AnswerId == correctAnswers.Select(p => p.AnswerId).FirstOrDefault())
                    GetAnswer.Add(new AddQuestionDialog.AnswerListClass
                    {
                        AnswerText = answer.AnswerText,
                        AnswerId = answerListId++,
                        AnswerCorrect = true
                    });
                else
                    GetAnswer.Add(new AddQuestionDialog.AnswerListClass
                    {
                        AnswerText = answer.AnswerText,
                        AnswerId = answerListId++
                    });

            AnswerList.ItemsSource = GetAnswer;
        }

        public string GetQuestionText => QuestionText.Text;

        public List<AddQuestionDialog.AnswerListClass> GetAnswer { get; } =
            new List<AddQuestionDialog.AnswerListClass>();

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var correct = false;

            foreach (var isChecked in GetAnswer)
                if (isChecked.AnswerCorrect)
                    correct = true;

            if (AnswerList.ItemsSource != null && QuestionText.Text != "" && correct)
                DialogResult = true;
            else
                MessageBox.Show("Заполните все поля!", "Информация");
        }

        private void AddAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            if (Answer.Text != "")
            {
                GetAnswer.Add(new AddQuestionDialog.AnswerListClass
                {
                    AnswerText = Answer.Text,
                    AnswerId = answerListId++
                });
                AnswerList.ItemsSource = null;
                AnswerList.ItemsSource = GetAnswer;
            }

            Answer.Clear();
        }

        private void DelAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            GetAnswer.Remove(GetAnswer.FirstOrDefault(p => p.AnswerId == answerListId));
            AnswerList.ItemsSource = null;
            AnswerList.ItemsSource = GetAnswer;
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            var lbi = sender as ListBoxItem;
            if (lbi != null)
            {
                var fam = lbi.DataContext as AddQuestionDialog.AnswerListClass;
                if (fam != null)
                {
                    var answerId = fam.AnswerId;
                    answerListId = answerId;
                }
            }
        }
    }
}