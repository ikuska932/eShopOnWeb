using System;
using System.Timers;

namespace BlazorAdmin.Services
{
    public class ToastService
    {
        public event Action<string, string> OnShow;
        public event Action OnHide;

        private Timer Countdown;

        public void ShowToast(string message, string title, int duration = 3000)
        {
            OnShow?.Invoke(message, title);

            if (Countdown != null)
            {
                Countdown.Stop();
                Countdown.Dispose();
            }

            Countdown = new Timer(duration);
            Countdown.Elapsed += HideToast;
            Countdown.AutoReset = false;
            Countdown.Start();
        }

        private void HideToast(object source, ElapsedEventArgs e)
        {
            OnHide?.Invoke();
        }
    }
}
