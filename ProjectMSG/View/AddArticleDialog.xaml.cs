using Microsoft.Win32;
using ProjectMSG.Model;
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

namespace ProjectMSG.View
{
    /// <summary>
    /// Логика взаимодействия для AddArticleDialog.xaml
    /// </summary>
    public partial class AddArticleDialog : Window
    {
        List<Photo> images = new List<Photo>();

        int idPhotoList;
        int numberPhoto = 0;

        public AddArticleDialog()
        {
            InitializeComponent();
        }

        public string ArticleName
        {
            get { return articleName.Text; }
        }

        public string ArticleText
        {
            get { return new TextRange(articleText.Document.ContentStart, articleText.Document.ContentEnd).Text; }
        }

        public List<Photo> ArticleImage
        {
            get { return images; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (articleName.Text != "" && ArticleText != null && articleImageAdd.ItemsSource != null)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBox.Show("Заполните все поля!","Информация");
            }
        }


        private void addArticleImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "";
            dlg.Filter = "Image files (*.jpg,*.png,*.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                var imageArray = ImageConvert.ConvertImageToByteArray(selectedFileName);
                images.Add(new Photo { ArticlePhoto = imageArray, ArticlePhotoId = numberPhoto++ });
                articleImageAdd.ItemsSource = null;
                articleImageAdd.ItemsSource = images;
            }
        }

        private void ListViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lbi = sender as ListViewItem;
            if (lbi != null)
            {
                Photo fam = lbi.DataContext as Photo;
                if (fam != null)
                {
                    int photoId = fam.ArticlePhotoId;
                    idPhotoList = photoId;
                }
            }
        }

        private void deleteImageFromArticle_Click(object sender, RoutedEventArgs e)
        {
            images.Remove(images.FirstOrDefault(p => p.ArticlePhotoId == idPhotoList));
            articleImageAdd.ItemsSource = null;
            articleImageAdd.ItemsSource = images;
        }
    }
}
