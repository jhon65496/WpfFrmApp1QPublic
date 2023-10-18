using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfFrmApp1.ViewModels;

namespace WpfFrmApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }
    }
}
