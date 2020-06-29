using System;
using System.Collections.Generic;
using Common;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Drawing;
using Common.PointLayout;

namespace Motion
{
    public enum SiteRegion : int
    {
        SOLDER_LIFT,
        SOLDER_RIGHT,
        POLISH_LIFT,
        POLISH_RIGHT
    }
    /// <summary>
    /// 上锡参数
    /// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class SolderDef : ICloneable //模块1 具体机器参数，需要下发
    {
        #region 上锡属性
        [Category("第一段"),DisplayName("第一段送锡长度")]
        public float FrontLen { get; set; }
        [Category("第一段"),DisplayName("第一段送锡速度")]
        public float FrontSpeed { get; set; }
        [Category("第一段"),DisplayName("第一段退锡长度")]
        public float BackLen { get; set; }
        [Category("第一段"),DisplayName("第一段退锡速度")]
        public float BackSpeed { get; set; }

        [Category("第二段"), DisplayName("第二段送锡长度")]
        public float FrontLen2 { get; set; }
        [Category("第二段"), DisplayName("第二段送锡速度")]
        public float FrontSpeed2 { get; set; }
        [Category("第二段"), DisplayName("第二段退锡长度")]
        public float BackLen2 { get; set; }
        [Category("第二段"), DisplayName("第二段退锡速度")]
        public float BackSpeed2 { get; set; }


        [Category("第三段"), DisplayName("第三段送锡长度")]
        public float FrontLen3 { get; set; }
        [Category("第三段"), DisplayName("第三段送锡速度")]
        public float FrontSpeed3 { get; set; }
        [Category("第三段"), DisplayName("第三段退锡长度")]
        public float BackLen3 { get; set; }
        [Category("第三段"), DisplayName("第三段退锡速度")]
        public float BackSpeed3 { get; set; }


        [Category("第一段"), DisplayName("第一段送锡延时")]
        public int SendDelay { get; set; }
        [Category("第二段"), DisplayName("第二段送锡延时")]
        public int SendDelay2 { get; set; }
        [Category("第三段"), DisplayName("第三段送锡延时")]
        public int SendDelay3 { get; set; }


        [DisplayName("抖动模式"), Description("抖动模式：0：上下，1：左右，2：前后")]
        public int mode { get; set; }
        [DisplayName("抖动次数")]
        public int times { get; set; }
        [DisplayName("抖动幅度")]
        public float interval { get; set; }
        [DisplayName("抖动高度")]
        public float height { get; set; }
        [DisplayName("抖动速度")]
        public float speed { get; set; }
        [DisplayName("抖动送锡长度")]
        public float sendlen { get; set; }
        [DisplayName("抖动送锡速度")]
        public float sendSpeed { get; set; }
        [DisplayName("返回方式")]
        public int Backmode { get; set; }
        [DisplayName("返回高度")]
        public float BackHeight { get; set; }
        [DisplayName("提起高度")]
        public float LiftHeight { get; set; }
        #endregion
        public SolderDef()
        {
            FrontLen = 0.25f;
            FrontSpeed = 100;
            BackLen = 0.25f;
            BackSpeed = 100;

            FrontLen2 = 0.25f;
            FrontSpeed2 = 50;
            BackLen2 = 0.25f;
            BackSpeed2 = 50;

            FrontLen3 = 0.25f;
            FrontSpeed3 = 30;
            BackLen3 = 0.25f;
            BackSpeed3 = 30;

            SendDelay = 10;
            SendDelay2 = 10;
            SendDelay3 = 10;
            mode = 1;
            times = 3;
            interval = 0.25f;
            height = 1;
            speed = 100;
            sendlen = 1;
            sendSpeed = 100;
            Backmode = 0;
            BackHeight = 1;
            LiftHeight = 1;
        }
        object ICloneable.Clone()
        {
            SolderDef pro = new SolderDef();
            pro.FrontLen = this.FrontLen;
            pro.FrontSpeed = this.FrontSpeed;
            pro.BackLen = this.BackLen;
            pro.BackSpeed = this.BackSpeed;

            pro.FrontLen2 = this.FrontLen2;
            pro.FrontSpeed2 = this.FrontSpeed2;
            pro.BackLen2 = this.BackLen2;
            pro.BackSpeed2 = this.BackSpeed2;

            pro.FrontLen3 = this.FrontLen3;
            pro.FrontSpeed3 = this.FrontSpeed;
            pro.BackLen3 = this.BackLen3;
            pro.BackSpeed3 = this.BackSpeed3;

            pro.SendDelay = this.SendDelay;
            pro.SendDelay2 = this.SendDelay2;
            pro.SendDelay3 = this.SendDelay3;

            pro.mode = this.mode;
            pro.times = this.times;
            pro.interval = this.interval;
            pro.height = this.height;
            pro.speed = this.speed;
            pro.sendlen = this.sendlen;
            pro.sendSpeed = this.sendSpeed;
            pro.Backmode = this.Backmode;
            pro.BackHeight = this.BackHeight;
            pro.LiftHeight = this.LiftHeight;

            return pro;
        }
        public SolderDef Clone()
        {
            return (SolderDef)((ICloneable)this).Clone();
        }
    }
    /// <summary>
    /// 打磨参数
    /// </summary>
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class PolishDef : ICloneable//模块2      具体机器参数，需要下发
    {
        #region 打磨属性
        [Category("打磨方式"),DisplayName("0：一字左右 1：一字左右 2：一字前后 3：二字前后")]
        public int mode { get; set; }
        [Category("往返次数")]
        public int GoBackTimes { get; set; }
        [Category("往返速度")]
        public int PolishSpeed  { get; set; }
        [DisplayName("打磨往返幅度")]
        public float GoBackRange { get; set; }
        [DisplayName("二字打磨间距")]
        public float PolishInterval { get; set; }
        [DisplayName("提起高度")]
        public float LiftHeight { get; set; }
        #endregion
        public PolishDef()
        {
            mode = 3;
            GoBackTimes = 1;
            PolishSpeed = 100;
            GoBackRange = 0.1f;
            PolishInterval = 0.1f;
            LiftHeight = 2f;
        }
        object ICloneable.Clone()
        {
            PolishDef pro = new PolishDef();
            pro.mode = this.mode;
            pro.GoBackTimes = this.GoBackTimes;
            pro.PolishSpeed = this.PolishSpeed;
            pro.GoBackRange = this.GoBackRange;
            pro.PolishInterval = this.PolishInterval;
            pro.LiftHeight = this.LiftHeight;
            return pro;
        }
        public PolishDef Clone()
        {
            return (PolishDef)((ICloneable)this).Clone();
        }
    }
    /// <summary>
    /// 清洗参数
    /// </summary>
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CleanDef
    {
        #region 清洗属性
        public PointF5 posL { get; set; }
        public PointF5 posR { get; set; }
        public float FrontLen { get; set; }
        public float FrontSpeed { get; set; }
        public float BackLen { get; set; }
        public float BackSpeed { get; set; }
        public int CleanTime { get; set; }
        #endregion
        public CleanDef()
        {
            posL = new PointF5();
            posR = new PointF5();

            FrontLen = 5;
            FrontSpeed = 100;
            BackLen = 1;
            BackSpeed = 100;
            CleanTime = 100;
        }
    }
    /// <summary>
    /// 基础参数
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Basics
    {
        #region 基础参数属性
        public int StartRunMode { get; set; }
        public int DevcieMode { get; set; }
        public int TinDetectEn { get; set; }
        public int CleanEn { get; set; }
        public int ShakeEn { get; set; }

        public float TurnAvoidPos_XL { get; set; }
        public float TurnAvoidPos_XR { get; set; }

        public float Safe_ZL { get; set; }
        public float Safe_ZR { get; set; }

        public float WeldSpeedL { get; set; }
        public float WeldSpeedR { get; set; }

        public float TeachSpeedL { get; set; }
        public float TeachSpeedR { get; set; }

        public int polish_z_Lpos { get; set; }//左拍照安全高度
        public int polish_z_Rpos { get; set; }//右拍照安全高度

        public float Safe_Z { get; set; }
        public float PolishSpeed { get; set; }
        public float TeachSpeed { get; set; }

        public float PolishOffset { get; set; }
        public int PolishTimes { get; set; }
        public int PolishBlowDelay { get; set; }
        public int PolishCounts { get; set; }//打磨次数统计，更换打磨头后数据必须清零
        public int PolishTotalOffset { get; set; }//打磨次数的补偿，更换打磨头必须清零

        #endregion
        public Basics()
        {
            StartRunMode = 0;
            DevcieMode = 1;
            TinDetectEn = 0;
            CleanEn = 0;
            ShakeEn = 1;

            TurnAvoidPos_XL = 200;
            TurnAvoidPos_XR = 200;
            Safe_ZL = 2;
            Safe_ZR = 2;
            WeldSpeedL = 20;
            WeldSpeedR = 20;
            TeachSpeedL = 30;
            TeachSpeedR = 30;

            Safe_Z = 2;
            PolishSpeed = 20;
            TeachSpeed = 20;

            PolishOffset = 0.1f;
            PolishTimes = 100;
            PolishBlowDelay = 100;
            PolishCounts = 0;
            PolishTotalOffset = 0;
        }
    }
    /// <summary>
    /// 下发参数
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SlaverData
    {
        /// <summary>
        /// 打磨复位后位置
        /// </summary>
        public RstPos rstPos { get; set; }
        /// <summary>
        /// 平台1复位后位置
        /// </summary>
        public RstPos_S rstPos1 { get; set; }
        /// <summary>
        /// 平台2复位后位置
        /// </summary>
        public RstPos_S rstPos2 { get; set; }
        /// <summary>
        /// 打磨复位后位置
        /// </summary>
        public RstPos endPos { get; set; }
        /// <summary>
        /// 平台1复位后位置
        /// </summary>
        public RstPos_S endPos1 { get; set; }
        /// <summary>
        /// 平台2复位后位置
        /// </summary>
        public RstPos_S endPos2 { get; set; }

        public RstPos_S endPosS(int index)
        {
            if (index == 0)
            {
                return endPos1;
            }
            else
            {
                return endPos2;
            }
        }
        /// <summary>
        /// 基础参数
        /// </summary>
        public Basics basics { get; set; }

        public SlaverData()
        {
            rstPos = new RstPos();
            rstPos1 = new RstPos_S();
            rstPos2 = new RstPos_S();

            endPos = new RstPos();
            endPos1 = new RstPos_S();
            endPos2 = new RstPos_S();

            basics = new Basics();
        }
    }
    /// <summary>
    /// 运行参数
    /// </summary>
    public class RunDataDef	: ILayoutPoint  //运行参数，不需要下发
    {
        /****设置运行参数的应用属性****/
        #region 数据
        /// <summary>
        /// 打磨点拍照
        /// </summary>
        public List<wPointF>[] wPointFs_Polish = new List<wPointF>[] {new List<wPointF>(),new List<wPointF>() };
        /// <summary>
        /// 上锡点拍照
        /// </summary>
        public List<wPointF>[] wPointFs_Solder = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
        /// <summary>
        /// 拍照延时
        /// </summary>
        public int vDeley { get; set; }
        /// <summary>
        /// 清洗模式
        /// </summary>
        public int rinseMode { get; set; }
        /// <summary>
        /// 清洗的点的个数
        /// </summary>
        public int clearnum { get; set; }

        /// <summary>
        /// 四个平台的个数
        /// </summary>
        public int pNumL { get; set; }
        public int pNumR { get; set; }
        public int sNumL { get; set; }
        public int sNumR { get; set; }
        /// <summary>
        /// UPH
        /// </summary>
        public int UPH { set; get; }
        /// <summary>
        /// 打磨次数
        /// </summary>
        public int polishtimes { set; get; }
        /// <summary>
        /// 运行速度
        /// </summary>
        public int moveSpd { get; set; }
        /// <summary>
        /// 左右焊锡头的使用次数
        /// </summary>
        public int leftSoldertintimes { set; get; }
        public int rightSoldertintimes { set; get; }

        /// <summary>
        /// 角度补偿左/右
        /// </summary>
        public TeachingMechinePra TeachingMechinePra_Left { get; set; }
        public TeachingMechinePra TeachingMechinePra_Right { get; set; }

        public bool Rotate { get; set; }
        public bool Rotate_r { get; set; }
        #endregion
        public bool rotate(int LorR)
        {
            if (LorR == 0)
            {
                return Rotate;
            }
            else
            {
                return Rotate_r;
            }
        }
        public RunDataDef()
        {
            wPointFs_Polish = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };
            wPointFs_Solder = new List<wPointF>[] { new List<wPointF>(), new List<wPointF>() };

            vDeley = 100;
            rinseMode = 0;

            UPH = 0;

            pNumL = 1;
            pNumR = 1;
            sNumL = 1;
            sNumR = 1;

            TeachingMechinePra_Left = new TeachingMechinePra();
            TeachingMechinePra_Right = new TeachingMechinePra();
            Rotate = false;
            Rotate_r = false;
        }

        [OnDeserialized()]
        private void OnDeserializedMed(StreamingContext context)
        {

        }
        SiteRegion _index = 0;
        int TRegion = 0;
        public void GetlayoutPointsShow(int index,int t)
        {
            this._index = (SiteRegion)index;
            this.TRegion = t;
        }
        private class SiteLayoutPoint : LayoutPoint
        {
            public const int MarkRidus = 2;
            public SiteLayoutPoint(wPointF obj):base(obj)
            {

            }
            public override void Drawing(Graphics gc)
            {
                gc.FillEllipse(Brushes.Green, Point.X - MarkRidus, Point.Y - MarkRidus, 2 * MarkRidus, 2 * MarkRidus);
                if (Selected)
                {
                    gc.FillEllipse(Brushes.Green, Point.X - MarkRidus, Point.Y - MarkRidus, 2 * MarkRidus, 2 * MarkRidus);
                }
            }
        }

        public List<LayoutPoint> GetLayoutPoints()
        {
            List<LayoutPoint> layouts = new List<LayoutPoint>();
            switch (_index)
            {
                case SiteRegion.POLISH_LIFT:
                    foreach (var p in wPointFs_Polish[0])
                    {
                        if (p.T == (float)this.TRegion)
                        {
                            SiteLayoutPoint site = new SiteLayoutPoint(p)
                            {
                                Point = new PointF(p.X, p.Y)
                            };

                            layouts.Add(site);
                        }
                    }
                    break;
                case SiteRegion.POLISH_RIGHT:
                    foreach (var p in wPointFs_Polish[1])
                    {
                        if (p.T == (float)this.TRegion)
                        {
                            SiteLayoutPoint site = new SiteLayoutPoint(p)
                            {
                                Point = new PointF(p.X, p.Y)
                            };
                            layouts.Add(site);
                        }
                    }
                    break;
                case SiteRegion.SOLDER_LIFT:
                    foreach (var p in wPointFs_Solder[0])
                    {
                        if (p.T == (float)this.TRegion)
                        {
                            SiteLayoutPoint site = new SiteLayoutPoint(p)
                            {
                                Point = new PointF(p.X, p.Y)
                            };
                            layouts.Add(site);
                        }
                    }
                    break;
                case SiteRegion.SOLDER_RIGHT:
                    foreach (var p in wPointFs_Solder[1])
                    {
                        if (p.T == (float)this.TRegion)
                        {
                            SiteLayoutPoint site = new SiteLayoutPoint(p)
                            {
                                Point = new PointF(p.X, p.Y)
                            };
                            layouts.Add(site);
                        }
                    }
                    break;
            }
            return layouts;
        }
        public IEnumerable<LayoutPoint> GenLayoutPointEnumerable()
        {
            return new LayoutPointEnumerable(this);
        }
    }

    #region 计算R轴旋转
    [Serializable]
    public class TeachingMechinePra                         // 用于记录机械中相机、旋转轴、焊头的各个位置
    {
        public PointF2 ZeroPostion { get; set; }             // 0度时候的坐标
        public PointF2 ReversePostion { get; set; }          // 180度时候的坐标
        public PointF2 RotatePostion { get; set; }           // 认为旋转中心会跟着轴移动,此时的旋转中心

        public PointF2 RotatePstionHXT_Size { get; set; }    // 求得焊锡头距离参考旋转中心的偏移
        public float Radius { get; set; }    // 求得焊锡头距离参考旋转中心的半径


        public PointF2 RotatePstionCameraSize { get; set; }  // 求得相机的中心到旋转中心的偏移

        public PointF2 CameraRotatePostion { get; set; }     // 在计算相机和旋转中心位置时候，相机位置参考
        public PointF4 HXT_OrgPostion { get; set; }          // 在计算焊锡头距离参考选中心时，焊锡头的位置


        public double RotatePostionStartAngle { get; set; } // 在初始机械结构中，焊头在旋转中前状态时候的初始角度，
                                                            // 为了计算焊头的点转换成相机点的一种转换方式

        public TeachingMechinePra()
        {
            ZeroPostion = new PointF2();
            ReversePostion = new PointF2();
            RotatePostion = new PointF2();
            RotatePstionCameraSize = new PointF2();
            CameraRotatePostion = new PointF2();
            HXT_OrgPostion = new PointF4();
            RotatePstionHXT_Size = new PointF2();
            RotatePostionStartAngle = 0;
            Radius = 0;
        }
    }

    #endregion
    /************************视觉部分****************************/

    /// <summary>
    /// 打磨点的坐标数据
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PolishPosdata
    {
        public PointF4 pos { get; set; }
        public PolishDef polishDef { get; set; }

        public PolishPosdata()
        {
            pos = new PointF4();
            polishDef = new PolishDef();
        }

        public override string ToString()
        {
            return pos.ToString();
        }
    }
    /// <summary>
    /// 上锡点的坐标数据
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SolderPosdata
    {
        public PointF4 pos { get; set; }
        public SolderDef solderDef { get; set; }
        public bool rinse { get; set; }
        public SolderPosdata()
        {
            pos = new PointF4();
            solderDef = new SolderDef();
            rinse = new bool();
        }

        public override string ToString()
        {
            return pos.ToString();
        }
    }
    /// <summary>
    /// 视觉识别后参数
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class VDataDef
    {
        /// <summary>
        /// 打磨
        /// </summary>
        public List<PolishPos> vPolishDatasL = new List<PolishPos>();
        public List<PolishPos> vPolishDatasR = new List<PolishPos>();
        /// <summary>
        /// 上锡
        /// </summary>
        public List<SolderPos> vSolderDatasL = new List<SolderPos>();
        public List<SolderPos> vSolderDatasR = new List<SolderPos>();

        public List<PolishPos> polishdata(int index)
        {
            if (index == 0)
                return vPolishDatasL;
            else
                return vPolishDatasR;
        }

        public List<SolderPos> soliderdata(int index)
        {
            if (index == 0)
                return vSolderDatasL;
            else
                return vSolderDatasR;
        }

        public VDataDef()
        {
            vPolishDatasL = new List<PolishPos>();
            vSolderDatasL = new List<SolderPos>();

            vPolishDatasR = new List<PolishPos>();
            vSolderDatasR = new List<SolderPos>();
        }

    }

    /// <summary>
    /// 对应打磨模板参数
    /// </summary>
    /// 
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PolishPos
    {
        public PointF2 Vpos { get; set; }
        public List<PolishPosdata> pos { get; set; }
        public PolishDef polishDef { get; set; }
        public PolishPos()
        {
            Vpos = new PointF2();
            polishDef = new PolishDef();
            pos = new List<PolishPosdata>();
        }
    }
    /// <summary>
    /// 对应上锡模板参数
    /// </summary>
    /// 
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SolderPos
    {
        public PointF2 Vpos { get; set; }
        public List<SolderPosdata> pos { get; set; }
        public SolderDef solderDef { get; set; }
        public SolderPos()
        {
            Vpos = new PointF2();
            solderDef = new SolderDef();
            pos = new List<SolderPosdata>();
        }
    }
    /**********************整个的逻辑参数***************************/
    /// <summary>
    /// 逻辑参数
    /// </summary>
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class SettingDataDef  
	{
        //增加使用的属性
        /// <summary>
        /// 运行参数
        /// </summary>
        public RunDataDef RunData { set; get; }
        /// <summary>
        /// 视觉参数
        /// </summary>
        public VDataDef vData { get; set; }
        /// <summary>
        /// 清洗参数
        /// </summary>
        public CleanDef rinseData { get; set; }
        /// <summary>
        /// 下发参数
        /// </summary>
        public SlaverData slaverData { get; set; }
        public SettingDataDef()
		{
            //方法
            RunData = new RunDataDef();
            vData = new VDataDef();
            rinseData = new CleanDef();
            slaverData = new SlaverData();
        }
		/// <summary>
        /// 新建配置
        /// </summary>
        public void CreatProject()
        {
            try
            {
                //实例化上述用到的工程类
                this.RunData = new RunDataDef();
                this.vData = new VDataDef();
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
                this.RunData = data.RunData;
                this.vData = data.vData;
                this.slaverData = data.slaverData;
                this.rinseData = data.rinseData;
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
