using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using static Lab_18_04.Program;

namespace Lab_18_04
{
    internal class Program
    {
        #region ex1
        public static void MyThread() {
            List<string> str = new List<string>() {
                "a", "b", "c", "d", "f", "g", "h", "k", "l"
            };
            foreach (string a in str) {
                Console.WriteLine(a);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Поток завершает работу!");
        }
        static void Main(string[] args) {
            Thread thr = new Thread(new ThreadStart(MyThread));
            thr.Start();
        }
        #endregion

        #region ex2

        public class Bank
        {
            public int money;
            public string name;
            public int percent;
            public MyThread mt;

            public Bank() { }
            public Bank(int money, string name, int percent)
            {
                this.money = money;
                this.name = name;
                this.percent = percent;
            }

            public void Edit()
            {
                Console.Write($"money: ");
                string m = Console.ReadLine();
                money = Convert.ToInt32(m);
                Console.Write($"name: ");
                name = Console.ReadLine();
                Console.Write($"percent: ");
                string p = Console.ReadLine();
                percent = Convert.ToInt32(p);
            }
            public void Print()
            {
                Console.WriteLine($"name: {name}");
                Console.WriteLine($"money: {money}");
                Console.WriteLine($"percent: {percent}");
            }
        }

        public class MyThread
        {
            public int money;
            public string name;
            public int procent;

            public MyThread(Bank bank)
            {
                money = bank.money;
                name = bank.name;
                procent = bank.percent;
            }

            public void ProcThread()
            {
                Thread t = Thread.CurrentThread;
                Thread.Sleep(500);
                FileInfo fl = new FileInfo("text.txt");
                fl.Create();
                StreamWriter sw = new StreamWriter("text.txt");
                sw.WriteLine(name);
                Console.WriteLine("Поток завершает работу !");
            }
        }

        static void Main(string[] args)
        {
            Bank bank = new Bank(0, " ", 0);

            MyThread thr = new MyThread(bank);
            bank.Edit();
            thr.ProcThread();
        }
        #endregion
    }
}
