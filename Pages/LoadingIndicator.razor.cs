using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace TestingBlazor.Pages
{
    public partial class LoadingIndicator : ComponentBase
    {
        static int OnInitializedCounter { get; set; }

        static int OnInitializedAsyncCounter { get; set; }

        protected bool Initialized { get; set; }

        protected bool Initializing { get; set; }

        protected string Activity1Status { get; set; }

        protected string Activity2Status { get; set; }

        protected string Activity3Status { get; set; }

        protected string Activity4Status { get; set; }

        protected string Activity5Status { get; set; }

        protected int OnAfterRenderCounter { get; set; }

        protected override void OnInitialized()
        {
            Console.WriteLine("OnInitialized");

            OnInitializedCounter++;

            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine("OnInitializedAsync");

            OnInitializedAsyncCounter += 1;

            await Task.Delay(2000);

            Initialized = true;
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

        protected async Task ExecuteActivity4Async()
        {
            Activity4Status = "Executing activity 4 ...";

            await Task.Delay(2000);

            Activity4Status = "Activity 4 executed half of work ...";

            // This is required or we will not see the intermediate status update above
            StateHasChanged();

            await Task.Delay(2000);

            Activity4Status = "Activity 4 executed.";
        }

        protected void ExecuteActivity5()
        {
            Activity5Status = "This is not rendered!";

            StateHasChanged();

            Task.Delay(2000).Wait() ;

            Activity5Status = "Activity 5 executed.";
        }
    }
}