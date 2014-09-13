
//#define _SHARE_DATA_USED_IN_MMI_

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Utilities;

namespace ShareMemory
{
    public class CCShareData
    {
        public struct tag_PulseAndSensor
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public double[] dMotionPulse;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 400)]
            public int[] iInput;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 400)]
            public int[] iOutput;
        }
        
        static private CCShareData singleton;

        public static CCShareData GetSingleton()
        {
            if (singleton == null)
            {
                singleton = new CCShareData();
            }
            return singleton;
        }

        #region Create/Delete Memory

        // ===================================================================== 
        // ShareGlsInfo FileMapping Create Object
        // ===================================================================== 
        private int mbFirstInited = 0;
        private IntPtr mhPulseAndSensorMutex = IntPtr.Zero;
        private IntPtr mhPulseAndSensorMapping = IntPtr.Zero;
        private IntPtr mlpPulseAndSensorAddress = IntPtr.Zero;

        public int ShareMemory_CreateDIOObject()
        {
            tag_PulseAndSensor PulseAndSensor = new tag_PulseAndSensor();

            if (this.mbFirstInited != 0) return -1;

            if ((mhPulseAndSensorMapping = Win32API.CreateFileMapping(Win32API.INVALID_HANDLE_VALUE, IntPtr.Zero, (uint)Win32API.PAGE_READWRITE, 0, 65535, "PulseAndSensorMem")) == IntPtr.Zero) return -2;
            if ((mlpPulseAndSensorAddress = Win32API.MapViewOfFile(mhPulseAndSensorMapping, (uint)Win32API.FILE_MAP_READ | (uint)Win32API.FILE_MAP_WRITE, 0, 0, 0)) == IntPtr.Zero) return -3;
            if ((mhPulseAndSensorMutex = Win32API.CreateMutex(IntPtr.Zero, false, "PulseAndSensorMutex")) == IntPtr.Zero) return -4;

            this.mbFirstInited = 1;
           
            PulseAndSensor.dMotionPulse = new double[40];
            PulseAndSensor.iInput = new int[400];
            PulseAndSensor.iOutput = new int[400];

            for (int i = 0; i < 20; i++) PulseAndSensor.dMotionPulse[i] = 0;
            for (int i = 0; i < 400; i++)
            {
                PulseAndSensor.iInput[i] = 0;
                PulseAndSensor.iOutput[i] = 0;
            }
            
            return 0;
        }

        // ===================================================================== 
        // ShareDIO FileMapping Delete Object
        // ===================================================================== 

        public int ShareMemory_DeleteDIOObject()
        {
            if (this.mbFirstInited != 1) return -1;
            this.mbFirstInited = 0;
            Win32API.UnmapViewOfFile(mlpPulseAndSensorAddress);
            Win32API.CloseHandle(mhPulseAndSensorMapping);
            Win32API.CloseHandle(mhPulseAndSensorMutex);

            return 0;
        }

        #endregion

        #region Get Value Methods

        // ===================================================================== 
        // ShareDIO Data Interface
        // =====================================================================     

        public int PulseAndSensor_Set(ref tag_PulseAndSensor PulseAndSensor)
        {
            int l_size = Marshal.SizeOf(PulseAndSensor);

            if (Win32API.WaitForSingleObject(mhPulseAndSensorMutex, 1000) == Win32API.WAIT_OBJECT_0)
            {
                Marshal.StructureToPtr(PulseAndSensor, mlpPulseAndSensorAddress, true);   //ShareDIO-> pPointer

                Win32API.ReleaseMutex(mhPulseAndSensorMutex);

            }
            else  // timeout
            {
                return -2;
            }

            return 0;

        }

        public int PulseAndSensor_Get(ref tag_PulseAndSensor PulseAndSensor)
        {

            if (Win32API.WaitForSingleObject(mhPulseAndSensorMutex, 1000) == Win32API.WAIT_OBJECT_0)
            {
                PulseAndSensor = (tag_PulseAndSensor)Marshal.PtrToStructure(mlpPulseAndSensorAddress, PulseAndSensor.GetType());
                Win32API.ReleaseMutex(mhPulseAndSensorMutex);
            }
            else  // timeout
            {
                return -2;
            }

            return 0;
        }
        #endregion

    }
}