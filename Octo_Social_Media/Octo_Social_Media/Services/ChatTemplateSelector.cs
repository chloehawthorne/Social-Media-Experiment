using System;
using System.Collections.Generic;
using System.Text;
using Octo_Social_Media.Models;
using Octo_Social_Media.Views;
using Xamarin.Forms;

namespace Octo_Social_Media.Services
{
    class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessageCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingMessageCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVM = item as MessageItem;

            if (messageVM == null)
                return null;

            return (messageVM.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }
    }
}
