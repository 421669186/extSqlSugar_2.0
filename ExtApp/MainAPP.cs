using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtApp.BusinessLogic;
using SqlSugar;
using CommonHelper;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace ExtApp
{

    public partial class MainAPP : Form
    {
        IImplement Implement = new ExtLogic();

        #region Button
        public MainAPP()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 导出多个Sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.txtMessage.AppendText(">>>程序运行信息... \n");

            //string pattern = Regex.Replace(this.txtDict.Text.Trim().Replace(" ",""),"\r\n|\n","|");
            //this.txtMessage.AppendText("输入关键词格式转换结果... \n");
            //this.txtMessage.AppendText(pattern + "\n");

            string filePath = GetFilePath();
            ExtExcel(Implement.GetDataTableList(), filePath);
        }

        /// <summary>
        /// 导出单个Sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.txtMessage.AppendText(">>>程序运行信息... \n");
            string filePath = GetFilePath();
            ExtExcel(Implement.GetDataTable(), filePath);
        }
        /// <summary>
        /// 获取并导入单个Sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.txtMessage.AppendText(">>>程序运行信息... \n");
            string filePath = ReadFilePath();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            DataTable dt = ReadExcel(filePath, "结果导入");
            if (dt != null)
            {
                string strHosName = this.comboBox1.SelectedValue.ToString().Trim();
                string strDisease = this.comboBox2.SelectedValue.ToString().Trim();

                Tuple<bool, string> tupleMsg = Implement.InsertDataToDb(dt, strHosName, strDisease);
                sw.Stop();
                if (tupleMsg.Item1 == true)
                {
                    this.txtMessage.AppendText(">>>导入成功，执行用时：" + sw.Elapsed.Seconds + "s!\n");
                }
                else
                {
                    this.txtMessage.AppendText(">>>导入失败，异常信息：" + tupleMsg.Item2 + "\n");
                }
            }
            else
            {
                this.txtMessage.AppendText(">>>数据读取异常！！！\n");
            }
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            TestClass tc = new TestClass();
            tc.Run();
        }

        /// <summary>
        /// 直接运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.txtMessage.AppendText(">>>程序运行信息... \n");
            //   string filePath = "C:\\Users\\Administrator\\Desktop\\清远\\结果\\" + DateTime.Now.ToString("MM月dd日HH时mm分ss秒") + "-" + "导出.xlsx";
            string filePath = "C:\\Users\\Administrator\\Desktop\\" + DateTime.Now.ToString("MM月dd日HH时mm分ss秒") + "-" + "导出.xlsx";
            ExtExcel(Implement.GetDataTable(), filePath);
        }
        #endregion

        #region  Excel Operation
        private string GetFilePath()
        {
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            //设置文件类型  
            sfd.Filter = " xlsx files(*.xlsx)|*.txt|All files(*.*)|*.*";
            //设置文件名称：
            sfd.FileName = DateTime.Now.ToString("MM月dd日HH时mm分ss秒") + "-" + "导出.xlsx";
            //设置默认文件类型显示顺序  
            sfd.FilterIndex = 2;
            //保存对话框是否记忆上次打开的目录  
            sfd.RestoreDirectory = true;
            //点了保存按钮进入  
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //获得文件路径  
                localFilePath = sfd.FileName.ToString();
            }
            return localFilePath;
        }
        private string ReadFilePath()
        {
            string localFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = ofd.FileName;
            }
            else
            {
                MessageBox.Show("打开失败");
            }
            return localFilePath;
        }
        private void ExtExcel(DataTable dt, string filePath)
        {
            using (ExcelTool et = new ExcelTool(filePath))
            {
                int count = et.DataTableToExcel(dt, "MySheet", true);
                if (count > 0)
                {
                    this.txtMessage.AppendText("开始导出文件导出路径 >>" + filePath + " \n");
                    //导出成功
                    this.txtMessage.AppendText("导出完成！ \n");
                }
                else
                {
                    this.txtMessage.AppendText("导出失败！ \n");
                }


            }
        }
        private void ExtExcel(List<DataTable> lsDt, string filePath)
        {
            using (ExcelTool et = new ExcelTool(filePath))
            {
                this.txtMessage.AppendText("开始导出文件导出路径 >>" + filePath + " \n");
                List<string> lsResult = et.DataTableToExcel(lsDt, true);
                foreach (string result in lsResult)
                {
                    this.txtMessage.AppendText(result + " \n");
                }

                this.txtMessage.AppendText("导出完成！ \n");
            }
        }
        private DataTable ReadExcel(string filePath, string sheet = "Sheet1")
        {
            DataTable dt = new DataTable();

            using (ExcelTool et = new ExcelTool(filePath))
            {
                dt = et.ExcelToDataTable(sheet, true);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.txtMessage.AppendText("读取文件路径 >>" + filePath + " \n");
                        //导出成功
                        this.txtMessage.AppendText("读取完成！ \n");
                    }
                    else
                    {
                        this.txtMessage.AppendText("导出失败！ \n");
                    }
                }
            }

            return dt;
        }
        #endregion

        private void MainAPP_Load(object sender, EventArgs e)
        {
            List<DataTable> dt = Implement.GetInitData();
            this.comboBox1.DataSource = dt[0];
            this.comboBox1.DisplayMember = "ITEM_NAME";
            this.comboBox1.ValueMember = "ITEM_CODE";

            this.comboBox2.DataSource = dt[1];
            this.comboBox2.DisplayMember = "ITEM_NAME";
            this.comboBox2.ValueMember = "ITEM_CODE";

        }
    }
}
