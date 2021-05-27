using System;
using Blazored.Toast.Configuration;
using Blazored.Toast.Enums;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast.Services
{
    public interface IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        event Action<ToastOptions> OnShow;

        void ShowToast(ToastOptions options);

        void ShowToast(string Message, string Heading = null);

        void ShowToast(RenderFragment Message, string Heading = null);
        
     }
}
