using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace 寝室反馈生成
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 贮存寝室数据
        /// </summary>
        public Dictionary<string, Dictionary<char, string>> data;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #region 给label寝室号
            string sss = "此行无用";
            LQS1.Text = sss;
            LQS2.Text = sss;
            LQS3.Text = sss;
            LQS4.Text = sss;
            LQS5.Text = sss;
            LQS6.Text = sss;
            LQS7.Text = sss;
            LQS8.Text = sss;
            #endregion
            #region 新建并读取配置文件
            //新建配置文件
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC");
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini");
            }
            //读取配置文件
            StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini");
            cbPath.Text = sr.ReadLine();//最近打开
            sr.Close();
            sr.Dispose();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //打开CSV文件
            openFileDialog1.Filter = "Microsoft Excel 逗号分隔值文件(*.csv)|*.csv";
            openFileDialog1.Title = "请选择CSV文件";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //读取CSV文件路径
                cbPath.Text = openFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini");
                sw.WriteLine(openFileDialog1.FileName);
                cbPath.Items.Add(openFileDialog1.FileName);//添加到最近打开中
                sw.Close();
                sw.Dispose();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //读取CSV文件
            StreamReader sr = new StreamReader(cbPath.Text, Encoding.GetEncoding("gb2312"));
            data = DataHandle.ReadCSV(sr);
            sr.Close();
            sr.Dispose();
            label2.Visible = true;
            DataHandle.ChangeQSLText(data, LQS1, LQS2, LQS3, LQS4, LQS5, LQS6, LQS7, LQS8);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }
        #region 无用
        private void label3_Click(object sender, EventArgs e)
        {
            //无用
        }

        private void LQS1_Click(object sender, EventArgs e)
        {
            //无用
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //无用
        }

        private void label19_Click(object sender, EventArgs e)
        {
            //无用
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            //无用
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //无用
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //无用
        }
        #endregion
        /// <summary>
        /// 将int转成char数组
        /// </summary>
        /// <param name="i">要转换的整数</param>
        /// <returns></returns>
        private char[] SevIntToCharArray(int i)
        {
            string s = i.ToString();
            return s.ToCharArray();
        }
        private List<DataInFeedback> GetDatas()
        {
            List<DataInFeedback> ddd = new List<DataInFeedback>();
            //逐个将信息添加到List中
            DataInFeedback data1 = new DataInFeedback();
            data1.BedRoomNumber = LQS1.Text;
            data1.BeiBuQiNumbers = B1.Text.ToCharArray();
            data1.ChuangDanBuPingNumbers = C1.Text.ToCharArray();
            data1.IfDiYouYin = D1.Checked;
            data1.IfMenJingZang = M1.Checked;
            data1.IfGoodOrOK = H1.Checked ? true : false;
            data1.ChuangHaoNumber = CH1.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data2 = new DataInFeedback();
            data2.BedRoomNumber = LQS2.Text;
            data2.BeiBuQiNumbers = B2.Text.ToCharArray();
            data2.ChuangDanBuPingNumbers = C2.Text.ToCharArray();
            data2.IfDiYouYin = D2.Checked;
            data2.IfMenJingZang = M2.Checked;
            data2.IfGoodOrOK = H2.Checked ? true : false;
            data2.ChuangHaoNumber = CH2.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data3 = new DataInFeedback();
            data3.BedRoomNumber = LQS3.Text;
            data3.BeiBuQiNumbers = B3.Text.ToCharArray();
            data3.ChuangDanBuPingNumbers = C3.Text.ToCharArray();
            data3.IfDiYouYin = D3.Checked;
            data3.IfMenJingZang = M3.Checked;
            data3.IfGoodOrOK = H3.Checked ? true : false;
            data3.ChuangHaoNumber = CH3.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data4 = new DataInFeedback();
            data4.BedRoomNumber = LQS4.Text;
            data4.BeiBuQiNumbers = B4.Text.ToCharArray();
            data4.ChuangDanBuPingNumbers = C4.Text.ToCharArray();
            data4.IfDiYouYin = D4.Checked;
            data4.IfMenJingZang = M4.Checked;
            data4.IfGoodOrOK = H4.Checked ? true : false;
            data4.ChuangHaoNumber = CH4.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data5 = new DataInFeedback();
            data5.BedRoomNumber = LQS5.Text;
            data5.BeiBuQiNumbers = B5.Text.ToCharArray();
            data5.ChuangDanBuPingNumbers = C5.Text.ToCharArray();
            data5.IfDiYouYin = D5.Checked;
            data5.IfMenJingZang = M5.Checked;
            data5.IfGoodOrOK = H5.Checked ? true : false;
            data5.ChuangHaoNumber = CH5.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data6 = new DataInFeedback();
            data6.BedRoomNumber = LQS6.Text;
            data6.BeiBuQiNumbers = B6.Text.ToCharArray();
            data6.ChuangDanBuPingNumbers = C6.Text.ToCharArray();
            data6.IfDiYouYin = D6.Checked;
            data6.IfMenJingZang = M6.Checked;
            data6.IfGoodOrOK = H6.Checked ? true : false;
            data6.ChuangHaoNumber = CH6.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data7 = new DataInFeedback();
            data7.BedRoomNumber = LQS7.Text;
            data7.BeiBuQiNumbers = B7.Text.ToCharArray();
            data7.ChuangDanBuPingNumbers = C7.Text.ToCharArray();
            data7.IfDiYouYin = D7.Checked;
            data7.IfMenJingZang = M7.Checked;
            data7.IfGoodOrOK = H7.Checked ? true : false;
            data7.ChuangHaoNumber = CH7.Text.ToCharArray();
            /*********************************************/
            DataInFeedback data8 = new DataInFeedback();
            data8.BedRoomNumber = LQS8.Text;
            data8.BeiBuQiNumbers = B8.Text.ToCharArray();
            data8.ChuangDanBuPingNumbers = C8.Text.ToCharArray();
            data8.IfDiYouYin = D8.Checked;
            data8.IfMenJingZang = M8.Checked;
            data8.IfGoodOrOK = H8.Checked ? true : false;
            data8.ChuangHaoNumber = CH8.Text.ToCharArray();
            /*********************************************/
            ddd.Add(data1);
            ddd.Add(data2);
            ddd.Add(data3);
            ddd.Add(data4);
            ddd.Add(data5);
            ddd.Add(data6);
            ddd.Add(data7);
            ddd.Add(data8);
            return ddd;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            List<DataInFeedback> data22 = GetDatas();
            StringBuilder res = new StringBuilder();
            foreach (var item in data22)
            {
                string s1 = "被不齐";
                string s2 = "床单不平";
                string s3 = "床好";
                res.Append(item.BedRoomNumber + "：");
                foreach (var item2 in item.BeiBuQiNumbers)
                {
                    string name = data[item.BedRoomNumber][item2];
                    res.Append(name);
                    res.Append('、');
                    
                }
                if (item.BeiBuQiNumbers.Length != 0)
                {
                    res = res.Remove(res.Length - 1, 1);
                    res.Append(s1);
                    res.Append('，');
                }
                foreach (var item3 in item.ChuangDanBuPingNumbers)
                {
                    string name = data[item.BedRoomNumber][item3];
                    res.Append(name + '、');
                   
                }
                if (item.ChuangDanBuPingNumbers.Length != 0)
                {
                    res = res.Remove(res.Length - 1, 1);
                    res.Append(s2);
                    res.Append('，');
                }
                foreach (var item4 in item.ChuangHaoNumber)
                {
                    string name = data[item.BedRoomNumber][item4];
                    res.Append(name + '、');
                    
                }
                if (item.ChuangHaoNumber.Length != 0)
                {
                    res = res.Remove(res.Length - 1, 1);
                    res.Append(s3);
                    res.Append('；');
                }
                string s = item.IfDiYouYin ? "地有印" : "";
                res.Append(s);
                string ss = item.IfMenJingZang ? "门镜脏" : "";
                res.Append(ss);
            }
            textBox1.Text += res;
        }
        string Result = "";
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //无用
        }
    }
}
