using System;

namespace Blazored.Toast.Configuration
{
    internal class ToastInstance
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public ToastOptions ToastOptions { get; set; }
    }
}
