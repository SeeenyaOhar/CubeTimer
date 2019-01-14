using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerCode.Code
{
    [Serializable]
    public enum ScrambleElements
    {
        R,L,F,D,U,B,
        R2,L2,F2,D2,U2,B2,
        R1,L1,F1,D1,U1,B1
    }
    [Serializable]
    public class Scramble
    {
        public static Scramble Empty { get; set; } = new Scramble(false);
        public ScrambleElements[] scrambleElements { get; private set; }
        public Scramble()
        {
            RandomSE rse = new RandomSE();
            scrambleElements = new ScrambleElements[20];
            for (Int32 i = 0; i < 20; i++)
            {
                scrambleElements[i] = rse.GetRandomSE();
                
            }
        }
        // <summary>
        // Boolean object is useful for overloading
        // </summary>
        // <param name="element"></param>
        private Scramble(Boolean sf)
        {
            scrambleElements = new ScrambleElements[0];
        }
        // <summary>
        // Only for empty object.
        // </summary>
        public void AddElement(ScrambleElements el)
        {
            
            if (scrambleElements.Count() == 20)
            {
                throw new InvalidOperationException("Method \"AddElement(el)\" is only avaliable for empty Scramble object"); // TODO: FIX BUG
            }
            else
            {
                
                var v = scrambleElements.ToList();
                v.Add(el);
                scrambleElements = v.ToArray();
                if (this.scrambleElements.Count() == 20)
                {
                    Empty = new Scramble(false);
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var v in scrambleElements)
            {
                sb.Append(Replace(v));
                sb.Append(" ");
            }
            return sb.ToString();
        }
        private String Replace(ScrambleElements se)
        {
            if (se.ToString() == "R1")
            {
                return "R'";
            }
            if (se.ToString() == "L1")
            {
                return "L'";
            }
            if (se.ToString() == "D1")
            {
                return "D'";
            }
            if (se.ToString() == "U1")
            {
                return "U'";
            }
            if (se.ToString() == "B1")
            {
                return "B'";
            }
            if (se.ToString() == "F1")
            {
                return "F'";
            }
            return se.ToString();
        }
    }
    class RandomSE
    {
        ScrambleElements previous;
        Boolean IsFirstTime = true;
        Random random = new Random();
        public void Randomize()
        {
            random = new Random();
        }
        public ScrambleElements GetRandomSE()
        {
            
            List<Int32> choosearray = new List<Int32>();
            ScrambleElements se;
            if (!IsFirstTime)
            {

                if (previous.ToString().Contains("R"))
                {
                    choosearray = new List<Int32>() { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17 };
                }
                if (previous.ToString().Contains("L"))
                {
                    choosearray = new List<Int32>() { 0, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 14, 15, 16, 17 };
                }
                if (previous.ToString().Contains("F"))
                {
                    choosearray = new List<Int32>() { 0, 1, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 15, 16, 17 };
                }
                if (previous.ToString().Contains("D"))
                {
                    choosearray = new List<Int32>() { 0, 1, 2, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 16, 17 };
                }
                if (previous.ToString().Contains("B"))
                {
                    choosearray = new List<Int32>() { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10, 12, 13, 14, 15, 16 };
                }
                if (previous.ToString().Contains("U"))
                {
                    choosearray = new List<Int32>() { 0, 1, 2, 3, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 17 };
                }
                random.Next(0,15);
                Int32 index = random.Next(0, 15);
                se = (ScrambleElements)choosearray[index];
                previous = se;
                return se;
            }
            IsFirstTime = false;
            se = (ScrambleElements)random.Next(0, 17);
            return se;
        }
    }
}
