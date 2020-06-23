using System;
using Common;
using System.Windows.Forms;
using Motion;
namespace UI
{
    public partial class Frm_ThreePArray : Form
    {
        public FormMain ftemp;
        public Frm_ThreePArray()
        {
            InitializeComponent();
        }

        private void Frm_DPArr_Load(object sender, EventArgs e)
        {
            ftemp = (FormMain)this.Owner;
        }


        private void btn_readleftup_Click(object sender, EventArgs e)
        {
            //numericUpDown1.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxX];
            //numericUpDown2.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxY];
            //numericUpDown3.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxZ];
        }

        private void btn_readrightup_Click(object sender, EventArgs e)
        {
            //numericUpDown4.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxX];
            //numericUpDown5.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxY];
            //numericUpDown6.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxZ];
        }

        private void btn_readrightdwon_Click(object sender, EventArgs e)
        {
            //numericUpDown7.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxX];
            //numericUpDown8.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxY];
            //numericUpDown9.Value = (decimal)ftemp.RunProcess.movedriverZm.CurrentPos.FloatValue[(int)AxisDef.AxZ];
        }

        PointF3 pLeftUp = new PointF3();
        PointF3 pRightUp = new PointF3();
        PointF3 pRightDwon = new PointF3();
        private void buttonArr_Click(object sender, EventArgs e)
        {
            if ((!radioButton1.Checked) && (!radioButton2.Checked))
            {
                MessageBox.Show("请选择方向并确认");
                return;
            }
           
            int RowNum = Convert.ToInt32(numericUpDown10.Value);
            int ColumnNum = Convert.ToInt32(numericUpDown11.Value);

            pLeftUp.X = Convert.ToSingle(numericUpDown1.Value);
            pLeftUp.Y = Convert.ToSingle(numericUpDown2.Value);
            pLeftUp.Z = Convert.ToSingle(numericUpDown3.Value);


            pRightUp.X = Convert.ToSingle(numericUpDown4.Value);
            pRightUp.Y = Convert.ToSingle(numericUpDown5.Value);
            pRightUp.Z = Convert.ToSingle(numericUpDown6.Value);

            pRightDwon.X = Convert.ToSingle(numericUpDown7.Value);
            pRightDwon.Y = Convert.ToSingle(numericUpDown8.Value);
            pRightDwon.Z = Convert.ToSingle(numericUpDown9.Value);
           
            int dripDirection = radioButton1.Checked ? 0 : 1;//点胶方式
            //ftemp.LoadStickData(PointArray.MatrixArrayList(pLeftUp, pRightUp, pRightDwon, RowNum, ColumnNum, dripDirection));
            MessageBox.Show("阵列成功");
        }


        private int GetPasteDirction()
        {
            // 测试方式   0 横向  1 纵向
            return radioButton1.Checked == true ? 0 : 1;
        }

        private void SetPasteDirction(int mode)
        {
            if (mode < 2)
            {
                if (mode == 0)
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;

            }
        }
    }
}
