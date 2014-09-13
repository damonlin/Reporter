using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TKUnit
{
   public class IOTable
   {
      // 使用者自訂
       public enum AxisType
       {
           Axis_S = 0,
           Axis_G,
           Axis_L,
           Axis_Z,
           Axis_QS1,
           Axis_QG1,
           Axis_QS2,
           Axis_QG2,
           Axis_QS3,
           Axis_QG3,
           Axis_QS4,
           Axis_QG4,
           Axis_QS5,
           Axis_QG5,
           Axis_QS6,
           Axis_QG6,
           Axis_QS7,
           Axis_QG7,
           Axis_SA1SA2,          
           Axis_C1C2,
           Axis_TS,
           Axis_TG,
           Axis_TZ,
           Axis_RT,
           Axis_RUD,
           Axis_B1,
           Axis_B2,
           Axis_BT,
           Axis_RZ
       }

       /*public struct FSP_Home
       {          
            public const int _FSP_HOME_ = 1;
            public enum JOB
            {
                _JOB_ALLHOME_ = 1,
            }           
       }*/
       #region FSP Define

       /// <summary>
       /// FSP1
       /// </summary>
       public const int _FSP_HOME_ = 1;
       public const int _JOB_ALLHOME_ = 1;

       /// <summary>
       /// FSP2
       /// </summary>
       public const int _FSP_TurnUint_ = 2;
       public const int _JOB_TU_LDRQ_ = 1;
       public const int _JOB_TU_UDRQ_ = 2;
       public const int _JOB_TU_TOP_LOAD_ = 3;                         // RUD上半部動作(入料)
       public const int _JOB_TU_TOP_UNLOAD_ = 4;                   // RUD上半部動作(出料)
       public const int _JOB_TU_BOTTOM_LOAD_ = 5;                // RUD下半部動作(入料)
       public const int _JOB_TU_BOTTOM_UNLOAD_ = 6;          // RUD下半部動作(出料)--最後一片出料

       /// <summary>
       /// FSP3
       /// </summary>
       public const int _FSP_STAGE_ = 3;
       public const int _JOB_STAGE_INITIALIZE_ = 1;                 // 包含C1C2、SA1,SA2、S、G、Quick、B1B2歸零
       public const int _JOB_STAGE_LOAD_ = 2;                          // 移動到自動入料位置
       public const int _JOB_STAGE_UNLOAD_ = 3;                    // 移動到自動退料位置

       /// <summary>
       /// FSP4
       /// </summary>
       public const int _FSP_QUICK_ = 4;
       public const int _JOB_QUICK_LIGHTON_ = 1;                         // 判斷移動的Quick移動Quick至點燈位置後點燈
       public const int _JOB_QUICK_TEACHING_ = 2;                // 進行Teaching程序

       /// <summary>
       /// FSP5
       /// </summary>
       public const int _FSP_TEACHBOX_ = 5;
       public const int _JOB_TEACHBOX_MODE_ = 1;                // 判斷使用控制模式
       #endregion

       public struct DI
       {           
           public const int _DI_STAGE_VACUUM1_ON = 0;     // 平台_吸真空1檢測
           public const int _DI_STAGE_VACUUM1_OFF_ = 1;  // 平台_破真空1檢測
           public const int _DI_STAGE_VACUUM2_ON = 2;     // 平台_吸真空2檢測
           public const int _DI_STAGE_VACUUM2_OFF_ = 3;  // 平台_破真空2檢測
           public const int _DI_STAGE_VACUUM3_ON = 4;     // 平台_吸真空3檢測
           public const int _DI_STAGE_VACUUM3_OFF_ = 5;  // 平台_破真空3檢測
           public const int _DI_STAGE_VACUUM4_ON = 6;     // 平台_吸真空4檢測
           public const int _DI_STAGE_VACUUM4_OFF_ = 7;  // 平台_破真空4檢測
           public const int _DI_STAGE_VACUUM5_ON = 8;     // 平台_吸真空5檢測
           public const int _DI_STAGE_VACUUM5_OFF_ = 9;  // 平台_破真空5檢測
           public const int _DI_STAGE_VACUUM6_ON = 10;     // 平台_吸真空6檢測
           public const int _DI_STAGE_VACUUM6_OFF_ = 11;  // 平台_破真空6檢測
           public const int _DI_STAGE_VACUUM7_ON = 12;     // 平台_吸真空7檢測
           public const int _DI_STAGE_VACUUM7_OFF_ = 13;  // 平台_破真空7檢測
           public const int _DI_STAGE_VACUUM8_ON = 14;     // 平台_吸真空8檢測
           public const int _DI_STAGE_VACUUM8_OFF_ = 15;  // 平台_破真空8檢測
           public const int _DI_STAGE_VACUUM9_ON = 16;     // 平台_吸真空9檢測
           public const int _DI_STAGE_VACUUM9_OFF_ = 17;  // 平台_破真空9檢測

           public const int _DI_STAGE_QZ1_UP_SENSOR_ = 18;           // 平台_QZ1汽缸上升檢測
           public const int _DI_STAGE_QZ1_DOWN_SENSOR_ = 19;    // 平台_QZ1汽缸下降檢測
           public const int _DI_STAGE_QZ2_UP_SENSOR_ = 20;           // 平台_QZ2汽缸上升檢測
           public const int _DI_STAGE_QZ2_DOWN_SENSOR_ = 21;    // 平台_QZ2汽缸下降檢測
           public const int _DI_STAGE_QZ3_UP_SENSOR_ = 22;           // 平台_QZ3汽缸上升檢測
           public const int _DI_STAGE_QZ3_DOWN_SENSOR_ = 23;    // 平台_QZ3汽缸下降檢測
           public const int _DI_STAGE_QZ4_UP_SENSOR_ = 24;           // 平台_QZ4汽缸上升檢測
           public const int _DI_STAGE_QZ4_DOWN_SENSOR_ = 25;    // 平台_QZ4汽缸下降檢測
           public const int _DI_STAGE_QZ5_UP_SENSOR_ = 26;           // 平台_QZ5汽缸上升檢測
           public const int _DI_STAGE_QZ5_DOWN_SENSOR_ = 27;    // 平台_QZ5汽缸下降檢測
           public const int _DI_STAGE_QZ6_UP_SENSOR_ = 28;           // 平台_QZ6汽缸上升檢測
           public const int _DI_STAGE_QZ6_DOWN_SENSOR_ = 29;    // 平台_QZ6汽缸下降檢測
           public const int _DI_STAGE_QZ7_UP_SENSOR_ = 30;           // 平台_QZ7汽缸上升檢測
           public const int _DI_STAGE_QZ7_DOWN_SENSOR_ = 31;    // 平台_QZ7汽缸下降檢測
           // 背光L軸偏光板切換_汽缸伸出位置1
           // 背光L軸偏光板切換_汽缸縮回位置1
           // 背光L軸偏光板切換_汽缸伸出位置2
           // 背光L軸偏光板切換_汽缸縮回位置2
           // 中間支撐BAR模組_汽缸伸出_平台(A接點)
           // 中間支撐BAR模組_汽缸縮回_平台(A接點
           // POWER  METER模組_汽缸伸出_平台(A接點)
           // POWER  METER模組_汽缸縮回_平台(A接點)
           public const int _DI_ROBOT_INTERLOCK_SENSOR_ = 40; // 平台_Robot檢測之Sensor
           // 平台_玻璃檢測
           // 平台_入出料到位檢測
           // 平台_SA1玻璃夾好檢測
           // 平台_SA1玻璃過壓檢測
           // 平台_SA2玻璃夾好檢測
           // 平台_SA2玻璃過壓檢測

           public const int _DI_STAGE_SAFETY_SENSOR_1_ = 48;           // 安全Sensor-1
           public const int _DI_STAGE_SAFETY_SENSOR_2_ = 49;           // 安全Sensor-2
           public const int _DI_STAGE_SAFETY_SENSOR_3_ = 50;           // 安全Sensor-3
           public const int _DI_STAGE_SAFETY_SENSOR_4_ = 51;           // 安全Sensor-4

           public const int _DI_SPIN_CLAMP_TX_SENSOR_ = 64;                               // 旋轉_夾片機構之TX夾好玻璃檢知
           public const int _DI_SPIN_CLAMP_TX_PRESSURE_SENSOR_ = 65;           // 旋轉_夾片機構之TX夾好玻璃檢知
           public const int _DI_SPIN_CLAMP_TX_EXTEND_SENSOR_ = 66;              // 旋轉_夾片機構之TX汽缸伸出檢測
           public const int _DI_SPIN_CLAMP_TX_TRIM_SENSOR_ = 67;                    // 旋轉_夾片機構之TX汽缸縮回檢測
           public const int _DI_SPIN_CLAMP_TY_SENSOR_ = 68;                               // 旋轉_夾片機構之TY夾好玻璃檢知
           public const int _DI_SPIN_CLAMP_TY_PRESSURE_SENSOR_ = 69;           // 旋轉_夾片機構之TY夾好玻璃檢知
           public const int _DI_SPIN_CLAMP_TY_EXTEND_SENSOR_ = 70;              // 旋轉_夾片機構之TY汽缸伸出檢測
           public const int _DI_SPIN_CLAMP_TY_TRIM_SENSOR_ = 71;                    // 旋轉_夾片機構之TY汽缸縮回檢測
           public const int _DI_SPIN_GLASS_SENSOR_ = 72;                                       // 旋轉_玻璃檢測
           public const int _DI_SPIN_TZ_0_SENSOR_ = 73;                                          // 旋轉_TZ_0度位置檢測
           public const int _DI_SPIN_TZ_180_SENSOR_ = 74;                                      // 旋轉_TZ_180度位置檢測

           public const int _DI_SPIN_VACUUM1_ON_ = 80;                                        // 旋轉_第一組吸真空
           public const int _DI_SPIN_VACUUM1_OFF_ = 81;                                       // 旋轉_第一組破真空
           public const int _DI_SPIN_VACUUM2_ON_ = 82;                                        // 旋轉_第二組吸真空
           public const int _DI_SPIN_VACUUM2_OFF_ = 83;                                       // 旋轉_第二組破真空

           public const int _DI_TURN_TOP_GLASS_SENSOR_ = 96;                               // 翻轉_上方_玻璃檢測
           public const int _DI_TURN_TOP_PIN_UP_SENSOR_ = 97;                               // 翻轉_上方_頂PIN上升檢測
           public const int _DI_TURN_TOP_PIN_DOWN_SENSOR_ = 98;                               // 翻轉_上方_頂PIN下降檢測
           public const int _DI_TURN_TOP_VACUUM1_ON_ = 99;                               // 翻轉_上方_第一組吸嘴吸真空
           public const int _DI_TURN_TOP_VACUUM1_OFF_ = 100;                               // 翻轉_上方_第一組吸嘴破真空
           public const int _DI_TURN_TOP_VACUUM2_ON_ = 101;                               // 翻轉_上方_第二組吸嘴吸真空
           public const int _DI_TURN_TOP_VACUUM2_OFF_ = 102;                               // 翻轉_上方_第二組吸嘴破真空
           public const int _DI_TURN_BOTTOM_GLASS_SENSOR_ = 103;                               // 翻轉_下方_玻璃檢測
           public const int _DI_TURN_BOTTOM_PIN_UP_SENSOR_ = 104;                               // 翻轉_下方_頂PIN上升檢測
           public const int _DI_TURN_BOTTOM_PIN_DOWN_SENSOR_ = 105;                               // 翻轉_下方_頂PIN下降檢測
           public const int _DI_TURN_BOTTOM_VACUUM1_ON_ = 106;                               // 翻轉_下方_第一組吸嘴吸真空
           public const int _DI_TURN_BOTTOM_VACUUM1_OFF_ = 107;                               // 翻轉_下方_第一組吸嘴破真空
           public const int _DI_TURN_BOTTOM_VACUUM2_ON_ = 108;                               // 翻轉_下方_第二組吸嘴吸真空
           public const int _DI_TURN_BOTTOM_VACUUM2_OFF_ = 109;                               // 翻轉_下方_第二組吸嘴破真空

           public const int _DI_TURN_0_SENSOR_ = 112;                               // 翻轉_0度位置檢測
           public const int _DI_TURN_180_SENSOR_ = 113;                               // 翻轉_180度位置檢測
           public const int _DI_TURN_SPIN_SENSOR_ = 114;                               // 翻轉_與旋轉取放片位置檢測
           public const int _DI_TURN_ROBOT_SENSOR_ = 115;                               // 翻轉_與ROBOT取放片高度位置檢測
           public const int _DI_TURN_TURN_SENSOR_ = 116;                               // 翻轉_之可轉動高度位置檢測
           public const int _DI_TURN_STAGE_SENSOR_ = 117;                               // 翻轉_與平台取放片位置檢測
           public const int _DI_TURN_TOP_VACUUM1_EXTEND_ = 118;                               // 翻轉_上方大尺寸吸嘴汽缸_1伸出
           public const int _DI_TURN_TOP_VACUUM1_SHRINK_ = 119;                               // 翻轉_上方大尺寸吸嘴汽缸_1縮回
           public const int _DI_TURN_TOP_VACUUM2_EXTEND_ = 120;                               // 翻轉_上方大尺寸吸嘴汽缸_2伸出
           public const int _DI_TURN_TOP_VACUUM2_SHRINK_ = 121;                               // 翻轉_上方大尺寸吸嘴汽缸_2縮回
           public const int _DI_TURN_BOTTOM_VACUUM1_EXTEND_ = 122;                               // 翻轉_下方大尺寸吸嘴汽缸_1伸出
           public const int _DI_TURN_BOTTOM_VACUUM1_SHRINK_ = 123;                               // 翻轉_下方大尺寸吸嘴汽缸_1縮回
           public const int _DI_TURN_BOTTOM_VACUUM2_EXTEND_ = 124;                               // 翻轉_下方大尺寸吸嘴汽缸_2伸出
           public const int _DI_TURN_BOTTOM_VACUUM2_SHRINK_ = 125;                               // 翻轉_下方大尺寸吸嘴汽缸_2縮回

           public const int _DI_MAIN_LASER_STATUS_ = 128;                                 // 雷射狀態(B接點)
           public const int _DI_MAIN_SPIN_IRON_ = 129;                                           // 靜電消除棒ALARM檢測_旋轉
           public const int _DI_MAIN_STAGE_IRON_ = 130;                                       // 靜電消除棒ALARM檢測_平台
           public const int _DI_MAIN_IRON_ = 131;                                                     // 靜電消除棒動作檢測
           public const int _DI_MAIN_PRESSURE_STAGE_ = 132;                           // 表頭正壓力檢測(避震平台)
           public const int _DI_MAIN_PRESSURE_IRON_ = 133;                                // 表頭正壓力檢測(靜電消除棒與破真空)
           public const int _DI_MAIN_PRESSURE_VACUUM_ = 134;                      // 表頭負壓力檢測(吸真空)
           public const int _DI_MAIN_POWER_STATUS_ = 135;                      // Power On/Off狀態(A接點)
           public const int _DI_MAIN_EMERGANCY_STOP_ = 136;                      // Emergancy Stop(A接點)
           public const int _DI_MAIN_SAFETYDOOR_SENSOR_ = 137;                      // 安全門檢測（所有安全門串接搭配PCB119）
           public const int _DI_MAIN_ALARM_SENSOR_ = 138;                      // 偵煙ALARM檢測
           public const int _DI_MAIN_MC2_STATUS_ = 139;                      // MC2接點狀態(A接點)
           public const int _DI_MAIN_MC2_HEAT_STATUS_ = 140;                      // MC2積熱電驛跳脫狀態(A接點)

           public const int _DI_MAIN_FAN_ALARM1_ = 144;                      // 風扇Alarm-1
           public const int _DI_MAIN_FAN_ALARM2_ = 145;                      // 風扇Alarm-2
           public const int _DI_MAIN_FAN_ALARM3_ = 146;                      // 風扇Alarm-3
           public const int _DI_MAIN_FAN_ALARM4_ = 147;                      // 風扇Alarm-4
           public const int _DI_MAIN_FAN_ALARM5_ = 148;                      // 風扇Alarm-5
           public const int _DI_MAIN_FAN_ALARM6_ = 149;                      // 風扇Alarm-6

           public const int _DI_MOTOR_S_ALARM_ = 160;                      // S軸_馬達告警
           public const int _DI_MOTOR_G_ALARM_ = 161;                      // G軸_馬達告警
           public const int _DI_MOTOR_L_ALARM_ = 162;                      // L軸_馬達告警
           public const int _DI_MOTOR_Z_ALARM_ = 163;                      // Z軸_馬達告警
           public const int _DI_MOTOR_QS1_ALARM_ = 164;                      // QS1軸_馬達告警
           public const int _DI_MOTOR_QG1_ALARM_ = 165;                      // QG1軸_馬達告警
           public const int _DI_MOTOR_QS2_ALARM_ = 166;                      // QS2軸_馬達告警
           public const int _DI_MOTOR_QG2_ALARM_ = 167;                      // QG2軸_馬達告警
           public const int _DI_MOTOR_QS3_ALARM_ = 168;                      // QS3軸_馬達告警
           public const int _DI_MOTOR_QG3_ALARM_ = 169;                      // QG3軸_馬達告警
           public const int _DI_MOTOR_QS4_ALARM_ = 170;                      // QS4軸_馬達告警
           public const int _DI_MOTOR_QG4_ALARM_ = 171;                      // QG4軸_馬達告警
           public const int _DI_MOTOR_QS5_ALARM_ = 172;                      // QS5軸_馬達告警
           public const int _DI_MOTOR_QG5_ALARM_ = 173;                      // QG5軸_馬達告警
           public const int _DI_MOTOR_QS6_ALARM_ = 174;                      // QS6軸_馬達告警
           public const int _DI_MOTOR_QG6_ALARM_ = 175;                      // QG6軸_馬達告警
           public const int _DI_MOTOR_QS7_ALARM_ = 176;                      // QS7軸_馬達告警
           public const int _DI_MOTOR_QG7_ALARM_ = 177;                      // QG7軸_馬達告警
           public const int _DI_MOTOR_SA1_ALARM_ = 178;                      // SA1軸_馬達告警
           public const int _DI_MOTOR_SA2_ALARM_ = 179;                      // SA2軸_馬達告警
           public const int _DI_MOTOR_C1C2_ALARM_ = 180;                      // C1C2軸_馬達告警
           public const int _DI_MOTOR_TS_ALARM_ = 181;                      // TS軸_馬達告警
           public const int _DI_MOTOR_TG_ALARM_ = 182;                      // TG軸_馬達告警
           public const int _DI_MOTOR_TZ_ALARM_ = 183;                      // TZ軸_馬達告警
           public const int _DI_MOTOR_RT_ALARM_ = 184;                      // RT軸_馬達告警
           public const int _DI_MOTOR_RUD_ALARM_ = 185;                      // RUD軸_馬達告警
           public const int _DI_MOTOR_B1_ALARM_ = 186;                      // B1軸_馬達警告
           public const int _DI_MOTOR_B2_ALARM_ = 187;                      // B2軸_馬達警告
           public const int _DI_MOTOR_T_ALARM_ = 188;                      // T軸馬達警告
           public const int _DI_MOTOR_RZ_ALARM_ = 189;                      // RZ軸馬達警告

           public const int _DI_TEACHBOX_AF_AUTOFOCUS_ = 192;                      // 操作盒_AF自動對焦檢測點位
           public const int _DI_TEACHBOX_AF_UPWARD_ = 193;                      // 操作盒_AF往上移動檢測點位
           public const int _DI_TEACHBOX_AF_DOWNWARD_ = 194;                      // 操作盒_AF往下移動檢測點位
           public const int _DI_TEACHBOX_SLOW_BTN_ = 195;                      // 操作盒_慢速按鈕
           public const int _DI_TEACHBOX_MIDDLE_BTN_ = 196;                      // 操作盒_中速按鈕
           public const int _DI_TEACHBOX_FAST_BTN_ = 197;                      // 操作盒_快速按鈕
           public const int _DI_TEACHBOX_STICK_UP_ = 198;                      // 操作盒_搖桿往上移動
           public const int _DI_TEACHBOX_STICK_DOWN_ = 199;                      // 操作盒_搖桿往下移動
           public const int _DI_TEACHBOX_STICK_LEFT_ = 200;                      // 操作盒_搖桿往左移動
           public const int _DI_TEACHBOX_STICK_RIGHT_ = 201;                      // 操作盒_搖桿往右移動               
           public const int _DI_TEACHBOX_FROMLIGHT_LIGHTER_ = 202;                      // 操作盒_正光源調亮             
           public const int _DI_TEACHBOX_FROMLIGHT_DARKER = 203;                      // 操作盒_正光源調滅          
           public const int _DI_TEACHBOX_BACKLIGHT_LIGHTER_ = 204;                      // 操作盒_背光源調亮          
           public const int _DI_TEACHBOX_BACKLIGHT_DARKER = 205;                      // 操作盒_背光源調滅          
           public const int _DI_TEACHBOX_OPERATE_BTN_ = 206;                      // 操作盒_Operate按鈕
           public const int _DI_TEACHBOX_LASE_RFIRE_BTN_ = 207;                      // 操作盒_Laser Fire
           public const int _DI_TEACHBOX_LASER_STOP_BTN_ = 208;                      // 操作盒_Laser Stop
           public const int _DI_TEACHBOX_LENS_X2_ = 209;                      // 操作盒_物件倍率指示燈 X2
           public const int _DI_TEACHBOX_LENS_X5_ = 210;                      // 操作盒_物件倍率指示燈 X5 
           public const int _DI_TEACHBOX_LENS_X20_ = 211;                      // 操作盒_物件倍率指示燈 X20
           public const int _DI_TEACHBOX_LENS_X50_ = 212;                      // 操作盒_物件倍率指示燈 X50
           public const int _DI_TEACHBOX_QUCIK_ = 213;                     // 操作盒_Quick(Empty)
           public const int _DI_TEACHBOX_BUZZER_ = 214;                      // 操作盒_Buzzer
           public const int _DI_TEACHBOX_TEACH_XY_ = 215;                      // 操作盒_Teach OXY
           public const int _DI_TEACHBOX_TEACH_ALIGNMENT_ = 216;                      // 操作盒_Teach Alignment
           public const int _DI_TEACHBOX_QUICK_CCD_ = 217;                      // 操作盒_Quick CCD
           public const int _DI_TEACHBOX_SAFETYDOOR_BYPASS_ = 218;                      // 操作盒_安全門bypass                  
       }

       public struct DO
       {
           public const int _DO_STAGE_VACUUM1_ON_ = 0;                      // 平台_吸真空1
           public const int _DO_STAGE_VACUUM1_OFF_ = 1;                      // 平台_破真空1
           public const int _DO_STAGE_VACUUM2_ON_ = 2;                      // 平台_吸真空2
           public const int _DO_STAGE_VACUUM2_OFF_ = 3;                      // 平台_破真空2
           public const int _DO_STAGE_VACUUM3_ON_ = 4;                      // 平台_吸真空3
           public const int _DO_STAGE_VACUUM3_OFF_ = 5;                      // 平台_破真空3
           public const int _DO_STAGE_VACUUM4_ON_ = 6;                      // 平台_吸真空4
           public const int _DO_STAGE_VACUUM4_OFF_ = 7;                      // 平台_破真空4
           public const int _DO_STAGE_VACUUM5_ON_ = 8;                      // 平台_吸真空5
           public const int _DO_STAGE_VACUUM5_OFF_ = 9;                      // 平台_破真空5
           public const int _DO_STAGE_VACUUM6_ON_ = 10;                      // 平台_吸真空6
           public const int _DO_STAGE_VACUUM6_OFF_ = 11;                      // 平台_破真空6
           public const int _DO_STAGE_VACUUM7_ON_ = 12;                      // 平台_吸真空7
           public const int _DO_STAGE_VACUUM7_OFF_ = 13;                      // 平台_破真空7
           public const int _DO_STAGE_VACUUM8_ON_ = 14;                      // 平台_吸真空8
           public const int _DO_STAGE_VACUUM8_OFF_ = 15;                      // 平台_破真空8
           public const int _DO_STAGE_VACUUM9_ON_ = 16;                      // 平台_吸真空9
           public const int _DO_STAGE_VACUUM9_OFF_ = 17;                      // 平台_破真空9
           public const int _DO_STAGE_QZ1_UP_ = 18;                             // 平台_QZ1汽缸上升
           public const int _DO_STAGE_QZ1_DOWN_ = 19;                      // 平台_QZ1汽缸下降
           public const int _DO_STAGE_QZ2_UP_ = 20;                      // 平台_QZ2汽缸上升
           public const int _DO_STAGE_QZ2_DOWN_ = 21;                      // 平台_QZ2汽缸下降
           public const int _DO_STAGE_QZ3_UP_ = 22;                      // 平台_QZ3汽缸上升
           public const int _DO_STAGE_QZ3_DOWN_ = 23;                      // 平台_QZ3汽缸下降
           public const int _DO_STAGE_QZ4_UP_ = 24;                      // 平台_QZ4汽缸上升
           public const int _DO_STAGE_QZ4_DOWN_ = 25;                      // 平台_QZ4汽缸下降
           public const int _DO_STAGE_QZ5_UP_ = 26;                      // 平台_QZ5汽缸上升
           public const int _DO_STAGE_QZ5_DOWN_ = 27;                      // 平台_QZ5汽缸下降
           public const int _DO_STAGE_QZ6_UP_ = 28;                      // 平台_QZ6汽缸上升
           public const int _DO_STAGE_QZ6_DOWN_ = 29;                      // 平台_QZ6汽缸下降
           public const int _DO_STAGE_QZ7_UP_ = 30;                      // 平台_QZ7汽缸上升
           public const int _DO_STAGE_QZ7_DOWN_ = 31;                      // 平台_QZ7汽缸下降

           // 背光L軸偏光板切換_汽缸伸出位置1_平台
           // 背光L軸偏光板切換_汽缸縮回位置1_平台
           // 背光L軸偏光板切換_汽缸伸出位置2_平台
           // 背光L軸偏光板切換_汽缸縮回位置2_平台
           // 中間支撐BAR模組_汽缸伸出_平台
           // 中間支撐BAR模組_汽缸縮回_平台
           // Power meter 模組_汽缸伸出_平台
           // Power meter 模組_汽缸縮回_平台

           public const int _DO_TEACHBOX_TEACH_OXY_ = 45;                      // 操作盒_Teach OXY
           public const int _DO_TEACHBOX_ALIGNMENT_ = 46;              // 操作盒_Teach Alignment
           public const int _DO_TEACHBOX_QUICK_CCD_ = 47;              // 操作盒_Quick CCD
           public const int _DO_TEACHBOX_SLOW_BTN_ = 48;              // 操作盒_慢速按鈕控制
           public const int _DO_TEACHBOX_MIDDLE_BTN_ = 49;              // 操作盒_中速按鈕控制_操作盒
           public const int _DO_TEACHBOX_FAST_BTN_ = 50;              // 操作盒_快速按鈕控制_操作盒
           public const int _DO_TEACHBOX_AF_ = 51;                         // 操作盒_AF自動對焦控制點位
           public const int _DO_TEACHBOX_AF_UPWARD_ = 52;              // 操作盒_AF往上移動控制點位
           public const int _DO_TEACHBOX_AF_DOWNWARD_ = 53;              // 操作盒_AF往下移動控制點位
           public const int _DO_TEACHBOX_OPERATE_BTN_ = 54;              // 操作盒_Operate按鈕
           public const int _DO_TEACHBOX_LASER_FIRE_ = 55;              // 操作盒_Laser Fire
           public const int _DO_TEACHBOX_LASER_STOP_ = 56;              // 操作盒_Laser Stop
           public const int _DO_TEACHBOX_LENS_X2_ = 57;              // 操作盒_物件倍率指示燈 X2
           public const int _DO_TEACHBOX_LENS_X5_ = 58;              // 操作盒_物件倍率指示燈 X5
           public const int _DO_TEACHBOX_LENS_X20_ = 59;              // 操作盒_物件倍率指示燈 X20
           public const int _DO_TEACHBOX_LENS_X50_ = 60;              // 操作盒_物件倍率指示燈 X50
           public const int _DO_TEACHBOX_QUICK_ = 61;              // 操作盒_Quick(Empty)
           public const int _DO_TEACHBOX_BUZZER_ = 62;              // 操作盒_Buzzer

           public const int _DO_SPIN_TX_EXTEND_ = 64;              // 旋轉_夾片機構之TX汽缸伸出
           public const int _DO_SPIN_TX_TRIM_ = 65;              // 旋轉_夾片機構之TX汽缸縮回
           public const int _DO_SPIN_TY_EXTEND_ = 66;              // 旋轉_夾片機構之TY汽缸伸出
           public const int _DO_SPIN_TY_TRIM_ = 67;              // 旋轉_夾片機構之TY汽缸縮回
           public const int _DO_SPIN_VACUUM1_ON_ = 68;              // 旋轉_第一組吸嘴吸真空
           public const int _DO_SPIN_VACUUM1_OFF_ = 69;              // 旋轉_第一組吸嘴破真空
           public const int _DO_SPIN_VACUUM2_ON_ = 70;              // 旋轉_第二組吸嘴吸真空
           public const int _DO_SPIN_VACUUM2_OFF_ = 71;              // 旋轉_第二組吸嘴破真空

           public const int _DO_TURN_TOP_PIN_UP_ = 96;              // 翻轉_上方_頂PIN上升
           public const int _DO_TURN_TOP_PIN_DOWN_ = 97;              // 翻轉_上方_頂PIN下降
           public const int _DO_TURN_TOP_VACUUM1_ON_ = 98;              // 翻轉_上方_第一組吸嘴吸真空
           public const int _DO_TURN_TOP_VACUUM1_OFF_ = 99;              // 翻轉_上方_第一組吸嘴破真空
           public const int _DO_TURN_TOP_VACUUM2_ON_ = 100;              // 翻轉_上方_第二組吸嘴吸真空
           public const int _DO_TURN_TOP_VACUUM2_OFF_ = 101;              // 翻轉_上方_第二組吸嘴破真空

           public const int _DO_TURN_BOTTOM_PIN_UP_ = 104;              // 翻轉_下方_頂PIN上升
           public const int _DO_TURN_BOTTOM_PIN_DOWN_ = 105;              // 翻轉_下方_頂PIN下降
           public const int _DO_TURN_BOTTOM_VACUUM1_ON_ = 106;              // 翻轉_下方_第一組吸嘴吸真空
           public const int _DO_TURN_BOTTOM_VACUUM1_OFF_ = 107;              // 翻轉_下方_第一組吸嘴破真空
           public const int _DO_TURN_BOTTOM_VACUUM2_ON_ = 108;              // 翻轉_下方_第二組吸嘴吸真空
           public const int _DO_TURN_BOTTOM_VACUUM2_OFF_ = 109;              // 翻轉_下方_第二組吸嘴破真空

           public const int _DI_TURN_TOP_VACUUM_EXTEND_ = 112;              // 上方大尺寸吸嘴汽缸伸出
           public const int _DI_TURN_TOP_VACUUM_TRIM_ = 113;              // 上方大尺寸吸嘴汽缸縮回
           public const int _DI_TURN_BOTTOM_VACUUM_EXTEND_ = 114;              // 下方大尺寸吸嘴汽缸伸出
           public const int _DI_TURN_BOTTOM_VACUUM_TRIM_ = 115;              // 下方大尺寸吸嘴汽缸縮回

           public const int _DO_MAIN_LASER_FIRE_ = 128;              // 雷射擊發
           public const int _DO_MAIN_AUTOFOCUS_ = 129;              // 自動對焦-AF
           public const int _DO_MAIN_Z_UPWARD_ = 130;              // 自動對焦-Z Up
           public const int _DO_MAIN_Z_DOWNWARD_ = 131;              // 自動對焦-Z Down
           public const int _DO_MAIN_IRON_ = 132;              // 靜電消除棒吹之氣缸控制
           public const int _DO_MAIN_IRON_REMOTEON_STAGE_ = 133;              // 靜電消除棒Remote ON_平台(CR)
           public const int _DO_MAIN_IRON_SAFETYDOOR_ = 134;              // 雷射擊發不檢測安全門之控制(CR)
           public const int _DO_MAIN_ALARM_RED_ = 135;              // 紅燈_警示燈
           public const int _DO_MAIN_ALARM_YELLOW_ = 136;              // 黃燈_警示燈
           public const int _DO_MAIN_ALARM_GREEN_ = 137;              // 綠燈_警示燈
           public const int _DO_MAIN_ALARM_BUZZER_ = 138;              // 蜂鳴器_警示燈
           //public const int _DO_MAIN_ALARM_BUZZER_ = 139;              // 靜電消除棒吹之氣缸控制
           public const int _DO_MAIN_IRON_REMOTEON_SPIN_ = 140;              // 靜電消除棒Remote ON_旋轉(CR)

           public const int _DO_MOTOR_S_ON_ = 160;              // S軸_馬達激磁
           public const int _DO_MOTOR_G_ON_ = 161;              // G軸_馬達激磁
           public const int _DO_MOTOR_L_ON_ = 162;              // L軸_馬達激磁
           public const int _DO_MOTOR_Z_ON_ = 163;              // Z軸_馬達激磁
           public const int _DO_MOTOR_QS1_ON_ = 164;              // QS1軸_馬達激磁
           public const int _DO_MOTOR_QG1_ON_ = 165;              // QG1軸_馬達激磁
           public const int _DO_MOTOR_QS2_ON_ = 166;              // QS2軸_馬達激磁
           public const int _DO_MOTOR_QG2_ON_ = 167;              // QG2軸_馬達激磁
           public const int _DO_MOTOR_QS3_ON_ = 168;              // QS3軸_馬達激磁
           public const int _DO_MOTOR_QG3_ON_ = 169;              // QG3軸_馬達激磁
           public const int _DO_MOTOR_QS4_ON_ = 170;              // QS4軸_馬達激磁
           public const int _DO_MOTOR_QG4_ON_ = 171;              // QG4軸_馬達激磁
           public const int _DO_MOTOR_QS5_ON_ = 172;              // QS5軸_馬達激磁
           public const int _DO_MOTOR_QG5_ON_ = 173;              // QG5軸_馬達激磁
           public const int _DO_MOTOR_QS6_ON_ = 174;              // QS6軸_馬達激磁
           public const int _DO_MOTOR_QG6_ON_ = 175;              // QG6軸_馬達激磁
           public const int _DO_MOTOR_QS7_ON_ = 176;              // QS7軸_馬達激磁
           public const int _DO_MOTOR_QG7_ON_ = 177;              // QG7軸_馬達激磁
           public const int _DO_MOTOR_SA1_ON_ = 178;              // SA1軸_馬達激磁
           public const int _DO_MOTOR_SA2_ON_ = 179;              // SA2軸_馬達激磁
           public const int _DO_MOTOR_C1C2_ON_ = 180;              // C1C2軸_馬達激磁
           public const int _DO_MOTOR_TS_ON_ = 181;              // TS軸_馬達激磁
           public const int _DO_MOTOR_TG_ON_ = 182;              // TG軸_馬達激磁
           public const int _DO_MOTOR_TZ_ON_ = 183;              // TZ軸_馬達激磁
           public const int _DO_MOTOR_RT_ON_ = 184;              // RT軸_馬達激磁
           public const int _DO_MOTOR_RUD_ON_ = 185;              // RUD軸_馬達激磁
           public const int _DO_MOTOR_B1_ON_ = 186;              // B1軸_馬達激磁
           public const int _DO_MOTOR_B2_ON_ = 187;              // B2軸_馬達激磁
           public const int _DO_MOTOR_RUD_BRAKE_RELEASE_ = 188;              // RUD軸馬達煞車釋放
           public const int _DO_MOTOR_RT_BRAKE_RELEASE_ = 189;              // RT軸馬達煞車釋放
           public const int _DO_MOTOR_T_ON_ = 190;              // T軸馬達激磁
           public const int _DO_MOTOR_RZ_ON_ = 191;              // RZ軸馬達激磁


       }

       public struct VIO
       {
           public const int _VIO_SAFEDOOR_ENABLE_ = 0;               // 安全門不檢測之旗標
           public const int _VIO_PAUSE_ = 1;                             // Stage平台動作程式中斷旗標
           public const int _VIO_STOP_ = 2;                               // 停止所有工作
           public const int _VIO_Quick_Use_Flag_ = 3;              //點燈使用之旗標
           public const int _VIO_LaserCommunction_ = 4;              //1->通訊中,0->通訊完畢
           public const int _VIO_MotorStop_ = 5;              //翻轉機構與交換片動作程式中斷旗標
           public const int _VIO_Reverse_MotorStop_ = 6;              //旋轉機構與交換片動作程式中斷旗標

           // FSP

           public const int _VIO_INITIALIAL_FINISH_ = 6;              // Cancel FSP 1
           public const int _VIO_CANCEL_FSP_HOME_ = 6;              // Cancel FSP 1
           public const int _VIO_CANCEL_FSP_TURNUNIT_ = 6;              // Cancel FSP 1
           public const int _VIO_CANCEL_FSP_STAGE_ = 6;              // Cancel FSP 2
           public const int _VIO_CANCEL_FSP_QUICK_ = 6;              // Cancel FSP 3
           public const int _VIO_CANCEL_FSP_TEACHBOX_ = 6;              // Cancel FSP 4
           public const int _VIO_CANCEL_FSP5_ = 6;              // Cancel FSP 5
           public const int _VIO_CANCEL_FSP6_ = 6;              // Cancel FSP 6
           public const int _VIO_CANCEL_FSP7_ = 6;              // Cancel FSP 7

           //------------------------------------------------------------------------------------操作盒切換
           public const int _VIO_TeachBoxTAXY_Enable_ = 6;              //操作盒-TeachTXY使用(TurnUnit)
           public const int _VIO_TeachBypass_SafeDoor_ = 6;              //Teach產品時Bypass安全門檢測
           public const int _VIO_TeachBoxEnable_ = 6;              //操作盒-TeachBox使用
           public const int _VIO_TeachBoxCLAMPEnable_ = 6;              //操作盒-TeachClamp使用
           public const int _VIO_TeachBoxQUICK1_Enable_ = 6;              //操作盒-TeachQuick1使用
           public const int _VIO_TeachBoxQUICK2_Enable_ = 6;              //操作盒-TeachQuick2使用
           public const int _VIO_TeachBoxQUICK3_Enable_ = 6;              //操作盒-TeachQuick3使用
           public const int _VIO_TeachBoxQUICK4_Enable_ = 6;              //操作盒-TeachQuick4使用
           public const int _VIO_TeachBoxQUICK5_Enable_ = 6;              //操作盒-TeachQuick5使用
           public const int _VIO_TeachBoxQUICK6_Enable_ = 6;              //操作盒-TeachQuick6使用
           public const int _VIO_TeachBoxQUICK7_Enable_ = 6;              //操作盒-TeachQuick7使用

           public const int _VIO_TeachBoxVCR_Enable_ = 6;              //操作盒-TeachVCR使用
           public const int _VIO_TeachBoxAlignment_Enable_ = 6;              //操作盒-TeachAlignment使用

           public const int _VIO_2XLenUseFlag_ = 6;              //使用2X鏡頭
           public const int _VIO_5XLenUseFlag_ = 6;              //使用5X鏡頭
           public const int _VIO_20XLenUseFlag_ = 6;              //使用20X鏡頭
           public const int _VIO_50XLenUseFlag_ = 6;              //使用50X鏡頭

           // TeachBox Trigger
           public const int _VIO_TRIG_AF_AUTOFOCUS_ = 192;                      // 操作盒_AF自動對焦檢測點位
           public const int _VIO_TRIG_AF_UPWARD_ = 193;                      // 操作盒_AF往上移動檢測點位
           public const int _VIO_TRIG_TEACHBOX_AF_DOWNWARD_ = 194;                      // 操作盒_AF往下移動檢測點位
           public const int _VIO_TRIG_TEACHBOX_SLOW_BTN_ = 195;                      // 操作盒_慢速按鈕
           public const int _VIO_TRIG_TEACHBOX_MIDDLE_BTN_ = 196;                      // 操作盒_中速按鈕
           public const int _VIO_TRIG_TEACHBOX_FAST_BTN_ = 197;                      // 操作盒_快速按鈕
           public const int _VIO_TRIG_STICK_UP_ = 198;                      // 操作盒_搖桿往上移動
           public const int _VIO_TRIG_STICK_DOWN_ = 199;                      // 操作盒_搖桿往下移動
           public const int _VIO_TRIG_STICK_LEFT_ = 200;                      // 操作盒_搖桿往左移動
           public const int _VIO_TRIG_STICK_RIGHT_ = 201;                      // 操作盒_搖桿往右移動               
           public const int _VIO_TRIG_FROMLIGHT_LIGHTER_ = 202;                      // 操作盒_正光源調亮             
           public const int _VIO_TRIG_FROMLIGHT_DARKER_ = 203;                      // 操作盒_正光源調滅          
           public const int _VIO_TRIG_BACKLIGHT_LIGHTER_ = 204;                      // 操作盒_背光源調亮          
           public const int _VIO_TRIG_BACKLIGHT_DARKER_ = 205;                      // 操作盒_背光源調滅          
           public const int _VIO_TRIG_OPERATE_BTN_ = 206;                      // 操作盒_Operate按鈕
           public const int _VIO_TRIG_LASE_RFIRE_BTN_ = 207;                      // 操作盒_Laser Fire
           public const int _VIO_TRIG_LASER_STOP_BTN_ = 208;                      // 操作盒_Laser Stop
           public const int _VIO_TRIG_LENS_X2_ = 209;                      // 操作盒_物件倍率指示燈 X2
           public const int _VIO_TRIG_LENS_X5_ = 210;                      // 操作盒_物件倍率指示燈 X5 
           public const int _VIO_TRIG_LENS_X20_ = 211;                      // 操作盒_物件倍率指示燈 X20
           public const int _VIO_TRIG_LENS_X50_ = 212;                      // 操作盒_物件倍率指示燈 X50
           public const int _VIO_TRIG_QUCIK_ = 213;                     // 操作盒_Quick(Empty)
           public const int _VIO_TRIG_BUZZER_ = 214;                      // 操作盒_Buzzer
           public const int _VIO_TRIG_TEACH_XY_ = 215;                      // 操作盒_Teach OXY
           public const int _VIO_TRIG_TEACH_ALIGNMENT_ = 216;                      // 操作盒_Teach Alignment
           public const int _VIO_TRIG_QUICK_CCD_ = 217;                      // 操作盒_Quick CCD
           public const int _VIO_TRIG_SAFETYDOOR_BYPASS_ = 218;                      // 操作盒_安全門bypass

           // Trigger Enable
           public const int _VIO_TRIG_AF_AUTOFOCUS_ENABLE_ = 192;                      // 操作盒_AF自動對焦檢測點位
           public const int _VIO_TRIG_AF_UPWARD_ENABLE_ = 193;                      // 操作盒_AF往上移動檢測點位
           public const int _VIO_TRIG_TEACHBOX_AF_DOWNWARD_ENABLE_ = 194;                      // 操作盒_AF往下移動檢測點位
           public const int _VIO_TRIG_TEACHBOX_SLOW_BTN_ENABLE_ = 195;                      // 操作盒_慢速按鈕
           public const int _VIO_TRIG_TEACHBOX_MIDDLE_BTN_ENABLE_ = 196;                      // 操作盒_中速按鈕
           public const int _VIO_TRIG_TEACHBOX_FAST_BTN_ENABLE_ = 197;                      // 操作盒_快速按鈕
           public const int _VIO_TRIG_STICK_UP_ENABLE_ = 198;                      // 操作盒_搖桿往上移動
           public const int _VIO_TRIG_STICK_DOWN_ENABLE_ = 199;                      // 操作盒_搖桿往下移動
           public const int _VIO_TRIG_STICK_LEFT_ENABLE_ = 200;                      // 操作盒_搖桿往左移動
           public const int _VIO_TRIG_STICK_RIGHT_ENABLE_ = 201;                      // 操作盒_搖桿往右移動               
           public const int _VIO_TRIG_FROMLIGHT_LIGHTER_ENABLE_ = 202;                      // 操作盒_正光源調亮             
           public const int _VIO_TRIG_FROMLIGHT_DARKER_ENABLE = 203;                      // 操作盒_正光源調滅          
           public const int _VIO_TRIG_BACKLIGHT_LIGHTER_ENABLE_ = 204;                      // 操作盒_背光源調亮          
           public const int _VIO_TRIG_BACKLIGHT_DARKER_ENABLE_ = 205;                      // 操作盒_背光源調滅          
           public const int _VIO_TRIG_OPERATE_BTN_ENABLE_ = 206;                      // 操作盒_Operate按鈕
           public const int _VIO_TRIG_LASE_RFIRE_BTN_ENABLE_ = 207;                      // 操作盒_Laser Fire
           public const int _VIO_TRIG_LASER_STOP_BTN_ENABLE_ = 208;                      // 操作盒_Laser Stop
           public const int _VIO_TRIG_LENS_X2_ENABLE_ = 209;                      // 操作盒_物件倍率指示燈 X2
           public const int _VIO_TRIG_LENS_X5_ENABLE_ = 210;                      // 操作盒_物件倍率指示燈 X5 
           public const int _VIO_TRIG_LENS_X20_ENABLE_ = 211;                      // 操作盒_物件倍率指示燈 X20
           public const int _VIO_TRIG_LENS_X50_ENABLE_ = 212;                      // 操作盒_物件倍率指示燈 X50
           public const int _VIO_TRIG_QUCIK_ENABLE_ = 213;                     // 操作盒_Quick(Empty)
           public const int _VIO_TRIG_BUZZER_ENABLE_ = 214;                      // 操作盒_Buzzer
           public const int _VIO_TRIG_TEACH_XY_ENABLE_ = 215;                      // 操作盒_Teach OXY
           public const int _VIO_TRIG_TEACH_ALIGNMENT_ENABLE_ = 216;                      // 操作盒_Teach Alignment
           public const int _VIO_TRIG_QUICK_CCD_ENABLE_ = 217;                      // 操作盒_Quick CCD
           public const int _VIO_TRIG_SAFETYDOOR_BYPASS_ENABLE_ = 218;                      // 操作盒_安全門bypass
    
       }

       public struct Global
       {
           public const int _G_MoveSpeed_ = 0; // 點對點-移動速度
           public const int _G_MoveACC_ = 0; // 點對點-加速度
           public const int _G_MoveDEC_ = 0; // 點對點-減速度
           public const int _G_C1C2MoveSpeed_ = 0; //C1C2軸-移動速度
           public const int _G_C1C2MoveACC_ = 0; //C1C2軸-加速度
           public const int _G_C1C2MoveDEC_ = 0; //C1C2軸-減速度
           public const int _G_SA1MoveSpeed_ = 0; //C1C2軸-移動速度           
           public const int _G_SA1MoveACC_ = 0; //SA1軸-加速度
           public const int _G_SA1MoveDEC_ = 0; //SA1軸-減速度
           public const int _G_SA2MoveSpeed_ = 0; //C1C2軸-移動速度
           public const int _G_SA2MoveACC_ = 0; //SA2軸-加速度
           public const int _G_SA2MoveDEC_ = 0; //SA2軸-減速度
           public const int _G_TSMoveSpeed_ = 0; //TS軸-移動速度
           public const int _G_TSMoveACC_ = 0; //TS軸-加速度
           public const int _G_TSMoveDEC_ = 0; //TS軸-減速度
           public const int _G_TGMoveSpeed_ = 0; //TG軸-移動速度
           public const int _G_TGMoveACC_ = 0; //TG軸-加速度
           public const int _G_TGMoveDEC_ = 0; //TG軸-減速度
           public const int _G_TZMoveSpeed_ = 0; //TG軸-移動速度
           public const int _G_TZMoveACC_ = 0; //TZ軸-加速度
           public const int _G_TZMoveDEC_ = 0; //TZ軸-減速度
           public const int _G_RTMoveSpeed_ = 0; //RT軸-移動速度
           public const int _G_RTMoveACC_ = 0; //RT軸-加速度
           public const int _G_RTMoveDEC_ = 0; //RT軸-減速度
           public const int _G_RUDMoveSpeed_ = 0; //RUD軸-移動速度
           public const int _G_RUDMoveACC_ = 0; //RUD軸-加速度
           public const int _G_RUDMoveDEC_ = 0; //RUD軸-減速度
           public const int _G_TMoveSpeed_ = 0; //T軸-移動速度
           public const int _G_TMoveACC_ = 0; //T軸-加速度
           public const int _G_TMoveDEC_ = 0; //T軸-減速度   

           public const int _G_Target_G_ = 0; //G軸-移動目標
           public const int _G_Target_S_ = 0; //S軸-移動目標
           public const int _G_Target_L_ = 0; //L軸-移動目標           
           public const int _G_TargetC1C2_ = 0; //C1C2軸-移動目標
           public const int _G_TargetSA1SA2_ = 0; //SA1 & SA2軸-移動目標
           public const int _G_TargetL_ = 0; //L軸-移動目標
           public const int _G_TargetQG1_ = 0; //QG1軸-移動目標
           public const int _G_TargetQS1_ = 0; //QS1-移動目標
           public const int _G_TargetQG2_ = 0; //QG2-移動目標
           public const int _G_TargetQS2_ = 0; //QS2-移動目標
           public const int _G_TargetQG3_ = 0; //QG3-移動目標
           public const int _G_TargetQS3_ = 0; //QS3-移動目標
           public const int _G_TargetQG4_ = 0; //QG4-移動目標
           public const int _G_TargetQS4_ = 0; //QS4-移動目標
           public const int _G_TargetQG5_ = 0; //QG5-移動目標
           public const int _G_TargetQS5_ = 0; //QS5-移動目標
           public const int _G_TargetQG6_ = 0; //QG6-移動目標
           public const int _G_TargetQS6_ = 0; //QS6-移動目標
           public const int _G_TargetQG7_ = 0; //QG7-移動目標
           public const int _G_TargetQS7_ = 0; //QS7-移動目標
           public const int _G_TargetTS_ = 0; //TS-移動目標
           public const int _G_TargetTG_ = 0; //TG-移動目標
           public const int _G_TargetTZ_ = 0; //TZ-移動目標
           public const int _G_TargetRT_ = 0; //RT-移動目標
           public const int _G_TargetRUD_ = 0; //RUD-移動目標
           public const int _G_TargetT_ = 0; //T-移動目標

           public const int _G_TargetBAR_ = 0; 
           public const int _G_BarNumber_ = 0; //選取的Bar編號

           public const int _G_TeachBoxHighSpeed_ = 0; //高速
           public const int _G_TeachBoxHighAcc_ = 0;
           public const int _G_TeachBoxHighDec_ = 0;
           public const int _G_TeachBoxMiddleSpeed_ = 0; //中速
           public const int _G_TeachBoxMiddleAcc_ = 0;
           public const int _G_TeachBoxMiddleDec_ = 0;
           public const int _G_TeachBoxSlowSpeed_ = 0; //低速
           public const int _G_TeachBoxSlowAcc_ = 0;
           public const int _G_TeachBoxSlowDec_ = 0;
       }
   }
}
