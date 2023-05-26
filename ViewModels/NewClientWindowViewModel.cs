using Bank.Cmds;
using Bank.Models;
using Bank.Validators;
using Bank.View;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.IO;
using System.Windows;

namespace Bank.ViewModels
{
    internal class NewClientWindowViewModel
    {
        /// <summary>
        /// Ссылка на view, для получения полей из формы нового клиента
        /// </summary>
        private NewClientWindow _window;

        private Client newClient;

        private ClientValidator validator;

        /// <summary>
        /// Посути - результат работы класса, новый клиент
        /// </summary>
        public Client NewClient { get => newClient; }

        public NewClientWindowViewModel(NewClientWindow window)
        {
            _window = window;

            newClient = new Client();

            validator = new ClientValidator();
    }

        private RelayCommand addClientCommand = null;
        /// <summary>
        /// Команда для создания клиента
        /// </summary>
        public RelayCommand AddClientCommand => addClientCommand ?? (new RelayCommand(AddClient, CanAddClient)); //CanAddClient

        private bool CanAddClient()
        {
            var result = validator.Validate(newClient);

            if (result.IsValid)
            {
                return true;
            }

            //foreach (var error in result.Errors)
            //{
            //    string path = Directory.GetCurrentDirectory() + @"\Images\A_logo.png";

            //    new ToastContentBuilder()
            //        .AddArgument("visual", "viewConversation")
            //        .AddArgument("conversationId", 9813)
            //        .AddText("Ощибка в данных")
            //        .AddText($"{error.ErrorMessage}")
            //        .AddAppLogoOverride(new Uri(path), ToastGenericAppLogoCrop.Circle)
            //        .Show(toast =>
            //        {
            //            toast.ExpirationTime = DateTime.Now.AddMilliseconds(1000);
            //        });
            //}
            return false;
        }

        /// <summary>
        /// Создает нового клиента
        /// </summary>
        private void AddClient()
        {
            newClient = new Client(firstName: _window.FirstNameTextBox.Text,
                                  middleName: _window.MidlleNameTextBox.Text,
                                  secondName: _window.SecondNameTextBox.Text,
                                     telefon: _window.TelefonTextBox.Text,
                     seriesAndPassportNumber: _window.SeriesAndPassportNumberTextBox.Text,
                                   currentId: newClient.ID,
                                    dateTime: DateTime.Now,
                                   isChanged: false);

            _window.DialogResult = true;
        }   

    }
}
