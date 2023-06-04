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
using REghZyFramework.Themes;

namespace Custom_Compendium_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public App CurrentApplication { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((MenuItem)sender).Uid))
            {
                // Light
                case 0: ThemesController.SetTheme(ThemesController.ThemeTypes.Light); break;
                // Colorful Light
                case 1: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulLight); break;
                // Dark
                case 2: ThemesController.SetTheme(ThemesController.ThemeTypes.Dark); break;
                // Colorful Dark
                case 3: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulDark); break;
            }

            e.Handled = true;
        }
    }
}
