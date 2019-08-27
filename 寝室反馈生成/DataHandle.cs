using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace 寝室反馈生成
{
   // public enum BedRoomIfGoodOrOK
    //{
       // Good,
        //OK
    //}
    /// <summary>
    /// 处理各种程序中的数据
    /// </summary>
    static class DataHandle
    {
        /// <summary>
        /// 读取CSV文件到Dictionary<string, Dictionary<string, int>>中
        /// </summary>
        /// <param name="sr">一个指向CSV(逗号分隔符)的文件流</param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<char, string>> ReadCSV(StreamReader sr)
        {
            Dictionary<string, Dictionary<char, string>> dic = new Dictionary<string, Dictionary<char, string>>();
            sr.ReadLine();//pass掉第一行数据
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();//读取单行数据,例:201808001,崔天植,A516,1
                s = s.Remove(0, 10);//移除学号,例:崔天植,A516,1
                string[] data = s.Split(',');//分割,例:崔天植  A516   1
                if (!dic.ContainsKey(data[1]))//如果不存在，添加寝室号并添加床号
                {
                    Dictionary<char,string> temp = new Dictionary<char,string>();
                    temp.Add(data[2].ToCharArray()[0], data[0]);
                    dic.Add(data[1], temp);
                }
                else//如果存在，添加床号
                {
                    dic[data[1]].Add(data[2].ToCharArray()[0], data[0]);
                }

            }
            return dic;
        }
        /// <summary>
        /// 批量将Label文字更改为寝室号
        /// </summary>
        /// <param name="dic">寝室号字典</param>
        /// <param name="labels">Label控件</param>
        public static void ChangeQSLText(Dictionary<string, Dictionary<char, string>> dic, params Label[] labels)
        {
            // Dictionary<string, Dictionary<char,string>.Enumerator en = dic.GetEnumerator();
            int i = 0;
            foreach (var item in dic.Keys)
            {
                labels[i].Text = item;
                i++;
            }
        }
        public static string[] CreateCompleteFeedback(Dictionary<string, Dictionary<string, int>> dic, params DataInFeedback[] tbif) { return null; }

    }
    public class DataInFeedback
    {
        /*  
         public List<TextBox> BeiBuQiLtb { get; set; }
         public List<TextBox> ChuangDanBuPingLtb { get; set; }
         public List<bool> IfDiYouYin { get; set; }
         public List<bool> IfMenJingZang { get; set; }
         public List<>*/
        public DataInFeedback()
        {

        }
        /*public DataInFeedback(string bedRoomNumber, int[] beiBuQiNumbers, int[] chuangDanBuPingNumbers, bool ifDiYouYin, bool ifMenJingZang, BedRoomIfGoodOrOK ifGoodOrOK)
        {
            BedRoomNumber = bedRoomNumber;
            BeiBuQiNumbers = beiBuQiNumbers;
            ChuangDanBuPingNumbers = chuangDanBuPingNumbers;
            IfDiYouYin = ifDiYouYin;
            IfMenJingZang = ifMenJingZang;
            IfGoodOrOK = ifGoodOrOK;
        }*/
        public string BedRoomNumber { get; set; }
        public char[] BeiBuQiNumbers { get; set; }
        public char[] ChuangDanBuPingNumbers { get; set; }
        public bool IfDiYouYin { get; set; }
        public bool IfMenJingZang { get; set; }
        public bool IfGoodOrOK { get; set; }
        public char[] ChuangHaoNumber { get; set; }
    }
}
