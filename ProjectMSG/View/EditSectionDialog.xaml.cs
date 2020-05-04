using System.Windows;

namespace ProjectMSG.View
{
    /// <summary>
    ///     Логика взаимодействия для EditSectionDialog.xaml
    /// </summary>
    public partial class EditSectionDialog : Window
    {
        public EditSectionDialog(string setSectionName)
        {
            InitializeComponent();
            GetSectionName = setSectionName;
        }

        public string GetSectionName
        {
            get => sectionName.Text;
            set => sectionName.Text = value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}