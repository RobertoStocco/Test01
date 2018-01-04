using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test01
{
    class Program
    {
        //public delegate TResult Func<Targ0, TResult>(Targ0 arg0);

        static void Main(string[] args)
        {
            Predicate<string> isEmpty = x => string.Empty.Equals(x);
            Action<object> writeAndRead = x => { Console.WriteLine(x); Console.ReadLine(); };
            Func<string, string, bool> areStringsEmpty = (str1, str2) => isEmpty(str1) && isEmpty(str2);

            //writeAndRead(areStringsEmpty(string.Empty, ""));

            Action<string, int> waitForMessage = async (str, time) =>
            {
                writeAndRead(string.Format("Attendi {0}ms...", time));
                await Task.Delay(time);
                writeAndRead(str);
            };

            waitForMessage("Fatto!", 9000);

            writeAndRead("");
        }

        static async Task aspetta(int millisecondi)
        {
            await Task.Delay(millisecondi);
        }
    }
}
