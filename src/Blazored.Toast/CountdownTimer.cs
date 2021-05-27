using System;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components;

namespace Blazored.Toast
{
    internal class CountdownTimer : IDisposable
    {
        private Timer _timer;
        private int _timeout;
        //private int _countdownTotal;
        private int _percentComplete;

        internal Action<int> OnTick;
        internal Action OnElapsed;

        internal CountdownTimer(int timeout)
        {
            _timeout = timeout;
            //_timeout = (_countdownTotal * 1000) / 100;
            _percentComplete = 0;
            SetupTimer();
        }

        internal void Start()
        {
            _timer.Start();
        }

        private void SetupTimer()
        {
            _timer = new Timer(_timeout);
            _timer.Elapsed += Elapsed;
            _timer.AutoReset = false;
        }

        private void Elapsed(object sender, ElapsedEventArgs args)
        {
            OnElapsed?.Invoke();
        }

        public void Dispose()
        {
            _timer.Dispose();
            _timer = null;
        }
    }
}
