using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Common;
using Config;
using MyControl;
using Motion;
using Logic;

namespace UI
{
	public partial class FormMain : Form
	{
		public LogicMain RunProcess = new LogicMain();
        public FormMain()
		{
            try
            {
                InitializeComponent();
                StartUpdate.SendStartMsg("应用程序启动 请稍等>>>");                 
                Config.ConfigHandle.Instance.Load();
                InitializeControl();
                
                ShowMessge.StartMsg += new ShowMessge.SendStartMsgEventHandler(ShowMessage);
                StartUpdate.SendStartMsg("通信连接");
                RunProcess.movedriverZm.ConnectCtrller(Config.ConfigHandle.Instance.SystemDefine.IP, Config.ConfigHandle.Instance.SystemDefine.Port);
                StartUpdate.SendStartMsg("通信连接完成");
                StartUpdate.SendStartMsg("正在进入系统>>>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
				timer1.Interval = 200;
                timer1.Enabled = true;
            }
		}

        #region 用户

        User CurrentUser;

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin frm = new UserLogin();
            if (DialogResult.OK == frm.ShowDialog())
            {

                UserMgrLogos(frm.GetCurrentUser());
                userInfo.GetUserList(frm.GetCurrentUser());
            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserPwd frm_ChangePwd = new ChangeUserPwd();
            frm_ChangePwd.SetUser(CurrentUser);
            if (DialogResult.OK == frm_ChangePwd.ShowDialog(this))
            {
                CurrentUser = frm_ChangePwd.GetCurrentUser();
            }
        }
        
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMgrIntialize();
        }
       
        private void UserMgrIntialize()
        {
            修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled =
            用户管理ToolStripMenuItem.Enabled = false;

            CurrentUser = null;
            tsslbl_loginUserMsg.Text = "";
        }
        
        private void UserMgrLogos(User user1)
        {
            try
            {
                if (user1.Type != "")
                {
                    CurrentUser = user1;
                    tsslbl_loginUserMsg.Text = user1.Name;
                    switch (user1.Type)
                    {
                        case "0":
                            break;
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        default:
                            break;
                    }
                    修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled =
                    用户管理ToolStripMenuItem.Enabled = true;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            userInfo.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            userInfo.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            userInfo.Size = this.panel4.Size;
            userInfo.Parent = this.panel4;//指定子窗体显示的容器
            userInfo.Show();
            userInfo.Activate();
        }
        #endregion

        #region 菜单
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton toolbtn = sender as ToolStripButton;
            if (toolbtn.Tag != null)
            {
                switch (toolbtn.Tag.ToString())
                {
                    case "0":
                        tabControl1.SelectedIndex = 0;
                        break;
                    case "1":
                        tabControl1.SelectedIndex = 1;
                        Motor.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        Motor.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        Motor.Size = this.panel1.Size;
                        Motor.Parent = this.panel1;//指定子窗体显示的容器
                        Motor.Show();
                        Motor.Activate();
                        break;
                    case "2":
                        tabControl1.SelectedIndex = 2;
                        IOControl.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        IOControl.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        IOControl.Size = this.panel2.Size;
                        IOControl.Parent = this.panel2;//指定子窗体显示的容器
                        IOControl.Show();
                        IOControl.Activate();
                        break;
                    case "3":
                        tabControl1.SelectedIndex = 3;
                        formLog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        formLog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        formLog.Size = this.panel3.Size;
                        formLog.Parent = this.panel3;//指定子窗体显示的容器
                        formLog.Show();
                        formLog.Activate();
                        break;
                    case "退出":
                        if (MessageBox.Show("是否退出软件", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                        {
                            Application.ExitThread();
                            //System.Environment.Exit(0);
                        }
                        else
                        {
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void btn_PrjFileControl_Click(object sender, EventArgs e)
        {
            ToolStripButton toolbtn = sender as ToolStripButton;
            if (toolbtn.Tag != null)
            {
                switch (toolbtn.Tag.ToString())
                {
                    case "PrjFileOpen":
                        btn_PrjFileOpen();
                        break;
                    case "PrjFileNew":
                        btn_PrjFileNew();
                        break;
                    case "PrjFileSave":
                        btn_PrjFileSave();
                        break;
                    case "PrjFileSaveAs":
                        btn_PrjFileSaveAs();
                        break;
                    default:
                        break;
                }
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            jog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            jog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            //jog.Size = this.取标.Size;
            //jog.Parent = this.取标;//指定子窗体显示的容器
            jog.Show();
            jog.Activate();
        }

        #endregion 

        #region  窗体事件

        private void Form_SubMain_Load(object sender, EventArgs e)
		{
			DataBinding();
            if (ConfigHandle.Instance.SystemDefine.ProjectDirectory != null && ConfigHandle.Instance.SystemDefine.ProjectDirectory != "")
            {
                OpenProject(ConfigHandle.Instance.SystemDefine.ProjectDirectory);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logic.LogicMain.LogicThreadLife = false;
        }

        #endregion

        #region 常用事件

        private void DataBinding()
		{
            try
            {
                //皮带
                //Functions.SetBinding(lbbletSpeed, "Value", RunProcess.LogicResources.SettingData.BeltFeedPara, "bletSpeed");
                //Functions.SetBinding(lbtrigPos, "Value", RunProcess.LogicResources.SettingData.BeltFeedPara, "trigPos");
                //Functions.SetBinding(lbstopPos, "Value", RunProcess.LogicResources.SettingData.BeltFeedPara, "stopPos");
 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据绑定有问题 " + ex.ToString());
            }

        }

        private InputOutput IOControl;
        private UserMachinePrm Motor ;
        private UserInfo userInfo;
        private Jog jog;
        private FormLog formLog;
        public void InitializeControl()
        {
            StartUpdate.SendStartMsg("初始化控件");
            formLog = new FormLog();
            userInfo = new UserInfo();

            IOControl = new InputOutput();
            Motor = new UserMachinePrm();
            jog = new Jog();
            IOControl.SetMoveController(RunProcess.movedriverZm);
            Motor.SetMoveController(RunProcess.movedriverZm);
            jog.SetMoveController(RunProcess.movedriverZm);

            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.SizeMode = TabSizeMode.Fixed;


            tabControl1.SelectedIndex = 0;
            StartUpdate.SendStartMsg("控件初始化完成");
        }

        private void tlssll_ControllerStatus_TextChanged(object sender, EventArgs e)
        {
            if (tlssll_ControllerStatus.Text == "控制器：在线")
            {
                Motor.DownMotorPrmToSlave();
            }
        }

        #endregion

        #region 启动停止

        private void btn_FsmControl_Click(object sender, EventArgs e)
        {
            ToolStripButton toolbtn = sender as ToolStripButton;
            if (toolbtn.Tag != null)
            {
                switch (toolbtn.Tag.ToString())
                {
                    case "FsmStart":
                        btn_FsmStart();

                        break;
                    case "FsmPause":
                        btn_FsmPause();

                        break;
                    case "FsmStop":
                        btn_FsmStop();

                        break;
                    case "FsmReset":
                        btn_FsmReset();

                        break;
                    default:
                        break;
                }
            }
        }

        userListView.UserCtrlMsgListView userCtrlMsgListView1 = new userListView.UserCtrlMsgListView();

        /// <summary>
        /// 启动
        /// </summary>
        public void btn_FsmStart()
        {

            if (RunProcess.movedriverZm.Succeed)
            {
                RunProcess.DataToSlaver();
                RunProcess.FSM.Run(RunProcess.FSM.RunMode);
                userCtrlMsgListView1.AddUserMsg("设备启动", "提示");
            }
        }
        /// <summary>
        /// 暂停
        /// </summary>
        public void btn_FsmPause()
        {
            if (RunProcess.movedriverZm.Succeed)
            {
                RunProcess.FSM.Pause();
                userCtrlMsgListView1.AddUserMsg("设备暂停", "提示");
            }
        }
        /// <summary>
        /// 停止
        /// </summary>
        public void btn_FsmStop()
        {
            if (RunProcess.movedriverZm.Succeed)
            {
                RunProcess.FSM.Stop();
                userCtrlMsgListView1.AddUserMsg("设备停止", "提示");
            }
        }
        /// <summary>
        /// 复位
        /// </summary>
        public void btn_FsmReset()
        {
            if (RunProcess.movedriverZm.Succeed)
            {
                RunProcess.ProcessData = new ProcessDataDef();
                RunProcess.LogicTask = new LogicTaskDef();
                RunProcess.FSM.Reset();
                userCtrlMsgListView1.AddUserMsg("设备复位", "提示");
            }
        }

        #endregion

        #region 工程调度

        string pathRoad = null;

        /// <summary>
        /// 打开文件
        /// </summary>
        public void btn_PrjFileOpen()
        {
            OpenFileDialog openDLG = new OpenFileDialog();
            openDLG.Title = "选择项目文件";
            openDLG.Multiselect = false;
            openDLG.Filter = "选择项目文件|*.pro";
            openDLG.InitialDirectory = "D:\\程式\\";
            if (openDLG.ShowDialog() == DialogResult.OK)
            {
                OpenProject(openDLG.FileName);
            }
        }

        private void OpenProject(string path)
        {
            try
            {
                pathRoad = Path.GetDirectoryName(path);
                ConfigHandle.Instance.SystemDefine.ProjectDirectory = path;
                RunProcess.LogicData.OpenProject(path);
                tsslbl_projectPath.Text = pathRoad.Substring(pathRoad.LastIndexOf('\\'));
                DataBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 新建文件
        /// </summary>
        public void btn_PrjFileNew()
        {
            RunProcess.LogicData.CreatProject();
            pathRoad = null;
            DataBinding();
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        public void btn_PrjFileSave()
        {
            if (pathRoad != null)
            {
                RunProcess.LogicData.SaveProject(pathRoad);
                return;
            }
            SaveFileDialog Save = new SaveFileDialog();
            Save.Title = "项目存为";
            Save.InitialDirectory = "D:\\程式\\";
            if (Save.ShowDialog() == DialogResult.OK)
            {
                pathRoad = Save.FileName;
                string fileName = Path.GetFileName(pathRoad);
                ConfigHandle.Instance.SystemDefine.ProjectDirectory = pathRoad + "\\" + fileName + ".pro"; ;
                RunProcess.LogicData.SaveProject(pathRoad);
                tsslbl_projectPath.Text = pathRoad.Substring(pathRoad.LastIndexOf('\\'));
            }
        }
        /// <summary>
        /// 文件另存为
        /// </summary>
        public void btn_PrjFileSaveAs()
        {
            SaveFileDialog SaveAs = new SaveFileDialog();
            SaveAs.Title = "项目另存为";
            SaveAs.InitialDirectory = "D:\\程式\\";
            if (SaveAs.ShowDialog() == DialogResult.OK)
            {
                RunProcess.LogicData.SaveProject(SaveAs.FileName);
            }
        }

        #endregion

        #region 定时器

        private int cnt = 0;
        private bool[,] b_statusError = new bool[20, 32];
        private void timer1_Tick(object sender, EventArgs e)
        {
			int[] error = (int[])RunProcess.movedriverZm.ErrorCode.IntValue.Clone();
			int[] errorLevel = (int[])RunProcess.movedriverZm.ErrorLevel.IntValue.Clone();
            foreach (string str in ConfigHandle.Instance.AlarmDefine.ErrorInformation(error, errorLevel[0], b_statusError))
            {
                userCtrlMsgListView1.AddUserMsg(str, "报警");
            }
            //tsslbl_AxisLoc0.Text = RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxX].ToString("f3");
            //tsslbl_AxisLoc1.Text = RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxY].ToString("f3");
            //tsslbl_AxisLoc2.Text = RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxZ].ToString("f3");
            //tsslbl_AxisLoc3.Text = RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxW].ToString("f3");

			switch ((FsmStaDef)RunProcess.movedriverZm.DeviceStatus.IntValue[0])
			{
				case FsmStaDef.INIT:
                    lbl_RunStates.Text = "设备初始";
                    lbl_RunStates.BackColor = SystemColors.ActiveCaption;
                    panel10.BackColor = SystemColors.ActiveCaption;
                    break;

				case FsmStaDef.PAUSE:
                    lbl_RunStates.Text = "设备暂停";
                    lbl_RunStates.BackColor = Color.Yellow;
                    panel10.BackColor = Color.Yellow;
                    break;

				case FsmStaDef.RESET:
                    lbl_RunStates.Text = "设备复位";
                    lbl_RunStates.BackColor = Color.Red;
                    panel10.BackColor = Color.Red;
                    break;

                case FsmStaDef.RUN:
                    lbl_RunStates.Text = "设备运行";
                    lbl_RunStates.BackColor = Color.Green;
                    panel10.BackColor = Color.Green;
                    break;

                case FsmStaDef.SCRAM:
                    lbl_RunStates.Text = "设备急停";
                    lbl_RunStates.BackColor = Color.Red;
                    panel10.BackColor = Color.Red;
                    break;

                case FsmStaDef.STOP:
                    lbl_RunStates.Text = "设备停止";
                    lbl_RunStates.BackColor = Color.Yellow;
                    panel10.BackColor = Color.Yellow;
                    break;
			}
			//控制器状态
			if (RunProcess.movedriverZm.Succeed)
			{
				tlssll_ControllerStatus.Text = "控制器：在线";
				tlssll_ControllerStatus.BackColor = SystemColors.Control;
			}
			else
			{
				tlssll_ControllerStatus.Text = "控制器：离线";
				tlssll_ControllerStatus.BackColor = Color.Red;
			}

 
            #region 日志

            if (cnt > 4500)
            {
                cnt = 0;
                userCtrlMsgListView1.ClearMsgItems();
            }
            else
            {
                cnt++;
            }

            #endregion 日志


        }
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunProcess.movedriverZm.WriteRegister(new BaseData(1130, new int[]{1}));
            ConfigHandle.Instance.AlarmDefine.ClearAlarmMessage(b_statusError);
			userCtrlMsgListView1.ClearMsgItems();
		}

        private void ShowMessage(SendCmdArgs e)
        {
            userCtrlMsgListView1.AddUserMsg(e.StrReciseve, "提示");
        }


        #endregion
      
    }
}
