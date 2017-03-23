/*
* Based on "Fisher–Yates shuffle" algorithm https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
* */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomListApplication
{
    class RandomList
    {
        private Int32 i, rand;
        private List<String> randList;
        private String sel;

        public String getRand()
        {
            var size = this.size();
            Int32 min = this.i;
            Int32 max = size;
            if (min<max)
            {
                Random rObj = new Random();
                this.rand = rObj.Next(min, max);
                this.sel = this.randList[this.rand];
                this.randList[this.rand] = this.randList[this.i];//shuffling value with "random key" & "current iterated key" within the range of pending iterations
                this.randList[this.i] = this.sel;//shuffling value with "current iterated key" & "random key" within the range of pending iterations
                this.i++;
            }
            else
            {
                this.reset();//Reset again. As, the reservoir is empty
                this.sel = this.getRand();
            }

            return this.sel;
        }

        public void reset()
        {
            this.i = 0;
            this.rand = 0;
            this.sel = "";
        }

        public Int32 size()
        {
            return this.randList.Count;
        }

        public RandomList(List<String> randList)
        {
            this.randList = randList;
        }
    }

    class ExecuteRandomList
    {
        static void Main(string[] args)
        {
            List<String> randList = new List<String>();
            randList.Add("a");
            randList.Add("b");
            randList.Add("c");
            RandomList randomList = new RandomList(randList);
            //Console.WriteLine(string.Join(",", randList));
            Console.WriteLine("Random 1: "+randomList.getRand());
            Console.WriteLine("Random 2: " + randomList.getRand());
            Console.WriteLine("Random 3: " + randomList.getRand());
            Console.WriteLine("Random 4: " + randomList.getRand());
            Console.ReadKey();
        }
    }
}
