using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SDDEMsg;
using ZSModule;

namespace Common
{
    public partial class Debug : Form
    {
        ZSMeasure test = new ZSMeasure();

        public Debug()
        {
            InitializeComponent();
            test.ZSModule_InitialComm();
        }

        static private Debug Singleton;

        public static Debug GetSingleton()
        {
            if (Singleton == null)
                Singleton = new Debug();
            return Singleton;
        }

        private void DDEMsg_Click(object sender, EventArgs e)
        {
            //int a;
            //StringBuilder pBuffer = new StringBuilder();
            //SDDE.GetSingleton().createObject();
            SDDE.GetSingleton().SDDE_Display();

            //SDDE.GetSingleton().GetMessageFromTK(pBuffer);
            //20090318 志忠~~MMI和TK連線
            //SDDE.GetSingleton().Connect();
            
            //a = SDDE.GetSingleton().GetSDDEStatus();
        }

        private void ConnectZS_Click(object sender, EventArgs e)
        {
            //test.SendCmdToModule("11");
            //DearError.DearErrorCode DearError = new DearError.DearErrorCode(true);
        }
    }
}