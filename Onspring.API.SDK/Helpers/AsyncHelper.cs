using System;
using System.Threading.Tasks;

namespace Onspring.API.SDK.Helpers
{
    /// <summary>
    /// Helper for running asynchronous code, synchronously.
    /// Should only be used when the async method is unavailable.
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// Runs the provided async delegate synchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asyncMethod"></param>
        /// <remarks>
        /// Source: https://docs.microsoft.com/en-us/archive/blogs/jpsanders/asp-net-do-not-use-task-result-in-main-context
        /// </remarks>
        /// <returns></returns>
        public static T RunTask<T>(Func<Task<T>> asyncMethod)
        {
            var task = Task.Run(asyncMethod);
            task.Wait();
            return task.Result;
        }
    }
}
