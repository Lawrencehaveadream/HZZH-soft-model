using System.Collections.Generic;
using Common;
using System.Diagnostics;
using Device;

namespace Motion
{
	public class BasicApiDef	//基础的api访问方式，不带参数
	{
		public ushort Addr { get; set; }//寄存器地址
		public int start { get; set; }
		public int busy { get; set; }
		public int done { get; set; }
		public BoardCtrllerManager movedriverZm { get; set; }//板卡
		public BaseData CommData { get; set; }//通讯数据实例


		//内部用的东西
		public int StartStep = 0;//执行步骤
		public Stopwatch StartOT = new Stopwatch ();//执行步骤定时器
		public int StatusStep = 0;//状态步骤
		public Stopwatch StatusOT = new Stopwatch();//状态步骤定时器
		public BasicApiDef(BoardCtrllerManager movedriverZm, ushort Addr)
		{
			this.movedriverZm = movedriverZm;
			this.Addr = Addr;

		}
		public bool exe()
		{
			switch (StartStep)
			{ 
				case 0:
					List<byte> temp = new List<byte>();
					temp.AddRange(Functions.NetworkBytes(1));
					temp.AddRange(Functions.NetworkBytes(0));
					temp.AddRange(Functions.NetworkBytes(0));
					CommData = new BaseData(Addr,temp.ToArray());
					movedriverZm.WriteRegister(CommData);
					StartOT.Restart();
					StartStep = 1;
					return false;
				case 1:
					if (CommData.Succeed == true)
					{
						StartStep = 0;
						CommData.Succeed = false;
						return true;
					}
					if (StartOT.ElapsedMilliseconds > 1000)
					{
						StartStep = 0;
					}
					return false;
				    default:
					StartStep = 0;
					CommData.Succeed = false;
					return false;
			}
		}
		public bool sta()
		{
			switch(StatusStep)
			{
				case 0:
					CommData = new BaseData(Addr, 3, DataType.Int);
					movedriverZm.ReadRegister(CommData);
					StatusOT.Restart();
					StatusStep = 1;
					return false;
				case 1:
					if (CommData.Succeed == true)
					{
						start = CommData.IntValue[0];
						busy = CommData.IntValue[1];
						done = CommData.IntValue[2];
						StatusStep = 0;
						CommData.Succeed = false;
						return true;
					}
					if (StatusOT.ElapsedMilliseconds > 1000)
					{
						StatusStep = 0;
					}
					return false;
				    default:
					StatusStep = 0;
					CommData.Succeed = false;
					return false;
			}
		}
	}
# region   根据不同项目编写面向项目的逻辑接口

    






#endregion
}
