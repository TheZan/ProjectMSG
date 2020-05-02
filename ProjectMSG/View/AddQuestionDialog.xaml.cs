using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectMSG.View
{
    /// <summary>
    /// Логика взаимодействия для AddQuestionDialog.xaml
    /// </summary>
    public partial class AddQuestionDialog : Window
    {
        private List<AnswerListClass> answerListCorrect = new List<AnswerListClass>();

        public AddQuestionDialog()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string GetQuestionText
        {
            get { return QuestionText.Text; }
        }

        public List<AnswerListClass> GetAnswer
        {
            get { return answerListCorrect; }
        }

        private void AddAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            answerListCorrect.Add(new AnswerListClass()
            {
                AnswerText = Answer.Text
            });
            AnswerList.ItemsSource = null;
            AnswerList.ItemsSource = answerListCorrect;
        }

        public class AnswerListClass
        {
            public string AnswerText { get; set; }
            public bool AnswerCorrect { get; set; }
        }
    }
}
