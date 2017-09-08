using System;
using System.Collections.Generic;
using System.Text;

namespace MPL_testing
{
   public class LearningPair
    {
        public int input_w;
        public int input_h;
        public int output_lenght;
        public List<float[,]> inputs;
        public float[] expected_output;

        public LearningPair(int inp_w, int inp_h, int outp_l, List<float[,]> inps, float[] expected_outp)
        {
            this.input_w = inp_w;
            this.input_h = inp_h;
            this.output_lenght = outp_l;
            this.inputs = inps;
            this.expected_output = expected_outp;
        }
    }
}
