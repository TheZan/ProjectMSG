﻿using System;
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

namespace ProjectMSG.View
{
    /// <summary>
    /// Логика взаимодействия для AddQuestionDialog.xaml
    /// </summary>
    public partial class AddQuestionDialog : Window
    {
        private List<AnswerListClass> answerListCorrect = new List<AnswerListClass>();
        private int answerListId = 0;

        public AddQuestionDialog()
        {
            InitializeComponent();
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

        public List<AnswerListClass> GetAnswer
        {
            get { return answerListCorrect; }
        }

        private void AddAnswer_OnClick(object sender, RoutedEventArgs e)
        {
            if (Answer.Text != "")
            {
                answerListCorrect.Add(new AnswerListClass()
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
                AnswerListClass fam = lbi.DataContext as AnswerListClass;
                if (fam != null)
                {
                    int answerId = fam.AnswerId;
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
