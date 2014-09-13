using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TKUnit
{
   public class IOTable
   {
      // �ϥΪ̦ۭq
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
       public const int _JOB_TU_TOP_LOAD_ = 3;                         // RUD�W�b���ʧ@(�J��)
       public const int _JOB_TU_TOP_UNLOAD_ = 4;                   // RUD�W�b���ʧ@(�X��)
       public const int _JOB_TU_BOTTOM_LOAD_ = 5;                // RUD�U�b���ʧ@(�J��)
       public const int _JOB_TU_BOTTOM_UNLOAD_ = 6;          // RUD�U�b���ʧ@(�X��)--�̫�@���X��

       /// <summary>
       /// FSP3
       /// </summary>
       public const int _FSP_STAGE_ = 3;
       public const int _JOB_STAGE_INITIALIZE_ = 1;                 // �]�tC1C2�BSA1,SA2�BS�BG�BQuick�BB1B2�k�s
       public const int _JOB_STAGE_LOAD_ = 2;                          // ���ʨ�۰ʤJ�Ʀ�m
       public const int _JOB_STAGE_UNLOAD_ = 3;                    // ���ʨ�۰ʰh�Ʀ�m

       /// <summary>
       /// FSP4
       /// </summary>
       public const int _FSP_QUICK_ = 4;
       public const int _JOB_QUICK_LIGHTON_ = 1;                         // �P�_���ʪ�Quick����Quick���I�O��m���I�O
       public const int _JOB_QUICK_TEACHING_ = 2;                // �i��Teaching�{��

       /// <summary>
       /// FSP5
       /// </summary>
       public const int _FSP_TEACHBOX_ = 5;
       public const int _JOB_TEACHBOX_MODE_ = 1;                // �P�_�ϥα���Ҧ�
       #endregion

       public struct DI
       {           
           public const int _DI_STAGE_VACUUM1_ON = 0;     // ���x_�l�u��1�˴�
           public const int _DI_STAGE_VACUUM1_OFF_ = 1;  // ���x_�}�u��1�˴�
           public const int _DI_STAGE_VACUUM2_ON = 2;     // ���x_�l�u��2�˴�
           public const int _DI_STAGE_VACUUM2_OFF_ = 3;  // ���x_�}�u��2�˴�
           public const int _DI_STAGE_VACUUM3_ON = 4;     // ���x_�l�u��3�˴�
           public const int _DI_STAGE_VACUUM3_OFF_ = 5;  // ���x_�}�u��3�˴�
           public const int _DI_STAGE_VACUUM4_ON = 6;     // ���x_�l�u��4�˴�
           public const int _DI_STAGE_VACUUM4_OFF_ = 7;  // ���x_�}�u��4�˴�
           public const int _DI_STAGE_VACUUM5_ON = 8;     // ���x_�l�u��5�˴�
           public const int _DI_STAGE_VACUUM5_OFF_ = 9;  // ���x_�}�u��5�˴�
           public const int _DI_STAGE_VACUUM6_ON = 10;     // ���x_�l�u��6�˴�
           public const int _DI_STAGE_VACUUM6_OFF_ = 11;  // ���x_�}�u��6�˴�
           public const int _DI_STAGE_VACUUM7_ON = 12;     // ���x_�l�u��7�˴�
           public const int _DI_STAGE_VACUUM7_OFF_ = 13;  // ���x_�}�u��7�˴�
           public const int _DI_STAGE_VACUUM8_ON = 14;     // ���x_�l�u��8�˴�
           public const int _DI_STAGE_VACUUM8_OFF_ = 15;  // ���x_�}�u��8�˴�
           public const int _DI_STAGE_VACUUM9_ON = 16;     // ���x_�l�u��9�˴�
           public const int _DI_STAGE_VACUUM9_OFF_ = 17;  // ���x_�}�u��9�˴�

           public const int _DI_STAGE_QZ1_UP_SENSOR_ = 18;           // ���x_QZ1�T���W���˴�
           public const int _DI_STAGE_QZ1_DOWN_SENSOR_ = 19;    // ���x_QZ1�T���U���˴�
           public const int _DI_STAGE_QZ2_UP_SENSOR_ = 20;           // ���x_QZ2�T���W���˴�
           public const int _DI_STAGE_QZ2_DOWN_SENSOR_ = 21;    // ���x_QZ2�T���U���˴�
           public const int _DI_STAGE_QZ3_UP_SENSOR_ = 22;           // ���x_QZ3�T���W���˴�
           public const int _DI_STAGE_QZ3_DOWN_SENSOR_ = 23;    // ���x_QZ3�T���U���˴�
           public const int _DI_STAGE_QZ4_UP_SENSOR_ = 24;           // ���x_QZ4�T���W���˴�
           public const int _DI_STAGE_QZ4_DOWN_SENSOR_ = 25;    // ���x_QZ4�T���U���˴�
           public const int _DI_STAGE_QZ5_UP_SENSOR_ = 26;           // ���x_QZ5�T���W���˴�
           public const int _DI_STAGE_QZ5_DOWN_SENSOR_ = 27;    // ���x_QZ5�T���U���˴�
           public const int _DI_STAGE_QZ6_UP_SENSOR_ = 28;           // ���x_QZ6�T���W���˴�
           public const int _DI_STAGE_QZ6_DOWN_SENSOR_ = 29;    // ���x_QZ6�T���U���˴�
           public const int _DI_STAGE_QZ7_UP_SENSOR_ = 30;           // ���x_QZ7�T���W���˴�
           public const int _DI_STAGE_QZ7_DOWN_SENSOR_ = 31;    // ���x_QZ7�T���U���˴�
           // �I��L�b�����O����_�T�����X��m1
           // �I��L�b�����O����_�T���Y�^��m1
           // �I��L�b�����O����_�T�����X��m2
           // �I��L�b�����O����_�T���Y�^��m2
           // �����伵BAR�Ҳ�_�T�����X_���x(A���I)
           // �����伵BAR�Ҳ�_�T���Y�^_���x(A���I
           // POWER  METER�Ҳ�_�T�����X_���x(A���I)
           // POWER  METER�Ҳ�_�T���Y�^_���x(A���I)
           public const int _DI_ROBOT_INTERLOCK_SENSOR_ = 40; // ���x_Robot�˴���Sensor
           // ���x_�����˴�
           // ���x_�J�X�ƨ���˴�
           // ���x_SA1�������n�˴�
           // ���x_SA1�����L���˴�
           // ���x_SA2�������n�˴�
           // ���x_SA2�����L���˴�

           public const int _DI_STAGE_SAFETY_SENSOR_1_ = 48;           // �w��Sensor-1
           public const int _DI_STAGE_SAFETY_SENSOR_2_ = 49;           // �w��Sensor-2
           public const int _DI_STAGE_SAFETY_SENSOR_3_ = 50;           // �w��Sensor-3
           public const int _DI_STAGE_SAFETY_SENSOR_4_ = 51;           // �w��Sensor-4

           public const int _DI_SPIN_CLAMP_TX_SENSOR_ = 64;                               // ����_�������c��TX���n�����˪�
           public const int _DI_SPIN_CLAMP_TX_PRESSURE_SENSOR_ = 65;           // ����_�������c��TX���n�����˪�
           public const int _DI_SPIN_CLAMP_TX_EXTEND_SENSOR_ = 66;              // ����_�������c��TX�T�����X�˴�
           public const int _DI_SPIN_CLAMP_TX_TRIM_SENSOR_ = 67;                    // ����_�������c��TX�T���Y�^�˴�
           public const int _DI_SPIN_CLAMP_TY_SENSOR_ = 68;                               // ����_�������c��TY���n�����˪�
           public const int _DI_SPIN_CLAMP_TY_PRESSURE_SENSOR_ = 69;           // ����_�������c��TY���n�����˪�
           public const int _DI_SPIN_CLAMP_TY_EXTEND_SENSOR_ = 70;              // ����_�������c��TY�T�����X�˴�
           public const int _DI_SPIN_CLAMP_TY_TRIM_SENSOR_ = 71;                    // ����_�������c��TY�T���Y�^�˴�
           public const int _DI_SPIN_GLASS_SENSOR_ = 72;                                       // ����_�����˴�
           public const int _DI_SPIN_TZ_0_SENSOR_ = 73;                                          // ����_TZ_0�צ�m�˴�
           public const int _DI_SPIN_TZ_180_SENSOR_ = 74;                                      // ����_TZ_180�צ�m�˴�

           public const int _DI_SPIN_VACUUM1_ON_ = 80;                                        // ����_�Ĥ@�էl�u��
           public const int _DI_SPIN_VACUUM1_OFF_ = 81;                                       // ����_�Ĥ@�կ}�u��
           public const int _DI_SPIN_VACUUM2_ON_ = 82;                                        // ����_�ĤG�էl�u��
           public const int _DI_SPIN_VACUUM2_OFF_ = 83;                                       // ����_�ĤG�կ}�u��

           public const int _DI_TURN_TOP_GLASS_SENSOR_ = 96;                               // ½��_�W��_�����˴�
           public const int _DI_TURN_TOP_PIN_UP_SENSOR_ = 97;                               // ½��_�W��_��PIN�W���˴�
           public const int _DI_TURN_TOP_PIN_DOWN_SENSOR_ = 98;                               // ½��_�W��_��PIN�U���˴�
           public const int _DI_TURN_TOP_VACUUM1_ON_ = 99;                               // ½��_�W��_�Ĥ@�էl�L�l�u��
           public const int _DI_TURN_TOP_VACUUM1_OFF_ = 100;                               // ½��_�W��_�Ĥ@�էl�L�}�u��
           public const int _DI_TURN_TOP_VACUUM2_ON_ = 101;                               // ½��_�W��_�ĤG�էl�L�l�u��
           public const int _DI_TURN_TOP_VACUUM2_OFF_ = 102;                               // ½��_�W��_�ĤG�էl�L�}�u��
           public const int _DI_TURN_BOTTOM_GLASS_SENSOR_ = 103;                               // ½��_�U��_�����˴�
           public const int _DI_TURN_BOTTOM_PIN_UP_SENSOR_ = 104;                               // ½��_�U��_��PIN�W���˴�
           public const int _DI_TURN_BOTTOM_PIN_DOWN_SENSOR_ = 105;                               // ½��_�U��_��PIN�U���˴�
           public const int _DI_TURN_BOTTOM_VACUUM1_ON_ = 106;                               // ½��_�U��_�Ĥ@�էl�L�l�u��
           public const int _DI_TURN_BOTTOM_VACUUM1_OFF_ = 107;                               // ½��_�U��_�Ĥ@�էl�L�}�u��
           public const int _DI_TURN_BOTTOM_VACUUM2_ON_ = 108;                               // ½��_�U��_�ĤG�էl�L�l�u��
           public const int _DI_TURN_BOTTOM_VACUUM2_OFF_ = 109;                               // ½��_�U��_�ĤG�էl�L�}�u��

           public const int _DI_TURN_0_SENSOR_ = 112;                               // ½��_0�צ�m�˴�
           public const int _DI_TURN_180_SENSOR_ = 113;                               // ½��_180�צ�m�˴�
           public const int _DI_TURN_SPIN_SENSOR_ = 114;                               // ½��_�P����������m�˴�
           public const int _DI_TURN_ROBOT_SENSOR_ = 115;                               // ½��_�PROBOT��������צ�m�˴�
           public const int _DI_TURN_TURN_SENSOR_ = 116;                               // ½��_���i��ʰ��צ�m�˴�
           public const int _DI_TURN_STAGE_SENSOR_ = 117;                               // ½��_�P���x�������m�˴�
           public const int _DI_TURN_TOP_VACUUM1_EXTEND_ = 118;                               // ½��_�W��j�ؤo�l�L�T��_1���X
           public const int _DI_TURN_TOP_VACUUM1_SHRINK_ = 119;                               // ½��_�W��j�ؤo�l�L�T��_1�Y�^
           public const int _DI_TURN_TOP_VACUUM2_EXTEND_ = 120;                               // ½��_�W��j�ؤo�l�L�T��_2���X
           public const int _DI_TURN_TOP_VACUUM2_SHRINK_ = 121;                               // ½��_�W��j�ؤo�l�L�T��_2�Y�^
           public const int _DI_TURN_BOTTOM_VACUUM1_EXTEND_ = 122;                               // ½��_�U��j�ؤo�l�L�T��_1���X
           public const int _DI_TURN_BOTTOM_VACUUM1_SHRINK_ = 123;                               // ½��_�U��j�ؤo�l�L�T��_1�Y�^
           public const int _DI_TURN_BOTTOM_VACUUM2_EXTEND_ = 124;                               // ½��_�U��j�ؤo�l�L�T��_2���X
           public const int _DI_TURN_BOTTOM_VACUUM2_SHRINK_ = 125;                               // ½��_�U��j�ؤo�l�L�T��_2�Y�^

           public const int _DI_MAIN_LASER_STATUS_ = 128;                                 // �p�g���A(B���I)
           public const int _DI_MAIN_SPIN_IRON_ = 129;                                           // �R�q������ALARM�˴�_����
           public const int _DI_MAIN_STAGE_IRON_ = 130;                                       // �R�q������ALARM�˴�_���x
           public const int _DI_MAIN_IRON_ = 131;                                                     // �R�q�����ΰʧ@�˴�
           public const int _DI_MAIN_PRESSURE_STAGE_ = 132;                           // ���Y�����O�˴�(�׾_���x)
           public const int _DI_MAIN_PRESSURE_IRON_ = 133;                                // ���Y�����O�˴�(�R�q�����λP�}�u��)
           public const int _DI_MAIN_PRESSURE_VACUUM_ = 134;                      // ���Y�t���O�˴�(�l�u��)
           public const int _DI_MAIN_POWER_STATUS_ = 135;                      // Power On/Off���A(A���I)
           public const int _DI_MAIN_EMERGANCY_STOP_ = 136;                      // Emergancy Stop(A���I)
           public const int _DI_MAIN_SAFETYDOOR_SENSOR_ = 137;                      // �w�����˴��]�Ҧ��w�����걵�f�tPCB119�^
           public const int _DI_MAIN_ALARM_SENSOR_ = 138;                      // ����ALARM�˴�
           public const int _DI_MAIN_MC2_STATUS_ = 139;                      // MC2���I���A(A���I)
           public const int _DI_MAIN_MC2_HEAT_STATUS_ = 140;                      // MC2�n���q����檬�A(A���I)

           public const int _DI_MAIN_FAN_ALARM1_ = 144;                      // ����Alarm-1
           public const int _DI_MAIN_FAN_ALARM2_ = 145;                      // ����Alarm-2
           public const int _DI_MAIN_FAN_ALARM3_ = 146;                      // ����Alarm-3
           public const int _DI_MAIN_FAN_ALARM4_ = 147;                      // ����Alarm-4
           public const int _DI_MAIN_FAN_ALARM5_ = 148;                      // ����Alarm-5
           public const int _DI_MAIN_FAN_ALARM6_ = 149;                      // ����Alarm-6

           public const int _DI_MOTOR_S_ALARM_ = 160;                      // S�b_���F�iĵ
           public const int _DI_MOTOR_G_ALARM_ = 161;                      // G�b_���F�iĵ
           public const int _DI_MOTOR_L_ALARM_ = 162;                      // L�b_���F�iĵ
           public const int _DI_MOTOR_Z_ALARM_ = 163;                      // Z�b_���F�iĵ
           public const int _DI_MOTOR_QS1_ALARM_ = 164;                      // QS1�b_���F�iĵ
           public const int _DI_MOTOR_QG1_ALARM_ = 165;                      // QG1�b_���F�iĵ
           public const int _DI_MOTOR_QS2_ALARM_ = 166;                      // QS2�b_���F�iĵ
           public const int _DI_MOTOR_QG2_ALARM_ = 167;                      // QG2�b_���F�iĵ
           public const int _DI_MOTOR_QS3_ALARM_ = 168;                      // QS3�b_���F�iĵ
           public const int _DI_MOTOR_QG3_ALARM_ = 169;                      // QG3�b_���F�iĵ
           public const int _DI_MOTOR_QS4_ALARM_ = 170;                      // QS4�b_���F�iĵ
           public const int _DI_MOTOR_QG4_ALARM_ = 171;                      // QG4�b_���F�iĵ
           public const int _DI_MOTOR_QS5_ALARM_ = 172;                      // QS5�b_���F�iĵ
           public const int _DI_MOTOR_QG5_ALARM_ = 173;                      // QG5�b_���F�iĵ
           public const int _DI_MOTOR_QS6_ALARM_ = 174;                      // QS6�b_���F�iĵ
           public const int _DI_MOTOR_QG6_ALARM_ = 175;                      // QG6�b_���F�iĵ
           public const int _DI_MOTOR_QS7_ALARM_ = 176;                      // QS7�b_���F�iĵ
           public const int _DI_MOTOR_QG7_ALARM_ = 177;                      // QG7�b_���F�iĵ
           public const int _DI_MOTOR_SA1_ALARM_ = 178;                      // SA1�b_���F�iĵ
           public const int _DI_MOTOR_SA2_ALARM_ = 179;                      // SA2�b_���F�iĵ
           public const int _DI_MOTOR_C1C2_ALARM_ = 180;                      // C1C2�b_���F�iĵ
           public const int _DI_MOTOR_TS_ALARM_ = 181;                      // TS�b_���F�iĵ
           public const int _DI_MOTOR_TG_ALARM_ = 182;                      // TG�b_���F�iĵ
           public const int _DI_MOTOR_TZ_ALARM_ = 183;                      // TZ�b_���F�iĵ
           public const int _DI_MOTOR_RT_ALARM_ = 184;                      // RT�b_���F�iĵ
           public const int _DI_MOTOR_RUD_ALARM_ = 185;                      // RUD�b_���F�iĵ
           public const int _DI_MOTOR_B1_ALARM_ = 186;                      // B1�b_���Fĵ�i
           public const int _DI_MOTOR_B2_ALARM_ = 187;                      // B2�b_���Fĵ�i
           public const int _DI_MOTOR_T_ALARM_ = 188;                      // T�b���Fĵ�i
           public const int _DI_MOTOR_RZ_ALARM_ = 189;                      // RZ�b���Fĵ�i

           public const int _DI_TEACHBOX_AF_AUTOFOCUS_ = 192;                      // �ާ@��_AF�۰ʹ�J�˴��I��
           public const int _DI_TEACHBOX_AF_UPWARD_ = 193;                      // �ާ@��_AF���W�����˴��I��
           public const int _DI_TEACHBOX_AF_DOWNWARD_ = 194;                      // �ާ@��_AF���U�����˴��I��
           public const int _DI_TEACHBOX_SLOW_BTN_ = 195;                      // �ާ@��_�C�t���s
           public const int _DI_TEACHBOX_MIDDLE_BTN_ = 196;                      // �ާ@��_���t���s
           public const int _DI_TEACHBOX_FAST_BTN_ = 197;                      // �ާ@��_�ֳt���s
           public const int _DI_TEACHBOX_STICK_UP_ = 198;                      // �ާ@��_�n�쩹�W����
           public const int _DI_TEACHBOX_STICK_DOWN_ = 199;                      // �ާ@��_�n�쩹�U����
           public const int _DI_TEACHBOX_STICK_LEFT_ = 200;                      // �ާ@��_�n�쩹������
           public const int _DI_TEACHBOX_STICK_RIGHT_ = 201;                      // �ާ@��_�n�쩹�k����               
           public const int _DI_TEACHBOX_FROMLIGHT_LIGHTER_ = 202;                      // �ާ@��_�������իG             
           public const int _DI_TEACHBOX_FROMLIGHT_DARKER = 203;                      // �ާ@��_�������շ�          
           public const int _DI_TEACHBOX_BACKLIGHT_LIGHTER_ = 204;                      // �ާ@��_�I�����իG          
           public const int _DI_TEACHBOX_BACKLIGHT_DARKER = 205;                      // �ާ@��_�I�����շ�          
           public const int _DI_TEACHBOX_OPERATE_BTN_ = 206;                      // �ާ@��_Operate���s
           public const int _DI_TEACHBOX_LASE_RFIRE_BTN_ = 207;                      // �ާ@��_Laser Fire
           public const int _DI_TEACHBOX_LASER_STOP_BTN_ = 208;                      // �ާ@��_Laser Stop
           public const int _DI_TEACHBOX_LENS_X2_ = 209;                      // �ާ@��_���󭿲v���ܿO X2
           public const int _DI_TEACHBOX_LENS_X5_ = 210;                      // �ާ@��_���󭿲v���ܿO X5 
           public const int _DI_TEACHBOX_LENS_X20_ = 211;                      // �ާ@��_���󭿲v���ܿO X20
           public const int _DI_TEACHBOX_LENS_X50_ = 212;                      // �ާ@��_���󭿲v���ܿO X50
           public const int _DI_TEACHBOX_QUCIK_ = 213;                     // �ާ@��_Quick(Empty)
           public const int _DI_TEACHBOX_BUZZER_ = 214;                      // �ާ@��_Buzzer
           public const int _DI_TEACHBOX_TEACH_XY_ = 215;                      // �ާ@��_Teach OXY
           public const int _DI_TEACHBOX_TEACH_ALIGNMENT_ = 216;                      // �ާ@��_Teach Alignment
           public const int _DI_TEACHBOX_QUICK_CCD_ = 217;                      // �ާ@��_Quick CCD
           public const int _DI_TEACHBOX_SAFETYDOOR_BYPASS_ = 218;                      // �ާ@��_�w����bypass                  
       }

       public struct DO
       {
           public const int _DO_STAGE_VACUUM1_ON_ = 0;                      // ���x_�l�u��1
           public const int _DO_STAGE_VACUUM1_OFF_ = 1;                      // ���x_�}�u��1
           public const int _DO_STAGE_VACUUM2_ON_ = 2;                      // ���x_�l�u��2
           public const int _DO_STAGE_VACUUM2_OFF_ = 3;                      // ���x_�}�u��2
           public const int _DO_STAGE_VACUUM3_ON_ = 4;                      // ���x_�l�u��3
           public const int _DO_STAGE_VACUUM3_OFF_ = 5;                      // ���x_�}�u��3
           public const int _DO_STAGE_VACUUM4_ON_ = 6;                      // ���x_�l�u��4
           public const int _DO_STAGE_VACUUM4_OFF_ = 7;                      // ���x_�}�u��4
           public const int _DO_STAGE_VACUUM5_ON_ = 8;                      // ���x_�l�u��5
           public const int _DO_STAGE_VACUUM5_OFF_ = 9;                      // ���x_�}�u��5
           public const int _DO_STAGE_VACUUM6_ON_ = 10;                      // ���x_�l�u��6
           public const int _DO_STAGE_VACUUM6_OFF_ = 11;                      // ���x_�}�u��6
           public const int _DO_STAGE_VACUUM7_ON_ = 12;                      // ���x_�l�u��7
           public const int _DO_STAGE_VACUUM7_OFF_ = 13;                      // ���x_�}�u��7
           public const int _DO_STAGE_VACUUM8_ON_ = 14;                      // ���x_�l�u��8
           public const int _DO_STAGE_VACUUM8_OFF_ = 15;                      // ���x_�}�u��8
           public const int _DO_STAGE_VACUUM9_ON_ = 16;                      // ���x_�l�u��9
           public const int _DO_STAGE_VACUUM9_OFF_ = 17;                      // ���x_�}�u��9
           public const int _DO_STAGE_QZ1_UP_ = 18;                             // ���x_QZ1�T���W��
           public const int _DO_STAGE_QZ1_DOWN_ = 19;                      // ���x_QZ1�T���U��
           public const int _DO_STAGE_QZ2_UP_ = 20;                      // ���x_QZ2�T���W��
           public const int _DO_STAGE_QZ2_DOWN_ = 21;                      // ���x_QZ2�T���U��
           public const int _DO_STAGE_QZ3_UP_ = 22;                      // ���x_QZ3�T���W��
           public const int _DO_STAGE_QZ3_DOWN_ = 23;                      // ���x_QZ3�T���U��
           public const int _DO_STAGE_QZ4_UP_ = 24;                      // ���x_QZ4�T���W��
           public const int _DO_STAGE_QZ4_DOWN_ = 25;                      // ���x_QZ4�T���U��
           public const int _DO_STAGE_QZ5_UP_ = 26;                      // ���x_QZ5�T���W��
           public const int _DO_STAGE_QZ5_DOWN_ = 27;                      // ���x_QZ5�T���U��
           public const int _DO_STAGE_QZ6_UP_ = 28;                      // ���x_QZ6�T���W��
           public const int _DO_STAGE_QZ6_DOWN_ = 29;                      // ���x_QZ6�T���U��
           public const int _DO_STAGE_QZ7_UP_ = 30;                      // ���x_QZ7�T���W��
           public const int _DO_STAGE_QZ7_DOWN_ = 31;                      // ���x_QZ7�T���U��

           // �I��L�b�����O����_�T�����X��m1_���x
           // �I��L�b�����O����_�T���Y�^��m1_���x
           // �I��L�b�����O����_�T�����X��m2_���x
           // �I��L�b�����O����_�T���Y�^��m2_���x
           // �����伵BAR�Ҳ�_�T�����X_���x
           // �����伵BAR�Ҳ�_�T���Y�^_���x
           // Power meter �Ҳ�_�T�����X_���x
           // Power meter �Ҳ�_�T���Y�^_���x

           public const int _DO_TEACHBOX_TEACH_OXY_ = 45;                      // �ާ@��_Teach OXY
           public const int _DO_TEACHBOX_ALIGNMENT_ = 46;              // �ާ@��_Teach Alignment
           public const int _DO_TEACHBOX_QUICK_CCD_ = 47;              // �ާ@��_Quick CCD
           public const int _DO_TEACHBOX_SLOW_BTN_ = 48;              // �ާ@��_�C�t���s����
           public const int _DO_TEACHBOX_MIDDLE_BTN_ = 49;              // �ާ@��_���t���s����_�ާ@��
           public const int _DO_TEACHBOX_FAST_BTN_ = 50;              // �ާ@��_�ֳt���s����_�ާ@��
           public const int _DO_TEACHBOX_AF_ = 51;                         // �ާ@��_AF�۰ʹ�J�����I��
           public const int _DO_TEACHBOX_AF_UPWARD_ = 52;              // �ާ@��_AF���W���ʱ����I��
           public const int _DO_TEACHBOX_AF_DOWNWARD_ = 53;              // �ާ@��_AF���U���ʱ����I��
           public const int _DO_TEACHBOX_OPERATE_BTN_ = 54;              // �ާ@��_Operate���s
           public const int _DO_TEACHBOX_LASER_FIRE_ = 55;              // �ާ@��_Laser Fire
           public const int _DO_TEACHBOX_LASER_STOP_ = 56;              // �ާ@��_Laser Stop
           public const int _DO_TEACHBOX_LENS_X2_ = 57;              // �ާ@��_���󭿲v���ܿO X2
           public const int _DO_TEACHBOX_LENS_X5_ = 58;              // �ާ@��_���󭿲v���ܿO X5
           public const int _DO_TEACHBOX_LENS_X20_ = 59;              // �ާ@��_���󭿲v���ܿO X20
           public const int _DO_TEACHBOX_LENS_X50_ = 60;              // �ާ@��_���󭿲v���ܿO X50
           public const int _DO_TEACHBOX_QUICK_ = 61;              // �ާ@��_Quick(Empty)
           public const int _DO_TEACHBOX_BUZZER_ = 62;              // �ާ@��_Buzzer

           public const int _DO_SPIN_TX_EXTEND_ = 64;              // ����_�������c��TX�T�����X
           public const int _DO_SPIN_TX_TRIM_ = 65;              // ����_�������c��TX�T���Y�^
           public const int _DO_SPIN_TY_EXTEND_ = 66;              // ����_�������c��TY�T�����X
           public const int _DO_SPIN_TY_TRIM_ = 67;              // ����_�������c��TY�T���Y�^
           public const int _DO_SPIN_VACUUM1_ON_ = 68;              // ����_�Ĥ@�էl�L�l�u��
           public const int _DO_SPIN_VACUUM1_OFF_ = 69;              // ����_�Ĥ@�էl�L�}�u��
           public const int _DO_SPIN_VACUUM2_ON_ = 70;              // ����_�ĤG�էl�L�l�u��
           public const int _DO_SPIN_VACUUM2_OFF_ = 71;              // ����_�ĤG�էl�L�}�u��

           public const int _DO_TURN_TOP_PIN_UP_ = 96;              // ½��_�W��_��PIN�W��
           public const int _DO_TURN_TOP_PIN_DOWN_ = 97;              // ½��_�W��_��PIN�U��
           public const int _DO_TURN_TOP_VACUUM1_ON_ = 98;              // ½��_�W��_�Ĥ@�էl�L�l�u��
           public const int _DO_TURN_TOP_VACUUM1_OFF_ = 99;              // ½��_�W��_�Ĥ@�էl�L�}�u��
           public const int _DO_TURN_TOP_VACUUM2_ON_ = 100;              // ½��_�W��_�ĤG�էl�L�l�u��
           public const int _DO_TURN_TOP_VACUUM2_OFF_ = 101;              // ½��_�W��_�ĤG�էl�L�}�u��

           public const int _DO_TURN_BOTTOM_PIN_UP_ = 104;              // ½��_�U��_��PIN�W��
           public const int _DO_TURN_BOTTOM_PIN_DOWN_ = 105;              // ½��_�U��_��PIN�U��
           public const int _DO_TURN_BOTTOM_VACUUM1_ON_ = 106;              // ½��_�U��_�Ĥ@�էl�L�l�u��
           public const int _DO_TURN_BOTTOM_VACUUM1_OFF_ = 107;              // ½��_�U��_�Ĥ@�էl�L�}�u��
           public const int _DO_TURN_BOTTOM_VACUUM2_ON_ = 108;              // ½��_�U��_�ĤG�էl�L�l�u��
           public const int _DO_TURN_BOTTOM_VACUUM2_OFF_ = 109;              // ½��_�U��_�ĤG�էl�L�}�u��

           public const int _DI_TURN_TOP_VACUUM_EXTEND_ = 112;              // �W��j�ؤo�l�L�T�����X
           public const int _DI_TURN_TOP_VACUUM_TRIM_ = 113;              // �W��j�ؤo�l�L�T���Y�^
           public const int _DI_TURN_BOTTOM_VACUUM_EXTEND_ = 114;              // �U��j�ؤo�l�L�T�����X
           public const int _DI_TURN_BOTTOM_VACUUM_TRIM_ = 115;              // �U��j�ؤo�l�L�T���Y�^

           public const int _DO_MAIN_LASER_FIRE_ = 128;              // �p�g���o
           public const int _DO_MAIN_AUTOFOCUS_ = 129;              // �۰ʹ�J-AF
           public const int _DO_MAIN_Z_UPWARD_ = 130;              // �۰ʹ�J-Z Up
           public const int _DO_MAIN_Z_DOWNWARD_ = 131;              // �۰ʹ�J-Z Down
           public const int _DO_MAIN_IRON_ = 132;              // �R�q�����Χj���������
           public const int _DO_MAIN_IRON_REMOTEON_STAGE_ = 133;              // �R�q������Remote ON_���x(CR)
           public const int _DO_MAIN_IRON_SAFETYDOOR_ = 134;              // �p�g���o���˴��w����������(CR)
           public const int _DO_MAIN_ALARM_RED_ = 135;              // ���O_ĵ�ܿO
           public const int _DO_MAIN_ALARM_YELLOW_ = 136;              // ���O_ĵ�ܿO
           public const int _DO_MAIN_ALARM_GREEN_ = 137;              // ��O_ĵ�ܿO
           public const int _DO_MAIN_ALARM_BUZZER_ = 138;              // ���ﾹ_ĵ�ܿO
           //public const int _DO_MAIN_ALARM_BUZZER_ = 139;              // �R�q�����Χj���������
           public const int _DO_MAIN_IRON_REMOTEON_SPIN_ = 140;              // �R�q������Remote ON_����(CR)

           public const int _DO_MOTOR_S_ON_ = 160;              // S�b_���F�E��
           public const int _DO_MOTOR_G_ON_ = 161;              // G�b_���F�E��
           public const int _DO_MOTOR_L_ON_ = 162;              // L�b_���F�E��
           public const int _DO_MOTOR_Z_ON_ = 163;              // Z�b_���F�E��
           public const int _DO_MOTOR_QS1_ON_ = 164;              // QS1�b_���F�E��
           public const int _DO_MOTOR_QG1_ON_ = 165;              // QG1�b_���F�E��
           public const int _DO_MOTOR_QS2_ON_ = 166;              // QS2�b_���F�E��
           public const int _DO_MOTOR_QG2_ON_ = 167;              // QG2�b_���F�E��
           public const int _DO_MOTOR_QS3_ON_ = 168;              // QS3�b_���F�E��
           public const int _DO_MOTOR_QG3_ON_ = 169;              // QG3�b_���F�E��
           public const int _DO_MOTOR_QS4_ON_ = 170;              // QS4�b_���F�E��
           public const int _DO_MOTOR_QG4_ON_ = 171;              // QG4�b_���F�E��
           public const int _DO_MOTOR_QS5_ON_ = 172;              // QS5�b_���F�E��
           public const int _DO_MOTOR_QG5_ON_ = 173;              // QG5�b_���F�E��
           public const int _DO_MOTOR_QS6_ON_ = 174;              // QS6�b_���F�E��
           public const int _DO_MOTOR_QG6_ON_ = 175;              // QG6�b_���F�E��
           public const int _DO_MOTOR_QS7_ON_ = 176;              // QS7�b_���F�E��
           public const int _DO_MOTOR_QG7_ON_ = 177;              // QG7�b_���F�E��
           public const int _DO_MOTOR_SA1_ON_ = 178;              // SA1�b_���F�E��
           public const int _DO_MOTOR_SA2_ON_ = 179;              // SA2�b_���F�E��
           public const int _DO_MOTOR_C1C2_ON_ = 180;              // C1C2�b_���F�E��
           public const int _DO_MOTOR_TS_ON_ = 181;              // TS�b_���F�E��
           public const int _DO_MOTOR_TG_ON_ = 182;              // TG�b_���F�E��
           public const int _DO_MOTOR_TZ_ON_ = 183;              // TZ�b_���F�E��
           public const int _DO_MOTOR_RT_ON_ = 184;              // RT�b_���F�E��
           public const int _DO_MOTOR_RUD_ON_ = 185;              // RUD�b_���F�E��
           public const int _DO_MOTOR_B1_ON_ = 186;              // B1�b_���F�E��
           public const int _DO_MOTOR_B2_ON_ = 187;              // B2�b_���F�E��
           public const int _DO_MOTOR_RUD_BRAKE_RELEASE_ = 188;              // RUD�b���F�٨�����
           public const int _DO_MOTOR_RT_BRAKE_RELEASE_ = 189;              // RT�b���F�٨�����
           public const int _DO_MOTOR_T_ON_ = 190;              // T�b���F�E��
           public const int _DO_MOTOR_RZ_ON_ = 191;              // RZ�b���F�E��


       }

       public struct VIO
       {
           public const int _VIO_SAFEDOOR_ENABLE_ = 0;               // �w�������˴����X��
           public const int _VIO_PAUSE_ = 1;                             // Stage���x�ʧ@�{�����_�X��
           public const int _VIO_STOP_ = 2;                               // ����Ҧ��u�@
           public const int _VIO_Quick_Use_Flag_ = 3;              //�I�O�ϥΤ��X��
           public const int _VIO_LaserCommunction_ = 4;              //1->�q�T��,0->�q�T����
           public const int _VIO_MotorStop_ = 5;              //½����c�P�洫���ʧ@�{�����_�X��
           public const int _VIO_Reverse_MotorStop_ = 6;              //������c�P�洫���ʧ@�{�����_�X��

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

           //------------------------------------------------------------------------------------�ާ@������
           public const int _VIO_TeachBoxTAXY_Enable_ = 6;              //�ާ@��-TeachTXY�ϥ�(TurnUnit)
           public const int _VIO_TeachBypass_SafeDoor_ = 6;              //Teach���~��Bypass�w�����˴�
           public const int _VIO_TeachBoxEnable_ = 6;              //�ާ@��-TeachBox�ϥ�
           public const int _VIO_TeachBoxCLAMPEnable_ = 6;              //�ާ@��-TeachClamp�ϥ�
           public const int _VIO_TeachBoxQUICK1_Enable_ = 6;              //�ާ@��-TeachQuick1�ϥ�
           public const int _VIO_TeachBoxQUICK2_Enable_ = 6;              //�ާ@��-TeachQuick2�ϥ�
           public const int _VIO_TeachBoxQUICK3_Enable_ = 6;              //�ާ@��-TeachQuick3�ϥ�
           public const int _VIO_TeachBoxQUICK4_Enable_ = 6;              //�ާ@��-TeachQuick4�ϥ�
           public const int _VIO_TeachBoxQUICK5_Enable_ = 6;              //�ާ@��-TeachQuick5�ϥ�
           public const int _VIO_TeachBoxQUICK6_Enable_ = 6;              //�ާ@��-TeachQuick6�ϥ�
           public const int _VIO_TeachBoxQUICK7_Enable_ = 6;              //�ާ@��-TeachQuick7�ϥ�

           public const int _VIO_TeachBoxVCR_Enable_ = 6;              //�ާ@��-TeachVCR�ϥ�
           public const int _VIO_TeachBoxAlignment_Enable_ = 6;              //�ާ@��-TeachAlignment�ϥ�

           public const int _VIO_2XLenUseFlag_ = 6;              //�ϥ�2X���Y
           public const int _VIO_5XLenUseFlag_ = 6;              //�ϥ�5X���Y
           public const int _VIO_20XLenUseFlag_ = 6;              //�ϥ�20X���Y
           public const int _VIO_50XLenUseFlag_ = 6;              //�ϥ�50X���Y

           // TeachBox Trigger
           public const int _VIO_TRIG_AF_AUTOFOCUS_ = 192;                      // �ާ@��_AF�۰ʹ�J�˴��I��
           public const int _VIO_TRIG_AF_UPWARD_ = 193;                      // �ާ@��_AF���W�����˴��I��
           public const int _VIO_TRIG_TEACHBOX_AF_DOWNWARD_ = 194;                      // �ާ@��_AF���U�����˴��I��
           public const int _VIO_TRIG_TEACHBOX_SLOW_BTN_ = 195;                      // �ާ@��_�C�t���s
           public const int _VIO_TRIG_TEACHBOX_MIDDLE_BTN_ = 196;                      // �ާ@��_���t���s
           public const int _VIO_TRIG_TEACHBOX_FAST_BTN_ = 197;                      // �ާ@��_�ֳt���s
           public const int _VIO_TRIG_STICK_UP_ = 198;                      // �ާ@��_�n�쩹�W����
           public const int _VIO_TRIG_STICK_DOWN_ = 199;                      // �ާ@��_�n�쩹�U����
           public const int _VIO_TRIG_STICK_LEFT_ = 200;                      // �ާ@��_�n�쩹������
           public const int _VIO_TRIG_STICK_RIGHT_ = 201;                      // �ާ@��_�n�쩹�k����               
           public const int _VIO_TRIG_FROMLIGHT_LIGHTER_ = 202;                      // �ާ@��_�������իG             
           public const int _VIO_TRIG_FROMLIGHT_DARKER_ = 203;                      // �ާ@��_�������շ�          
           public const int _VIO_TRIG_BACKLIGHT_LIGHTER_ = 204;                      // �ާ@��_�I�����իG          
           public const int _VIO_TRIG_BACKLIGHT_DARKER_ = 205;                      // �ާ@��_�I�����շ�          
           public const int _VIO_TRIG_OPERATE_BTN_ = 206;                      // �ާ@��_Operate���s
           public const int _VIO_TRIG_LASE_RFIRE_BTN_ = 207;                      // �ާ@��_Laser Fire
           public const int _VIO_TRIG_LASER_STOP_BTN_ = 208;                      // �ާ@��_Laser Stop
           public const int _VIO_TRIG_LENS_X2_ = 209;                      // �ާ@��_���󭿲v���ܿO X2
           public const int _VIO_TRIG_LENS_X5_ = 210;                      // �ާ@��_���󭿲v���ܿO X5 
           public const int _VIO_TRIG_LENS_X20_ = 211;                      // �ާ@��_���󭿲v���ܿO X20
           public const int _VIO_TRIG_LENS_X50_ = 212;                      // �ާ@��_���󭿲v���ܿO X50
           public const int _VIO_TRIG_QUCIK_ = 213;                     // �ާ@��_Quick(Empty)
           public const int _VIO_TRIG_BUZZER_ = 214;                      // �ާ@��_Buzzer
           public const int _VIO_TRIG_TEACH_XY_ = 215;                      // �ާ@��_Teach OXY
           public const int _VIO_TRIG_TEACH_ALIGNMENT_ = 216;                      // �ާ@��_Teach Alignment
           public const int _VIO_TRIG_QUICK_CCD_ = 217;                      // �ާ@��_Quick CCD
           public const int _VIO_TRIG_SAFETYDOOR_BYPASS_ = 218;                      // �ާ@��_�w����bypass

           // Trigger Enable
           public const int _VIO_TRIG_AF_AUTOFOCUS_ENABLE_ = 192;                      // �ާ@��_AF�۰ʹ�J�˴��I��
           public const int _VIO_TRIG_AF_UPWARD_ENABLE_ = 193;                      // �ާ@��_AF���W�����˴��I��
           public const int _VIO_TRIG_TEACHBOX_AF_DOWNWARD_ENABLE_ = 194;                      // �ާ@��_AF���U�����˴��I��
           public const int _VIO_TRIG_TEACHBOX_SLOW_BTN_ENABLE_ = 195;                      // �ާ@��_�C�t���s
           public const int _VIO_TRIG_TEACHBOX_MIDDLE_BTN_ENABLE_ = 196;                      // �ާ@��_���t���s
           public const int _VIO_TRIG_TEACHBOX_FAST_BTN_ENABLE_ = 197;                      // �ާ@��_�ֳt���s
           public const int _VIO_TRIG_STICK_UP_ENABLE_ = 198;                      // �ާ@��_�n�쩹�W����
           public const int _VIO_TRIG_STICK_DOWN_ENABLE_ = 199;                      // �ާ@��_�n�쩹�U����
           public const int _VIO_TRIG_STICK_LEFT_ENABLE_ = 200;                      // �ާ@��_�n�쩹������
           public const int _VIO_TRIG_STICK_RIGHT_ENABLE_ = 201;                      // �ާ@��_�n�쩹�k����               
           public const int _VIO_TRIG_FROMLIGHT_LIGHTER_ENABLE_ = 202;                      // �ާ@��_�������իG             
           public const int _VIO_TRIG_FROMLIGHT_DARKER_ENABLE = 203;                      // �ާ@��_�������շ�          
           public const int _VIO_TRIG_BACKLIGHT_LIGHTER_ENABLE_ = 204;                      // �ާ@��_�I�����իG          
           public const int _VIO_TRIG_BACKLIGHT_DARKER_ENABLE_ = 205;                      // �ާ@��_�I�����շ�          
           public const int _VIO_TRIG_OPERATE_BTN_ENABLE_ = 206;                      // �ާ@��_Operate���s
           public const int _VIO_TRIG_LASE_RFIRE_BTN_ENABLE_ = 207;                      // �ާ@��_Laser Fire
           public const int _VIO_TRIG_LASER_STOP_BTN_ENABLE_ = 208;                      // �ާ@��_Laser Stop
           public const int _VIO_TRIG_LENS_X2_ENABLE_ = 209;                      // �ާ@��_���󭿲v���ܿO X2
           public const int _VIO_TRIG_LENS_X5_ENABLE_ = 210;                      // �ާ@��_���󭿲v���ܿO X5 
           public const int _VIO_TRIG_LENS_X20_ENABLE_ = 211;                      // �ާ@��_���󭿲v���ܿO X20
           public const int _VIO_TRIG_LENS_X50_ENABLE_ = 212;                      // �ާ@��_���󭿲v���ܿO X50
           public const int _VIO_TRIG_QUCIK_ENABLE_ = 213;                     // �ާ@��_Quick(Empty)
           public const int _VIO_TRIG_BUZZER_ENABLE_ = 214;                      // �ާ@��_Buzzer
           public const int _VIO_TRIG_TEACH_XY_ENABLE_ = 215;                      // �ާ@��_Teach OXY
           public const int _VIO_TRIG_TEACH_ALIGNMENT_ENABLE_ = 216;                      // �ާ@��_Teach Alignment
           public const int _VIO_TRIG_QUICK_CCD_ENABLE_ = 217;                      // �ާ@��_Quick CCD
           public const int _VIO_TRIG_SAFETYDOOR_BYPASS_ENABLE_ = 218;                      // �ާ@��_�w����bypass
    
       }

       public struct Global
       {
           public const int _G_MoveSpeed_ = 0; // �I���I-���ʳt��
           public const int _G_MoveACC_ = 0; // �I���I-�[�t��
           public const int _G_MoveDEC_ = 0; // �I���I-��t��
           public const int _G_C1C2MoveSpeed_ = 0; //C1C2�b-���ʳt��
           public const int _G_C1C2MoveACC_ = 0; //C1C2�b-�[�t��
           public const int _G_C1C2MoveDEC_ = 0; //C1C2�b-��t��
           public const int _G_SA1MoveSpeed_ = 0; //C1C2�b-���ʳt��           
           public const int _G_SA1MoveACC_ = 0; //SA1�b-�[�t��
           public const int _G_SA1MoveDEC_ = 0; //SA1�b-��t��
           public const int _G_SA2MoveSpeed_ = 0; //C1C2�b-���ʳt��
           public const int _G_SA2MoveACC_ = 0; //SA2�b-�[�t��
           public const int _G_SA2MoveDEC_ = 0; //SA2�b-��t��
           public const int _G_TSMoveSpeed_ = 0; //TS�b-���ʳt��
           public const int _G_TSMoveACC_ = 0; //TS�b-�[�t��
           public const int _G_TSMoveDEC_ = 0; //TS�b-��t��
           public const int _G_TGMoveSpeed_ = 0; //TG�b-���ʳt��
           public const int _G_TGMoveACC_ = 0; //TG�b-�[�t��
           public const int _G_TGMoveDEC_ = 0; //TG�b-��t��
           public const int _G_TZMoveSpeed_ = 0; //TG�b-���ʳt��
           public const int _G_TZMoveACC_ = 0; //TZ�b-�[�t��
           public const int _G_TZMoveDEC_ = 0; //TZ�b-��t��
           public const int _G_RTMoveSpeed_ = 0; //RT�b-���ʳt��
           public const int _G_RTMoveACC_ = 0; //RT�b-�[�t��
           public const int _G_RTMoveDEC_ = 0; //RT�b-��t��
           public const int _G_RUDMoveSpeed_ = 0; //RUD�b-���ʳt��
           public const int _G_RUDMoveACC_ = 0; //RUD�b-�[�t��
           public const int _G_RUDMoveDEC_ = 0; //RUD�b-��t��
           public const int _G_TMoveSpeed_ = 0; //T�b-���ʳt��
           public const int _G_TMoveACC_ = 0; //T�b-�[�t��
           public const int _G_TMoveDEC_ = 0; //T�b-��t��   

           public const int _G_Target_G_ = 0; //G�b-���ʥؼ�
           public const int _G_Target_S_ = 0; //S�b-���ʥؼ�
           public const int _G_Target_L_ = 0; //L�b-���ʥؼ�           
           public const int _G_TargetC1C2_ = 0; //C1C2�b-���ʥؼ�
           public const int _G_TargetSA1SA2_ = 0; //SA1 & SA2�b-���ʥؼ�
           public const int _G_TargetL_ = 0; //L�b-���ʥؼ�
           public const int _G_TargetQG1_ = 0; //QG1�b-���ʥؼ�
           public const int _G_TargetQS1_ = 0; //QS1-���ʥؼ�
           public const int _G_TargetQG2_ = 0; //QG2-���ʥؼ�
           public const int _G_TargetQS2_ = 0; //QS2-���ʥؼ�
           public const int _G_TargetQG3_ = 0; //QG3-���ʥؼ�
           public const int _G_TargetQS3_ = 0; //QS3-���ʥؼ�
           public const int _G_TargetQG4_ = 0; //QG4-���ʥؼ�
           public const int _G_TargetQS4_ = 0; //QS4-���ʥؼ�
           public const int _G_TargetQG5_ = 0; //QG5-���ʥؼ�
           public const int _G_TargetQS5_ = 0; //QS5-���ʥؼ�
           public const int _G_TargetQG6_ = 0; //QG6-���ʥؼ�
           public const int _G_TargetQS6_ = 0; //QS6-���ʥؼ�
           public const int _G_TargetQG7_ = 0; //QG7-���ʥؼ�
           public const int _G_TargetQS7_ = 0; //QS7-���ʥؼ�
           public const int _G_TargetTS_ = 0; //TS-���ʥؼ�
           public const int _G_TargetTG_ = 0; //TG-���ʥؼ�
           public const int _G_TargetTZ_ = 0; //TZ-���ʥؼ�
           public const int _G_TargetRT_ = 0; //RT-���ʥؼ�
           public const int _G_TargetRUD_ = 0; //RUD-���ʥؼ�
           public const int _G_TargetT_ = 0; //T-���ʥؼ�

           public const int _G_TargetBAR_ = 0; 
           public const int _G_BarNumber_ = 0; //�����Bar�s��

           public const int _G_TeachBoxHighSpeed_ = 0; //���t
           public const int _G_TeachBoxHighAcc_ = 0;
           public const int _G_TeachBoxHighDec_ = 0;
           public const int _G_TeachBoxMiddleSpeed_ = 0; //���t
           public const int _G_TeachBoxMiddleAcc_ = 0;
           public const int _G_TeachBoxMiddleDec_ = 0;
           public const int _G_TeachBoxSlowSpeed_ = 0; //�C�t
           public const int _G_TeachBoxSlowAcc_ = 0;
           public const int _G_TeachBoxSlowDec_ = 0;
       }
   }
}
