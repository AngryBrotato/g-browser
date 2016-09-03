using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; set; }
        private static Page _returnPage;
        private static Page _mainPage;
        private double _aspectRatio = 1.33;

        static MainWindow()
        {
            Instance = new MainWindow();
            Page mainPage = new MainPage();
            SetPage(mainPage);
        }

        private MainWindow()
        {
            InitializeComponent();
        }

        private static void SetPage(Page pageToShow)
        {
            _returnPage = Instance.Content as Page;
            Instance.Content = pageToShow;
        }

        public static void Return()
        {
            var tempContent = Instance.Content as Page;
            Instance.Content = _returnPage;
            _returnPage = _mainPage;
        }

        public static void OpenEditor(FileData file)
        {
            SetPage(new EditorPage(file));
        }
    }
}
