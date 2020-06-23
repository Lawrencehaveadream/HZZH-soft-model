using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;


namespace MyControl
{
    public partial class Jog :Form, IDisposable
    {
        public Jog()
        {
            InitializeComponent();
            InitializeAxisName();
            ContorlBinding();
        }
        public void SetMoveController(Device.BoardCtrllerManager movedriverZm)
        {
            this.movedriverZm = movedriverZm;
        }

        private void InitializeAxisName()
        {
            IList<ComboBoxIndex> list = new List<ComboBoxIndex>();

            list.Add(new ComboBoxIndex() { index = 0, name = "X轴" });
            list.Add(new ComboBoxIndex() { index = 1, name = "Y轴" });
            list.Add(new ComboBoxIndex() { index = 2, name = "Z轴" });
            list.Add(new ComboBoxIndex() { index = 3, name = "R轴" });
            list.Add(new ComboBoxIndex() { index = 4, name = "供膜轴" });
            list.Add(new ComboBoxIndex() { index = 5, name = "输送带轴" });

            comboBox4.DataSource = list;
            comboBox4.ValueMember = "index";
            comboBox4.DisplayMember = "name";
            comboBox4.SelectedIndex = 0;
        }
        public void ContorlBinding()
        {
            ConfigJog(Direction.Pos, button29);
            ConfigJog(Direction.Neg, button30);

            ConfigJog(Direction.Pos, button16);
            ConfigJog(Direction.Neg, button2);
            ConfigJog(Direction.Pos, button3);
            ConfigJog(Direction.Neg, button1);
            ConfigJog(Direction.Pos, button18);
            ConfigJog(Direction.Neg, button17);
            ConfigJog(Direction.Pos, button12);
            ConfigJog(Direction.Neg, button10);

            ConfigJog(Direction.Hom, button22);
        }

        private void numericUpDown31_ValueChanged(object sender, EventArgs e)
        {
            _targetPos = (float)numericUpDown31.Value;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                _mode = 1;
            }
            else
            {
                _mode = 0;
            }
        }


        #region 按键事件
        /// <summary>
        /// 绑定的板卡
        /// </summary>
        private Device.BoardCtrllerManager movedriverZm;
        /// <summary>
        /// 移动距离
        /// </summary>
        public float _targetPos = 1;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float _speed = 5;

        public int _mode = 1;

        private void ConfigJog(Direction type, Button _b)
        {
            switch (type)
            {
                case Direction.Pos:
                    _b.MouseDown += btn_JogAxisPos_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case Direction.Neg:
                    _b.MouseDown += btn_JogAxisNeg_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case Direction.Hom:
                    _b.Click += btn_Home_Click;
                    break;
            }
        }

        private void btn_JogAxisPos_MouseDown(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);
            if (e.Button == MouseButtons.Left)
            {
                _speed = 50;
                JogAxisPos(axis, _mode, _speed, _targetPos);
            }
            if (e.Button == MouseButtons.Right)
            {
                _speed = 10;
                JogAxisPos(axis, _mode, _speed, _targetPos);
            }
        }

        private void btn_JogAxis_MouseUp(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);
            JogAxisStop(axis, _mode);
        }

        private void btn_JogAxisNeg_MouseDown(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            ushort axis = Convert.ToUInt16(_btn.Tag);
            if (e.Button == MouseButtons.Left)
            {
                _speed = 50;
                JogAxisNeg(axis, _mode, _speed, _targetPos);
            }
            if (e.Button == MouseButtons.Right)
            {
                _speed = 10;
                JogAxisNeg(axis, _mode, _speed, _targetPos);
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            Button _btn = sender as Button;
			ushort axis = (ushort)comboBox4.SelectedIndex;
            float speed = 100;
            AxisHomeAction(axis, speed, comboBox4.Text);
        }

        public void JogAxisNeg(ushort axisNum, int mode, float jogSpeed, float targetPos)
        {
            //判断是走连续，还是走固定步长
            if (mode == 0)
            {
				movedriverZm.MoveSpd(axisNum, jogSpeed, targetPos);
            }

            else
            {
				movedriverZm.MoveRel(axisNum, jogSpeed, targetPos);
            }
        }

        public void JogAxisPos(ushort axisNum, int mode, float jogSpeed, float targetPos)
        {
            //判断是走连续，还是走固定步长
            if (mode == 0)
            {
				movedriverZm.MoveSpd(axisNum, jogSpeed, -targetPos);
            }

            else
            {
				movedriverZm.MoveRel(axisNum, jogSpeed, -targetPos);
            }
        }

        public void JogAxisStop(ushort axisNum,int mode)
        {
            if (mode == 0)
            {
				movedriverZm.MoveStop(axisNum);
            }
        }

        public void AxisHomeAction(ushort axisNum, float jogSpeed, string Axis_Name)
        {
            if (MessageBox.Show("确定要执行此轴回零...", Axis_Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
				movedriverZm.MoveHome(axisNum, jogSpeed);
            }
        }


        #endregion

    }

    public enum Direction : int
    {
        Pos,
        Neg,
        Hom
    }

    public class ComboBoxIndex
    {
        public int index { get; set; }
        public string name { get; set; }
    }

}
