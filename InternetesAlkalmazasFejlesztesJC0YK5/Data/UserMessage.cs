using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetesAlkalmazasFejlesztesJC0YK5.Data
{
    public class UserMessage
    {
        public MessageType Type { get; set; }
        public string Text { get; set; }
        public UserMessage(string text, MessageType type)
        {
            Type = type;
            Text = text;
        }
    }
    public enum MessageType
    {
        Hiba = 0,
        Siker = 1
    }
}
