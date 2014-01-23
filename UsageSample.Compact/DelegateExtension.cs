using System;
using System.Windows.Forms;

namespace UsageSample.Compact
{
    public static class DelegateExtension
    {
        public static AsyncCallback BindTo(this AsyncCallback callback, Control context)
        {
            if (callback == null)
                throw new ArgumentNullException();

            return (asyncResult) =>
                {
                    if (!context.IsDisposed)
                        context.Invoke(callback, asyncResult);
                };
        }

        public static EventHandler<T> BindTo<T>(this EventHandler<T> handler, Control context) where T : EventArgs
        {
            if (handler == null)
                throw new ArgumentNullException();

            return (sender, eventArgs) =>
                {
                    if (!context.IsDisposed)
                        context.Invoke(handler, sender, eventArgs);
                };
        }
    }
}