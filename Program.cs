using System;
using System.Collections.Generic;
using System.Text;

namespace MPL_testing
{
    class Program
    {
        
        static void Main(string[] args)
        {
            float[] inPut1 = new float[] 
            { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0,
             0, 0, 0, 1, 1, 1, 1, 0, 0, 0,
             0, 0, 1, 1, 1, 0, 1, 1, 0, 0,
             0, 1, 1, 1, 0, 0, 1, 1, 0, 0,
             0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
             0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
             0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
             0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
             0, 1, 1, 0, 0, 0, 1, 1, 0, 0,
             0, 1, 1, 0, 0, 0, 1, 1, 0, 0};
            //код целевого выхода
            float[] target1 = new float[] { 0, 0, 0, 0, 1 };
            //
            float[] inPut2 = new float[] { 
                0, 1, 1, 1, 1, 1, 0, 0, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 0,
                0, 1, 1, 1, 1, 1, 0, 0, 0, 0,
                0, 1, 1, 1, 1, 1, 0, 0, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 0,
                0, 1, 1, 0, 0, 1, 1, 0, 0, 0,
                0, 1, 1, 1, 1, 1, 1, 0, 0, 0,
            };

            float[] target2 = new float[] { 0, 0, 0, 1, 0 };
            //
            float[] inPut3 = new float[] { 
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0
            };
            float[] target3 = new float[] { 0, 0, 0, 1, 1 };
            //

            //
            float[] inPut4 = new float[] { 
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 1, 1, 0,
               0, 1, 1, 0, 0, 0, 0, 1, 1, 0,
               0, 1, 1, 0, 0, 0, 0, 1, 1, 0,
               0, 1, 1, 0, 0, 0, 0, 1, 1, 0,
               0, 1, 1, 0, 0, 0, 0, 1, 1, 0,
               0, 1, 1, 0, 0, 0, 0, 1, 1, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0

            };
            float[] target4 = new float[] { 0, 0, 1, 0, 0 };
            //


            //
            float[] inPut5 = new float[] { 
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0

            };
            float[] target5 = new float[] { 0, 0, 1, 0, 1 };
            //

            //
            float[] inPut6 = new float[] { 
               0, 0, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 1, 1, 1, 1, 1, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 1, 1, 0, 0, 0, 0, 0, 0, 0,
               0, 0, 1, 0, 0, 0, 0, 0, 0, 0

            };
            float[] target6 = new float[] { 0, 0, 1, 1, 0 };
            //


            float[,] inp1 = new float[10, 10];
            float[,] inp2 = new float[10, 10];
            float[,] inp3 = new float[10, 10];
            float[,] inp4 = new float[10, 10];
            float[,] inp5 = new float[10, 10];
            float[,] inp6 = new float[10, 10];

       /*     float[,] inp11 = new float[5, 5];
            float[,] inp12 = new float[5, 5];
            float[,] inp13 = new float[5, 5];
            float[,] inp14 = new float[5, 5];

            float[,] inp21 = new float[5, 5];
            float[,] inp22 = new float[5, 5];
            float[,] inp23 = new float[5, 5];
            float[,] inp24 = new float[5, 5];

            float[,] inp31 = new float[5, 5];
            float[,] inp32 = new float[5, 5];
            float[,] inp33 = new float[5, 5];
            float[,] inp34 = new float[5, 5];


            float[,] inp41 = new float[5, 5];
            float[,] inp42 = new float[5, 5];
            float[,] inp43 = new float[5, 5];
            float[,] inp44 = new float[5, 5];


            float[,] inp51 = new float[5, 5];
            float[,] inp52 = new float[5, 5];
            float[,] inp53 = new float[5, 5];
            float[,] inp54 = new float[5, 5];

            float[,] inp61 = new float[5, 5];
            float[,] inp62 = new float[5, 5];
            float[,] inp63 = new float[5, 5];
            float[,] inp64 = new float[5, 5];
            
 */ 
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                { 
                    inp1[i, j] = inPut1[i + 10 * j];
                    inp2[i, j] = inPut2[i + 10 * j];
                    inp3[i, j] = inPut3[i + 10 * j];
                    inp4[i, j] = inPut4[i + 10 * j];
                    inp5[i, j] = inPut5[i + 10 * j];
                    inp6[i, j] = inPut6[i + 10 * j]; 
                } 
            }

     /*       for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    inp11[i,j] = inp1[i, j];
                    inp21[i, j] = inp2[i, j];
                    inp31[i, j] = inp3[i, j];
                    inp41[i, j] = inp4[i, j];
                    inp51[i, j] = inp5[i, j];
                    inp61[i, j] = inp6[i, j];
                }
            }

            for (int j = 0; j < 5; j++)
            {
                for (int i = 5; i < 10; i++)
                {
                    inp12[i-5, j] = inp1[i, j];
                    inp22[i-5, j] = inp2[i, j];
                    inp32[i-5, j] = inp3[i, j];
                    inp42[i - 5, j] = inp4[i, j];
                    inp52[i - 5, j] = inp5[i, j];
                    inp62[i - 5, j] = inp6[i, j];
                }
            }

            for (int j = 5; j < 10; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    inp13[i, j-5] = inp1[i, j];
                    inp23[i, j-5] = inp2[i, j];
                    inp33[i, j-5] = inp3[i, j];
                    inp43[i, j - 5] = inp4[i, j];
                    inp53[i, j - 5] = inp5[i, j];
                    inp63[i, j - 5] = inp6[i, j];
                }
            }

            for (int j = 5; j < 10; j++)
            {
                for (int i = 5; i < 10; i++)
                {
                    inp14[i-5, j-5] = inp1[i, j];
                    inp24[i-5, j-5] = inp2[i, j];
                    inp34[i-5, j-5] = inp3[i, j];
                    inp44[i - 5, j - 5] = inp4[i, j];
                    inp54[i - 5, j - 5] = inp5[i, j];
                    inp64[i - 5, j - 5] = inp6[i, j];
                }
            }
*/



            List <LearningPair> all_lps = new List<LearningPair>();
            List<float[,]> l1 = new List<float[,]>();
            l1.Add(inp1);
       /*     l1.Add(inp12);
            l1.Add(inp13);
            l1.Add(inp14); */
            List<float[,]> l2 = new List<float[,]>();
            l2.Add(inp2);
        /*    l2.Add(inp22);
            l2.Add(inp23);
            l2.Add(inp24); */
            List<float[,]> l3 = new List<float[,]>();
            l3.Add(inp3);
        /*    l3.Add(inp32);
            l3.Add(inp33);
            l3.Add(inp34); */
            List<float[,]> l4 = new List<float[,]>();
            l4.Add(inp4);
         /*   l4.Add(inp42);
            l4.Add(inp43);
            l4.Add(inp44); */
            List<float[,]> l5 = new List<float[,]>();
            l5.Add(inp5);
         /*   l5.Add(inp52);
            l5.Add(inp53);
            l5.Add(inp54); */
            List<float[,]> l6 = new List<float[,]>();
            l6.Add(inp6);
         /*   l6.Add(inp62);
            l6.Add(inp63);
            l6.Add(inp64);
            */
          all_lps.Add(new LearningPair(5, 5, 5, l1, inPut1));
          all_lps.Add(new LearningPair(5, 5, 5, l2, inPut2));
          all_lps.Add(new LearningPair(5, 5, 5, l3, inPut3));

          all_lps.Add(new LearningPair(5, 5, 5, l4, inPut4));
          all_lps.Add(new LearningPair(5, 5, 5, l5, inPut5));
          all_lps.Add(new LearningPair(5, 5, 5, l6, inPut6)); 

          Network test_netw = new Network(1, 10, 10, 100, 50, 100);

            test_netw.Learn(all_lps, 0.001f, 5000);


              Console.WriteLine("\r\n Recognization result for A: " + test_netw.Recognize(l1));
              Console.WriteLine("\r\n Recognization result for B: " + test_netw.Recognize(l2));
              Console.WriteLine("\r\n Recognization result for C: " + test_netw.Recognize(l3));
              Console.WriteLine("\r\n Recognization result for D: " + test_netw.Recognize(l4));
              Console.WriteLine("\r\n Recognization result for E: " + test_netw.Recognize(l5));
              Console.WriteLine("\r\n Recognization result for F: " + test_netw.Recognize(l6));

              Console.WriteLine("\r\n Recognization result for F: " + test_netw.Recognize(l6));
              Console.WriteLine("\r\n Recognization result for A: " + test_netw.Recognize(l1));
              Console.WriteLine("\r\n Recognization result for C: " + test_netw.Recognize(l3));
              Console.WriteLine("\r\n Recognization result for B: " + test_netw.Recognize(l2));
              Console.WriteLine("\r\n Recognization result for D: " + test_netw.Recognize(l4));
              Console.WriteLine("\r\n Recognization result for E: " + test_netw.Recognize(l5));

            Console.ReadLine();


        }

    }
}
