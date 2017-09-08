using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MPL_testing
{
    class MatrixOperations
    {
        public static Random random_generator = new Random(DateTime.Now.Second);

        public static void set_matrix(float[,] _matrix, float[,] new_matrix, int w, int h)
        {
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    _matrix[i, j] = new_matrix[i, j];
                }
            }
        }

        public static void init_matrix_random(float[,] _matrix, int w, int h)
        {
            
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    _matrix[i, j] = (float)(random_generator.NextDouble() * 0.5 + 0.5);
                    if (random_generator.Next(1, 3) == 1)
                   _matrix[i, j] *=(-1);
                }
            }
        }



        public static void print_matrix(string name, float[,] matrix, int w, int h)
        {
            Console.WriteLine();
            Console.WriteLine(name);
            Console.WriteLine();
            for (int j = 0; j < h; j++)
            {
                Console.WriteLine();
                for (int i = 0; i < w; i++)
                {
                    Console.Write(Math.Round(matrix[i, j], 6) + " | ");
                }

            }

        }

        public static void print_vector(string name, float[] vector, int len)
        {
            Console.WriteLine();
            Console.WriteLine(name);
            Console.WriteLine();
            for (int i = 0; i < len; i++)
            {
                    Console.Write(Math.Round(vector[i], 6) + " | ");
            }
            save_vector_to_file(name, vector, len);
        }

        static void save_vector_to_file(string name, float[] vect, int len)
        {
            string appdataPath = Environment.CurrentDirectory;
            var dir = new DirectoryInfo(appdataPath).Parent.Parent.Parent;
            string curmappath = dir.FullName + Path.DirectorySeparatorChar + "temp.txt";
            var newmap = new FileInfo(curmappath);
            string line = name + "\r\n" + "  {";
            //заполнение 
            try
            {

                StreamWriter sw = new StreamWriter(curmappath, true, Encoding.UTF8);

                using (sw)
                {
                    sw.WriteLine(" { ");

                        for (int i = 0; i < len; ++i)
                        {
                            line += Math.Round(vect[i], 6).ToString().Replace(",", ".") + " , ";
                        }
                        sw.WriteLine(line);
                        line = "";
                    sw.WriteLine("};");
                }

                sw.Close();

                Console.WriteLine(" file saved!:)");

            }


            catch (Exception)
            {
                Console.WriteLine("Error of map creation:(");
            }

        }

        public  static float[,] MatrMult(float[,] m1, float[,] m2, int w1, int h1, int w2, int h2)
        {
            float[,] result = null;
            if (w1 == h2)
            {
                result = new float[w2, h1]; //rows number - from m0.1f; cols number from m2 
                for (int i = 0; i < w2; ++i)
                {
                    for (int j = 0; j < h1; ++j)
                    {
                        for (int k = 0; k < h2; ++k)
                        {
                            result[j, i] += m1[k, i] * m2[j, k]; //summ of mults
                        }
                    }
                }
            }

            return result;

        }




    }
}
