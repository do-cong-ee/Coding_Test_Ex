using System;
using System.Collections;

namespace MyProgram
{
    class Operation_BackTraking
    {
        private long max;
        private long min;

        private short N;
        private short[] arr;
        private List<char> operation_arr;
        private List<char> operations;



        public Operation_BackTraking ()
        {
            string[] input;
            input = Console.ReadLine().Split();
            this.N = Int16.Parse(input[0]);
            //n입력받기.

            input = Console.ReadLine().Split();
            arr = new short[input.Length];
            for (int i = 0; i < input.Length; i++)
                arr[i] = Int16.Parse(input[i]);
            // 정수입력받기

            short deohagi=0;
            short ppagi=0;
            short gophagi=0;
            short nanugi=0;

            input = Console.ReadLine().Split();

            deohagi = Int16.Parse(input[0]);
            ppagi = Int16.Parse(input[1]);
            gophagi = Int16.Parse(input[2]);
            nanugi = Int16.Parse(input[3]);

            operation_arr = new List<char>();

            for (short i = 0; i < deohagi; i++)
                operation_arr.Add('+');
            for (short i = 0; i < ppagi; i++)
                operation_arr.Add('-');
            for (short i = 0; i < gophagi; i++)
                operation_arr.Add('*');
            for (short i = 0; i < nanugi; i++)
                operation_arr.Add('/');

            operations = new List<char>();
        }

        public void Run()
        {
            long result = 0;
            int index;
            index = (this.N - 1);
        }

        private void yeonsanja(int index)
        {
            for(short i=0;i<index;i++)
            {
                operations.Add(operation_arr[i]);
                yeonsanja(index - 1);
                operations.Remove(operation_arr[i]);
            }
        }

        private long yeonSan()
        {
            return 0;
        }

    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Operation_BackTraking opb = new Operation_BackTraking();



        }
    }
}