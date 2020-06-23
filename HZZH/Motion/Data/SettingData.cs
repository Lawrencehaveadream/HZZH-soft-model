using System;
using System.Collections.Generic;
using Common;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Motion
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class module1 //模块1        具体机器参数，需要下发
    {
		
	}
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class module2    //模块2      具体机器参数，需要下发
    {
		
	}
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    //模块3
    //模块4
    //............
    
	public class RunDataDef		//运行参数，不需要下发
	{
	 /**************************************
      * 
      * 
      * 
      设置运行参数的应用属性
      *
      * 
      * 
      * ****************************************/
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]


    public class SettingDataDef  //整个逻辑参数
	{
		//增加使用的属性
		public SettingDataDef()
		{
		  //方法
		}

		/// <summary>
        /// 新建配置
        /// </summary>
        public void CreatProject()
        {
            try
            {
                //实例化上述用到的工程类
            }
            catch (Exception ex)
            {
                Common.LogWriter.WriteException(ex);
                Common.LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }

		/// <summary>
		/// 加载配置
		/// </summary>
		public void OpenProject(string path)
		{
			try
			{
				SettingDataDef data = (SettingDataDef)Common.CreateProject.OpenProject(typeof(SettingDataDef), path);
				//将data的数据赋给this. 数据
			}
			catch (Exception ex)
			{
				Common.LogWriter.WriteException(ex);
				Common.LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
			}
		}
        /// <summary>
        /// 保存配置
        /// </summary>
        public void SaveProject(string path)
        {
            Common.CreateProject.SaveProject(this,path);
        }
	}
}
