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
        // Instanced version of our filescanner. Recursively gets all .exe's from a given directory and stores their relative information in memory.
        private FileScanner scanner = new FileScanner();
        private DataExporter exporter = new DataExporter();

        public MainWindow()
        {
            InitializeComponent();
            string path = @"C:/Users/daniwood/";
            var files = scanner.selectfolders(path, "exe");
            myDataGrid.ItemsSource = files;
            save_button.PreviewMouseLeftButtonUp += new MouseButtonEventHandler((object sender, MouseButtonEventArgs e) => { exporter.export(files); });
        }
    }
}
