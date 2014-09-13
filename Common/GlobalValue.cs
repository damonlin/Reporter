using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Common
{
    public class GlobalValue
    {
        private static bool[] g_GlassProcessStatus = new bool[] { false, false, false };
        private static CCGlassData g_GlassData1 = null;
        private static CCGlassData g_GlassData2 = null;
        private static CCGlassData g_TempGlassData = null;
        private static CCLaserPowerData g_LaserPowerData = new CCLaserPowerData();
        private static int g_UnloadGlass = 0;
        private static Queue<string> g_AlarmQueue = new Queue<string>();
        private static string g_szVCRGlassData = "";
        private static int g_iRecipeData = 0;


        private static int g_iNowsLens = 0;
        private static int g_iLastLens = 0;
        private static Dictionary<int, CCLensOffset> g_LensOffset = new Dictionary<int, CCLensOffset>();
        private static bool g_bLensChange = false;


        #region ¬ö¿ýByPass ºX¼Ð
        public const int NO_BYPASS = 0x00;
        public const int HANDSHAKE_BYPASS = 0x01;
        public const int IO_BYPASS = 0x02;

        private static int g_iByPassMaskFlag = 0x00;
        public static int ByPassMaskFlag
        {
            get{return g_iByPassMaskFlag;}
            set { g_iByPassMaskFlag = value; }
        }

        public static bool HandShakeByPass
        {
            set
            { 
                if( true == value)
                    ByPassMaskFlag |= HANDSHAKE_BYPASS; 
            }
            get
            {
                if ((ByPassMaskFlag & HANDSHAKE_BYPASS) == HANDSHAKE_BYPASS)
                    return true;
                else
                    return false;
            }
        }
        #endregion

        public static bool[] GlassProcessStatus
        {
            get { return g_GlassProcessStatus; }
            set { g_GlassProcessStatus = value; }
        }

        [TypeConverterAttribute(typeof(CCGlassData))]
        public static CCGlassData GlassData1
        {
            get { return g_GlassData1; }
            set { g_GlassData1 = value; }
        }

        [TypeConverterAttribute(typeof(CCGlassData))]
        public static CCGlassData GlassData2
        {
            get { return g_GlassData2; }
            set { g_GlassData2 = value; }
        }

        public static CCLaserPowerData LaserPowerData
        {
            get { return g_LaserPowerData; }
            set { g_LaserPowerData = value; }
        }

        public static int UnloadGlass
        {
            get { return g_UnloadGlass; }
            set { g_UnloadGlass = value; }
        }

        public static Queue<string> AlarmQueue
        {
            get { return g_AlarmQueue; }
            set { g_AlarmQueue = value; }
        }

        public static string VCRGlassData
        {
            get { return g_szVCRGlassData; }
            set { g_szVCRGlassData = value; }
        }

        public static int RecipeData
        {
            get { return g_iRecipeData; }
            set { g_iRecipeData = value; }
        }

        public static CCGlassData TempGlassData
        {
            get { return g_TempGlassData; }
            set { g_TempGlassData = value; }
        }

        public static int Lens
        {
            get { return g_iNowsLens; }
            set
            {
                if (value != g_iNowsLens)
                {
                    g_iLastLens = g_iNowsLens;
                    g_iNowsLens = value;
                    g_bLensChange = true;
                }
            }
        }

        public static bool LensChange
        {
            get { return g_bLensChange; }
            set { g_bLensChange = value; }
        }

        public static Dictionary<int, CCLensOffset> LensOffset
        {
            get { return g_LensOffset; }
            set { g_LensOffset = value; }
        }

        public static void GetLensOffset(ref int iTargetX, ref int iTargetY, ref int iTargetZ)
        {
            int iBaseX = g_LensOffset[g_iLastLens].iX;
            int iBaseY = g_LensOffset[g_iLastLens].iY;
            int iBaseZ = g_LensOffset[g_iLastLens].iZ;

            /*iTargetX = iBaseX - g_LensOffset[g_iNowsLens].iX;
            iTargetY = iBaseY - g_LensOffset[g_iNowsLens].iY;
            iTargetY = iBaseY - g_LensOffset[g_iNowsLens].iY;*/

            iTargetX = g_LensOffset[g_iNowsLens].iX;
            iTargetY = g_LensOffset[g_iNowsLens].iY;
            iTargetZ = g_LensOffset[g_iNowsLens].iZ;
        }
    }

    public struct CCLensOffset
    {
        public int iX;
        public int iY;
        public int iZ;
    }

    public class CCGlassData : ExpandableObjectConverter
    {
        private int iSlotNo = 0;
        private int iCassetteNo = 0;
        private int iKindNo = 0;
        private int iPortNo = 0;

        private string szBatchID = "";
        private string szBatchType = "";
        private string szLotID = "";
        private string szLotType = "";
        private string szGlassID = "";
        private string szGlassType = "";
        private string szProductID = "";
        private string szPlanID = "";
        private string szStepID = "";
        private string szStepNo = "";
        private string szRecipeID = "";
        private string szPPID = "";
        private string szAbnormalFlag = "";
        private string szFinalJudge = "";
        private string szGrade = "";
        private string szGradeCode = "";
        private int iCelRepCount = 0;
        private int iCelTrimCount = 0;
        private string szParCount = "";
        private string szModelName = "";
        private string szEQID = "";
        private string szVCRFlag = "";
        private string szLotSubType = "";
        private string szArrayGlassID = "";
        private string szCFGlassID = "";
        private string szProcessPortNo = "";
        private string szCassetteID = "";
        private string szSlotID = "";

        public int SlotNo
        {
            get { return iSlotNo; }
            set { iSlotNo = value; }
        }

        public int CassetteNo
        {
            get { return iCassetteNo; }
            set { iCassetteNo = value; }
        }

        public int KindNo
        {
            get { return iKindNo; }
            set { iKindNo = value; }
        }

        public int PortNo
        {
            get { return iPortNo; }
            set { iPortNo = value; }
        }

        public string BatchID
        {
            get { return szBatchID; }
            set { szBatchID = value; }
        }

        public string BatchType
        {
            get { return szBatchType; }
            set { szBatchType = value; }
        }

        public string LotID
        {
            get { return szLotID; }
            set { szLotID = value; }
        }

        public string LotType
        {
            get { return szLotType; }
            set { szLotType = value; }
        }

        public string GlassID
        {
            get { return szGlassID; }
            set { szGlassID = value; }
        }

        public string GlassType
        {
            get { return szGlassType; }
            set { szGlassType = value; }
        }

        public string ProductID
        {
            get { return szProductID; }
            set { szProductID = value; }
        }

        public string PlanID
        {
            get { return szPlanID; }
            set { szPlanID = value; }
        }

        public string StepID
        {
            get { return szStepID; }
            set { szStepID = value; }
        }

        public string StepNo
        {
            get { return szStepNo; }
            set { szStepNo = value; }
        }

        public string RecipeID
        {
            get { return szRecipeID; }
            set { szRecipeID = value; }
        }

        public string PPID
        {
            get { return szPPID; }
            set { szPPID = value; }
        }

        public string AbnormalFlag
        {
            get { return szAbnormalFlag; }
            set { szAbnormalFlag = value; }
        }

        public string FinalJudge
        {
            get { return szFinalJudge; }
            set { szFinalJudge = value; }
        }

        public string Grade
        {
            get { return szGrade; }
            set { szGrade = value; }
        }

        public string GradeCode
        {
            get { return szGradeCode; }
            set { szGradeCode = value; }
        }

        public int CelRepCount
        {
            get { return iCelRepCount; }
            set { iCelRepCount = value; }
        }

        public int CelTrimCount
        {
            get { return iCelTrimCount; }
            set { iCelTrimCount = value; }
        }

        public string ParCount
        {
            get { return szParCount; }
            set { szParCount = value; }
        }

        public string ModelName
        {
            get { return szModelName; }
            set { szModelName = value; }
        }

        public string EQID
        {
            get { return szEQID; }
            set { szEQID = value; }
        }

        public string VCRFlag
        {
            get { return szVCRFlag; }
            set { szVCRFlag = value; }
        }

        public string LotSubType
        {
            get { return szLotSubType; }
            set { szLotSubType = value; }
        }

        public string ArrayGlassID
        {
            get { return szArrayGlassID; }
            set { szArrayGlassID = value; }
        }

        public string CFGlassID
        {
            get { return szCFGlassID; }
            set { szCFGlassID = value; }
        }

        public string ProcessPortNo
        {
            get { return szProcessPortNo; }
            set { szProcessPortNo = value; }
        }

        public string CassetteID
        {
            get { return szCassetteID; }
            set { szCassetteID = value; }
        }

        public string SlotID
        {
            get { return szSlotID; }
            set { szSlotID = value; }
        }
    }

    public class CCLaserPowerData
    {
        private int iMaxPower = 0;
        private int iMinPower = 0;
        private int iAvgPower = 0;
        private int iStdPower = 0;

        public int MaxPower
        {
            get { return iMaxPower; }
        }

        public int MinPower
        {
            get { return iMinPower; }
        }

        public int AvgPower
        {
            get { return iAvgPower; }
        }

        public int StdPower
        {
            get { return iStdPower; }
        }

        public int SetPower
        {
            set
            {
                if (value > iMaxPower)
                {
                    iMaxPower = value;
                }

                if (value < iMinPower)
                {
                    iMinPower = value;
                }

                if (iAvgPower == 0)
                {
                    iAvgPower = value;
                }
                else
                {
                    iAvgPower = (iAvgPower + value) / 2;
                }

                if (iStdPower == 0)
                {
                    iStdPower = value;
                }
            }
        }
    }
}
