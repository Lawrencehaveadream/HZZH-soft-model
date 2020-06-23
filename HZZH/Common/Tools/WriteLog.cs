using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
namespace Tools
{
    public static class WriteLog
    {
        private static BlockingCollection<string> queue = new BlockingCollection<string>();
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static WriteLog()
        {
            if (!Directory.Exists(@"Logs"))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(@"Logs"); //新建文件夹   
            }

            var thread = new Thread(StartConsuming);
            thread.IsBackground = true;
            thread.Start();
        }



        public static void AddLog(string message)
        {
            queue.Add(DateTime.Now + "," + message + Environment.NewLine);
            autoResetEvent.Set();
        }

        private static void StartConsuming()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    try
                    {
                        File.AppendAllText(@"Logs\" + DateTime.Now.ToString("yyyy-MM-dd") + ".lg", queue.Take());
                    }
                    catch
                    { }
                }
                else
                {
                    autoResetEvent.WaitOne();
                }
            }
        }

    }

    public static class WriteForce
    {
        private static BlockingCollection<string> queue = new BlockingCollection<string>();
        private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public static string time = DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
        private static string path = @"AllForceData\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
        static WriteForce()
        {
            if (!Directory.Exists(@"AllForceData"))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(@"AllForceData"); //新建文件夹   
            }

            var thread = new Thread(StartData);
            thread.IsBackground = true;
            thread.Start();
        }


        public static void AddForceData(string aData,string bData)
        {
            queue.Add(DateTime.Now + "," + aData + "," + bData + Environment.NewLine);
            autoResetEvent.Set();
        }

        private static void StartData()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    try
                    {
                        if (!Directory.Exists(@"AllForceData\" + DateTime.Now.ToString("yyyy-MM-dd")+"\\"))//若文件夹不存在则新建文件夹   
                        {
                            path = @"AllForceData\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\";
                            Directory.CreateDirectory(path); //新建文件夹   
                        }
                        File.AppendAllText(path + time + ".data", queue.Take());
                    }
                    catch
                    { }
                }
                else
                {
                    autoResetEvent.WaitOne();
                }
            }
        }
    }
}
