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
            LQS1.Text = "此行无用";
            LQS2.Text = "此行无用";
            LQS3.Text = "此行无用";
            LQS4.Text = "此行无用";
            LQS5.Text = "此行无用";
            LQS6.Text = "此行无用";
            LQS7.Text = "此行无用";
            LQS8.Text = "此行无用";
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC");
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini");
            }
            StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini");
            cbPath.Text = sr.ReadLine();
            sr.Close();
            sr.Dispose();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Microsoft Excel 逗号分隔值文件(*.csv)|*.csv";
            openFileDialog1.Title = "请选择CSV文件";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cbPath.Text = openFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\QSFQSC\1.ini");
                sw.WriteLine(openFileDialog1.FileName);
                cbPath.Items.Add(openFileDialog1.FileName);
                sw.Close();
                sw.Dispose();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(cbPath.Text, Encoding.GetEncoding("gb2312"));
            data = DataHandle.ReadCSV(sr);
            sr.Close();
            sr.Dispose();
            label2.Visible = true;
            DataHandle.ChangeQSLText(data, LQS1, LQS2, LQS3, LQS4, LQS5, LQS6, LQS7, LQS8);
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LQS1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private char[] SevIntToCharArray(int i)
        {
            string s = i.ToString();
            return s.ToCharArray();
        }
        private List<DataInFeedback> GetDatas()
        {
            List<DataInFeedback> ddd = new List<DataInFeedback>();
            //temp.Add(new DataInFeedback());
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
            string res = "";
            foreach (var item in data22)
            {
                string s1 = "被不齐";
                string s2 = "床单不平";
                string s3 = "床好";
                res += (item.BedRoomNumber + "：");
                foreach (var item2 in item.BeiBuQiNumbers)
                {
                    string name = data[item.BedRoomNumber][item2];
                    res += (name + '、');
                    res = res.Remove(res.Length - 1);
                    res += s1;
                    res += '；';
                }
                
                foreach (var item3 in item.ChuangDanBuPingNumbers)
                {
                    string name = data[item.BedRoomNumber][item3];
                    res += (name + '、');
                    res = res.Remove(res.Length - 1);
                    res += s2;
                    res += '；';
                }
                foreach (var item4 in item.ChuangHaoNumber)
                {
                    string name = data[item.BedRoomNumber][item4];
                    res += (name + '、');
                    res = res.Remove(res.Length - 1);
                    res += s3;
                    res += '；';
                }
                
            }
            MessageBox.Show(res);
        }
        string Result = "";
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
