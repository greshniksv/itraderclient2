using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace itcClassess
{
    public enum RadioMode
    {
        Off = 0,
        Connectable = 1,
        Discoverable = 2
    }

    public class ResetDevice
    {
        [DllImport("coredll.dll")]

        public static extern int KernelIoControl(int dwIoControlCode, IntPtr lpInBuf, int nInBufSize, IntPtr lpOutBuf, int nOutBufSize, ref int lpBytesReturned);

        private int CTL_CODE(int DeviceType, int Func, int Method, int Access)
        {

            return (DeviceType << 16) | (Access << 14) | (Func << 2) | Method;

        }
        public int Run()
        {
            const int FILE_DEVICE_HAL = 0x101;

            const int METHOD_BUFFERED = 0;

            const int FILE_ANY_ACCESS = 0;

            int bytesReturned = 0;

            int IOCTL_HAL_REBOOT;

            IOCTL_HAL_REBOOT = CTL_CODE(FILE_DEVICE_HAL, 15, METHOD_BUFFERED, FILE_ANY_ACCESS);

            return KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, ref bytesReturned);

        }
    }
}
