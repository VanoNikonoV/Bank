using Bank.View;
using Bank.ViewModels;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Windows.Foundation.Collections;
using Windows.System;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //string path = Directory.GetCurrentDirectory() + @"\Data\ClientsBank.json";

            string path = null;

            MainWindow window = new MainWindow();

            var viewModel = new MainWindowViewModel(path);

            window.DataContext = viewModel;

            window.Show();

        }

    }
}
