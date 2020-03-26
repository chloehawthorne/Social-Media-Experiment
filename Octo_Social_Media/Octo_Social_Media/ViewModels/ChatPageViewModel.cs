using System;
using System.Collections.Generic;
using System.Text;
using Octo_Social_Media.Models;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace Octo_Social_Media.ViewModels
{
    public class ChatPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MessageItem> Messages { get; set; } = new ObservableCollection<MessageItem>();

        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }

        public ChatPageViewModel()
        {
            Messages.Add(new MessageItem() { Text = "Hi" });
            Messages.Add(new MessageItem() { Text = "Hey, This really works :O" });
            Messages.Add(new MessageItem() { Text = "Hey, how are you?" });

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Add(new MessageItem() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
