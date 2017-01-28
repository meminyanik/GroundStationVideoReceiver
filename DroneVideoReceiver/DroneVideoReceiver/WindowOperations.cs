using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneVideoReceiver
{
    class WindowOperations
    {
        /*Window operations defined in user32.dll****************************************************************/
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hwnd, bool enable);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        /********************************************************************************************************/

        //Gets a panel and a handle of a window as parameters and links the window to the specified panel 
        public IntPtr LinkToMainWindow(System.Windows.Forms.Panel panelMain, IntPtr handleForVideoReceiverWindow)
        {
            IntPtr handleForOriginalParent = IntPtr.Zero;

            handleForOriginalParent = SetParent(handleForVideoReceiverWindow, panelMain.Handle);
            SetWindowLong(handleForVideoReceiverWindow, -16, 0x10000000);
            ShowWindow(handleForVideoReceiverWindow, 3);

            return handleForOriginalParent;
        }

        //Gets a handle of a window as parameter and hides the specified window
        public void HideWindow(IntPtr handleForWindow)
        {
            ShowWindow(handleForWindow, 0);
        }
    }
}
