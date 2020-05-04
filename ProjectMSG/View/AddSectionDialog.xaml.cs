using System.Windows;

namespace ProjectMSG.View
{
    /// <summary>
    ///     Логика взаимодействия для AddSectionDialog.xaml
    /// </summary>
    public partial class AddSectionDialog : Window
    {
        public AddSectionDialog()
        {
            InitializeComponent();
        }

        public string GetSectionName => sectionName.Text;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}