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
        static Bitmap bitMap = new Bitmap("maze1.png");

        static void Main(string[] args)
        {
            Color pixelColor = bitMap.GetPixel(0, 1);

            int height = bitMap.Height;
            int width = bitMap.Width;
            int[] startCoordinates = findStartPoint(height, width, bitMap);
            int[] endCoordinates = findEndPoint(height, width, bitMap);
            int startX = startCoordinates[0];
            int startY = startCoordinates[1];

            exploreMaze(startX, startY);

            bitMap.Save(@"C:\Users\kevinl\Documents\_projects\BlueBeamMaze\BlueBeamMaze\bin\Debug\output\output.png");

        }


        //Implement a recursive function to continue drawing if it detects white space without black
        public static void exploreMaze(int x, int y)
        {

            //Console.WriteLine("x: " + x + " y: " + y);
            
            markPath(x, y);

            if (bitMap.GetPixel(x + 1, y).ToArgb() != Color.Black.ToArgb() && bitMap.GetPixel(x + 1, y).ToArgb() != Color.MediumTurquoise.ToArgb())
                exploreMaze(x + 1, y);

            if (bitMap.GetPixel(x - 1, y).ToArgb() != Color.Black.ToArgb() && bitMap.GetPixel(x - 1, y).ToArgb() != Color.MediumTurquoise.ToArgb())
                exploreMaze(x - 1, y);

            if (bitMap.GetPixel(x, y + 1).ToArgb() != Color.Black.ToArgb() && bitMap.GetPixel(x, y + 1).ToArgb() != Color.MediumTurquoise.ToArgb())
                exploreMaze(x, y + 1);

            if (bitMap.GetPixel(x, y - 1).ToArgb() != Color.Black.ToArgb() && bitMap.GetPixel(x, y - 1).ToArgb() != Color.MediumTurquoise.ToArgb())
                exploreMaze(x, y - 1);
                      
            
            //while (true) { }

        }

        public static void markPath(int x, int y)
        {
                bitMap.SetPixel(x, y, Color.MediumTurquoise);
        }

        public static int[] findStartPoint(int height, int width, Bitmap bitMap)
        {
            // Find a red pixel that indicates the start of the maze 
            bool foundStart = false;
            int[] start = new int[2];

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

            return start;
        }

        public static int[] findEndPoint(int height, int width, Bitmap bitMap)
        {
            // Find a blue pixel that indicates the end of the maze
            bool foundEnd = false;
            int[] end = new int[2];

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

            return end;
        }




    }
}
