using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Toolbox;

namespace g_browser
{
    /// <summary>
    /// Interaction logic for EditorPage.xaml
    /// </summary>
    public partial class EditorPage : Page
    {
        public Page ReturnPage;

        public EditorPage(FileData item)
        {
            if (item == null) return;

            InitializeComponent();
            SetupButtonEvents();
            this.Title = "Editing " + item.FileName;
            title_input.FontSize = title_input.Height/2;
            title_input.Text = item.FileName;
            last_played_date.Content = item.LastUsed.ToShortDateString();
            installed_date.Content = item.CreationDate.ToShortDateString();
            description_input.Text = item.FileName_full;
        }

        private void SetupButtonEvents()
        {
            return_button.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(
                (object sender, MouseButtonEventArgs e) => { MainWindow.Return(); });
        }
    }
}
