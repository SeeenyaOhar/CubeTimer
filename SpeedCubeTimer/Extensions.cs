using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerCode.Code;
using System.Windows.Media;
namespace SpeedCubeTimer
{
    internal static class CECExtension
    {
        internal static Brush ConvertToBrush(this CEC c)
        {
            switch (c)
            {
                case CEC.Blue: return Brushes.Blue;
                case CEC.Green: return Brushes.Green;
                case CEC.Orange: return Brushes.Orange;
                case CEC.Red: return Brushes.Red;
                case CEC.White: return Brushes.White;
                case CEC.Yellow: return Brushes.Yellow;
                default: return null;
            }
        }
    }


}
