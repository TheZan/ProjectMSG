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
    /// Логика взаимодействия для EditSectionDialog.xaml
    /// </summary>
    public partial class EditSectionDialog : Window
    {
        public EditSectionDialog(string setSectionName)
        {
            InitializeComponent();
            GetSectionName = setSectionName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string GetSectionName
        {
            get { return sectionName.Text; }
            set { sectionName.Text = value; }
        }
    }
}
