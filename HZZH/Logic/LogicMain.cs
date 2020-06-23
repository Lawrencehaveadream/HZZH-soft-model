using System;
using System.Collections.Generic;
using Common;
using System.Windows.Forms;
using System.Threading;
using Motion;
using Config;
using System.Diagnostics;
using Device;
using Vision;

namespace Logic
{
	public class TaskDef//每个任务运行的控制参数	下位的LogicParaDef
	{
		public int execute;
		public int step;
		public int done;
		public int cnt;
		public Stopwatch Timer = new Stopwatch ();

		public void Start()	//通用的任务开始方法
		{
			if (execute == 1 && step == 0)
			{
				step = 1;
				done = 0;
			}
		}
	}

	public class LogicTaskDef//流程任务集合	下位的LogicTaskDef
	{
        /// <summary>
        /// 实例化项目任务
        /// </summary>
		//例如  上锡任务/打磨任务/上胶任务/切刀任务/包装任务等等等
	}

	public class LogicMain//设备流程 下位的Logic.c
	{
       //在这里实例化logic所有需要用到的资源
		public static bool LogicThreadLife = true;
        public BoardCtrllerManager movedriverZm = new BoardCtrllerManager();//板卡
		public Thread LogicThread;	
        public LogicTaskDef LogicTask { get; set; }					 //上位的流程任务集
        public SettingDataDef LogicData { get; set; }			    //下位模块运行所需要的数据
        public ProcessDataDef ProcessData { get; set; } 	    //过程数据，流程运行的临时数据，比如说料盒到第几层啦，点胶到第几个点
        public FsmDef FSM { get; set; }								            //状态机，只提供状态切换和当前状态

		public LogicMain()
        {
            /// <summary>
            /// 实例化接口及数据
            /// </summary>
            LogicTask = new LogicTaskDef();
			LogicData = new SettingDataDef();
            ProcessData = new ProcessDataDef();
			FSM = new FsmDef(movedriverZm);
			LogicThread = new Thread(LogicThreadFunc);
			LogicThread.Start();
        }
        #region 在这里写流程模块
       /// <summary>
       /// 流程分模块编写
       /// </summary>
		#endregion

		#region 下位机数据块下发
		public void DataToSlaver()
		{
			List<byte> temp = new List<byte>();
			///<summary>
            ///下发数据的内容，有顺序的进行下发，防止乱码
            ///</summary>


		}
		#endregion

		public void LogicThreadFunc()//逻辑最外层函数，需放在线程中一直运行，下位的Logic()
		{
			Stopwatch TC = new Stopwatch();
			while (LogicThreadLife)
			{
				try
				{
					if (movedriverZm.Succeed == true)
					{
                        if (FSM.GetStatus() == (int)FsmStaDef.INIT)
                        {
                            //LogicTask = new LogicTaskDef();
                            //LogicAPI = new LogicAPIDef(movedriverZm);
                        }


					}
					else
					{
						Thread.Sleep(1);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Logic流程错误：" + ex.Message.ToString());
				}
			}
		}
    }
}
