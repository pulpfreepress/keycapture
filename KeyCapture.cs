using System;
using System.Text;
using System.Threading;
using System.IO;



namespace KeyCapture
{
    class KeyCapture
    {
        private StringBuilder _sb;
        private ConsoleKeyInfo _key_info;

        public KeyCapture()
        {
            _sb = new StringBuilder();
        }

        public void Run()
        {
           while((_key_info = Console.ReadKey()).Key != ConsoleKey.Escape)
            {
                if(_key_info.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    _sb.Append("\r\n");
                } else if(_key_info.Key == ConsoleKey.OemPeriod)
                {
                    _sb.Append(_key_info.KeyChar);
                    using (StreamWriter writer = new StreamWriter("keys.txt", true))
                    {
                        writer.Write(_sb.ToString());
                    }
                    _sb.Clear();
                } else
                {
                    _sb.Append(_key_info.KeyChar);
                }
                

            }

            _sb.Append("\r\n");
            using (StreamWriter writer = new StreamWriter("keys.txt", true))
            {
                writer.Write(_sb.ToString());
            }
            _sb.Clear();

        }

        static void Main(string[] args)
        {
            KeyCapture kc = new KeyCapture();
            Thread t = new Thread(kc.Run);
            t.Start();
        }
    }
}
