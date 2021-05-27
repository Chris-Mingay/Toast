using Blazored.Toast.Configuration;
using Blazored.Toast.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;

namespace Blazored.Toast
{
    public partial class BlazoredToast : IDisposable
    {
        [CascadingParameter] private BlazoredToasts ToastsContainer { get; set; }

        [Parameter] public Guid ToastId { get; set; }
        [Parameter] public ToastOptions ToastOptions { get; set; }

        private string CardClass { get; set; } = "border-gray-400 bg-white";
        private string HeadingClass { get; set; } = "text-gray-800";
        private string CloseButtonClass { get; set; } = "text-gray-400";
        private string ContentClass { get; set; } = "text-gray-600";
        private string FadeOutClass { get; set; } = "opacity-1";
        public string ActionButtonClass { get; set; } = "text-indigo-500";

        private Timer _countdownTimer;
        private Timer _fadeCountdownTimer;

        protected override void OnInitialized()
        {

            switch (ToastOptions.Level)
            {
                case ToastLevel.Success:
                    CardClass = "border-green-700 bg-green-500";
                    HeadingClass = "text-white";
                    CloseButtonClass = "text-green-800";
                    ContentClass = "text-green-100";
                    ActionButtonClass = "text-white";
                    break;
                case ToastLevel.Error:
                    CardClass = "border-red-700 bg-red-500";
                    HeadingClass = "text-white";
                    CloseButtonClass = "text-red-800";
                    ContentClass = "text-red-100";
                    ActionButtonClass = "text-white";
                    break;
                case ToastLevel.Warning:
                    CardClass = "border-yellow-700 bg-yellow-500";
                    HeadingClass = "text-white";
                    CloseButtonClass = "text-yellow-800";
                    ContentClass = "text-yellow-100";
                    ActionButtonClass = "text-white";
                    break;
            }

            if (ToastOptions.Timeout > 0)
            {
                _countdownTimer = new Timer(ToastOptions.Timeout);
                _countdownTimer.Elapsed += (s, e) => Close();
                _countdownTimer.Start();
            }

            if (ToastOptions.Timeout > 500)
            {
                _fadeCountdownTimer = new Timer(ToastOptions.Timeout - 500);
                _fadeCountdownTimer.Elapsed += (s,e) =>
                {
                    FadeOutClass = "opacity-0";
                    InvokeAsync(() => StateHasChanged());
                };
                _fadeCountdownTimer.Start();
            }


        }

        private void Close()
        {
            ToastsContainer.RemoveToast(ToastId);
        }

        private void PerformActionAndClose()
        {
            ToastOptions.OnClick.Invoke();
            Close();
        }

        public void Dispose()
        {
            if (_countdownTimer != null)
            {
                _countdownTimer.Dispose();
                _countdownTimer = null;
            }

            if (_fadeCountdownTimer != null)
            {
                _fadeCountdownTimer.Dispose();
                _fadeCountdownTimer = null;
            }

        }

        private async Task OnMouseEnter()
        {
            if (_countdownTimer != null) _countdownTimer.Stop();
            if (_fadeCountdownTimer != null) _fadeCountdownTimer.Stop();
                
        }

        private async Task OnMouseLeave()
        {
            if (_countdownTimer != null) _countdownTimer.Start();
            if (_fadeCountdownTimer != null) _fadeCountdownTimer.Start();
            
        }

    }
}
