using System;
using System.Diagnostics;
using System.Threading;

namespace PlayOnTime
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("这是一个定时播放歌曲的程序");
            //获取时间
            String time = DateTime.Now.ToString("hhmmss");
            Console.WriteLine(time);
            //设定时间
            
                /*Console.WriteLine("请设定时间");
                string timeOp = Console.ReadLine(); 
                int timeOpp = int.Parse(timeOp);*/
                string timeOp = System.IO.File.ReadAllText(@".\time.txt");
                System.Console.WriteLine("time={0}", timeOp);
                int timeOpp = int.Parse(timeOp);
            //设定歌曲名
            string song = System.IO.File.ReadAllText(@".\song.txt");
            System.Console.WriteLine("song{0}", song);

            //找好路径
            string songpath = (".\\"+song+".mp3");
            //Console.WriteLine(songpath);
            ProcessStartInfo processStartInfo = new ProcessStartInfo(songpath);
            Process process = new Process();
            process.StartInfo = processStartInfo;
            process.StartInfo.UseShellExecute = true;

            for (; ; ) 
            {
                
                //获取时间
                time = DateTime.Now.ToString("hhmmss");
                Console.WriteLine(time);
                //转换成int类型
                int timenowed = int.Parse(time);
                //做差比较
                int test = timenowed - timeOpp;
                Console.WriteLine(test);

                //符合条件则执行
                bool A = test < 200;
                bool B = test > -0;
                bool C = A == true & B == true;
                if (C == true)
                {
                    Console.WriteLine("It's the time to play");

                    process.Start(); // 打开文件
                    break;
                }
                Thread.Sleep(1000);
            }
             
            
              Console.ReadKey();

        }
    }
}
