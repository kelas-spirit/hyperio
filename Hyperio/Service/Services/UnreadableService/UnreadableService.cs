using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    public interface IUnreadableService
    {
        void TestDI();
        void Do(string element, ref string[] array);
        void MakeItReadable(string element, string[] array);
        string[] Result { get; }
    }
    
    public class UnreadableService : IUnreadableService
    {
        private string[] _result;
        void Print(string[] arr)
        {
            foreach (var a in arr)
            {
                Console.WriteLine(a);
            }
        }
        public void TestDI()
        {
            Console.WriteLine("Dependency Injection works fine ... ;)");
        }
        public void Do(string element, ref string[] array)
        {
            // Parameter
            string x = element;
            string[] a = array;

            // Logic
            string[] b = new string[a.Length - 1];
            bool flag = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (flag)
                    b[i - 1] = a[i];
                else
                {
                    flag = a[i] == x;

                    if (!flag)
                        b[i] = a[i];
                }
            }
            array = b;
            Print(array);
        }

        public string[] Result
        {
            get { return _result; }
        }
        public void MakeItReadable(string element, string[] array)
        {
            if (array.Any(x => x == element))
            {
                var result = array.Where(x => x != element).ToArray();
                _result = result;
                Print(result);
            }
            else
            {
                _result = array;
                Print(array);
            }

        }
    }
}
