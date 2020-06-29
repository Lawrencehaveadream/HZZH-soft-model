using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Motion
{ 
	public class ProcessDataDef//过程数据，不需要存文件，但流程运行中会改变的数据
	{
        //设置过程数据里的属性
        /// <summary>
        /// 打磨点拍照
        /// </summary>
        public List<wPointF>[] wPointFs_PolishF = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
        public List<wPointF>[] wPointFs_PolishV = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };



        /// <summary>
        /// 上锡点拍照
        /// </summary>
        public List<wPointF>[] wPointFs_SolderF = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
        public List<wPointF>[] wPointFs_SolderV = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };

        /// <summary>
        /// 工作点
        /// </summary>
        public List<SolderPosdata>[] SolderList = new List<SolderPosdata>[] { new List<SolderPosdata>(), new List<SolderPosdata>() };
        public List<PolishPosdata>[] PolishList = new List<PolishPosdata>[] { new List<PolishPosdata>(), new List<PolishPosdata>() };

        public List<float>[] SolderList_Ang = new List<float>[] { new List<float>(), new List<float>() };

        public ProcessDataDef()
		{
            //定义 过程数据的方法
            wPointFs_PolishF = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
            wPointFs_PolishV = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
            wPointFs_SolderF = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
            wPointFs_SolderV = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };

            SolderList = new List<SolderPosdata>[] { new List<SolderPosdata>(), new List<SolderPosdata>() };
            PolishList = new List<PolishPosdata>[] { new List<PolishPosdata>(), new List<PolishPosdata>() };

        }
    }

}
