using Octo_Social_Media.Models;
using Octo_Social_Media.Views;
using Xamarin.Forms;

namespace Octo_Social_Media.Services
{
    public class ChatTemplateSelector : DataTemplateSelector
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
            var messageVm = item as MessageItem;
            if (messageVm == null)
                return null;


            return (messageVm.User != App.User) ? incomingDataTemplate : outgoingDataTemplate;
        }

    }
}
