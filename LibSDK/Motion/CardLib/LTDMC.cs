using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace csLTDMC //�����ռ����Ӧ�ó����޸�
{
    public partial class LTDMC
    {
        //---------------------   �忨��ʼ�����ú���  ----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_init", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_init();
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_reset();
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_close", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_close();
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_init_onecard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_init_onecard(ushort CardNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_close_onecard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_close_onecard(ushort CardNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_board_reset_onecard", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_board_reset_onecard(ushort CardNo);      
        [DllImport("LTDMC.dll")]
        public static extern short dmc_soft_reset(ushort CardNo);//�ȸ�λ�����߿���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_cool_reset(ushort CardNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_original_reset", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_original_reset(ushort CardNo);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_CardInfList", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_CardInfList(ref UInt16 CardNum, UInt32[] CardTypeList, UInt16[] CardIdList);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_version(UInt16 CardNo, ref UInt32 CardVersion);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_soft_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_soft_version(UInt16 CardNo, ref UInt32 FirmID, ref UInt32 SubFirmID);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_card_lib_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_card_lib_version(ref UInt32 LibVer);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_release_version", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_release_version(ushort ConnectNo, byte[] ReleaseVersion);//��ȡ�����汾��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_axes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_axes(UInt16 CardNo, ref UInt32 TotalAxis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_ionum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_ionum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_adcnum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_adcnum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_total_liners", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_total_liners(UInt16 CardNo, ref UInt32 TotalLiner);

        // ��IOӳ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_AxisIoMap", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_AxisIoMap(UInt16 CardNo, UInt16 Axis, UInt16 IoType, UInt16 MapIoType, UInt16 MapIoIndex, UInt32 Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_AxisIoMap", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_AxisIoMap(UInt16 CardNo, UInt16 Axis, UInt16 IoType, ref UInt16 MapIoType, ref UInt16 MapIoIndex, ref UInt32 Filter);
        //���Ϻ����Ժ���Ϊ��λ�ɼ���ʹ�ã��º�����ʱ��ͳһ����Ϊ��λ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_axis_io_map", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_axis_io_map(UInt16 CardNo, UInt16 Axis, UInt16 IoType, UInt16 MapIoType, UInt16 MapIoIndex, double Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_axis_io_map", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_axis_io_map(UInt16 CardNo, UInt16 Axis, UInt16 IoType, ref UInt16 MapIoType, ref UInt16 MapIoIndex, ref double Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_special_input_filter", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_special_input_filter(UInt16 CardNo, double Filter);      //��������ר��IO�˲�ʱ��

        //�����������忨 ����IOӳ��  ���ڶ�ȡ�˲����IO�ڵ�ƽ״̬
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_map_virtual", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_map_virtual(UInt16 CardNo, UInt16 bitno, UInt16 MapIoType, UInt16 MapIoIndex, double Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_map_virtual", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_map_virtual(UInt16 CardNo, UInt16 bitno, ref UInt16 MapIoType, ref UInt16 MapIoIndex, ref double Filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inbit_virtual", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_inbit_virtual(UInt16 CardNo, UInt16 bitno);

        //���ز����ļ�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_configfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_configfile(UInt16 CardNo, String FileName);
        //���ع̼��ļ�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_firmware", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_firmware(UInt16 CardNo, String FileName);

        //----------------------��λ�쳣����-------------------------------	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_softlimit(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 source_sel, UInt16 SL_action, Int32 N_limit, Int32 P_limit);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_softlimit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_softlimit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 source_sel, ref UInt16 SL_action, ref Int32 N_limit, ref Int32 P_limit);
        //�����������忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_el_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_el_mode(UInt16 CardNo, UInt16 axis, UInt16 el_enable, UInt16 el_logic, UInt16 el_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_el_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_el_mode(UInt16 CardNo, UInt16 axis, ref UInt16 el_enable, ref UInt16 el_logic, ref UInt16 el_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_emg_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_emg_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 emg_logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_emg_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_emg_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enbale, ref UInt16 emg_logic);
        //�ⲿ����ֹͣ�źż�����ֹͣʱ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dstp_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic, UInt32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dstp_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic, ref UInt32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dstp_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dstp_time(UInt16 CardNo, UInt16 axis, UInt32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dstp_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dstp_time(UInt16 CardNo, UInt16 axis, ref UInt32 time);
        //���Ϻ����Ժ���Ϊ��λ�ɼ���ʹ�ã��º�����ʱ��ͳһ����Ϊ��λ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_dstp_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_dstp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_dstp_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_dec_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_dec_stop_time(UInt16 CardNo, UInt16 axis, double stop_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_dec_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_dec_stop_time(UInt16 CardNo, UInt16 axis, ref double stop_time);
        //�岹�˶�����ֹͣʱ������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_dec_stop_time(UInt16 CardNo, UInt16 Crd, double stop_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_dec_stop_time(UInt16 CardNo, UInt16 Crd, ref double stop_time);
        //����ֹͣ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_dec_stop_dist(UInt16 CardNo, UInt16 axis, Int32 dist);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_dec_stop_dist(UInt16 CardNo, UInt16 axis, ref Int32 dist);
        //����ͨ������ڵ�һλ����ֹͣIO��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_dstp_bitno(UInt16 CardNo, UInt16 axis, UInt16 bitno, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_dstp_bitno(UInt16 CardNo, UInt16 axis, ref UInt16 bitno, ref double filter);

        //---------------------------�ٶ�����----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile(UInt16 CardNo, UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile(UInt16 CardNo, UInt16 axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double stop_vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_acc_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_acc_profile(UInt16 CardNo, UInt16 axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_acc_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_acc_profile(UInt16 CardNo, UInt16 axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double stop_vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_s_profile(UInt16 CardNo, UInt16 axis, UInt16 s_mode, double s_para);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_s_profile(UInt16 CardNo, UInt16 axis, UInt16 s_mode, ref double s_para);
        //�岹�˶��ٶ����ã�3000ϵ�����忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_profile_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_profile_multicoor(UInt16 CardNo, UInt16 Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_profile_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_profile_multicoor(UInt16 CardNo, UInt16 Crd, ref double Min_Vel, ref double Max_Vel, ref double Taccdec, ref double Tdec, ref double Stop_Vel);
        //�岹�˶�ƽ���ٶ����߲������ã�3000ϵ�����忨
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_vector_s_profile_multicoor(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, double s_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_vector_s_profile_multicoor(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, ref double s_para);

        //---------------------�˶�ģ������ģʽ------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pulse_outmode(UInt16 CardNo, UInt16 axis, UInt16 outmode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pulse_outmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pulse_outmode(UInt16 CardNo, UInt16 axis, ref UInt16 outmode);

        //-----------------------��λ�˶�-----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_pmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_pmove(UInt16 CardNo, UInt16 axis, Int32 Dist, UInt16 posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_extern(UInt16 CardNo, UInt16 axis, double dist, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double stop_Vel, double s_para, UInt16 posi_mode);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_target_position(UInt16 CardNo, UInt16 axis, Int32 dist, UInt16 posi_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_change_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_change_speed(UInt16 CardNo, UInt16 axis, double Curr_Vel, double Taccdec);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_update_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_update_target_position(UInt16 CardNo, UInt16 axis, Int32 dist, UInt16 posi_mode);
        //----------------------PVT�˶�---------------------------
        //PVT�˶��ɰ� 3K5K���忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, Int32[] pPos, double[] pVel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PtsTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PtsTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, Int32[] pPos, double[] pPercent);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtsTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtsTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, Int32[] pPos, double velBegin, double velEnd);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PttTable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PttTable(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, int[] pPos);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_PvtMove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_PvtMove(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList);
        //PVT���������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PttTable_add(UInt16 CardNo, UInt16 iaxis, UInt16 count, double[] pTime, long[] pPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_PtsTable_add(UInt16 CardNo, UInt16 iaxis, UInt16 count, double[] pTime, long[] pPos, double[] pPercent);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_get_remain_space(UInt16 CardNo, UInt16 iaxis);//��ȡpvtʣ��ռ�
        //PVT�˶� 3K5K���߿��¹滮
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos, double[] pVel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pts_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos, double[] pPercent);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvts_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos, double velBegin, double velEnd);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ptt_table_unit(UInt16 CardNo, UInt16 iaxis, UInt32 count, double[] pTime, double[] pPos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pvt_move(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_SetGearProfile(UInt16 CardNo, UInt16 axis, UInt16 MasterType, UInt16 MasterIndex, Int32 MasterEven, Int32 SlaveEven, UInt32 MasterSlope);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GetGearProfile(UInt16 CardNo, UInt16 axis, ref UInt16 MasterType, ref UInt16 MasterIndex, ref UInt32 MasterEven, ref UInt32 SlaveEven, ref UInt32 MasterSlope);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_GearMove(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList);

        //---------------------JOG�˶�--------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_vmove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_vmove(UInt16 CardNo, UInt16 axis, UInt16 dir);
        //ֱ�߲岹��3000ϵ�����忨		
        [DllImport("LTDMC.dll", EntryPoint = "dmc_line_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_line_multicoor(UInt16 CardNo, UInt16 crd, UInt16 axisNum, UInt16[] axisList, Int32[] DistList, UInt16 posi_mode);
        //ƽ��Բ����3000ϵ�����忨	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_multicoor(UInt16 CardNo, UInt16 crd, UInt16[] AxisList, Int32[] Target_Pos, Int32[] Cen_Pos, UInt16 Arc_Dir, UInt16 posi_mode);

        //--------------------�����˶�---------------------
        //���忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_home_pin_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_home_pin_logic(UInt16 CardNo, UInt16 axis, UInt16 org_logic, double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_home_pin_logic", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_home_pin_logic(UInt16 CardNo, UInt16 axis, ref UInt16 org_logic, ref double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_homemode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_homemode(UInt16 CardNo, UInt16 axis, UInt16 home_dir, double vel, UInt16 mode, UInt16 EZ_count);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homemode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homemode(UInt16 CardNo, UInt16 axis, ref UInt16 home_dir, ref double vel, ref UInt16 home_mode, ref UInt16 EZ_count);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_home_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_home_move(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_profile_unit(ushort CardNo, ushort axis, double Low_Vel, double High_Vel, double Tacc, double Tdec);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_profile_unit(ushort CardNo, ushort axis, ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_result(UInt16 CardNo, UInt16 axis, ref UInt16 state);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_position_unit(UInt16 CardNo, UInt16 axis, UInt16 enable, double position);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_position_unit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double position);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_el_home(UInt16 CardNo, UInt16 axis, UInt16 mode);

        // ��ԭ������ź����ã�3410ר��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_sd_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_sd_mode(UInt16 CardNo, UInt16 axis, UInt16 sd_logic, UInt16 sd_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_sd_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_sd_mode(UInt16 CardNo, UInt16 axis, ref UInt16 sd_logic, ref UInt16 sd_mode);
        //--------------------ԭ������ ���忨-------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_homelatch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_homelatch_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic, UInt16 source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homelatch_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic, ref UInt16 source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_homelatch_flag(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_homelatch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_homelatch_flag(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_homelatch_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_homelatch_value(UInt16 CardNo, UInt16 axis);
        //EZ���棬���忨
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_ezlatch_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 logic, UInt16 source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 logic, ref UInt16 source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_flag(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_ezlatch_flag(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern Int32 dmc_get_ezlatch_value(UInt16 CardNo, UInt16 axis);

        //--------------------�����˶�---------------------	
        //���忨ר�� ����ͨ��ѡ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_channel(UInt16 CardNo, UInt16 index);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_channel", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_channel(UInt16 CardNo, ref UInt16 index);
        //һ�������źſ��Ƶ������˶������п�	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode(UInt16 CardNo, UInt16 axis, UInt16 inmode, Int32 multi, double vh);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode(UInt16 CardNo, UInt16 axis, ref UInt16 inmode, ref Int32 multi, ref double vh);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode_decimals", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode_decimals(UInt16 CardNo, UInt16 axis, UInt16 inmode, double multi, double vh);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode_decimals", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode_decimals(UInt16 CardNo, UInt16 axis, ref UInt16 inmode, ref double multi, ref double vh);

        //���п� һ�������źſ��ƶ�����˶�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_handwheel_inmode_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_handwheel_inmode_extern(UInt16 CardNo, UInt16 inmode, UInt16 AxisNum, UInt16[] AxisList, Int32[] multi);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_handwheel_inmode_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_handwheel_inmode_extern(UInt16 CardNo, ref UInt16 inmode, ref UInt16 AxisNum, UInt16[] AxisList, Int32[] multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_inmode_extern_decimals(UInt16 CardNo, UInt16 inmode, UInt16 AxisNum, UInt16[] AxisList, double[] multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_inmode_extern_decimals(UInt16 CardNo, ref UInt16 inmode, ref UInt16 AxisNum, UInt16[] AxisList, double[] multi);
        //���������˶�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_handwheel_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_handwheel_move(UInt16 CardNo, UInt16 axis);
        //���ֱ����� ���߿�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_encoder(ushort CardNo, ushort channel, int pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_encoder(ushort CardNo, ushort channel, ref int pos);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_axislist(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 AxisNum, UInt16[] AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_axislist(UInt16 CardNo, UInt16 AxisSelIndex, ref UInt16 AxisNum, UInt16[] AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_ratiolist(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 StartRatioIndex, UInt16 RatioSelNum, double[] RatioList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_ratiolist(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 StartRatioIndex, UInt16 RatioSelNum, double[] RatioList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_mode(UInt16 CardNo, UInt16 InMode, UInt16 IfHardEnable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_mode(UInt16 CardNo, ref UInt16 InMode, ref UInt16 IfHardEnable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_set_index(UInt16 CardNo, UInt16 AxisSelIndex, UInt16 RatioSelIndex);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_get_index(UInt16 CardNo, ref UInt16 AxisSelIndex, ref UInt16 RatioSelIndex);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_handwheel_stop(UInt16 CardNo);

        //---------------------������ ���忨---------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_counter_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_counter_inmode(UInt16 CardNo, UInt16 axis, UInt16 mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_counter_inmode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_counter_inmode(UInt16 CardNo, UInt16 axis, ref UInt16 mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_encoder(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder(UInt16 CardNo, UInt16 axis, Int32 encoder_value);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_ez_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_ez_mode(UInt16 CardNo, UInt16 axis, UInt16 ez_logic, UInt16 ez_mode, double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_ez_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_ez_mode(UInt16 CardNo, UInt16 axis, ref UInt16 ez_logic, ref UInt16 ez_mode, ref double filter);
        //---------------------���������� ���߿�---------------------
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder_mode(ushort CardNo, ushort channel, ushort inmode, ushort multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder_mode(ushort CardNo, ushort channel, ref ushort inmode, ref ushort multi);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_extra_encoder(ushort CardNo, ushort channel, int pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_extra_encoder(ushort CardNo, ushort channel, ref int pos);

        //-------------------------�������� ���忨-------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_ltc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_ltc_mode(UInt16 CardNo, UInt16 axis, UInt16 ltc_logic, UInt16 ltc_mode, Double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_ltc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_ltc_mode(UInt16 CardNo, UInt16 axis, ref UInt16 ltc_logic, ref UInt16 ltc_mode, ref Double filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_latch_mode(UInt16 CardNo, UInt16 axis, UInt16 all_enable, UInt16 latch_source, UInt16 triger_chunnel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_mode(UInt16 CardNo, UInt16 axis, ref UInt16 all_enable, ref UInt16 latch_source, ref UInt16 triger_chunnel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_latch_value(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_value_unit(UInt16 CardNo, UInt16 axis, ref double pos_by_mm);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_flag(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_latch_flag", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_latch_flag(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_value_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_latch_value_extern(UInt16 CardNo, UInt16 axis, UInt16 Index);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_flag_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_flag_extern(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetLtcOutMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetLtcOutMode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetLtcOutMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetLtcOutMode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 bitno);
        //LTC�˿ڴ�����ʱ��ͣʱ�� ��λus
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_latch_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_latch_stop_time(UInt16 CardNo, UInt16 axis, Int32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_latch_stop_time", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_latch_stop_time(UInt16 CardNo, UInt16 axis, ref Int32 time);
        //----------------------�������� ���߿�---------------------------
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_mode(ushort CardNo, ushort latch, ushort ltc_mode, ushort ltc_logic, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_mode(ushort CardNo, ushort latch, ref ushort ltc_mode, ref ushort ltc_logic, ref double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_set_source(ushort CardNo, ushort latch, ushort axis, ushort ltc_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_source(ushort CardNo, ushort latch, ushort axis, ref ushort ltc_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_reset(ushort CardNo, ushort latch);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_number(ushort CardNo, ushort latch, ushort axis, ref int number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ltc_get_value_unit(ushort CardNo, ushort latch, ushort axis, ref double value);
        //-----------------------������ ���п�---------------------------------
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_set_mode(ushort ConnectNo, ushort latch, ushort ltc_enable, ushort ltc_mode, ushort ltc_inbit, ushort ltc_logic, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_mode(ushort ConnectNo, ushort latch, ref ushort ltc_enable, ref ushort ltc_mode, ref ushort ltc_inbit, ref ushort ltc_logic, ref double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_set_source(ushort ConnectNo, ushort latch, ushort axis, ushort ltc_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_source(ushort ConnectNo, ushort latch, ushort axis, ref ushort ltc_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_reset(ushort ConnectNo, ushort latch);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_number(ushort ConnectNo, ushort latch, ushort axis, ref int number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_softltc_get_value_unit(ushort ConnectNo, ushort latch, ushort axis, ref double value);

        //----------------------�������λ�ñȽ�-----------------------	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_set_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_set_config(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 cmp_source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_config(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 cmp_source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_clear_points", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_clear_points(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_add_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_add_point(UInt16 CardNo, UInt16 axis, int pos, UInt16 dir, UInt16 action, UInt32 actpara);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_current_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_current_point(UInt16 CardNo, UInt16 axis, ref Int32 pos);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_runned", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_runned(UInt16 CardNo, UInt16 axis, ref Int32 pointNum);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_remained", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_remained(UInt16 CardNo, UInt16 axis, ref Int32 pointNum);

        //-------------------��ά����λ�ñȽ�-----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_set_config_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_set_config_extern(UInt16 CardNo, UInt16 enable, UInt16 cmp_source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_config_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_config_extern(UInt16 CardNo, ref UInt16 enable, ref UInt16 cmp_source);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_clear_points_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_clear_points_extern(UInt16 CardNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_add_point_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_add_point_extern(UInt16 CardNo, UInt16[] axis, Int32[] pos, UInt16[] dir, UInt16 action, UInt32 actpara);//�������忨ʹ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_current_point_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_current_point_extern(UInt16 CardNo, Int32[] pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_extern_unit(UInt16 CardNo, UInt16[] axis, double[] pos, UInt16[] dir, UInt16 action, UInt32 actpara);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point_extern_unit(UInt16 CardNo, double[] pos);//5000���п�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_runned_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_runned_extern(UInt16 CardNo, ref Int32 pointNum);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_compare_get_points_remained_extern", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_compare_get_points_remained_extern(UInt16 CardNo, ref Int32 pointNum);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_set_config_multi(UInt16 CardNo, UInt16 queue, UInt16 enable, UInt16 axis, UInt16 cmp_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_config_multi(UInt16 CardNo, UInt16 queue, ref UInt16 enable, ref UInt16 axis, ref UInt16 cmp_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_multi(UInt16 CardNo, UInt16 cmp, Int32 pos, UInt16 dir, UInt16 action, UInt32 actpara, double times);

        //----------- �������λ�ñȽ�-----------------------        
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_mode(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_mode(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_config(UInt16 CardNo, UInt16 hcmp, UInt16 axis, UInt16 cmp_source, UInt16 cmp_logic, Int32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_config", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_config(UInt16 CardNo, UInt16 hcmp, ref UInt16 axis, ref UInt16 cmp_source, ref UInt16 cmp_logic, ref Int32 time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_config_extern(UInt16 CardNo, UInt16 hcmp, UInt16 axis, UInt16 cmp_source, UInt16 cmp_logic, UInt16 cmp_mode, Int32 dist, Int32 time);//����λ�ñȽ���չ������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_config_extern(UInt16 CardNo, UInt16 hcmp, ref UInt16 axis, ref UInt16 cmp_source, ref UInt16 cmp_logic, ref UInt16 cmp_mode, ref Int32 dist, ref Int32 time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_add_point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_add_point(UInt16 CardNo, UInt16 hcmp, Int32 cmp_pos);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_set_liner", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_set_liner(UInt16 CardNo, UInt16 hcmp, Int32 Increment, Int32 Count);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_liner", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_liner(UInt16 CardNo, UInt16 hcmp, ref Int32 Increment, ref Int32 Count);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_get_current_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_get_current_state(UInt16 CardNo, UInt16 hcmp, ref Int32 remained_points, ref Int32 current_point, ref Int32 runned_points);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_hcmp_clear_points", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_hcmp_clear_points(UInt16 CardNo, UInt16 hcmp);       
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_cmp_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_cmp_pin(UInt16 CardNo, UInt16 hcmp);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_cmp_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_cmp_pin(UInt16 CardNo, UInt16 hcmp, UInt16 on_off);
        //��ά����λ�ñȽϹ���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_enable(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_enable(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_config(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_mode, UInt16 x_axis, UInt16 x_cmp_source, UInt16 y_axis, UInt16 y_cmp_source, Int32 error, UInt16 cmp_logic, Int32 time, UInt16 pwm_enable, double duty, Int32 freq, UInt16 port_sel, UInt16 pwm_number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_config(UInt16 CardNo, UInt16 hcmp, ref UInt16 cmp_mode, ref UInt16 x_axis, ref UInt16 x_cmp_source, ref UInt16 y_axis, ref UInt16 y_cmp_source, ref Int32 error, ref UInt16 cmp_logic, ref Int32 time, ref UInt16 pwm_enable, ref double duty, ref Int32 freq, ref UInt16 port_sel, ref UInt16 pwm_number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_add_point(UInt16 CardNo, UInt16 hcmp, Int32 x_cmp_pos, Int32 y_cmp_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_current_state(UInt16 CardNo, UInt16 hcmp, ref Int32 remained_points, ref Int32 x_current_point, ref Int32 y_current_point, ref Int32 runned_points, ref UInt16 current_state);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_clear_points(UInt16 CardNo, UInt16 hcmp);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_force_output(UInt16 CardNo, UInt16 hcmp, UInt16 cmp_outbit);

        //------------------------ͨ��IO-----------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_inbit(UInt16 CardNo, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outbit(UInt16 CardNo, UInt16 bitno, UInt16 on_off);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_outbit(UInt16 CardNo, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_inport(UInt16 CardNo, UInt16 portno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_outport(UInt16 CardNo, UInt16 portno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outport(UInt16 CardNo, UInt16 portno, UInt32 outport_val);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_outport_16X", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_outport_16X(UInt16 CardNo, UInt16 portno, UInt32 outport_val);
        // IO��������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_IO_TurnOutDelay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_IO_TurnOutDelay(UInt16 CardNo, UInt16 bitno, UInt32 DelayTime);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetIoCountMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetIoCountMode(UInt16 CardNo, UInt16 bitno, UInt16 mode, UInt32 filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetIoCountMode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetIoCountMode(UInt16 CardNo, UInt16 bitno, ref UInt16 mode, ref UInt32 filter);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_SetIoCountValue", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_SetIoCountValue(UInt16 CardNo, UInt16 bitno, UInt32 CountValue);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_GetIoCountValue", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_GetIoCountValue(UInt16 CardNo, UInt16 bitno, ref UInt32 CountValue);
        //���Ϻ����Ժ���Ϊ��λ�ɼ���ʹ�ã��º�����ʱ��ͳһ����Ϊ��λ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reverse_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reverse_outbit(UInt16 CardNo, UInt16 bitno, double reverse_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_count_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_count_mode(UInt16 CardNo, UInt16 bitno, UInt16 mode, double filter_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_count_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_count_mode(UInt16 CardNo, UInt16 bitno, ref UInt16 mode, ref double filter_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_io_count_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_io_count_value(UInt16 CardNo, UInt16 bitno, UInt32 CountValue);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_io_count_value", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_io_count_value(UInt16 CardNo, UInt16 bitno, ref UInt32 CountValue);

        //-----------------------ר��IO ���忨ר��-------------------------
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_inp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_inp_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 inp_logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_inp_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_inp_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 inp_logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_rdy_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 rdy_logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_rdy_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 rdy_logic);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_erc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_erc_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 erc_logic, UInt16 erc_width, UInt16 erc_off_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_erc_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_erc_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 erc_logic, ref UInt16 erc_width, ref UInt16 erc_off_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_alm_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_alm_mode(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 alm_logic, UInt16 alm_action);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_alm_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_alm_mode(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 alm_logic, ref UInt16 alm_action);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_sevon_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_sevon_pin(UInt16 CardNo, UInt16 axis, UInt16 on_off);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_sevon_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_sevon_pin(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_erc_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_erc_pin(UInt16 CardNo, UInt16 axis, UInt16 sel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_erc_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_erc_pin(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_rdy_pin", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_rdy_pin(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_sevrst_pin(UInt16 CardNo, UInt16 axis, UInt16 on_off);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_sevrst_pin(UInt16 CardNo, UInt16 axis);
        //--------------------�˶�״̬----------------------	
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_current_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern double dmc_read_current_speed(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_position(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_position(UInt16 CardNo, UInt16 axis, Int32 current_position);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_target_position", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_get_target_position(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_done(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_done_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_done_multicoor(UInt16 CardNo, UInt16 crd);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_axis_io_status", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_axis_io_status(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_stop(UInt16 CardNo, UInt16 axis, UInt16 stop_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_stop_multicoor", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_stop_multicoor(UInt16 CardNo, UInt16 crd, UInt16 stop_mode);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_emg_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_emg_stop(UInt16 CardNo);
        //����ᵽλ״̬
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_factor_error", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_factor_error(UInt16 CardNo, UInt16 axis, double factor, Int32 error);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_factor_error", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_factor_error(UInt16 CardNo, UInt16 axis, ref double factor, ref Int32 error);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_success_pulse", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_success_pulse(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_success_encoder", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_success_encoder(UInt16 CardNo, UInt16 axis);
        //���忨ָ�� ��������ߺ�ͨѶ״̬
        [DllImport("LTDMC.dll", EntryPoint = "dmc_LinkState", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_LinkState(UInt16 CardNo, ref UInt16 State);

        //���忨ָ�� CAN-IO��չ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_can_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_can_state(UInt16 CardNo, UInt16 NodeNum, UInt16 state, UInt16 Baud);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_can_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_can_state(UInt16 CardNo, ref UInt16 NodeNum, ref UInt16 state);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_can_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_can_outbit(UInt16 CardNo, UInt16 Node, UInt16 bitno, UInt16 on_off);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_can_outbit(UInt16 CardNo, UInt16 Node, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_inbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_can_inbit(UInt16 CardNo, UInt16 Node, UInt16 bitno);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_can_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_can_outport(UInt16 CardNo, UInt16 Node, UInt16 PortNo, UInt32 outport_val);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_outport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_can_outport(UInt16 CardNo, UInt16 Node, UInt16 PortNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_can_inport", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern UInt32 dmc_read_can_inport(UInt16 CardNo, UInt16 Node, UInt16 PortNo);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_can_errcode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_can_errcode(UInt16 CardNo, ref UInt16 Errcode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_can_errcode_extern(UInt16 CardNo, ref UInt16 Errcode, ref UInt16 msg_losed, ref UInt16 emg_msg_num, ref UInt16 lostHeartB, ref UInt16 EmgMsg);
        //CAN-ADDA ���忨ָ��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_output(ushort CardNo, ushort NoteID, ushort channel, double Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_output(ushort CardNo, ushort NoteID, ushort channel, ref double Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_input(ushort CardNo, ushort NoteID, ushort channel, ref double Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_ad_mode(ushort CardNo, ushort NoteID, ushort channel, ushort mode, uint buffer_nums);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_mode(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, uint buffer_nums);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_mode(ushort CardNo, ushort NoteID, ushort channel, ushort mode, uint buffer_nums);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_mode(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, uint buffer_nums);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_to_flash(ushort CardNo, ushort PortNum, ushort NodeNum);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_connect_state(UInt16 CardNo, UInt16 NodeNum, UInt16 state, UInt16 baud);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_connect_state(UInt16 CardNo, ref UInt16 NodeNum, ref UInt16 state);

        //�������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_write_sn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_write_sn(UInt16 CardNo, string new_sn);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_check_sn", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_check_sn(UInt16 CardNo, string check_sn);
        //����sn20191101
        [DllImport("LTDMC.dll")]
        public static extern short dmc_enter_password_ex(UInt16 CardNo, string str_pass);

        //�������ӡ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_debug_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_debug_mode(UInt16 mode, string FileName);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_debug_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_debug_mode(ref UInt16 mode, IntPtr FileName);

        //DMC5000ϵ�����忨��DMC3000/5000���߿����������嵱���ĸ߼��˶��������岹�ȹ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_axis_run_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_axis_run_mode(UInt16 CardNo, UInt16 axis, ref UInt16 run_mode);    //���˶�ģʽ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_trace", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_trace(UInt16 CardNo, UInt16 axis, UInt16 enable);   //trace����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_trace", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_trace(UInt16 CardNo, UInt16 axis, ref UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_trace_data", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_trace_data(UInt16 CardNo, UInt16 axis, UInt16 data_option, ref Int32 ReceiveSize, double[] time, double[] data, ref Int32 remain_num);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_equiv", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_equiv(UInt16 CardNo, UInt16 axis, ref double equiv);   //���嵱��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_equiv", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_equiv(UInt16 CardNo, UInt16 axis, double equiv);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_backlash_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_backlash_unit(UInt16 CardNo, UInt16 axis, double backlash);    //�����϶
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_backlash_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_backlash_unit(UInt16 CardNo, UInt16 axis, ref double backlash);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_position_unit(UInt16 CardNo, UInt16 axis, double pos);   //��ǰָ��λ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_position_unit(UInt16 CardNo, UInt16 axis, ref double pos);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder_unit(UInt16 CardNo, UInt16 axis, double pos);     //��ǰ����λ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_encoder_unit(UInt16 CardNo, UInt16 axis, ref double pos);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_pmove_unit(UInt16 CardNo, UInt16 axis, double Dist, UInt16 posi_mode);   //����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_t_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_t_pmove_unit(UInt16 CardNo, UInt16 axis, double Dist, UInt16 posi_mode);   //�Գ�T�Ͷ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_ex_t_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_ex_t_pmove_unit(UInt16 CardNo, UInt16 axis, double Dist, UInt16 posi_mode);    //�ǶԳ�T�Ͷ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_s_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_s_pmove_unit(UInt16 CardNo, UInt16 axis, double Dist, UInt16 posi_mode);   //�Գ�S�Ͷ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_ex_s_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_ex_s_pmove_unit(UInt16 CardNo, UInt16 axis, double Dist, UInt16 posi_mode);    //�ǶԳ�S�Ͷ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_line_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_line_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, UInt16 posi_mode);    //����ֱ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_center_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_center_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode);     //Բ���յ�ʽԲ��/������/������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_radius_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_radius_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double Arc_Radius, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode);    //�뾶�յ�ʽԲ��/������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_arc_move_3points_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_arc_move_3points_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Mid_Pos, Int32 Circle, UInt16 posi_mode);     //����ʽԲ��/������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_read_current_speed_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_read_current_speed_unit(UInt16 CardNo, UInt16 Axis, ref double current_speed);   //�ᵱǰ�����ٶ�
        //�岹�ٶȲ���(����)�����߿�/5000���忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_profile_unit(UInt16 CardNo, UInt16 Crd, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);   //���β岹�ٶȲ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_profile_unit(UInt16 CardNo, UInt16 Crd, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile_unit(UInt16 CardNo, UInt16 Axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);   //�����ٶȲ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile_unit(UInt16 CardNo, UInt16 Axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_profile_unit_acc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_profile_unit_acc(UInt16 CardNo, UInt16 Axis, double Min_Vel, double Max_Vel, double Tacc, double Tdec, double Stop_Vel);   //�����ٶȲ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_profile_unit_acc", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_profile_unit_acc(UInt16 CardNo, UInt16 Axis, ref double Min_Vel, ref double Max_Vel, ref double Tacc, ref double Tdec, ref double Stop_Vel);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_reset_target_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_reset_target_position_unit(UInt16 CardNo, UInt16 Axis, double New_Pos);     //���߱�λ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_update_target_position_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_update_target_position_unit(UInt16 CardNo, UInt16 Axis, double New_Pos);      //ǿ�б�λ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_change_speed_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_change_speed_unit(UInt16 CardNo, UInt16 Axis, double New_Vel, double Taccdec);      //���߱���

        //�����岹��5000ϵ������/���忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_open_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_open_list(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList);     //������������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_close_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_close_list(UInt16 CardNo, UInt16 Crd);     //�ر�����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_reset_list(UInt16 CardNo, UInt16 Crd);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_stop_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_stop_list(UInt16 CardNo, UInt16 Crd, UInt16 stop_mode);      //�����岹��ֹͣ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_pause_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_pause_list(UInt16 CardNo, UInt16 Crd);   	//�����岹����ͣ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_start_list", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_start_list(UInt16 CardNo, UInt16 Crd);     	//��ʼ�����岹
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_remain_space", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_conti_remain_space(UInt16 CardNo, UInt16 Crd);     //�������岹ʣ�໺����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_read_current_mark", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 dmc_conti_read_current_mark(UInt16 CardNo, UInt16 Crd);      //��ȡ��ǰ�����岹�εı��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_blend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_blend(UInt16 CardNo, UInt16 Crd, UInt16 enable);      //blend�սǹ���ģʽ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_blend", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_blend(UInt16 CardNo, UInt16 Crd, ref UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_lookahead_end_vel_zero", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_lookahead_end_vel_zero(UInt16 CardNo, UInt16 Crd, UInt16 enable);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_profile_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_profile_unit(UInt16 CardNo, UInt16 Crd, double Min_Vel, double Max_vel, double Tacc, double Tdec, double Stop_Vel);      //���������岹�ٶ�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_s_profile(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, double s_para);     //���������岹ƽ��ʱ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_s_profile(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, ref double s_para);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pause_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pause_output(UInt16 CardNo, UInt16 Crd, UInt16 action, Int32 mask, Int32 state);     //��ͣʱIO��� action 0, ��������1�� ��ͣʱ���io_state; 2 ��ͣʱ���io_state, ��������ʱ���Ȼָ�ԭ����io; 3,��2�Ļ����ϣ�ֹͣʱҲ��Ч��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_pause_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_pause_output(UInt16 CardNo, UInt16 Crd, ref UInt16 action, ref Int32 mask, ref Int32 state);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_override", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_override(UInt16 CardNo, UInt16 Crd, double Percent);      //����ÿ���ٶȱ���  ������ָ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_change_speed_ratio", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_change_speed_ratio(UInt16 CardNo, UInt16 Crd, double Percent);    //�����岹��̬����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_run_state", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_run_state(UInt16 CardNo, UInt16 Crd);      //��ȡ�����岹״̬��0-���У�1-��ͣ��2-����ֹͣ��3-�쳣ֹͣ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_check_done", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_check_done(UInt16 CardNo, UInt16 Crd);      //��������岹�˶�״̬��0-���У�1-ֹͣ
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_wait_input", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_wait_input(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double TimeOut, Int32 mark);      //���������岹�ȴ�����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_outbit_to_start", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_outbit_to_start(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double delay_value, UInt16 delay_mode, double ReverseTime);      //����ڹ켣�����IO�ͺ����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_outbit_to_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_outbit_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double delay_time, double ReverseTime);      //����ڹ켣���յ�IO�ͺ����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_ahead_outbit_to_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_ahead_outbit_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double ahead_value, UInt16 ahead_mode, double ReverseTime);  //��Թ켣���յ�IO��ǰ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_accurate_outbit_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_accurate_outbit_unit(UInt16 CardNo, UInt16 Crd, UInt16 cmp_no, UInt16 on_off, UInt16 map_axis, double abs_pos, UInt16 pos_source, double ReverseTime);    //ȷ��λ�þ�ȷ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_write_outbit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_write_outbit(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double ReverseTime);      //����������IO���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay(UInt16 CardNo, UInt16 Crd, double delay_time, Int32 mark);     //�����ʱָ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_reverse_outbit(UInt16 CardNo, UInt16 Crd, UInt16 bitno, double reverse_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_delay_outbit(UInt16 CardNo, UInt16 Crd, UInt16 bitno, UInt16 on_off, double delay_time);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_pmove_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_pmove_unit(UInt16 CardNo, UInt16 Crd, UInt16 Axis, double dist, UInt16 posi_mode, UInt16 mode, Int32 mark); //�����岹�п���ָ�������˶�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_line_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_line_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, UInt16 posi_mode, Int32 mark); //�����岹ֱ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_center_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_center_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode, Int32 mark);     //Բ���յ�ʽԲ��/������/������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_radius_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_radius_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double Arc_Radius, UInt16 Arc_Dir, Int32 Circle, UInt16 posi_mode, Int32 mark);    //�뾶�յ�ʽԲ��/������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_arc_move_3points_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_arc_move_3points_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Mid_Pos, Int32 Circle, UInt16 posi_mode, Int32 mark);     //����ʽԲ��/������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_clear_io_action", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_clear_io_action(UInt16 CardNo, UInt16 Crd, UInt32 IoMask);     //�������δִ�����IO����

        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_stop_reason", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_stop_reason(UInt16 CardNo, UInt16 axis, ref Int32 StopReason);     //��ȡ��ֹͣԭ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_clear_stop_reason", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_clear_stop_reason(UInt16 CardNo, UInt16 axis);     //�����ֹͣԭ��

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_involute_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_involute_mode(UInt16 CardNo, UInt16 Crd, UInt16 mode);      //�����������Ƿ���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_involute_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_involute_mode(UInt16 CardNo, UInt16 Crd, ref UInt16 mode);   //��ȡ�������Ƿ�������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_rectangle_move_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_rectangle_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] TargetPos, double[] MaskPos, Int32 Count, UInt16 rect_mode, UInt16 posi_mode, Int32 mark);     //��������岹�������岹ָ��
        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_center", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_center(double[] start_pos, double[] target_pos, double[] cen_pos, UInt16 arc_dir, double circle, ref double ArcLength);      //����Բ��Բ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_3point", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_3point(double[] start_pos, double[] mid_pos, double[] target_pos, double circle, ref double ArcLength);      //��������Բ������
        [DllImport("LTDMC.dll", EntryPoint = "dmc_calculate_arclength_radius", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_calculate_arclength_radius(double[] start_pos, double[] target_pos, double arc_radius, UInt16 arc_dir, double circle, ref double ArcLength);     //����뾶Բ������

        [DllImport("LTDMC.dll", EntryPoint = "dmc_rectangle_move_unit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_rectangle_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] TargetPos, double[] MaskPos, Int32 Count, UInt16 rect_mode, UInt16 posi_mode);     //��������岹�����β岹ָ��

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_gear_follow_profile(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 master_axis, double ratio);//˫Z��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_gear_follow_profile(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 master_axis, ref double ratio);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_extern(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, UInt16 posi_mode, Int32 mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_arc_move_center_unit_extern(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Target_Pos, double[] Cen_Pos, double Arc_Radius, UInt16 posi_mode, Int32 mark);

        //���ƿ����ߺ�DA���
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_da_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_da_enable(UInt16 CardNo, UInt16 enable);//����DA���       
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_da_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_da_enable(UInt16 CardNo, ref UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_da_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_da_output(UInt16 CardNo, UInt16 channel, double Vout);//����DA���      
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_da_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_da_output(UInt16 CardNo, UInt16 channel, ref double Vout);
        //DA���� 5000���忨
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_da_output(UInt16 CardNo, UInt16 Crd, UInt16 channel, double Vout);

        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_da_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_da_enable(ushort CardNo, ushort Crd, ushort enable, ushort channel, int mark);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_encoder_da_follow_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_encoder_da_follow_enable(ushort CardNo, ushort axis, ushort enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_encoder_da_follow_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_encoder_da_follow_enable(ushort CardNo, ushort axis, ref ushort enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_da_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_da_follow_speed(ushort CardNo, ushort Crd, ushort da_no, double MaxVel, double MaxValue, double acc_offset, double dec_offset, double acc_dist, double dec_dist);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_da_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_da_follow_speed(ushort CardNo, ushort Crd, ushort da_no, ref double MaxVel, ref double MaxValue, ref double acc_offset, ref double dec_offset, ref double acc_dist, ref double dec_dist);
        //���ƿ����ߺ�AD����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_input(ushort CardNo, ushort channel, ref double Vout);

        //���ò岹�˶��ٶ����ߵ�ƽ��ʱ�䣬���߿�/5000���忨
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_vector_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_vector_s_profile(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, double s_para);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_vector_s_profile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_vector_s_profile(UInt16 CardNo, UInt16 Crd, UInt16 s_mode, ref double s_para);
        //С�߶�ǰհ 5000���忨/���߿�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_lookahead_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_lookahead_mode(UInt16 CardNo, UInt16 Crd, UInt16 enable, Int32 LookaheadSegments, double PathError, double LookaheadAcc);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_lookahead_mode", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_lookahead_mode(UInt16 CardNo, UInt16 Crd, ref UInt16 enable, ref Int32 LookaheadSegments, ref double PathError, ref double LookaheadAcc);
        //PWM��� 5000���忨/���߿�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_pin(UInt16 CardNo, UInt16 portno, UInt16 ON_OFF, double dfreqency, double dduty);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_pin(UInt16 CardNo, UInt16 portno, ref UInt16 ON_OFF, ref double dfreqency, ref double dduty);       
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_enable(UInt16 CardNo, UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_enable", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_enable(UInt16 CardNo, ref UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_output(UInt16 CardNo, UInt16 pwm_no, double fDuty, double fFre);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_output(UInt16 CardNo, UInt16 pwm_no, ref double fDuty, ref double fFre);

        //�����岹PWM��� 5000���忨/���߿�
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_pwm_onoff_duty", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_pwm_onoff_duty(UInt16 CardNo, UInt16 PwmNo, double fOnDuty, double fOffDuty);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_pwm_onoff_duty", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_pwm_onoff_duty(UInt16 CardNo, UInt16 PwmNo, ref double fOnDuty, ref double fOffDuty);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pwm_output", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pwm_output(UInt16 CardNo, UInt16 Crd, UInt16 pwm_no, double fDuty, double fFre);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pwm_enable_extern(UInt16 CardNo, UInt16 channel, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pwm_enable_extern(UInt16 CardNo, UInt16 channel, ref UInt16 enable);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_set_pwm_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_set_pwm_follow_speed(UInt16 CardNo, UInt16 Crd, UInt16 pwm_no, UInt16 mode, double MaxVel, double MaxValue, double OutValue);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_get_pwm_follow_speed", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_get_pwm_follow_speed(UInt16 CardNo, UInt16 Crd, UInt16 pwm_no, ref UInt16 mode, ref double MaxVel, ref double MaxValue, ref double OutValue);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_delay_pwm_to_start", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_delay_pwm_to_start(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double delay_value, UInt16 delay_mode, double ReverseTime);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_ahead_pwm_to_stop", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_ahead_pwm_to_stop(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double ahead_value, UInt16 ahead_mode, double ReverseTime);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_conti_write_pwm", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_conti_write_pwm(UInt16 CardNo, UInt16 Crd, UInt16 pwmno, UInt16 on_off, double ReverseTime);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_set_arc_limit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_set_arc_limit(UInt16 CardNo, UInt16 Crd, UInt16 Enable, double MaxCenAcc, double MaxArcError);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_get_arc_limit", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_get_arc_limit(UInt16 CardNo, UInt16 Crd, ref UInt16 Enable, ref double MaxCenAcc, ref double MaxArcError);
        //trace
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_start(ushort CardNo, ushort AxisNum, ushort[] AxisList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_trace_stop(ushort CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_IoFilter(UInt16 CardNo, UInt16 bitno, double filter);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_IoFilter(UInt16 CardNo, UInt16 bitno, ref double filter);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_lsc_index_value(UInt16 CardNo, UInt16 axis, UInt16 IndexID, Int32 IndexValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_lsc_index_value(UInt16 CardNo, UInt16 axis, UInt16 IndexID, ref Int32 IndexValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_lsc_config(UInt16 CardNo, UInt16 axis, UInt16 Origin, UInt32 Interal, UInt32 NegIndex, UInt32 PosIndex, double Ratio);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_lsc_config(UInt16 CardNo, UInt16 axis, ref UInt16 Origin, ref UInt32 Interal, ref UInt32 NegIndex, ref UInt32 PosIndex, ref double Ratio);
        //���Ź���ָ���ʹ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog(UInt16 CardNo, UInt16 enable, UInt32 time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_call_watchdog(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_diagnoseData(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_cmd_end(UInt16 CardNo, UInt16 Crd, UInt16 enable);
        //��������λ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_zone_limit_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, Int32 x_pos_p, Int32 x_pos_n, Int32 y_pos_p, Int32 y_pos_n, UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_zone_limit_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, ref Int32 x_pos_p, ref Int32 x_pos_n, ref Int32 y_pos_p, ref Int32 y_pos_n, ref UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_zone_limit_enable(UInt16 CardNo, UInt16 enable);
        //�ụ������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interlock_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, Int32 delta_pos, UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_interlock_config(UInt16 CardNo, UInt16[] axis, UInt16[] Source, ref Int32 delta_pos, ref UInt16 action_para);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interlock_enable(UInt16 CardNo, UInt16 enable);
        //����ģʽ������ 5000ϵ�п�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_grant_error_protect(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt32 dstp_error, UInt32 emg_error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_grant_error_protect(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt32 dstp_error, ref UInt32 emg_error);
        //����ּ��� �ּ�ר��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_camerablow_config(UInt16 CardNo, UInt16 camerablow_en, Int32 cameraPos, UInt16 piece_num, Int32 piece_distance, UInt16 axis_sel, Int32 latch_distance_min);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_camerablow_config(UInt16 CardNo, ref UInt16 camerablow_en, ref Int32 cameraPos, ref UInt16 piece_num, ref Int32 piece_distance, ref UInt16 axis_sel, ref Int32 latch_distance_min);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_camerablow_errorcode(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_camerablow_errorcode(UInt16 CardNo, ref UInt16 errorcode);
        //����ͨ�����루0~15����Ϊ�����λ�ź�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_limit_config(UInt16 CardNo, UInt16 portno, UInt16 enable, UInt16 axis_sel, UInt16 el_mode, UInt16 el_logic);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_limit_config(UInt16 CardNo, UInt16 portno, ref UInt16 enable, ref UInt16 axis_sel, ref UInt16 el_mode, ref UInt16 el_logic);
        //�����˲�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_handwheel_filter(UInt16 CardNo, UInt16 axis, double filter_factor);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_handwheel_filter(UInt16 CardNo, UInt16 axis, ref double filter_factor);
        //��ȡ����ϵ����ĵ�ǰ�滮����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_interp_map(UInt16 CardNo, UInt16 Crd, ref UInt16 AxisNum, UInt16[] AxisList, double[] pPosList);
        //����ϵ������� 
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_crd_errcode(UInt16 CardNo, UInt16 Crd, ref UInt16 errcode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_line_unit_follow(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] Dist, UInt16 posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_follow(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] pPosList, UInt16 posi_mode, Int32 mark);
        //�����岹������DA����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_da_action(UInt16 CardNo, UInt16 Crd, UInt16 mode, UInt16 portno, double dvalue);
        //���������ٶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_encoder_speed(UInt16 CardNo, UInt16 Axis, ref double current_speed);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_axis_follow_line_enable(UInt16 CardNo, UInt16 Crd, UInt16 enable_flag);
        //�岹�����岹��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_interp_compensation(UInt16 CardNo, UInt16 axis, double dvalue, double time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_interp_compensation(UInt16 CardNo, UInt16 axis, ref double dvalue, ref double time);
        //IO��ȷֹͣ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_exactstop(UInt16 CardNo, UInt16 axis, UInt16 ioNum, UInt16[] ioList, UInt16 enable, UInt16 valid_logic, UInt16 action, UInt16 move_dir);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_distance_to_start(UInt16 CardNo, UInt16 Crd, ref double distance_x, ref double distance_y, Int32 imark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_start_distance_flag(UInt16 CardNo, UInt16 Crd, UInt16 flag);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_soft_limit(UInt16 CardNo, UInt16 Axis, Int32 N_limit, Int32 P_limit);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_soft_limit(UInt16 CardNo, UInt16 Axis, ref Int32 N_limit, ref Int32 P_limit);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_gear_unit(UInt16 CardNo, UInt16 Crd, UInt16 axis, double dist, UInt16 follow_mode, Int32 imark);
        //�켣���ʹ������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_path_fitting_enable(UInt16 CardNo, UInt16 Crd, UInt16 enable);
        //�ݾಹ������(��)
        [DllImport("LTDMC.dll")]
        public static extern short dmc_enable_leadscrew_comp(UInt16 CardNo, UInt16 axis, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_leadscrew_comp_config(UInt16 CardNo, UInt16 axis, UInt16 n, Int32 startpos, Int32 lenpos, Int32[] pCompPos, Int32[] pCompNeg);
        //ָ����������λ���˶� ���̶������˶�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern(UInt16 CardNo, UInt16 axis, double MidPos, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, UInt16 posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_pulse_encoder_count_error(UInt16 CardNo, UInt16 axis, UInt16 error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pulse_encoder_count_error(UInt16 CardNo, UInt16 axis, ref UInt16 error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_pulse_encoder_count_error(UInt16 CardNo, UInt16 axis, ref Int32 pulse_position, ref Int32 enc_position);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_update_target_position_extern(UInt16 CardNo, UInt16 axis, double mid_pos, double aim_pos, double vel, UInt16 posi_mode);

        //������ּ��� �ּ�ר��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_close(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_start(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_init_config(UInt16 CardNo, UInt16 cameraCount, Int32[] pCameraPos, UInt16[] pCamIONo, UInt32 cameraTime, UInt16 cameraTrigLevel, UInt16 blowCount, Int32[] pBlowPos, UInt16[] pBlowIONo, UInt32 blowTime, UInt16 blowTrigLevel, UInt16 axis, UInt16 dir, UInt16 checkMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_camera_trig_count(UInt16 CardNo, UInt16 cameraNum, UInt32 cameraTrigCnt);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_trig_count(UInt16 CardNo, UInt16 cameraNum, ref UInt32 pCameraTrigCnt, UInt16 count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_count(UInt16 CardNo, UInt16 blowNum, UInt32 blowTrigCnt);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_trig_count(UInt16 CardNo, UInt16 blowNum, ref UInt32 pBlowTrigCnt, UInt16 count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_config(UInt16 CardNo, UInt16 index, ref Int32 pos, ref UInt32 trigTime, ref UInt16 ioNo, ref UInt16 trigLevel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_config(UInt16 CardNo, UInt16 index, ref Int32 pos, ref UInt32 trigTime, ref UInt16 ioNo, ref UInt16 trigLevel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_status(UInt16 CardNo, ref Int32 trigCntAll, ref UInt16 trigMore, ref UInt16 trigLess);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_trig_blow(UInt16 CardNo, UInt16 blowNum);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_enable(UInt16 CardNo, UInt16 blowNum, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_piece_config(UInt16 CardNo, UInt32 maxWidth, UInt32 minWidth, UInt32 minDistance, UInt32 minTimeIntervel);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_piece_status(UInt16 CardNo, ref UInt32 pieceFind, ref UInt32 piecePassCam, ref UInt32 dist2next, ref UInt32 pieceWidth);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_cam_trig_phase(UInt16 CardNo, UInt16 blowNo, double coef);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_phase(UInt16 CardNo, UInt16 blowNo, double coef);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_sevon_enable(UInt16 CardNo, UInt16 axis, UInt16 on_off);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sevon_enable(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_cycle(UInt16 CardNo, UInt16 cmp, Int32 pos, UInt16 dir, UInt32 bitno, UInt32 cycle, UInt16 level);//��ӱȽϵ�

        //ʹ�ܺ����ø��ٱ��������ڷ�Χ��ʱ���ֹͣģʽ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_encoder_count_error_action_config(UInt16 CardNo,UInt16 enable,UInt16 stopmode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_count_error_action_config(UInt16 CardNo,ref UInt16 enable,ref UInt16 stopmode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_el_return(UInt16 CardNo, UInt16 axis, UInt16 enable);
        //����������da����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_set_encoder_da_follow_enable(UInt16 CardNo, UInt16 Crd,UInt16 axis,UInt16 enable);	
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_get_encoder_da_follow_enable(UInt16 CardNo, UInt16 Crd,ref UInt16 axis,ref UInt16 enable);
      
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_done_pos(UInt16 CardNo, UInt16 axis, UInt16 posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_factor(UInt16 CardNo, UInt16 axis, double factor);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_error(UInt16 CardNo, UInt16 axis, Int32 error);

        //IO����������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_count_profile(UInt16 CardNo, UInt16 chan, UInt16 bitno,UInt16 mode,double filter, double count_value, UInt16[] axis_list, UInt16 axis_num, UInt16 stop_mode );
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_count_profile(UInt16 CardNo, UInt16 chan, ref UInt16 bitno,ref UInt16 mode,ref double filter, ref double count_value, UInt16[] axis_list, ref UInt16 axis_num, ref UInt16 stop_mode );
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_count_enable(UInt16 CardNo, UInt16 chan, UInt16 ifenable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_clear_io_count(UInt16 CardNo, UInt16 chan);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_count_value_extern(UInt16 CardNo, UInt16 chan, ref Int32 current_value);

        //�ݾಹ��ǰ������λ�ã�������λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_position_ex(UInt16 CardNo,UInt16 axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_encoder_ex(UInt16 CardNo,UInt16 axis, ref double pos);
        //����ƫ��ģʽ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_shift_param(UInt16 CardNo, UInt16 axis, UInt16 pos_clear_mode, double ShiftValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_shift_param(UInt16 CardNo, UInt16 axis, ref UInt16 pos_clear_mode, ref double ShiftValue);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_home_position(UInt16 CardNo, UInt16 axis, UInt16 enable, double position);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_position(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double position);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_change_speed_extend(UInt16 CardNo,UInt16 axis,double Curr_Vel, double Taccdec, UInt16 pin_num, UInt16 trig_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_follow_vector_speed_move(UInt16 CardNo,UInt16 axis,UInt16 Follow_AxisNum,UInt16[] Follow_AxisList,double ratio);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_unit_extend(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] pPosList, UInt16 posi_mode, double Extend_Len, UInt16 enable,Int32 mark); //�����岹ֱ��
        //��ά���ٱȽ� ���߿�/5000���忨
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_config_unit(UInt16 CardNo,UInt16 hcmp,UInt16 cmp_mode,UInt16 x_axis, UInt16 x_cmp_source, double x_cmp_error, UInt16 y_axis, UInt16 y_cmp_source, double y_cmp_error,UInt16 cmp_logic,int time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_config_unit(UInt16 CardNo,UInt16 hcmp,ref UInt16 cmp_mode,ref UInt16 x_axis, ref UInt16 x_cmp_source, ref double x_cmp_error, ref UInt16 y_axis, ref UInt16 y_cmp_source, ref double y_cmp_error,ref UInt16 cmp_logic,ref int time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_set_pwmoutput(UInt16 CardNo,UInt16 hcmp,UInt16 pwm_enable,double duty,double freq,UInt16 pwm_number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_pwmoutput(UInt16 CardNo,UInt16 hcmp,ref UInt16 pwm_enable,ref double duty,ref double freq,ref UInt16 pwm_number);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_add_point_unit(UInt16 CardNo,UInt16 hcmp, double x_cmp_pos, double y_cmp_pos,UInt16 cmp_outbit);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_2d_get_current_state_unit(UInt16 CardNo, UInt16 hcmp, ref int remained_points, ref double x_current_point, ref double y_current_point, ref int runned_points, ref UInt16 current_state, ref UInt16 current_outbit); 

        //ͨ���ļ�����
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_file(ushort CardNo, string pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_download_memfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_download_memfile(ushort CardNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_upload_file", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_upload_file(ushort CardNo, string pfilename, byte[] pfilenameinControl, ushort filetype);
        [DllImport("LTDMC.dll", EntryPoint = "dmc_upload_memfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short dmc_upload_memfile(ushort CardNo, byte[] pbuffer, uint buffsize, byte[] pfilenameinControl, ref uint puifilesize, ushort filetype);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_progress(ushort CardNo, ref float process);

        //���߲���
        [DllImport("LTDMC.dll", EntryPoint = "nmc_download_configfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_download_configfile(UInt16 CardNo, UInt16 PortNum, String FileName);//����ENI�����ļ�
        [DllImport("LTDMC.dll", EntryPoint = "nmc_download_mapfile", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_download_mapfile(UInt16 CardNo, String FileName);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_upload_configfile(UInt16 CardNo, UInt16 PortNum, String FileName);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_set_manager_para", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_set_manager_para(UInt16 CardNo, UInt16 PortNum, Int32 baudrate, UInt16 ManagerID);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_manager_para", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_manager_para(UInt16 CardNo, UInt16 PortNum, ref UInt32 baudrate, ref UInt16 ManagerID);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_set_manager_od", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_set_manager_od(UInt16 CardNo, UInt16 PortNum, UInt16 index, UInt16 subindex, UInt16 valuelength, UInt32 value);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_manager_od", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_manager_od(UInt16 CardNo, UInt16 PortNum, UInt16 index, UInt16 subindex, UInt16 valuelength, ref UInt32 value);

        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_total_axes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_total_axes(ushort CardNo, ref uint TotalAxis);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_total_ionum", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_total_ionum(UInt16 CardNo, ref UInt16 TotalIn, ref UInt16 TotalOut);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_LostHeartbeat_Nodes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_LostHeartbeat_Nodes(UInt16 CardNo, UInt16 PortNum, UInt16[] NodeID, ref UInt16 NodeNum);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_get_EmergeneyMessege_Nodes", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_get_EmergeneyMessege_Nodes(UInt16 CardNo, UInt16 PortNum, UInt32[] NodeMsg, ref UInt16 MsgNum);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_SendNmtCommand", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_SendNmtCommand(UInt16 CardNo, UInt16 PortNum, UInt16 NodeID, UInt16 NmtCommand);
        [DllImport("LTDMC.dll", EntryPoint = "nmc_syn_move", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern short nmc_syn_move(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, Int32[] Position, UInt16[] PosiMode);
        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_syn_move_unit(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, double[] Position, UInt16[] PosiMode);
        //���߶���ͬ���˶�
        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_pmove_unit(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, double[] Dist, UInt16[] PosiMode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_sync_vmove_unit(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] Dir);
        //������վ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_master_para(UInt16 CardNo, UInt16 PortNum, UInt16 Baudrate, UInt32 NodeCnt, UInt16 MasterId);
        //��ȡ��վ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_master_para(UInt16 CardNo, UInt16 PortNum, ref UInt16 Baudrate, ref UInt32 NodeCnt, ref UInt16 MasterId);
        //��ȡ����ADDA�����������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_total_adcnum(ushort CardNo, ref ushort TotalIn, ref ushort TotalOut);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_controller_workmode(ushort CardNo, ushort controller_mode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_controller_workmode(ushort CardNo, ref ushort controller_mode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_cycletime(ushort CardNo, ushort FieldbusType, int CycleTime);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_cycletime(ushort CardNo, ushort FieldbusType, ref int CycleTime);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index, ushort subindex, ushort valuelength, ref int value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_node_od(ushort CardNo, ushort PortNum, ushort nodenum, ushort index, ushort subindex, ushort valuelength, int value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_to_factory(ushort CardNo, ushort PortNum, ushort NodeNum);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_alarm_clear(ushort CardNo, ushort PortNum, ushort nodenum);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_nodes(ushort CardNo, ushort PortNum, ushort BaudRate, ref ushort NodeId, ref ushort NodeNum);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit(ushort CardNo, ushort NodeID, ushort IoBit, ushort IoValue);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit(ushort CardNo, ushort NodeID, ushort IoBit, ref ushort IoValue);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit(ushort CardNo, ushort NodeID, ushort IoBit, ref ushort IoValue);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport(ushort CardNo, ushort NodeID, ushort PortNo, UInt32 IoValue);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport(ushort CardNo, ushort NodeID, ushort PortNo, ref UInt32 IoValue);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport(ushort CardNo, ushort NodeID, ushort PortNo, ref UInt32 IoValue);
        //��״̬��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_state_machine(ushort CardNo, ushort axis, ref ushort Axis_StateMachine);
        //��ȡ��״̬��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_statusword(ushort CardNo, ushort axis, ref int statusword);
        //��ȡ�����ÿ���ģʽ������ֵ��6����ģʽ��8cspģʽ��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_setting_contrlmode(ushort CardNo, ushort axis, ref int contrlmode);
        //���������������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_contrlword(ushort CardNo, ushort axis, int contrlword);
        //��ȡ�����������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlword(ushort CardNo, ushort axis, ref int contrlword);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_type(ushort CardNo, ushort axis, ref ushort Axis_Type);
        //��ȡ����ʱ������ƽ��ʱ�䣬���ʱ�䣬ִ��������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_consume_time_fieldbus(ushort CardNo, ushort Fieldbustype, ref uint Average_time, ref uint Max_time, ref UInt64 Cycles);
        //���ʱ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_consume_time_fieldbus(ushort CardNo, ushort Fieldbustype);
        //���ߵ���ʹ�ܺ��� 255��ʾȫʹ��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_enable(ushort CardNo, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_disable(ushort CardNo, ushort axis);
        // ��ȡ��Ĵ�վ��Ϣ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_node_address(ushort CardNo, ushort axis, ref ushort SlaveAddr, ref ushort Sub_SlaveAddr);
        //��ȡ��������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_total_slaves(ushort CardNo, ushort PortNum, ref ushort TotalSlaves);
        [DllImport("LTDMC.dll")]
        //���߻�ԭ�㺯��
        public static extern short nmc_set_home_profile(ushort CardNo, ushort axis, ushort home_mode, double Low_Vel, double High_Vel, double Tacc, double Tdec, double offsetpos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_home_profile(ushort CardNo, ushort axis, ref ushort home_mode, ref double Low_Vel, ref double High_Vel, ref double Tacc, ref double Tdec, ref double offsetpos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_home_move(ushort CardNo, ushort axis);
        //
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_scan_ethercat(ushort CardNo, ushort AddressID);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_scan_ethercat(ushort CardNo, ushort AddressID);
        //�����������ģʽ 1Ϊppģʽ��6Ϊ����ģʽ��8Ϊcspģʽ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_run_mode(ushort CardNo, ushort axis, ushort run_mode);
        //����˿ڱ���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_alarm_fieldbus(ushort CardNo, ushort PortNum);
        //ֹͣethercat����,����0��ʾ�ɹ�������������ʾ���ɹ�
        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_etc(ushort CardNo, ref ushort ETCState);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_contrlmode(ushort CardNo, ushort Axis, ref int Contrlmode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_io_in(ushort CardNo, ushort axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_axis_io_out(UInt16 CardNo, UInt16 axis, UInt32 iostate);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_io_out(UInt16 CardNo, UInt16 axis);
        // ��ȡ���߶˿ڴ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_errcode(ushort CardNo, ushort channel, ref ushort errcode);
        // ������߶˿ڴ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_errcode(ushort CardNo, ushort channel);
        // ��ȡ�����������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_axis_errcode(ushort CardNo, ushort axis, ref ushort Errcode);
        // ��������������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_axis_errcode(ushort CardNo, ushort axis);

        //RTEX����Ӻ���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_connect(UInt16 CardNo, UInt16 chan, ref UInt16 info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_vendor_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_type_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_name_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_slave_version_info(UInt16 CardNo, UInt16 axis, Byte[] info, ref UInt16 len);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_parameter(UInt16 CardNo, UInt16 axis, UInt16 index, UInt16 subindex, UInt32 para_data);
        /**************************************************************
        *����˵����RTEX������дEEPROM����
        **************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_slave_eeprom(UInt16 CardNo, UInt16 axis);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_parameter(UInt16 CardNo, UInt16 axis, UInt16 index, UInt16 subindex, ref UInt32 para_data);
        /**************************************************************
         * *index:rtex�������Ĳ�������
         * *subindex:rtex��������index����µĲ������
         * *para_data:�����Ĳ���ֵ
         * **************************************************************/
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_parameter_attributes(UInt16 CardNo, UInt16 axis, UInt16 index, UInt16 subindex, ref UInt32 para_data);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_cmdcycletime(UInt16 CardNo, UInt16 PortNum, UInt32 cmdtime);
        //����RTEX�������ڱ�(us)
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_cmdcycletime(UInt16 CardNo, UInt16 PortNum, ref UInt32 cmdtime);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_config_atuo_log(UInt16 CardNo, UInt16 ifenable, UInt16 dir, UInt16 byte_index, UInt16 mask, UInt16 condition, UInt32 counter);

        //��չPDO
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, Int32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref Int32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref Int32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_rxpdo_extra_uint(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, UInt32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_rxpdo_extra_uint(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref UInt32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_txpdo_extra_uint(UInt16 CardNo, UInt16 PortNum, UInt16 address, UInt16 DataLen, ref UInt32 Value);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_log_state(UInt16 CardNo, UInt16 chan, ref UInt32 state);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_driver_reset(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_offset_pos(UInt16 CardNo, UInt16 axis, double offset_pos);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_offset_pos(UInt16 CardNo, UInt16 axis, ref double offset_pos);
        //���rtex����ֵ�������Ķ�Ȧֵ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_abs_driver_multi_cycle(UInt16 CardNo, UInt16 axis);

        //---------------------------EtherCAT IO��չģ�����ָ��----------------------
        //����io���32λ������չ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 portno, UInt32 outport_val);
        //��ȡio���32λ������չ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 portno, ref UInt32 outport_val);
        //��ȡio����32λ������չ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 portno, ref UInt32 inport_val);
        //����io���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 IoBit, UInt16 IoValue);
        //��ȡio���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 IoBit, ref UInt16 IoValue);
        //��ȡio����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit_extern(UInt16 CardNo, UInt16 Channel, UInt16 NoteID, UInt16 IoBit, ref UInt16 IoValue);
        
        //�������������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_current_fieldbus_state_info(UInt16 CardNo, UInt16 Channel, ref UInt16 Axis, ref UInt16 ErrorType, ref UInt16 SlaveAddr, ref UInt32 ErrorFieldbusCode);
        // ������ʷ������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_detail_fieldbus_state_info(UInt16 CardNo, UInt16 Channel, UInt32 ReadErrorNum, ref UInt32 TotalNum, ref UInt32 ActualNum, UInt16[] Axis, UInt16[] ErrorType, UInt16[] SlaveAddr, UInt32[] ErrorFieldbusCode);
        //�����ɼ�
        [DllImport("LTDMC.dll")]
        public static extern short nmc_start_pdo_trace(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, UInt16 Index_Num, UInt32 Trace_Len, UInt16[] Index, UInt16[] Sub_Index);
        //��ȡ�ɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt16 Index_Num, ref UInt32 Trace_Len, UInt16[] Index, UInt16[] Sub_Index);
        //���ô����ɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_pdo_trace_trig_para(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, UInt16 Trig_Index, UInt16 Trig_Sub_Index, int Trig_Value, UInt16 Trig_Mode);
        //��ȡ�����ɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace_trig_para(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt16 Trig_Index, ref UInt16 Trig_Sub_Index, ref int Trig_Value, ref UInt16 Trig_Mode);
        //�ɼ����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_clear_pdo_trace_data(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr);
        //�ɼ�ֹͣ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_stop_pdo_trace(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr);
        //�ɼ����ݶ�ȡ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_pdo_trace_data(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, UInt32 StartAddr, UInt32 Readlen, ref UInt32 ActReadlen, Byte[] Data);
        //�Ѳɼ�����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace_num(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt32 Data_num, ref UInt32 Size_of_each_bag);
        //�ɼ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_pdo_trace_state(UInt16 CardNo, UInt16 Channel, UInt16 SlaveAddr, ref UInt16 Trace_state);
        //����ר��
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_canopen(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_rtex(UInt16 CardNo);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_reset_etc(UInt16 CardNo);
        //���ߴ���������
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_fieldbus_error_switch(UInt16 CardNo, UInt16 channel, UInt16 data);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_fieldbus_error_switch(UInt16 CardNo, UInt16 channel, ref UInt16 data);

        [DllImport("LTDMC.dll")]
        public static extern short nmc_torque_move(UInt16 CardNo, UInt16 axis, int Torque, UInt16 PosLimitValid, double PosLimitValue, UInt16 PosMode);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_change_torque(UInt16 CardNo, UInt16 axis, int Torque);
        //��ȡת�ش�С
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_torque(UInt16 CardNo, UInt16 axis, ref int Torque);
        //modbus����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_modbus_active_COM1(UInt16 id, string COMID,int speed, int bits, int check, int stop);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_modbus_active_COM2(UInt16 id, string COMID, int speed, int bits, int check, int stop);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_modbus_active_ETH(UInt16 id, UInt16 port);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_0x(UInt16 CardNo, UInt16 start, UInt16 inum, byte[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_0x(UInt16 CardNo, UInt16 start, UInt16 inum, byte[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_4x(UInt16 CardNo, UInt16 start, UInt16 inum, UInt16[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_4x(UInt16 CardNo, UInt16 start, UInt16 inum, UInt16[] pdata);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_4x_float(UInt16 CardNo, UInt16 start, UInt16 inum, float[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_4x_float(UInt16 CardNo, UInt16 start, UInt16 inum, float[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_modbus_4x_int(UInt16 CardNo, UInt16 start, UInt16 inum, int[] pdata);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_modbus_4x_int(UInt16 CardNo, UInt16 start, UInt16 inum, int[] pdata);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_line_io_union(UInt16 CardNo,UInt16 Crd,UInt16 AxisNum,UInt16[] AxisList,double[] pPosList,UInt16 posi_mode,UInt16 bitno,UInt16 on_off,double io_value,UInt16 io_mode,UInt16 MapAxis,UInt16 pos_source,double ReverseTime,long mark);
        //���ñ���������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_encoder_dir(UInt16 CardNo, UInt16 axis,UInt16 dir);
        //Բ����������λ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_arc_zone_limit_config(UInt16 CardNo, UInt16[] AxisList, UInt16 AxisNum, double[] Center, double Radius, UInt16 Source,UInt16 StopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_config(UInt16 CardNo, UInt16[] AxisList, ref UInt16 AxisNum, double[] Center, ref double Radius, ref UInt16 Source,ref UInt16 StopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_axis_status(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_arc_zone_limit_enable(UInt16 CardNo, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_arc_zone_limit_enable(UInt16 CardNo, ref UInt16 enable);
        //1��	���û��淽ʽ��ӱȽ�λ�ã�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_set_mode(UInt16 CardNo, UInt16 hcmp, UInt16 fifo_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_get_mode(UInt16 CardNo, UInt16 hcmp, ref UInt16 fifo_mode);
        //2��	��ȡʣ�໺��״̬����λ��ͨ���˺����ж��Ƿ������ӱȽ�λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_get_state(UInt16 CardNo, UInt16 hcmp, ref long remained_points); 
        //3��	������ķ�ʽ������ӱȽ�λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_point_unit(UInt16 CardNo, UInt16 hcmp, UInt16 num, double[] cmp_pos);
        //4��	����Ƚ�λ��,Ҳ���FPGA��λ��ͬ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_clear_points(UInt16 CardNo, UInt16 hcmp);
        //��Ӵ����ݣ������һ��ʱ�䣬ָ������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_fifo_add_table(UInt16 CardNo, UInt16 hcmp, UInt16 num, double[] cmp_pos);
        //���ƿ����ߺж��ߺ��Ƿ��ʼ�������ƽ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_output_status_repower(UInt16 CardNo, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_softlanding(UInt16 CardNo, UInt16 axis, double MidPos, double TargetPos, double start_Vel, double Max_Vel, double stop_Vel, UInt32 delay_ms, double Max_Vel2, double stop_vel2, double acc_time, double dec_time, UInt16 posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_XD(UInt16 CardNo, UInt16 cmp, long pos, UInt16 dir, UInt16 action, UInt32 actpara, long startPos);//���綨�ƱȽϺ���
        
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_change_pos_speed_config(UInt16 CardNo, UInt16 axis, double tar_vel, double tar_rel_pos, UInt16 trig_mode, UInt16 source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_config(UInt16 CardNo, UInt16 axis, ref double tar_vel, ref double tar_rel_pos, ref UInt16 trig_mode, ref UInt16 source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pmove_change_pos_speed_enable(UInt16 CardNo, UInt16 axis, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_enable(UInt16 CardNo, UInt16 axis, ref UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_extend(UInt16 CardNo, UInt16 axis, long pos, UInt16 dir, UInt16 action, UInt16 para_num, ref UInt32 actpara, UInt32 compare_time);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_cmd_position(UInt16 CardNo, UInt16 axis, ref double pos);
        //�߼���������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_logic_analyzer_config(UInt16 CardNo, UInt16 channel, UInt32 SampleFre, UInt32 SampleDepth, UInt16 SampleMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_start_logic_analyzer(UInt16 CardNo, UInt16 channel, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_logic_analyzer_counter(UInt16 CardNo, UInt16 channel, ref UInt32 counter);
        //kg����	 20190923�޸Ķ��ƺ����ӿ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inbit_append(UInt16 CardNo, UInt16 bitno);//��ȡ����ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outbit_append(UInt16 CardNo, UInt16 bitno, UInt16 on_off);//��������ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outbit_append(UInt16 CardNo, UInt16 bitno);//��ȡ����ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern UInt32 dmc_read_inport_append(UInt16 CardNo, UInt16 portno);//��ȡ����˿ڵ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern UInt32 dmc_read_outport_append(UInt16 CardNo, UInt16 portno);//��ȡ����˿ڵ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_write_outport_append(UInt16 CardNo, UInt16 portno, UInt32 port_value);//������������˿ڵ�ֵ
        // ��������ϵ�������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_tangent_follow(UInt16 CardNo, UInt16 Crd, UInt16 axis, UInt16 follow_curve, UInt16 rotate_dir, double degree_equivalent);
        // ��ȡָ������ϵ����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_tangent_follow_param(UInt16 CardNo, UInt16 Crd, ref UInt16 axis, ref UInt16 follow_curve, ref UInt16 rotate_dir, ref double degree_equivalent);
        // ȡ������ϵ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_disable_follow_move(UInt16 CardNo, UInt16 Crd);
        // ��Բ�岹
        [DllImport("LTDMC.dll")]
        public static extern short dmc_ellipse_move(UInt16 CardNo, UInt16 Crd, UInt16 axisNum, UInt16[] Axis_List, double[] Target_Pos, double[] Cen_Pos, double A_Axis_Len, double B_Axis_Len, UInt16 Dir, UInt16 Pos_Mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_vector_speed_unit(UInt16 CardNo, UInt16 Crd, ref double current_speed);	//��ȡ��ǰ���Ĳ岹�ٶ�
        //��ȡ��������λ����ʹ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_home_el_return(UInt16 CardNo, UInt16 axis, ref UInt16 enable);
        //�¿��Ź�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog_action_event(UInt16 CardNo, UInt16 event_mask);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_watchdog_action_event(UInt16 CardNo, ref UInt16 event_mask);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_watchdog_enable(UInt16 CardNo, double timer_period, UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_watchdog_enable(UInt16 CardNo, ref double timer_period, ref UInt16 enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_reset_watchdog_timer(UInt16 CardNo);
        //io���ƹ���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_io_check_control(UInt16 CardNo, UInt16 sensor_in_no, UInt16 check_mode, UInt16 A_out_no, UInt16 B_out_no, UInt16 C_out_no, UInt16 output_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_io_check_control(UInt16 CardNo, ref UInt16 sensor_in_no, ref UInt16 check_mode, ref UInt16 A_out_no, ref UInt16 B_out_no, ref UInt16 C_out_no, ref UInt16 output_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_stop_io_check_control(UInt16 CardNo);
        //������λ����ƫ�ƾ���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_el_ret_deviation(UInt16 CardNo, UInt16 axis, UInt16 enable, double deviation);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_el_ret_deviation(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref double deviation);
        //����ģʽ��������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_grant_error_protect_unit(UInt16 CardNo, UInt16 axis,UInt16 enable,double dstp_error, double emg_error);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_grant_error_protect_unit(UInt16 CardNo, UInt16 axis,ref UInt16 enable, ref double dstp_error, ref double emg_error);
        //�ݾಹ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_leadscrew_comp_config(UInt16 CardNo, UInt16 axis, ref UInt16 n, ref int startpos, ref int lenpos, int[] pCompPos, int[] pCompNeg);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_leadscrew_comp_config_unit(UInt16 CardNo, UInt16 axis, UInt16 n, double startpos, double lenpos, double[] pCompPos, double[] pCompNeg);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_leadscrew_comp_config_unit(UInt16 CardNo, UInt16 axis, ref UInt16 n, ref double startpos, ref double lenpos, double[] pCompPos, double[] pCompNeg);
        //EZ���� ԭ�����棬���������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_homelatch_value_unit(UInt16 CardNo, UInt16 axis, ref double pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ezlatch_value_unit(UInt16 CardNo, UInt16 axis, ref double pos);
        //��������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_latch_value_extern_unit(UInt16 CardNo, UInt16 axis, UInt16 index, ref double pos_by_mm);//������ȡֵ��ȡ 
        //һά�Ƚ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_unit(UInt16 CardNo,UInt16 cmp,double pos,UInt16 dir, UInt16 action,UInt32 actpara);//��ӱȽϵ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_get_current_point_unit(UInt16 CardNo,UInt16 cmp,ref double pos);//��ȡ��ǰ�Ƚϵ�
        //����λ�ñȽ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_multi_unit(UInt16 CardNo, UInt16 cmp,double pos, UInt16 dir,  UInt16 action, UInt32 actpara,double times);//��ӱȽϵ� ��ǿ
        //����λ�ñȽ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_add_point_unit(UInt16 CardNo,UInt16 hcmp, double cmp_pos);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_liner_unit(UInt16 CardNo,UInt16 hcmp, double Increment,Int32 Count);//��������ģʽ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_liner_unit(UInt16 CardNo,UInt16 hcmp, ref double Increment, ref Int32 Count);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_current_state_unit(UInt16 CardNo, UInt16 hcmp, ref Int32 remained_points, ref double current_point, ref Int32 runned_points); //��ȡ���ٱȽ�״̬
                
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_softlimit_unit(UInt16 CardNo, UInt16 axis, UInt16 enable, UInt16 source_sel, UInt16 SL_action, double N_limit, double P_limit);//��������λ����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_softlimit_unit(UInt16 CardNo, UInt16 axis, ref UInt16 enable, ref UInt16 source_sel, ref UInt16 SL_action, ref double N_limit, ref double P_limit);//��ȡ����λ����
        //����λ�õ��ӣ����ٱȽϹ���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_set_config_overlap(UInt16 CardNo, UInt16 hcmp, UInt16 axis, UInt16 cmp_source, UInt16 cmp_logic, Int32 time, UInt16 axis_num, UInt16 aux_axis, UInt16 aux_source);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_hcmp_get_config_overlap(UInt16 CardNo, UInt16 hcmp, ref UInt16 axis, ref UInt16 cmp_source, ref UInt16 cmp_logic, ref Int32 time, ref UInt16 axis_num, ref UInt16 aux_axis, ref UInt16 aux_source);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_t_pmove_extern_unit(UInt16 CardNo, UInt16 axis, double MidPos, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, UInt16 posi_mode);

        //�������߹ر�RTCP����,�������
        
        //�����岹
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_helix_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AixsList, double[] StartPos, double[] TargetPos, UInt16 Arc_Dir, int Circle, UInt16 mode, int mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_helix_move_unit(UInt16 CardNo, UInt16 Crd, UInt16 AxisNum, UInt16[] AxisList, double[] StartPos, double[] TargetPos, UInt16 Arc_Dir, int Circle, UInt16 mode);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_compare_add_point_cycle_unit(UInt16 CardNo, UInt16 cmp, double pos, UInt16 dir, UInt32 bitno, UInt32 cycle, UInt16 level);//��ӱȽϵ�
        //PDO����20190715
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_enter(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_stop(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_clear(UInt16 CardNo, UInt16 axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_run_state(UInt16 CardNo,UInt16 axis, ref int RunState, ref int Remain, ref int NotRunned, ref int Runned);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_add_data(UInt16 CardNo,UInt16 axis, int size, int[] data_table);
        
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_start_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] ResultList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_pause_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] ResultList);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_pdo_buffer_stop_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, UInt16[] ResultList);
        //[DllImport("LTDMC.dll")]
        //public static extern short dmc_pdo_buffer_add_data_multi(UInt16 CardNo, UInt16 AxisNum, UInt16[] AxisList, int size, int[][] data_table);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_calculate_arccenter_3point(double[] start_pos, double[] mid_pos, double[] target_pos, double[] cen_pos);       
        //��λ���������˶�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_set_muti_profile_unit(ushort card, ushort group, ushort axis_num, ushort[] axis_list, double[] start_vel, double[] max_vel, double[] tacc, double[] tdec, double[] stop_vel);//�����ٶ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_set_profile_unit(ushort card, ushort group, ushort axis, double start_vel, double max_vel, double tacc, double tdec, double stop_vel);//�����ٶ�����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_sigaxis_moveseg_data(ushort card, ushort group, ushort axis, double Target_pos, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_sigaxis_move_twoseg_data(ushort card, ushort group, ushort axis, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiaxis_moveseg_data(ushort card, ushort group, ushort axisnum, ushort[] axis_list, double[] Target_pos, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiaxis_move_twoseg_data(ushort card, ushort group, ushort axisnum, ushort[] axis_list, double[] Target_pos, double[] second_pos, double[] second_vel, double[] second_endvel, ushort process_mode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioTrig_movseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, ushort process_mode, ushort trigINbit, ushort trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiposTrig_movseg_data(ushort card, ushort group, ushort axis, double Target_pos, ushort process_mode, ushort trigaxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);//λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_mutiposTrig_mov_twoseg_data(ushort card, ushort group, ushort axis, double Target_pos, double softland_pos, double softland_vel, double softland_endvel, ushort process_mode, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);//����λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_upseg_data(ushort card, ushort group, ushort axis, double Target_pos, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_up_twoseg_data(ushort card, ushort group, ushort axis, double Target_pos, double second_pos, double second_vel, double second_endvel, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_movseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, ushort TrigINNum, ushort[] trigINList, ushort[] trigINstate, uint mark);//λ��+io�����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_mov_twoseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, double[] second_pos, double[] second_vel, double[] second_endvel, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, ushort TrigINNum, ushort[] trigINList, ushort[] trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_movseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, uint mark);//λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_mov_twoseg_data(ushort card, ushort group, ushort axisNum, ushort[] axisList, double[] Target_pos, double[] second_pos, double[] second_vel, double[] second_endvel, ushort process_mode, ushort trigAxis, double trigPos, ushort trigPosType, ushort trigMode, uint mark);//λ�ô����ƶ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_down_seg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, ushort trigIN, ushort trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_ioPosTrig_down_twoseg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, ushort trigIN, ushort trigINstate, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_seg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_twoseg_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort trigAxisNum, ushort[] trigAxisList, double[] trigPos, ushort[] trigPosType, ushort[] trigMode, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_seg_cmd_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, ushort trigAxisNum, ushort[] trigAxisList, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_add_posTrig_down_twoseg_cmd_data(ushort card, ushort group, ushort axis, double safePos, double Target_pos, double second_pos, double second_vel, double second_endvel, ushort trigAxisNum, ushort[] trigAxisList, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_posTrig_outbit(ushort card, ushort group, ushort bitno, ushort on_off, ushort ahead_axis, double ahead_value, ushort ahead_PosType, ushort ahead_Mode, uint mark);//λ�ô���IO���
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_immediate_write_outbit(ushort card, ushort group, ushort bitno, ushort on_off, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_wait_input(ushort card, ushort group, ushort bitno, ushort on_off, double time_out, uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_delay_time(ushort card, ushort group, double delay_time, uint mark);//��ʱָ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_get_run_state(ushort card, ushort group, ref ushort state, ref ushort enable, ref uint stop_reason, ref ushort trig_phase, ref uint mark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_open_list(ushort card, ushort group, ushort axis_num, ushort[] axis_list);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_close_list(ushort card, ushort group);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_start_list(ushort card, ushort group);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_stop_list(ushort card, ushort group, ushort stopMode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_m_pause_list(ushort card, ushort group);

        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_ad_input_all(ushort CardNo, ref double Vout);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_pmove_unit_pausemode(ushort CardNo, ushort axis, double TargetPos, double Min_Vel, double Max_Vel, double stop_Vel, double acc, double dec, double smooth_time, ushort posi_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_return_pausemode(ushort CardNo, ushort Crd, ushort axis);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_check_if_crc_support(ushort CardNo);
        //����ײ��⹦�ܽӿ� 
        [DllImport("LTDMC.dll")]
        public static extern short dmc_set_axis_conflict_config(ushort CardNo, ushort[] axis_list, ushort[] axis_depart_dir, double home_dist, double conflict_dist, ushort stop_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_conflict_config(ushort CardNo, ushort[] axis_list, ushort[] axis_depart_dir, ref double home_dist, ref double conflict_dist, ref ushort stop_mode);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_axis_conflict_config_en(ushort CardNo, ushort enable);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_conflict_config_en(ushort CardNo, ref ushort enable);
        //trig_num ����������trig_pos ����λ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_pmove_change_pos_speed_state(ushort CardNo, ushort axis, ref ushort trig_num, double[] trig_pos);
        //������������Ӵ�����ֵ�Ľӿ�
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inbit_ex(ushort CardNo, ushort bitno, ref ushort state);//��ȡ����ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outbit_ex(ushort CardNo, ushort bitno, ref ushort state);//��ȡ����ڵ�״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_inport_ex(ushort CardNo, ushort portno, ref UInt32 state);//��ȡ����˿ڵ�ֵ
        [DllImport("LTDMC.dll")]
        public static extern short dmc_read_outport_ex(ushort CardNo, ushort portno, ref UInt32 state);//��ȡ����˿ڵ�ֵ
        //ģ�����Ӷ�ȡ״̬
        //����io���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outbit_ex(ushort CardNo, ushort NoteID, ushort IoBit, ushort IoValue, ref ushort state);
        //��ȡio���
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outbit_ex(ushort CardNo, ushort NoteID, ushort IoBit, ref ushort IoValue, ref ushort state);
        //��ȡio����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inbit_ex(ushort CardNo, ushort NoteID, ushort IoBit, ref ushort IoValue, ref ushort state);
        //����io���32λ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_outport_ex(ushort CardNo, ushort NoteID, ushort portno, UInt32 outport_val, ref ushort state);
        //��ȡio���32λ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_outport_ex(ushort CardNo, ushort NoteID, ushort portno, ref UInt32 outport_val, ref ushort state);
        //��ȡio����32λ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_read_inport_ex(ushort CardNo, ushort NoteID, ushort portno, ref UInt32 inport_val, ref ushort state);
        //CAN ADDAָ�� ����DA���� ���忨	
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_output_ex(ushort CardNo,ushort NoteID,ushort channel,double Value,ref ushort state);
        //��ȡDA����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_output_ex(ushort CardNo, ushort NoteID, ushort channel, ref double Value, ref ushort state);
        //��ȡAD����
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_input_ex(ushort CardNo, ushort NoteID, ushort channel, ref double Value, ref ushort state);
        //����ADģʽ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_ad_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ushort mode, UInt32 buffer_nums, ref ushort state);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_ad_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, UInt32 buffer_nums, ref ushort state);
        //����DAģʽ
        [DllImport("LTDMC.dll")]
        public static extern short nmc_set_da_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ushort mode, UInt32 buffer_nums, ref ushort state);
        [DllImport("LTDMC.dll")]
        public static extern short nmc_get_da_mode_ex(ushort CardNo, ushort NoteID, ushort channel, ref ushort mode, UInt32 buffer_nums, ref ushort state);
        //����д��flash
        [DllImport("LTDMC.dll")]
        public static extern short nmc_write_to_flash_ex(ushort CardNo, ushort PortNum, ushort NodeNum, ref ushort state);
        //����ּ��ͨ��
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_close_ex(ushort CardNo, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_start_ex(ushort CardNo, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_init_config_ex(ushort CardNo, ushort cameraCount, int[] pCameraPos, ushort[] pCamIONo, UInt32 cameraTime, ushort cameraTrigLevel, ushort blowCount, int[] pBlowPos, ushort[] pBlowIONo, UInt32 blowTime, ushort blowTrigLevel, ushort axis, ushort dir, ushort checkMode, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_camera_trig_count_ex(ushort CardNo, ushort cameraNum, UInt32 cameraTrigCnt, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_trig_count_ex(ushort CardNo, ushort cameraNum, ref UInt32 pCameraTrigCnt, ushort count, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_count_ex(ushort CardNo, ushort blowNum, UInt32 blowTrigCnt, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_trig_count_ex(ushort CardNo, ushort blowNum, ref UInt32 pBlowTrigCnt, ushort count, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_camera_config_ex(ushort CardNo, ushort index, ref int pos, ref UInt32 trigTime, ref ushort ioNo, ref ushort trigLevel, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_config_ex(ushort CardNo, ushort index, ref int pos, ref UInt32 trigTime, ref ushort ioNo, ref ushort trigLevel, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_blow_status_ex(ushort CardNo, ref UInt32 trigCntAll, ref ushort trigMore, ref ushort trigLess, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_trig_blow_ex(ushort CardNo, ushort blowNum, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_enable_ex(ushort CardNo, ushort blowNum, ushort enable, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_piece_config_ex(ushort CardNo, UInt32 maxWidth, UInt32 minWidth, UInt32 minDistance, UInt32 minTimeIntervel, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_get_piece_status_ex(ushort CardNo, ref UInt32 pieceFind, ref UInt32 piecePassCam, ref UInt32 dist2next, ref UInt32 pieceWidth, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_cam_trig_phase_ex(ushort CardNo, ushort blowNo, double coef, ushort sortModuleNo);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_sorting_set_blow_trig_phase_ex(ushort CardNo, ushort blowNo, double coef, ushort sortModuleNo);
        //��ȡ�ּ�ָ����������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sortdev_blow_cmd_cnt(ushort CardNo, ushort blowDevNum, ref long cnt);
        //��ȡδ����ָ��������������
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sortdev_blow_cmderr_cnt(ushort CardNo, ushort blowDevNum, ref long errCnt);
        //�ּ����״̬
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_sortqueue_status(ushort CardNo, ref long curSorQueueLen, ref long passCamWithNoCmd);
        // ��Բ�����岹
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_ellipse_move_unit(ushort CardNo, ushort Crd,ushort AxisNum, ushort[] AxisList, double[] Target_Pos, double[] Cen_Pos, double A_Axis_Len, double B_Axis_Len, ushort Dir, ushort Pos_Mode,long mark);
        //��ȡ��״̬����
        [DllImport("LTDMC.dll")]
        public static extern short dmc_get_axis_status_advance(ushort CardNo, ushort axis_no, ushort motion_no, ref ushort axis_plan_state, ref UInt32 ErrPlulseCnt, ref ushort fpga_busy);
        //�����岹vmove
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_vmove_unit(ushort CardNo, ushort Crd, ushort axis, double vel, double acc, ushort dir, Int32 imark);
        [DllImport("LTDMC.dll")]
        public static extern short dmc_conti_vmove_stop(ushort CardNo, ushort Crd, ushort axis, double dec, Int32 imark);
    }
}
