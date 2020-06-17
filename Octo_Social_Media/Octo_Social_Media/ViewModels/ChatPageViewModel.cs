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
        public bool ShowScrollTap { get; set; } = false; //Show the jump icon 
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }
        public Queue<MessageItem> DelayedMessages { get; set; } = new Queue<MessageItem>();
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }
        public ChatPageViewModel()
        {
            MessageAppearingCommand = new Command<MessageItem>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<MessageItem>(OnMessageDisappearing);

            Messages.Insert(0, new MessageItem() { Text = "Hi" });
            Messages.Insert(0, new MessageItem() { Text = "How are you?", User = App.User });
            Messages.Insert(0, new MessageItem() { Text = "I'm good, how about you?" });
            Messages.Insert(0, new MessageItem() { Text = "I'm fine thanks :) How is programming going?", User = App.User });

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Add(new MessageItem() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;
                }
            });
        }
        void OnMessageAppearing(MessageItem message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(MessageItem message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
