using System;
using System.Collections;

namespace MyProgram
{
    class Operation_BackTraking
    {
        private int max;
        private int min;

        private short N;
        private short[] arr;
        private List<(char,bool)> operation_arr;
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

            operation_arr = new List<(char,bool)>();

            for (short i = 0; i < deohagi; i++)
                operation_arr.Add(('+',true));
            for (short i = 0; i < ppagi; i++)
                operation_arr.Add(('-',true));
            for (short i = 0; i < gophagi; i++)
                operation_arr.Add(('*',true));
            for (short i = 0; i < nanugi; i++)
                operation_arr.Add(('/',true));

            operations = new List<char>();
            this.max = Int32.MinValue;
            this.min = Int32.MaxValue;
        }

        public void Run()
        {
            this.yeonsanja(this.N - 1);
            Output_result();
        }

        private void Output_result()
        {
            Console.WriteLine("{0}\n{1}", this.max, this.min);
        }

        private void yeonsanja(int left)
        {
            char temp;
            bool isused;

            if(left == 0)
            {
                yeonSan();
                return;
            }

            for(short i=0;i<operation_arr.Count; i++)
            {
                //방문확인 방식으로 한번 바꿔보아라! -> 이따가 할일 !!!!
                var (op,canuse) = operation_arr[i];

                if (canuse == true)
                {
                    operations.Add(op);
                    operation_arr[i] = (op, false);
                    yeonsanja(left - 1);
                    operation_arr[i] = (op, true);
                    operations.RemoveAt(operations.Count-1);
                }
               
            }
        }

        private void yeonSan()
        {
            int result = arr[0];

            for (int i = 0; i < operations.Count; i++)
            {
                switch (operations[i])
                {
                    case '+':
                        result += this.arr[i+1];
                        break;
                    case '-':
                        result -= this.arr[i+1];
                        break;
                    case '*':
                        result *= this.arr[i+1];
                        break;
                    case '/':
                        result /= this.arr[i+1];
                        break;
                }
                ;
            }

       
            if(this.max<result)
            {
                this.max = result;
            }
            if (this.min > result)
            {
                this.min = result;
            }
        }

    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Operation_BackTraking opb = new Operation_BackTraking();
            opb.Run();
            return;
        }
    }
}