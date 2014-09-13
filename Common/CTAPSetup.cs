using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class CTAPSetup
    {
        private static string g_szEQID = "";
        private static enuFunctionButtonLocation g_enuFunctionButtonLocation = enuFunctionButtonLocation.Top;
        private static string g_szNowUserName = "";
        private static bool g_bFastLogin = true;
        private static bool g_bEnableTK = false;
        private static bool g_bEnableCVITK = false;
        private static bool g_bEnableCardReader = false;
        private static int g_iAutoLogoutTime = 60;
        private static int g_iAutoLogoutCount = 0;
        
        public static string EQID
        {
            get { return g_szEQID; }
            set { g_szEQID = value; }
        }

        public static enuFunctionButtonLocation FunctionButtonLocation
        {
            get { return g_enuFunctionButtonLocation; }
            set { g_enuFunctionButtonLocation = value; }
        }

        public static string NowUserName
        {
            get { return g_szNowUserName; }
            set { g_szNowUserName = value; }
        }

        public static bool FastLogin
        {
            get { return g_bFastLogin; }
            set { g_bFastLogin = value; }
        }

        public static bool EnableTK
        {
            get { return g_bEnableTK; }
            set { g_bEnableTK = value; }
        }

        public static bool EnableCVITK
        {
            get { return g_bEnableCVITK; }
            set { g_bEnableCVITK = value; }
        }

        public static int AutoLogoutTime
        {
            get { return g_iAutoLogoutTime / 60; }
            set { g_iAutoLogoutTime = value * 60; }
        }

        public static int AutoLogoutCount
        {
            get { return g_iAutoLogoutCount; }
            set { g_iAutoLogoutCount = value; }
        }

        public static bool EnableCardReader
        {
            get { return g_bEnableCardReader; }
            set { g_bEnableCardReader = value; }
        }
    }

    public enum enuFunctionButtonLocation
    {
        Top = 0,
        Bottom = 1
    }
}
