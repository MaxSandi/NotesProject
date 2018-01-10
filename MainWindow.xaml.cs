using System.Windows;
using NotesProject.ViewModel;
using System;
using System.Windows.Media.Imaging;

namespace NotesProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            Uri iconUri = new Uri("pack://application:,,,/Resources/main.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}