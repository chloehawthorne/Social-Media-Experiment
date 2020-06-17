using Octo_Social_Media.Models;
using Octo_Social_Media.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;

namespace Octo_Social_Media.ViewModels
{
   public  class InboxViewModel : INotifyPropertyChanged
    {
        ObservableCollection<InboxModel> inbox;
        public ObservableCollection<InboxModel> Inbox
        {
            set
            {
                if(inbox != value)
                {
                    inbox = value;
                    if (PropertyChanged!= null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Inbox"));
                    }
                }
            }
            get
            {
                return inbox; 
            }
        }
        public InboxViewModel()
        {
            CreateCells();
        }
        public void CreateCells()
        {
            ObservableCollection<InboxModel> list = new ObservableCollection<InboxModel>();

            list.Add(new InboxModel() { Username = "Username01", Message = "Here's a message that is longer than 50 characters just wanted to see how this would work" });
            list.Add(new InboxModel() { Username = "Username02", Message = "Here's a message" });
            list.Add(new InboxModel() { Username = "AlexHam01", Message = "There's a million things I haven't done but just you wait" });
            list.Add(new InboxModel() { Username = "JohnC3na", Message = "u can't see me :p" });
            Inbox = list ;
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
