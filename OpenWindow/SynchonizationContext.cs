using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace OpenWindow
{
    /// <summary>
    /// SynchronizationContext used to synchronize operations on threads.
    /// </summary>
    public class CustomSynchronizationContext : SynchronizationContext
    {
        private readonly Queue<Action> _messageToProcess = new Queue<Action>();
        private static readonly object _syncHandle = new object();
        private static bool _isRunning = true;

        /// <summary>
        /// Initialize a new CustomerSynchronizationContext instance.
        /// </summary>
        public CustomSynchronizationContext()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        public override void Send(SendOrPostCallback d, object state)
        {
            base.Send(d, state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="state"></param>
        public override void Post(SendOrPostCallback d, object state)
        {
            if (_messageToProcess.Count > 100)
                _messageToProcess.Dequeue();

            lock (_syncHandle)
            {
                _messageToProcess.Enqueue(() => d(state));
                SignalContinue();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RunMessagePump()
        {
            while (CanContinue())
            {
                try
                {
                    Action nextToRun = GrabItem();
                    nextToRun();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private Action GrabItem()
        {
            lock (_syncHandle)
            {
                while (CanContinue() && _messageToProcess.Count == 0)
                {
                    Monitor.Wait(_syncHandle);
                }

                return _messageToProcess.Dequeue();
            }
        }

        private bool CanContinue()
        {
            lock (_syncHandle)
            {
                return _isRunning;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Cancel()
        {
            lock (_syncHandle)
            {
                _isRunning = false;
                SignalContinue();
            }
        }

        private void SignalContinue()
        {
            Monitor.Pulse(_syncHandle);
        }
    }
}
