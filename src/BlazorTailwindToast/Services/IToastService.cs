using System;
using BlazorTailwindToast.Configuration;
using BlazorTailwindToast.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorTailwindToast.Services
{
    public interface IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        event Action<ToastOptions> OnShow;

        void ShowToast(ToastOptions options);

        void ShowToast(string Message, string Heading = null);
        
     }
}
