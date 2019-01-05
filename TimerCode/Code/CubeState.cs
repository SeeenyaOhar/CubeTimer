using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimerCode.Code
{
    public enum CEC // Color of Edge or Corner -> CEC
    {
        Blue, Green, Red, Orange, White, Yellow
    }
    enum RotateWay
    {
        Right,Left
    }
    public class CubeState
    {
        private Side s1; // GREEN
        private Side s2; // WHITE
        private Side s3; // BLUE
        private Side s4; // YELLOW
        private Side s5; // RED
        private Side s6; // ORANGE

        public Side S1 { get => s1; internal set => s1 = value; }
        public Side S2 { get => s2; internal set => s2 = value; }
        public Side S3 { get => s3; internal set => s3 = value; }
        public Side S4 { get => s4; internal set => s4 = value; }
        public Side S5 { get => s5; internal set => s5 = value; }
        public Side S6 { get => s6; internal set => s6 = value; }

        public CubeState()
        {
            S1 = new Side(CEC.Green);
            S2 = new Side(CEC.White);
            S3 = new Side(CEC.Blue);
            S4 = new Side(CEC.Yellow);
            S5 = new Side(CEC.Red);
            S6 = new Side(CEC.Orange);
        }
        public void PrepareForUI()
        {
            Rotate(s3, RotateWay.Right, 2);
            
        }
        public static CubeState Scramble(Scramble scramble)
        {
            var cs = new CubeState();
            foreach (var v in scramble.scrambleElements)
            {
                switch (v)
                {
                    case ScrambleElements.B:
                        cs.Back();
                        break;
                    case ScrambleElements.B1:
                        cs.BackCounterClockwise();
                        break;
                    case ScrambleElements.B2:
                        cs.Back();
                        cs.Back();
                        break;
                    case ScrambleElements.D:
                        cs.Down();
                        break;
                    case ScrambleElements.D1:
                        cs.DownCounterClockwise();
                        break;
                    case ScrambleElements.D2:
                        cs.DownCounterClockwise();
                        cs.DownCounterClockwise();
                        break;
                    case ScrambleElements.F:
                        cs.Front();
                        break;
                    case ScrambleElements.F1:
                        cs.FrontCounterClockwise();
                        break;
                    case ScrambleElements.F2:
                        cs.FrontCounterClockwise();
                        cs.FrontCounterClockwise();
                        break;
                    case ScrambleElements.L:
                        cs.Left();
                        break;
                    case ScrambleElements.L1:
                        cs.LeftCounterClockwise();
                        break;
                    case ScrambleElements.L2:
                        cs.LeftCounterClockwise();
                        cs.LeftCounterClockwise();
                        break;
                    case ScrambleElements.R:
                        cs.Right();
                        break;
                    case ScrambleElements.R1:
                        cs.RightCounterClockwise();
                        break;
                    case ScrambleElements.R2:
                        cs.RightCounterClockwise();
                        cs.RightCounterClockwise();
                        break;
                    case ScrambleElements.U:
                        cs.Up();
                        break;
                    case ScrambleElements.U1:
                        cs.UpCounterClockwise();
                        break;
                    case ScrambleElements.U2:
                        cs.UpCounterClockwise();
                        cs.UpCounterClockwise();
                        break;

                }
            }
            return cs;
        }
        public void Right()
        {
            
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[2], S1.Elements[5], S1.Elements[8]},
            new List<CEC>(){S2.Elements[2], S2.Elements[5], S2.Elements[8]},
            new List<CEC>(){S3.Elements[2], S3.Elements[5],S3.Elements[8]  },
            new List<CEC>(){S4.Elements[2], S4.Elements[5],S4.Elements[8]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[3];
            list1[1] = f[0];
            list1[2] = f[1];
            list1[3] = f[2];
            List<CEC> list2 = new List<CEC>() { }; // ORANGE SIDE
            Rotate(S5, RotateWay.Right, 1);

            S1.Elements[2] = (list1[0])[0];
            S1.Elements[5] = (list1[0])[1];
            S1.Elements[8] = (list1[0])[2];

            S2.Elements[2] = (list1[1])[0];
            S2.Elements[5] = (list1[1])[1];
            S2.Elements[8] = (list1[1])[2];

            S3.Elements[2] = (list1[2])[0];
            S3.Elements[5] = (list1[2])[1];
            S3.Elements[8] = (list1[2])[2];

            S4.Elements[2] = (list1[3])[0];
            S4.Elements[5] = (list1[3])[1];
            S4.Elements[8] = (list1[3])[2];


            
        }
        public void RightCounterClockwise()
        {
           
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[2], S1.Elements[5], S1.Elements[8]},
            new List<CEC>(){S2.Elements[2], S2.Elements[5], S2.Elements[8]},
            new List<CEC>(){S3.Elements[2], S3.Elements[5],S3.Elements[8]  },
            new List<CEC>(){S4.Elements[2], S4.Elements[5],S4.Elements[8]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[1];
            list1[1] = f[2];
            list1[2] = f[3];
            list1[3] = f[0];
            List<CEC> list2 = new List<CEC>() { }; // ORANGE SIDE
            Rotate(S5, RotateWay.Left, 1);


            S1.Elements[2] = (list1[0])[0];
            S1.Elements[5] = (list1[0])[1];
            S1.Elements[8] = (list1[0])[2];

            S2.Elements[2] = (list1[1])[0];
            S2.Elements[5] = (list1[1])[1];
            S2.Elements[8] = (list1[1])[2];

            S3.Elements[2] = (list1[2])[0];
            S3.Elements[5] = (list1[2])[1];
            S3.Elements[8] = (list1[2])[2];

            S4.Elements[2] = (list1[3])[0];
            S4.Elements[5] = (list1[3])[1];
            S4.Elements[8] = (list1[3])[2];


            
        }
        
        
        public void Left()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[0], S1.Elements[3], S1.Elements[6]},
            new List<CEC>(){S2.Elements[0], S2.Elements[3], S2.Elements[6]},
            new List<CEC>(){S3.Elements[0], S3.Elements[3],S3.Elements[6]  },
            new List<CEC>(){S4.Elements[0], S4.Elements[3],S4.Elements[6]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[1];
            list1[1] = f[2];
            list1[2] = f[3];
            list1[3] = f[0];

            Rotate(S6, RotateWay.Right, 1);


            S1.Elements[0] = (list1[0])[0];
            S1.Elements[3] = (list1[0])[1];
            S1.Elements[6] = (list1[0])[2];

            S2.Elements[0] = (list1[1])[0];
            S2.Elements[3] = (list1[1])[1];
            S2.Elements[6] = (list1[1])[2];

            S3.Elements[0] = (list1[2])[0];
            S3.Elements[3] = (list1[2])[1];
            S3.Elements[6] = (list1[2])[2];

            S4.Elements[0] = (list1[3])[0];
            S4.Elements[3] = (list1[3])[1];
            S4.Elements[6] = (list1[3])[2];

            
        }
        public void LeftCounterClockwise()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[0], S1.Elements[3], S1.Elements[6]},
            new List<CEC>(){S2.Elements[0], S2.Elements[3], S2.Elements[6]},
            new List<CEC>(){S3.Elements[0], S3.Elements[3],S3.Elements[6]  },
            new List<CEC>(){S4.Elements[0], S4.Elements[3],S4.Elements[6]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[3];
            list1[1] = f[0];
            list1[2] = f[1];
            list1[3] = f[2];

            Rotate(S6, RotateWay.Left, 1);


            S1.Elements[0] = (list1[0])[0];
            S1.Elements[3] = (list1[0])[1];
            S1.Elements[6] = (list1[0])[2];

            S2.Elements[0] = (list1[1])[0];
            S2.Elements[3] = (list1[1])[1];
            S2.Elements[6] = (list1[1])[2];

            S3.Elements[0] = (list1[2])[0];
            S3.Elements[3] = (list1[2])[1];
            S3.Elements[6] = (list1[2])[2];

            S4.Elements[0] = (list1[3])[0];
            S4.Elements[3] = (list1[3])[1];
            S4.Elements[6] = (list1[3])[2];

        }
        public void Up()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[0], S1.Elements[1], S1.Elements[2]},
            new List<CEC>(){S6.Elements[0], S6.Elements[1], S6.Elements[2]},
            new List<CEC>(){ S3.Elements[6], S3.Elements[7], S3.Elements[8]  },
            new List<CEC>(){S5.Elements[1 - 1], S5.Elements[2 - 1],S5.Elements[3 - 1]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[3];
            list1[1] = f[0];
            list1[2] = f[1];
            list1[3] = f[2];

            Rotate(S2, RotateWay.Right, 1);


            S1.Elements[0] = (list1[0])[0];
            S1.Elements[1] = (list1[0])[1];
            S1.Elements[2] = (list1[0])[2];

            S6.Elements[0] = (list1[1])[0];
            S6.Elements[1] = (list1[1])[1];
            S6.Elements[2] = (list1[1])[2];

            S3.Elements[6] = (list1[2])[2];
            S3.Elements[7] = (list1[2])[1];
            S3.Elements[8] = (list1[2])[0];

            S5.Elements[0] = (list1[3])[2];
            S5.Elements[1] = (list1[3])[1];
            S5.Elements[2] = (list1[3])[0];

        }
        public void UpCounterClockwise()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[0], S1.Elements[1], S1.Elements[2]},
            new List<CEC>(){S6.Elements[0], S6.Elements[1], S6.Elements[2]},
            new List<CEC>(){ S3.Elements[6], S3.Elements[7], S3.Elements[8]  },
            new List<CEC>(){S5.Elements[0], S5.Elements[1],S5.Elements[2]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[1];
            list1[1] = f[2];
            list1[2] = f[3];
            list1[3] = f[0];

            Rotate(S2, RotateWay.Left, 1);


            S1.Elements[0] = (list1[0])[0];
            S1.Elements[1] = (list1[0])[1];
            S1.Elements[2] = (list1[0])[2];

            S6.Elements[0] = (list1[1])[2];
            S6.Elements[1] = (list1[1])[1];
            S6.Elements[2] = (list1[1])[0];

            S3.Elements[6] = (list1[2])[2];
            S3.Elements[7] = (list1[2])[1];
            S3.Elements[8] = (list1[2])[0];

            S5.Elements[0] = (list1[3])[0];
            S5.Elements[1] = (list1[3])[1];
            S5.Elements[2] = (list1[3])[2];
        }
        public void Down()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[6], S1.Elements[7], S1.Elements[8]},
            new List<CEC>(){S6.Elements[6], S6.Elements[7], S6.Elements[8]},
            new List<CEC>(){ S3.Elements[0], S3.Elements[1], S3.Elements[2]  },
            new List<CEC>(){S5.Elements[6], S5.Elements[7],S5.Elements[8]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[1];
            list1[1] = f[2];
            list1[2] = f[3];
            list1[3] = f[0];

            Rotate(S4, RotateWay.Right, 1);


            S1.Elements[6] = (list1[0])[0];
            S1.Elements[7] = (list1[0])[1];
            S1.Elements[8] = (list1[0])[2];

            S6.Elements[6] = (list1[1])[2];
            S6.Elements[7] = (list1[1])[1];
            S6.Elements[8] = (list1[1])[0];

            S3.Elements[0] = (list1[2])[2];
            S3.Elements[1] = (list1[2])[1];
            S3.Elements[2] = (list1[2])[0];

            S5.Elements[6] = (list1[3])[0];
            S5.Elements[7] = (list1[3])[1];
            S5.Elements[8] = (list1[3])[2];
        }
        public void DownCounterClockwise()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S1.Elements[6], S1.Elements[7], S1.Elements[8]},
            new List<CEC>(){S6.Elements[6], S6.Elements[7], S6.Elements[8]},
            new List<CEC>(){ S3.Elements[0], S3.Elements[1], S3.Elements[2]  },
            new List<CEC>(){S5.Elements[6], S5.Elements[7],S5.Elements[8]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[3];
            list1[1] = f[0];
            list1[2] = f[1];
            list1[3] = f[2];

            Rotate(S4, RotateWay.Left, 1);


            S1.Elements[6] = (list1[0])[0];
            S1.Elements[7] = (list1[0])[1];
            S1.Elements[8] = (list1[0])[2];

            S6.Elements[6] = (list1[1])[0];
            S6.Elements[7] = (list1[1])[1];
            S6.Elements[8] = (list1[1])[2];

            S3.Elements[0] = (list1[2])[2];
            S3.Elements[1] = (list1[2])[1];
            S3.Elements[2] = (list1[2])[0];

            S5.Elements[6] = (list1[3])[2];
            S5.Elements[7] = (list1[3])[1];
            S5.Elements[8] = (list1[3])[0];
        }
        public void Front()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S6.Elements[2], S6.Elements[5],S6.Elements[8]},
            new List<CEC>(){S2.Elements[6], S2.Elements[7], S2.Elements[8]},
            new List<CEC>(){ S5.Elements[0], S5.Elements[3], S5.Elements[6]  },
            new List<CEC>(){S4.Elements[0], S4.Elements[1],S4.Elements[2]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[3];
            list1[1] = f[0];
            list1[2] = f[1];
            list1[3] = f[2];

            Rotate(S1, RotateWay.Right, 1);


            S6.Elements[2] = (list1[0])[0];
            S6.Elements[5] = (list1[0])[1];
            S6.Elements[8] = (list1[0])[2];

            S2.Elements[6] = (list1[1])[2];
            S2.Elements[7] = (list1[1])[1];
            S2.Elements[8] = (list1[1])[0];

            S5.Elements[0] = (list1[2])[0];
            S5.Elements[3] = (list1[2])[1];
            S5.Elements[6] = (list1[2])[2];

            S4.Elements[0] = (list1[3])[2];
            S4.Elements[1] = (list1[3])[1];
            S4.Elements[2] = (list1[3])[0];
        }
        public void FrontCounterClockwise()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S6.Elements[2], S6.Elements[5],S6.Elements[8]},
            new List<CEC>(){S2.Elements[6], S2.Elements[7], S2.Elements[8]},
            new List<CEC>(){ S5.Elements[0], S5.Elements[3], S5.Elements[6]  },
            new List<CEC>(){S4.Elements[0], S4.Elements[1],S4.Elements[2]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[1];
            list1[1] = f[2];
            list1[2] = f[3];
            list1[3] = f[0];

            Rotate(S1, RotateWay.Left, 1);


            S6.Elements[2] = (list1[0])[2];
            S6.Elements[5] = (list1[0])[1];
            S6.Elements[8] = (list1[0])[0];

            S2.Elements[6] = (list1[1])[0];
            S2.Elements[7] = (list1[1])[1];
            S2.Elements[8] = (list1[1])[2];

            S5.Elements[0] = (list1[2])[2];
            S5.Elements[3] = (list1[2])[1];
            S5.Elements[6] = (list1[2])[0];

            S4.Elements[0] = (list1[3])[0];
            S4.Elements[1] = (list1[3])[1];
            S4.Elements[2] = (list1[3])[2];
        }
        public void Back()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S6.Elements[0], S6.Elements[3],S6.Elements[6]},
            new List<CEC>(){S2.Elements[0], S2.Elements[1], S2.Elements[2]},
            new List<CEC>(){ S5.Elements[2], S5.Elements[5], S5.Elements[8]  },
            new List<CEC>(){S4.Elements[6], S4.Elements[7],S4.Elements[8]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[1];
            list1[1] = f[2];
            list1[2] = f[3];
            list1[3] = f[0];

            Rotate(S3, RotateWay.Right, 1);


            S6.Elements[0] = (list1[0])[2];
            S6.Elements[3] = (list1[0])[1];
            S6.Elements[6] = (list1[0])[0];

            S2.Elements[0] = (list1[1])[0];
            S2.Elements[1] = (list1[1])[1];
            S2.Elements[2] = (list1[1])[2];

            S5.Elements[2] = (list1[2])[2];
            S5.Elements[5] = (list1[2])[1];
            S5.Elements[8] = (list1[2])[0];

            S4.Elements[6] = (list1[3])[0];
            S4.Elements[7] = (list1[3])[1];
            S4.Elements[8] = (list1[3])[2];
        }
        public void BackCounterClockwise()
        {
            List<List<CEC>> list1 = new List<List<CEC>>()
            { new List<CEC>() { S6.Elements[0], S6.Elements[3],S6.Elements[6]},
            new List<CEC>(){S2.Elements[0], S2.Elements[1], S2.Elements[2]},
            new List<CEC>(){ S5.Elements[2], S5.Elements[5], S5.Elements[8]  },
            new List<CEC>(){S4.Elements[6], S4.Elements[7],S4.Elements[8]} };
            var f = new List<CEC>[list1.Count];
            list1.CopyTo(f);
            list1[0] = f[3];
            list1[1] = f[0];
            list1[2] = f[1];
            list1[3] = f[2];

            Rotate(S3, RotateWay.Left, 1);


            S6.Elements[0] = (list1[0])[0];
            S6.Elements[3] = (list1[0])[1];
            S6.Elements[6] = (list1[0])[2];

            S2.Elements[0] = (list1[1])[2];
            S2.Elements[1] = (list1[1])[1];
            S2.Elements[2] = (list1[1])[0];

            S5.Elements[2] = (list1[2])[0];
            S5.Elements[5] = (list1[2])[1];
            S5.Elements[8] = (list1[2])[2];

            S4.Elements[6] = (list1[3])[2];
            S4.Elements[7] = (list1[3])[1];
            S4.Elements[8] = (list1[3])[0];
        }
        void Rotate(Side sd, RotateWay rw, int repetitions)
        {
            for (Int32 i = 0; i < repetitions; i++)
            {

                if (rw == RotateWay.Left)
                {
                    var ar = sd.Elements.ToArray();
                    sd.Elements[0] = ar[2];
                    sd.Elements[1] = ar[5];
                    sd.Elements[2] = ar[8];
                    sd.Elements[3] = ar[1];
                    sd.Elements[5] = ar[7];
                    sd.Elements[6] = ar[0];
                    sd.Elements[7] = ar[3];
                    sd.Elements[8] = ar[6];
                }
                if (rw == RotateWay.Right)
                {
                    var ar = sd.Elements.ToArray();
                    sd.Elements[0] = ar[6];
                    sd.Elements[1] = ar[3];
                    sd.Elements[2] = ar[0];
                    sd.Elements[3] = ar[7];
                    sd.Elements[5] = ar[1];
                    sd.Elements[6] = ar[8];
                    sd.Elements[7] = ar[5];
                    sd.Elements[8] = ar[2];
                }
            }
            switch (sd.Center)
            {
                case CEC.Blue: S3 = sd;
                    break;
                case CEC.Green: S1 = sd;
                    break;
                case CEC.Orange: S6 = sd;
                    break;
                case CEC.Red: S5 = sd;
                    break;
                case CEC.White: S2 = sd;
                    break;
                case CEC.Yellow: S4 = sd;
                    break;
            }
        }
    }
    public class Side
    {
        public CEC Center { get; private set; }
        public List<CEC> Elements { get; set; } = new List<CEC>(9);
        public Side(CEC center)
        {
            Center = center;
            for (Int32 i = 0; i < 9; i++)
            {
                Elements.Add(center); // asign field/property field as a center
            }
        }
        
    }
}
