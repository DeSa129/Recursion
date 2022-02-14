using System;


namespace Reiz
{
    class Program
    {

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcome to my amazing clock arrow angle calculator");
                Console.WriteLine("please enter hours 0 - 12");
                var hoursInput = Console.ReadLine();
                if (!int.TryParse(hoursInput, out int hours) | hours > 12 | hours < 0)
                {
                    Console.WriteLine("invalid value, needs to be a number between 0-12 ");
                    continue;
                }

                Console.WriteLine("please enter minutes 0 - 60");
                var minuteInput = Console.ReadLine();
                if (!int.TryParse(minuteInput, out int min) | min > 60 | min < 0)
                {
                    Console.WriteLine("invalid value, needs to be a number between 0-60 ");
                    continue;
                }
                var answare = CalculateAngle(hours, min);
                Console.WriteLine("Smaller angle between arrows is : {0} deg", answare);
                Console.WriteLine("press any key to continue");
                Console.ReadLine();
                Console.WriteLine("and last but not least, branch object depth calculator (i asume for this one you will evaluate code)");
                Console.WriteLine("homework didnt specify to do anything in console window");
                var newlist = new Branch();
                newlist.branches.Add(new Branch());
                newlist.branches.Add(new Branch());
                newlist.branches[0].branches.Add(new Branch());
                newlist.branches[1].branches.Add(new Branch());
                newlist.branches[1].branches.Add(new Branch());
                newlist.branches[1].branches.Add(new Branch());
                newlist.branches[1].branches[0].branches.Add(new Branch());
                newlist.branches[1].branches[1].branches.Add(new Branch());
                newlist.branches[1].branches[1].branches.Add(new Branch());
                newlist.branches[1].branches[1].branches[0].branches.Add(new Branch());
                var listDepth = CountDepth(newlist);
                Console.WriteLine("branch list depth is : {0} ", listDepth);
                Console.ReadLine();
                return;
            }
        }
        // I dont realy like declaring these variables here, but seem'd like the simplest way
        static int depth = 0;
        static int maxDepth = 0;
        public static int CountDepth(Branch list)
        {
            if (list.branches.Count == 0)
            {
                depth -=1;
                if (depth > maxDepth) maxDepth = depth;
                return 0;
            }
            foreach (var branch in list.branches)
            {
                depth += 1;
                CountDepth(branch);
            }
            return maxDepth;
        }
    
        public static float CalculateAngle(int hours, int min)
        {
            float circleDegree = 360;
            float oneHourDeg = circleDegree / 12;
            float oneMinDeg = circleDegree / 60;
            float oneMidDegInHourArrow = oneHourDeg / 60;

            float hourArrowDeg = hours * oneHourDeg + oneMidDegInHourArrow * min;
            float minArrowDeg = min * oneMinDeg;

            float degBetWeenArrows = Math.Abs(minArrowDeg - hourArrowDeg);
            float otherHalf = circleDegree - degBetWeenArrows;

            var lesserAngle = degBetWeenArrows >= otherHalf ? otherHalf : degBetWeenArrows;

            return lesserAngle;
        }
    }
}
