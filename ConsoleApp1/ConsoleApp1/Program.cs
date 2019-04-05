using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace ConsoleApp1

{
    public interface Sum { void output(); }
    class WordCount             //打开文件
    {

        public string Read()
        {
            string all = "";
            while (all == "")
            {
                Console.Write("请输入想要统计的文件:");
                string fx = Console.ReadLine();
                if (File.Exists(fx))
                {
                    string fn = @fx;
                    //string fn = @"E:\text.txt";
                    all = File.ReadAllText(fn, Encoding.UTF8);
                    return all;
                }
                else
                {
                    Console.WriteLine("文件不存在");
                }
            }
            return all;
        }
    }
    class   Sumletter:Sum 
    {
        public void output()
        {
            int i;
            int a = 0;
            byte[] bytedata = new byte[100];
            char[] chardata = new char[100];
            FileStream fs = new FileStream("E:\\text.txt", FileMode.Open);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(bytedata, 0, 100);
            Decoder d = Encoding.Default.GetDecoder();
            d.GetChars(bytedata, 0, bytedata.Length, chardata, 0);
            Console.WriteLine(chardata);
            
            for (i = 0; i < chardata.Length; i++)
            {
                if (chardata[i] <= 127 && chardata[i] > 0)
                    a++;
            }
            Console.WriteLine(a);
        }
     

    }
    class  Sumword:Sum 
    {
        public void output()
        {
        int i, j;
        int a = 0;
        byte[] bytedata = new byte[100];
        char[] chardata = new char[100];
        FileStream fs = new FileStream("E:\\text.txt", FileMode.Open);
        fs.Seek(0, SeekOrigin.Begin);
        fs.Read(bytedata, 0, 100);
        Decoder d = Encoding.Default.GetDecoder();
        d.GetChars(bytedata, 0, bytedata.Length, chardata, 0);
        Console.WriteLine(chardata);
        for (i = 0; i < chardata.Length;)
        {
            if ((chardata[i] >= 97 && chardata[i] <= 122) && (chardata[i + 1] >= 97 && chardata[i + 1] <= 122) && (chardata[i + 2] >= 97 && chardata[i + 2] <= 122) && (chardata[i + 3] >= 97 && chardata[i + 3] <= 122))
            {
                for (j = i; chardata[j] >= 97 && chardata[j] <= 122; j++)
                {
                    i = j;
                }
                a++;
            }
            else i++;
        }
        Console.WriteLine(a);
    }
       }
    class Sumline:Sum
    {

        public void output()
        {
            int i = 0;
            StreamReader fs = new StreamReader("e:\\text.txt");
            string line;
            while ((line = fs.ReadLine()) != null)
            {
                i++;
            }
            Console.WriteLine(i);
        }
    }
    public class Sumtime:Sum
    {



        public void output()
        {

            string All;
            int p = 0;
            WordCount A = new WordCount();
            All = A.Read();
            string[] words = All.Split(
                new char[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);//按照文件中所有空格，换行等，将文件分离为单个单词放进一个数组
            string[] ALL1 = new string[10000];
            for (int i = 0; i < words.Length; i++)
            {
                string str = words[i].ToString();
                string str0 = words[i].ToString();//保留初值
                string strup = str0.ToLower();
                int c = 0;
                if (words[i].Length >= 4)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        string str1 = str.Substring(0, 1);
                        str = str.Remove(0, 1);
                        char ch = Convert.ToChar(str1);
                        if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                        {
                            c++;
                        }
                    }
                    if (c == 4)
                    {
                        ALL1[p] = strup;
                        p++;
                    }
                }
            }
            /*for (int z = 0; z < p; z++)
            {
                Console.WriteLine(ALL1[z]);
            }*/
            Console.WriteLine("单词总数为：" + p);
            Console.WriteLine("出现最多的10个单词为");
            int a = 0;
            foreach (var kv in ALL1.GroupBy(x => x).OrderByDescending(x => x.Count()))
            {
                if (kv.Key != null)
                {
                    Console.WriteLine("{0}:{1}", kv.Key, kv.Count());
                    a++;
                }
                if (a == 10)
                    break;
            }
            Console.ReadLine();


            

        }
    }
    class pinlv : Sum
    {
        public void output()
        {
            int qq;
            Console.WriteLine("分组数为：");
            qq= int.Parse(Console.ReadLine());
            int i, j;
            int a = 0;
            byte[] bytedata = new byte[100];
            char[] chardata = new char[100];
            FileStream fs = new FileStream("E:\\text.txt", FileMode.Open);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(bytedata, 0, 100);
            Decoder d = Encoding.Default.GetDecoder();
            d.GetChars(bytedata, 0, bytedata.Length, chardata, 0);
            Console.WriteLine(chardata);
            for (i = 0; i < chardata.Length;)
            {
                if ((chardata[i] >= 97 && chardata[i] <= 122) && (chardata[i + 1] >= 97 && chardata[i + 1] <= 122) && (chardata[i + 2] >= 97 && chardata[i + 2] <= 122) && (chardata[i + 3] >= 97 && chardata[i + 3] <= 122))
                {
                    for (j = i; chardata[j] >= 97 && chardata[j] <= 122; j++)
                    {
                        i = j;
                    }
                    a++;
                }
                else i++;
            }
            Console.WriteLine(a/qq);

        }
    }class zhiding : Sum
    {
        public void output()
        {

            string All;
            int p = 0;
            WordCount A = new WordCount();
            All = A.Read();
            string[] words = All.Split(
                new char[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);//按照文件中所有空格，换行等，将文件分离为单个单词放进一个数组
            string[] ALL1 = new string[10000];
            for (int i = 0; i < words.Length; i++)
            {
                string str = words[i].ToString();
                string str0 = words[i].ToString();//保留初值
                string strup = str0.ToLower();
                int c = 0;
                if (words[i].Length >= 4)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        string str1 = str.Substring(0, 1);
                        str = str.Remove(0, 1);
                        char ch = Convert.ToChar(str1);
                        if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                        {
                            c++;
                        }
                    }
                    if (c == 4)
                    {
                        ALL1[p] = strup;
                        p++;
                    }
                }
            }
            /*for (int z = 0; z < p; z++)
            {
                Console.WriteLine(ALL1[z]);
            }*/
            Console.WriteLine("单词总数为：" + p);
            Console.WriteLine("请输入需要输出的数量：");
            int qq = int.Parse(Console.ReadLine ());
            int a = 0;
            foreach (var kv in ALL1.GroupBy(x => x).OrderByDescending(x => x.Count()))
            {
                if (kv.Key != null)
                {
                    Console.WriteLine("{0}:{1}", kv.Key, kv.Count());
                    a++;
                }
                if (a == qq)
                    break;
            }
            Console.ReadLine();




        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sum Sumtime = new Sumtime();
            Sum Sumline = new Sumline();
            Sum Sumletter = new Sumletter();
            Sum Sumword = new Sumword();
            Sum Pinlv = new Pinlv();
            Sum Zhiding = new Zhiding();
            Console.WriteLine("1:查询字符数   2:查询单词数   3:查询有效行数   4:查询词频最高的10个并输出  ");
            Console.WriteLine("请输入你需要的功能");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1: Sumletter.output(); break;
                case 2: Sumword.output(); break;
                case 3: Sumline.output(); break;
                case 4: Sumtime.output(); break;
                default: Console.WriteLine("你输入的指令有误！！"); break;
            }
            Console.ReadKey();

        }
    }

}

