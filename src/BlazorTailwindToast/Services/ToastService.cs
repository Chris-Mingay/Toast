﻿using System;
using BlazorTailwindToast.Configuration;
using BlazorTailwindToast.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorTailwindToast.Services
{
    public class ToastService : IToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<ToastOptions> OnShow;

        public void ShowToast(ToastOptions options)
        {
            _Invoke(options);
        }

        public void ShowToast(string Message, string Heading = null)
        {
            var options = ToastOptions.Defaults.Copy();
            options.Message = Message;
            options.Heading = Heading;
            _Invoke(options);
        }


        private void _Invoke(ToastOptions options)
        {
            OnShow?.Invoke(options);
        }

    }
}
