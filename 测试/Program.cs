using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 测试
{
    class Program
    {
        static void Main(string[] args)
        {
           /* StreamReader sr = new StreamReader(@"D:\Desktop\样本.csv",Encoding.GetEncoding("gb2312"));
            Dictionary<string, Dictionary<string, int>> dic = ReadCVS(sr);
            foreach (KeyValuePair<string, Dictionary<string, int>> item in dic)
            {
                foreach (KeyValuePair<string,int> item2 in item.Value)
                {
                    Console.WriteLine(item.Key+" "+item2.Key+"  "+item2.Value);
                }
            }
            Console.WriteLine(@"\********************\");*/
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));

            int i = 12345678;
            string s = i.ToString();
            char[] ss = s.ToCharArray();
            foreach (var item in ss)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public static Dictionary<string, Dictionary<string, int>> ReadCVS(StreamReader sr)
        {
            Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();
            sr.ReadLine();//pass掉第一行数据
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();//读取单行数据,例:201808001,崔天植,A516,1
                s=s.Remove(0, 10);//移除学号,例:崔天植,A516,1
                //Console.WriteLine(s);
                string[] data = s.Split(',');//分割,例:崔天植  A516   1
                /*foreach (var item in data)
                {
                    Console.WriteLine(item);
                }*/
                if (!dic.ContainsKey(data[1]))
                {
                    Dictionary<string, int> temp = new Dictionary<string, int>();
                    temp.Add(data[0], Convert.ToInt32(data[2]));
                    dic.Add(data[1], temp);
                }
                else
                {
                    dic[data[1]].Add(data[0], Convert.ToInt32(data[2]));
                }

            }
            return dic;
        }
    }
}
