using BlazorTailwindToast.Enums;
using BlazorTailwindToast.Configuration;
using BlazorTailwindToast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BlazorTailwindToast
{

    public partial class BlazoredToasts
    {
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public bool RemoveToastsOnNavigation { get; set; }
        

        internal List<ToastInstance> TopLeftList { get; set; } = new List<ToastInstance>();
        internal List<ToastInstance> TopCenterList { get; set; } = new List<ToastInstance>();
        internal List<ToastInstance> TopRightList { get; set; } = new List<ToastInstance>();
        internal List<ToastInstance> BottomLeftList { get; set; } = new List<ToastInstance>();
        internal List<ToastInstance> BottomCenterList { get; set; } = new List<ToastInstance>();
        internal List<ToastInstance> BottomRightList { get; set; } = new List<ToastInstance>();

        internal List<ToastInstance>[] AllLists { get; set; } = new List<ToastInstance>[0];

        protected override void OnInitialized()
        {

            AllLists = new List<ToastInstance>[6]
            {
                TopLeftList,
                TopCenterList,
                TopRightList,
                BottomLeftList,
                BottomCenterList,
                BottomRightList
            };

            ToastService.OnShow += ShowToast;

            if (RemoveToastsOnNavigation)
            {
                NavigationManager.LocationChanged += ClearToasts;
            }

        }

        public void RemoveToast(Guid toastId)
        {
            InvokeAsync(() =>
            {

                foreach (var l in AllLists)
                {
                    var toastInstance = l.SingleOrDefault(x => x.Id == toastId);
                    if (toastInstance != null)
                    {
                        l.Remove(toastInstance);
                        StateHasChanged();
                        return;
                    }
                }

            });
        }

        private void ClearToasts(object sender, LocationChangedEventArgs args)
        {
            InvokeAsync(() =>
            {
                //ToastList.Clear();
                foreach(var l in AllLists)
                {
                    l.Clear();
                }
                
                StateHasChanged();
            });
        }

        private void ShowToast(ToastOptions options)
        {
            InvokeAsync(() =>
            {
                var toast = new ToastInstance
                {
                    Id = Guid.NewGuid(),
                    TimeStamp = DateTime.Now,
                    ToastOptions = options
                };

                AllLists[(int)options.Position].Add(toast);

                StateHasChanged();
            });

        }
    }
}
