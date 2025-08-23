using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics._00_Indexers
{

    public class IP
    {
        private int[] segments = new int[4];


        public int this[int index]
        {
            get
            {
                return segments[index];
            }

            set
            {
                segments[index] = value;
            }

        }

        public IP(string IpAdress)
        {
            string[] segs = IpAdress.Split('.'); 
            for (int i = 0; i < segs.Length; i++)
            {
                segments[i] = int.Parse(segs[i]);
            }
        }

        public IP(int segment1, int segment2, int segment3, int segment4)
        {
            segments[0] = segment1;
            segments[1] = segment2;
            segments[2] = segment3;
            segments[3] = segment4;
        }

        public string Address => string.Join(".", segments);

    }


    public class Suduko
    {

        private int[,] _matrix;


        public int this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= _matrix.GetLength(0))
                    return -1;

                if (col < 0 || col >= _matrix.GetLength(1))
                    return -1;

                return _matrix[row, col];
            }

            set
            {
                if (row < 0 || row >= _matrix.GetLength(0))
                    return;

                if (col < 0 || col >= _matrix.GetLength(1))
                    return;

                if (value < 1)
                    return;

                _matrix[row, col] = value;
            }
        }

        public Suduko(int[,] matrix)
        {
            _matrix = matrix;
        }


    }

    public class Indexers
    {
        /*An indexer in C# lets you treat an object like an array — you can access its elements using the [] (square brackets) syntax.*/



        public static void TestIndexers()
        {
            // ********* using int ***********

            //var ip = new IP(127, 10, 01, 0);

            //Console.WriteLine(ip.Address);
            //Console.WriteLine("First Index of obj : {0}", ip[0]); // indexer


            // ********* using string ***********


            //var ip = new IP("127.10.01.0");

            //Console.WriteLine(ip.Address);


            // ********** Multipe Dimensional Map *************


            int[,] inputs = new int[,]
            {
                {8, 3, 5, 4, 1, 6, 9, 2, 7},
                {2, 9, 6, 8, 5, 7, 4, 3, 1},
                {4, 1, 7, 2, 9, 3, 6, 5, 8},
                {5, 6, 9, 1, 3, 4, 7, 8, 2},
                {1, 2, 3, 6, 7, 8, 5, 4, 9},
                {7, 4, 8, 5, 2, 42, 1, 6, 3},
                {6, 5, 2, 7, 8, 1, 3, 9, 4},
                {9, 8, 1, 3, 4, 5, 2, 7, 6},
                {3, 7, 4, 9, 6, 2, 8, 1, 5}
            };


            var suduko = new Suduko(inputs);

            Console.WriteLine(suduko[5, 5]);

            suduko[5, 5] = 1337;

            Console.WriteLine(suduko[5, 5]);
        }

    }
}
