using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private FileScanner scanner = new FileScanner();
        private DataExporter exporter = new DataExporter();

        public MainPage()
        {
            InitializeComponent();
            SetupStyles();
            string path = @"C:\Program Files (x86)\Steam";
            var files = scanner.SelectFiles(path, "exe");
            myDataGrid.ItemsSource = files;
            Style rowStyle = new Style(typeof(DataGridRow));
            rowStyle.Setters.Add(new EventSetter(DataGridRow.MouseDoubleClickEvent,
                                     new MouseButtonEventHandler(Row_DoubleClick)));
            myDataGrid.RowStyle = rowStyle;
            save_button.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(
                (object sender, MouseButtonEventArgs e) => { exporter.export(files); });

            edit_button.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(
                (object sender, MouseButtonEventArgs e) => { this.Content = new EditorPage((FileData)myDataGrid.SelectedItem); });
        }

        public void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            var file = ((DataGridRow) sender).Item as FileData;
            PopulateFileData(file);
            //label.Content = file.Details.ProductName + " - " + file.Details.FileDescription;
            //scanner.ReadInfo(file).ForEach(s => label.Content += s);
            //MainWindow.OpenEditor(file);
        }

        public void PopulateFileData(FileData file)
        {
            TitleLabel.Content = file.FileName;
            PathLabel.Content = file.FileNameFull;
            LastPlayedLabel.Content = file.LastUsed;
            NameSuggestions.ItemsSource = file.SuggestedNames;
        }

        public void SetupStyles()
        {
            TitleLabel.FontSize = TitleLabel.Height/2;
        }
    }
}
