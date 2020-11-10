using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace TestingBlazor.Pages
{
    public partial class LoadingIndicator : ComponentBase
    {
        protected bool Initialized
        {
            get;
            set;
        }

        static int OnInitializedCounter { get; set; }

        protected int OnAfterRenderCounter { get; set; }

        protected override void OnInitialized()
        {
            Console.WriteLine("OnInitialized");

            base.OnInitialized();

            OnInitializedCounter++;
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("OnInitializedAsync");

            if (!Initialized)
            {
                await Task.Delay(2000);
                Initialized = true;
                StateHasChanged();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            OnAfterRenderCounter++;
        }

        string Activity1Status { get; set; }

        protected async Task ExecuteActivity1()
        {
            Activity1Status = "Executing activity 1 ...";
            StateHasChanged();

            await Task.Delay(2000);

            Activity1Status = "Activity 1 executed.";
            StateHasChanged();
        }
    }
}