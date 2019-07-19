using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FringleTimer.Model
{
    class Ticker
    {
        public Int32 IntervalMilliseconds { get; private set; }
        public event EventHandler Ticked;
        private Task _ticker;
        private CancellationTokenSource tokensource = new CancellationTokenSource();
        
        public Ticker(int intervalMilliseconds)
        {
            IntervalMilliseconds = intervalMilliseconds;
        }
        /// <summary>
        /// Starts the ticker and invokes Ticked event when there is a tick.
        /// </summary>
        /// 
        public async Task StartAsync()
        {
            _ticker = new Task(() =>
            {
                Task.Delay(IntervalMilliseconds);
                Ticked?.Invoke(this, new EventArgs());
            }, tokensource.Token);
            await _ticker;
        }
        public void Start(Action action)
        {
            _ticker = new Task(() =>
            {
                while (!tokensource.Token.IsCancellationRequested)
                {
                    Thread.Sleep(IntervalMilliseconds);
                    action();
                }
                
            }, tokensource.Token);
            _ticker.Start();
        }
        public Boolean IsRunning
        {
            get
            {
                return (_ticker.Status == TaskStatus.WaitingToRun ||
                    _ticker.Status == TaskStatus.Running);
            }
        }
        /// <summary>
        /// Stops the ticker.
        /// </summary>
        /// <returns>Returns a TaskStatus to see what's the reason of stopping the task.</returns>
        public async Task<TaskStatus> Stop()
        {
            if (_ticker.Status == TaskStatus.WaitingToRun ||
                _ticker.Status == TaskStatus.Running)
            {
                tokensource.Cancel();
                await _ticker;
                return _ticker.Status;

            }
            else throw new InvalidOperationException("Ticker hasn't been started.");
        }
    }
}
