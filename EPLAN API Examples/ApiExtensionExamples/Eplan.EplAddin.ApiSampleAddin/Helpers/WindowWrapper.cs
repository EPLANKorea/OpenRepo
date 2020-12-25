using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Eplan.EplAddin.ApiSampleAddin.Helpers
{
    public class WindowWrapper : IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            this.Handle = handle;
        }

        public IntPtr Handle
        {
            get;
            private set;
        }

        public static WindowWrapper GetEplanMainWindow()
        {
            return new WindowWrapper(Process.GetCurrentProcess().MainWindowHandle);
        }
    }
}
