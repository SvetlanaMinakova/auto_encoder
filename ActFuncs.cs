using System;
using System.Collections.Generic;
using System.Text;

namespace MPL_testing
{
    class ActFuncs
    {
        // activation function. It «presses» its input and produces output for neuron
        //this kind of activation function is sigmoidal, but it can be different
        public static float f_act(float input)
        {//input for act func is [-inf;+inf] and our input is [0;1]
            float result= (float)(1 / (1 + Math.Pow(Math.E, (-1) * (input))));
            return result;
        }

        public static  float f_act_deriv(float input)
        {
            return f_act(input) * (1 - f_act(input));
        }

    }


}
