using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageCropper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Setting input and output directory ...");
            const string inputs = @"//Input Directory//";
            const string outputs = @"//Output Directory//";

            Console.WriteLine("Creating array of file names and list of Bitmap objects ...");
            string[] fileNames = Directory.GetFiles(inputs);
            List<Bitmap> inputFiles = new List<Bitmap>();

            Console.WriteLine("Looping through the files and converting them to bitmap objects ...");
            foreach (string f in fileNames)
            {
                Bitmap temp = new Bitmap(f);
                inputFiles.Add(temp);
            }

            Console.WriteLine("Creating a couter variable and the section to crop off ...");
            int n = 1;
            Rectangle cropSection = new Rectangle(new Point(0, 200), new Size(1440, 950));

            Console.WriteLine("Looping though each object and saving that object as a png file ...");
            foreach (Bitmap bmp in inputFiles)
            {
                Bitmap cropped = CropImage(bmp, cropSection);
                cropped.Save(outputs + n++ + ".png");
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }

        static public Bitmap CropImage(Bitmap input, Rectangle crop)
        {
            Bitmap temp = new Bitmap(crop.Width, crop.Height);
            Graphics g = Graphics.FromImage(temp);
            g.DrawImage(input, 0, 0, crop, GraphicsUnit.Pixel);
            return temp;
        }
    }
}
