using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BlueBeamMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bitMap = new Bitmap("maze1.png");
            Color pixelColor = bitMap.GetPixel(0, 1);

            bitMap.SetPixel(0, 1, Color.White);

            bitMap.Save("C:/Users/kevinl/Documents/_projects/BlueBeam/Output/maze1.png");

        }
    }
}
