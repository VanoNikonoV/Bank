using Bank.DataAccesses;
using Bank.Models;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Bank.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // SAVE ctrl + s

            //MainGrid.KeyDown += (s, e) =>
            //{
            //    if (e.Key == Key.Return)
            //    {
            //        var curUser = usersList.SelectedItem as TelegramUser;

            //        if (curUser != null && !string.IsNullOrWhiteSpace(txtMsgSend.Text))
            //        {
            //            client.SendMessage(txtMsgSend.Text, TargetSend.Text, curUser);

            //            MessageLog.SaveFile(client.Users);

            //            txtMsgSend.Text = string.Empty;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Выберите пользователя", caption: nameof(TelegramMessageClient));
            //        }
            //    }
            //};
        }

        private void CloseWindows(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Для анимации закрытия списка изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            СhangesClient.Visibility = Visibility.Collapsed;
            ListChanges_Label.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Для анимации открытия списка изменений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            СhangesClient.Visibility = Visibility.Visible;
            ListChanges_Label.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Перемещение окна в пространестве рабочего стола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { this.DragMove(); }
        }

        private bool IsMaximized = false;
        /// <summary>
        /// Сворачивание окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gride_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Height = 800;
                    this.Width = 1250;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }
    }
}
