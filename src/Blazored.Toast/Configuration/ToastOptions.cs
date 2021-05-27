using Blazored.Toast.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazored.Toast.Configuration
{
    public class ToastOptions
    {
        public static ToastOptions Defaults { get; set; } = new ToastOptions();


        public ToastLevel Level { get; set; } = ToastLevel.Info;
        public ToastPosition Position { get; set; } = ToastPosition.TopRight;
        public string Heading { get; set; }
        public RenderFragment Message { get; set; }
        public int Timeout { get; set; } = 5000;
        public Action? OnClick { get; set; }
        public string ButtonLabel { get; set; }

        public ToastOptions Copy()
        {
            return new ToastOptions
            {
                Level = Level,
                Position = Position,
                Heading = Heading,
                Message = Message,
                Timeout = Timeout,
                OnClick = OnClick,
                ButtonLabel = ButtonLabel
            };
        }
    }
}
