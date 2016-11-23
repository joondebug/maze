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

            int height = bitMap.Height;
            int width = bitMap.Width;

            int[] start = new int[2];
            int[] end = new int[2];

            //for (int x = 0; x < width; x++)
            //{
            //    for (int y = 0; y < height; y++)
            //    {
            //        if (bitMap.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
            //        {
            //            bitMap.SetPixel(x, y, Color.Green);
            //        }
            //    }
            //}


            // Find a red pixel that indicates the start of the maze 
            bool foundStart = false;

            for (int x = 0; (x < width) && (!foundStart); x++)
            {
                for (int y = 0; (y < height) && (!foundStart); y++)
                {
                    if (bitMap.GetPixel(x, y).ToArgb() == Color.Red.ToArgb())
                    {
                        //bitMap.SetPixel(x, y, Color.Green);
                        start[0] = x;
                        start[1] = y;
                        foundStart = true;
                    }
                }
            }


            // Find a blue pixel that indicates the end of the maze
            bool foundEnd = false;

            for (int x = 0; (x < width) && (!foundEnd); x++)
            {
                for (int y = 0; (y < height) && (!foundEnd); y++)
                {
                    if (bitMap.GetPixel(x, y).ToArgb() == Color.Blue.ToArgb())
                    {
                        //bitMap.SetPixel(x, y, Color.Green);
                        end[0] = x;
                        end[1] = y;
                        foundEnd = true;
                    }
                }
            }



            bitMap.Save("C:/Users/kevinl/Documents/_projects/BlueBeam/Output/maze1.png");

        }
    }
}
