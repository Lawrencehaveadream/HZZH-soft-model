using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion
{
	public enum AxisDef:int
	{
        #region 对下位的轴的定义枚举 引用轴时只需要引用此枚举里的数值
        //轴1 = 0，
        //轴2，
        //轴3，
        //轴4，
        //轴5，
        //轴6，
        //轴7，
        //轴8，
        //轴9，
        //轴10，
        //轴11
        AxX1 = 0,
        AxY1 = 1,
        AxZ1 = 2,
        AxR1 = 3,
        AxT1 = 4,
        AxS1 = 5,

        AxX2 = 6,
        AxY2 = 7,
        AxZ2 = 8,
        AxR2 = 9,
        AxT2 = 10,
        AxS2 = 11,

        AxX3 = 12,
        AxZ3 = 13,
        AxR3 = 14,
        #endregion
    }
}
