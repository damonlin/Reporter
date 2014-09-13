using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Utilities
{

    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public UInt32 nLength;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }

    public class Win32API
    {
        /*
         [DllImport("kernel32.lib")]
        public static extern IntPtr CreateFileMapping(
                                         IntPtr hFile,                             // handle to file
                                         ref SECURITY_ATTRIBUTES lpAttributes,     // security
                                         UInt32 flProtect,                         // protection
                                         UInt32 dwMaximumSizeHigh,                 // high-order DWORD of size
                                         UInt32 dwMaximumSizeLow,                  // low-order DWORD of size
                                         string lpName                             // object name
                                         );
        */
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFileMapping(int hFile,                      // handle to file
                                                      IntPtr lpAttributes,            // security
                                                      uint flProtect,                 // protection
                                                      uint dwMaxSizeHi,               // high-order DWORD of size
                                                      uint dwMaxSizeLow,              // low-order DWORD of size
                                                      string lpName);                 // object name


        [DllImport("Kernel32.dll ", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenFileMapping(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr MapViewOfFile(
                                         IntPtr hFileMappingObject,                // handle to file-mapping object
                                         UInt32 dwDesiredAccess,                   // access mode
                                         UInt32 dwFileOffsetHigh,                  // high-order DWORD of offset
                                         UInt32 dwFileOffsetLow,                   // low-order DWORD of offset
                                         UInt32 dwNumberOfBytesToMap               // number of bytes to map
                                         );

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateMutex(
                                         IntPtr lpMutexAttributes,// SD
                                         bool bInitialOwner,                       // initial owner
                                         string lpName                             // object name
                                         );

        [DllImport("Kernel32.dll ", CharSet = CharSet.Auto)]
        public static extern bool UnmapViewOfFile(IntPtr pvBaseAddress);

        [DllImport("Kernel32.dll ", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("Kernel32.dll ", CharSet = CharSet.Auto)]
        public static extern UInt32 WaitForSingleObject(IntPtr hFileMappingObject, UInt32 dwMilliseconds);

        [DllImport("Kernel32.dll ", CharSet = CharSet.Auto)]
        public static extern UInt32 ReleaseMutex(IntPtr hFileMappingObject);


        public const int FILE_MAP_COPY = 0x0001;
        public const int FILE_MAP_WRITE = 0x0002;
        public const int FILE_MAP_READ = 0x0004;
        public const int FILE_MAP_ALL_ACCESS = 0x0002 | 0x0004;

        public const int PAGE_READONLY = 0x02;
        public const int PAGE_READWRITE = 0x04;
        public const int PAGE_WRITECOPY = 0x08;
        public const int PAGE_EXECUTE = 0x10;
        public const int PAGE_EXECUTE_READ = 0x20;
        public const int PAGE_EXECUTE_READWRITE = 0x40;

        public const int SEC_COMMIT = 0x8000000;
        public const int SEC_IMAGE = 0x1000000;
        public const int SEC_NOCACHE = 0x10000000;
        public const int SEC_RESERVE = 0x4000000;
        public const int INVALID_HANDLE_VALUE = -1;

        public const UInt32 STATUS_WAIT_0 = ((UInt32)0x00000000L);
        public const UInt32 WAIT_OBJECT_0 = ((STATUS_WAIT_0) + 0);

    }

}
