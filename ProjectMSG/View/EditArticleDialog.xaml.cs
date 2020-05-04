﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Win32;
using ProjectMSG.Model;

namespace ProjectMSG.View
{
    /// <summary>
    ///     Логика взаимодействия для EditArticleDialog.xaml
    /// </summary>
    public partial class EditArticleDialog : Window
    {
        private int idPhotoList;
        private int numberPhoto;

        public EditArticleDialog(string ArticleName, string ArticleText, List<Photo> ArticleImage)
        {
            InitializeComponent();
            articleName.Text = ArticleName;
            articleText.AppendText(ArticleText);
            this.ArticleImage = ArticleImage;
            articleImageAdd.ItemsSource = this.ArticleImage;
        }

        public string ArticleName => articleName.Text;

        public string ArticleText =>
            new TextRange(articleText.Document.ContentStart, articleText.Document.ContentEnd).Text;

        public List<Photo> ArticleImage { get; } = new List<Photo>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (articleName.Text != "" && ArticleText != null && articleImageAdd.ItemsSource != null)
                DialogResult = true;
            else
                MessageBox.Show("Заполните все поля!", "Информаци");
        }


        private void addArticleImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                var selectedFileName = dlg.FileName;
                var imageArray = ImageConvert.ConvertImageToByteArray(selectedFileName);
                ArticleImage.Add(new Photo {ArticlePhoto = imageArray, ArticlePhotoId = numberPhoto++});
                articleImageAdd.ItemsSource = null;
                articleImageAdd.ItemsSource = ArticleImage;
            }
        }

        private void ListViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var lbi = sender as ListViewItem;
            if (lbi != null)
            {
                var fam = lbi.DataContext as Photo;
                if (fam != null)
                {
                    var photoId = fam.ArticlePhotoId;
                    idPhotoList = photoId;
                }
            }
        }

        private void deleteImageFromArticle_Click(object sender, RoutedEventArgs e)
        {
            ArticleImage.Remove(ArticleImage.Where(p => p.ArticlePhotoId == idPhotoList).FirstOrDefault());
            articleImageAdd.ItemsSource = null;
            articleImageAdd.ItemsSource = ArticleImage;
        }
    }
}