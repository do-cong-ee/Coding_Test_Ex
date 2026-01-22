using System;

namespace MyProgram
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string[] input;
            input = Console.ReadLine().Split("");
            int n = Int32.Parse(input[0]);
            int cnt = 0, bun_mo = 0, bun_ja = 0, bunmo_bunja = 0;

            int layer = (int)Math.Sqrt(n);

            while (true)
            {
                if(layer*(layer+1)/2>= n && layer*(layer-1)/2 <= n)
                {
                    break;
                }
                else
                {
                    layer++;
                }
            }
            bunmo_bunja = layer + 1;
            cnt = layer*(layer - 1) / 2+1;

            if (layer % 2 == 0)
            {
                bun_ja = 1;
                bun_mo = bunmo_bunja - 1;
                while(true)
                {
                    if (cnt >=n)
                    {
                        break;
                    }
                    else
                    {
                        bun_ja++;
                        bun_mo--;
                        cnt++;
                    }
                }

            }
            else
            {
                bun_mo = 1;
                bun_ja = bunmo_bunja - 1;

                while (true)
                {
                    if (cnt >= n)
                    {
                        break;
                    }
                    else
                    {
                        bun_mo++;
                        bun_ja--;
                        cnt++;
                    }
                }
            }

            Console.WriteLine($"{bun_ja}/{bun_mo}");
                return;
        }
    }
}