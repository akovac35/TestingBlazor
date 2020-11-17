using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace TestingBlazor.Pages
{
    public partial class LoadingIndicator : ComponentBase
    {
        static int OnInitializedCounter { get; set; }

        protected bool Initialized { get; set; }

        protected bool Initializing { get; set; }

        protected string Activity1Status { get; set; }

        protected string Activity2Status { get; set; }

        protected string Activity3Status { get; set; }

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

            if (!Initialized && !Initializing)
            {
                Initializing = true;

                try
                {
                    await Task.Delay(2000);
                }
                finally
                {
                    Initializing = false;
                    Initialized = true;
                }
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            OnAfterRenderCounter++;
        }        

        protected async Task ExecuteActivity1Async()
        {
            Activity1Status = "Executing activity 1 ...";

            await Task.Delay(2000);

            Activity1Status = "Activity 1 executed.";
        }

        protected Task ExecuteActivity2()
        {
            Activity2Status = "Activity 2 executed.";

            return Task.CompletedTask;
        }

        protected Task ExecuteActivity3()
        {
            Activity3Status = "Activity 3 executing. The page will make another render once the task completes.";

            return Task.Delay(2000);
        }
    }
}