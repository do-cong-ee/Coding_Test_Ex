using System;
using System.Collections;

namespace MyProgram
{
    class Operation_BackTraking
    {
        private int? max;
        private int? min;

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
            this.max = null;
            this.min = null;
        }

        public void Run()
        {
            this.yeonsanja(this.N - 1);
        }

        private void Output_result()
        {
            Console.WriteLine("{0}", this.max);
            Console.WriteLine("{0}", this.min);
        }

        private void yeonsanja(int left)
        {
            char temp;

            if(left <= 0)
            {
                yeonSan();
                return;
            }

            for(short i=0;i<left; i++)
            {
                temp = operation_arr[i];
                operations.Add(temp);
                operation_arr.Remove(temp);

                yeonsanja(left - 1);

                operations.Remove(temp);
                operation_arr.Add(temp);
            }
        }

        private void yeonSan()
        {
            int result = 0;

            switch(operations[0])
            {
                case '+':
                    result = this.arr[0] + this.arr[1];
                    break;
                case '-':
                    result = this.arr[0] - this.arr[1];
                    break;
                case '*':
                    result = this.arr[0] * this.arr[1];
                    break;
                case '/':
                    result = this.arr[0] / this.arr[1];
                    break;
            };

            for (int i = 2; i < this.N - 1; i++)
            {
                switch (operations[i - 1])
                {
                    case '+':
                        result += this.arr[i];
                        break;
                    case '-':
                        result -= this.arr[i];
                        break;
                    case '*':
                        result *= this.arr[i];
                        break;
                    case '/':
                        result /= this.arr[i];
                        break;
                }
                ;
            }

            if (this.max == null || this.min == null)
            {
                this.max = result;
                this.min = result;
            }
            else
            {
                if(this.max<result)
                {
                    this.max = result;
                }
                if(this.min>result)
                {
                    this.min = result;
                }
            }
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