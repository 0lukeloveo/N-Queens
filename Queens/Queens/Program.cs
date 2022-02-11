using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queens
{
    class Queen
    {
        static void Main(string[] args)
        {
            int n = 8; //有幾個皇后
            Queue(n);
            Console.ReadLine();
        }

        public static void Queue(int n)
        {
            int i;
            int index = 1; //第一個皇后
            int[] CNum = new int[n + 1];
            int Answer = 0;
            string Queen; //表示為皇后OR空白

            string solution = "";//定義空值
            for (i = 1; i <= n; i++)
            {
                CNum[i] = 0;//初始化從第0列開始
            }
            while (index > 0)
            {
                CNum[index]++;//第index個皇后所在的列數
                while (CNum[index] <= n && !Place(CNum, index))  //尋找皇后的位置
                {
                    CNum[index]++;
                }
                if (CNum[index] <= n)
                {
                    if (index == n)//最後一個皇后放置成功
                    {
                        Answer++;//第幾種方法
                        solution ="方法" + Answer + ":";
                        Console.WriteLine(solution);
                        for (i = 1; i <= n; i++)
                        {
                            for (int j = 1; j <= n; j++)
                            {
                                Queen = j == CNum[i] ? "Q" : ".";
                                Console.Write(Queen);
                            }
                            solution = solution + "  " + CNum[i];
                            Console.WriteLine("");
                        }
                    }
                    else //尋找下一個皇后的位置
                    {
                        index++; //皇后數+1
                        CNum[index] = 0;
                    }
                }
                else
                {
                    index--; //當前皇后無法放置，回溯至上一個皇后
                }
            }
        }
        public static bool Place(int[] Column, int index)  //Column--列  
        {
            for (int i = 1; i < index; i++)//若index>2，與前兩個皇后進行比較
            {
                int Columndiffer = Math.Abs(Column[index] - Column[i]);
                int Rowdiffer = Math.Abs(index - i);
                if (Column[i] == Column[index] || Columndiffer == Rowdiffer)//是否有皇后與其在同行或同一斜線
                {
                    return false;
                }
            }
            return true; //沒有皇后與其同型、同列或同對角線
        }
    }
}
