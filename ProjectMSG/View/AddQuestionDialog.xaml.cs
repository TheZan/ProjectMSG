using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectMSG.View
{
    /// <summary>
    ///     Логика взаимодействия для AddQuestionDialog.xaml
    /// </summary>
    public partial class AddQuestionDialog : Window
    {
        private int answerListId;

        public AddQuestionDialog()
        {
            InitializeComponent();
        }

        public string GetQuestionText => QuestionText.Text;

        public List<AnswerListClass> GetAnswer { get; } = new List<AnswerListClass>();

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
                GetAnswer.Add(new AnswerListClass
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
                var fam = lbi.DataContext as AnswerListClass;
                if (fam != null)
                {
                    var answerId = fam.AnswerId;
                    answerListId = answerId;
                }
            }
        }

        public class AnswerListClass
        {
            public int AnswerId { get; set; }
            public string AnswerText { get; set; }
            public bool AnswerCorrect { get; set; }
        }
    }
}