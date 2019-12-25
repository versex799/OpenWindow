using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OpenWindow
{
    /// <summary>
    /// Synchronizes the threads pulled from the thread pool for thread sensitive operations.
    /// </summary>
    public class SynchronizedThread
    {
        /// <summary>
        /// Operational Thread.
        /// </summary>
        public Thread Thread { get; set; }

        /// <summary>
        /// Synchronization context used to synchronize the thread.
        /// </summary>
        public CustomSynchronizationContext CTX { get; set; }

        /// <summary>
        /// Name used to identify the SynchronizedThread instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The operation to execute on the thread.
        /// </summary>
        public Action Method { get; set; }
    }
}
