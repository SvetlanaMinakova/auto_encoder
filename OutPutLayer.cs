using System;
using System.Collections.Generic;
using System.Text;

namespace MPL_testing
{
    class OutPutLayer
    {
        public float[] input;
        public float[,] weights;
        float[] non_activated_stages;
        public float[]output;
        public float[] error;
        int inputs_number;
        int outputs_number;
        float learning_speed = 0.7f;


        public OutPutLayer(MPL_Layer mpl,int outp_number)
        {
            this.input = mpl.output;
            this.inputs_number = mpl.outputs_number;
            this.outputs_number = outp_number;
            this.weights = new float[inputs_number, outputs_number];
            MatrixOperations.init_matrix_random(weights, inputs_number, outputs_number);
            non_activated_stages = new float[outputs_number];
            error = new float[outputs_number];
            output=new float[outputs_number];

        }

        //full-connected layer
        public void get_output()
        {
            for (int j = 0; j < outputs_number; j++)
            {//clear
                non_activated_stages[j] = 0;
                //get new value
                for (int i = 0; i < inputs_number; i++)
                {
                    non_activated_stages[j] += input[i] * weights[i, j];
                }
                output[j] = ActFuncs.f_act(non_activated_stages[j]);
            }

        }

        #region Learning
        public void getError(float[] expected_output)
        {
            for (int i = 0; i < error.Length; i++)
            {
                error[i] = (expected_output[i]-output[i]) * ActFuncs.f_act_deriv(non_activated_stages[i]);
            }
        }

        public void correct_weights()
        {  for (int j = 0; j < outputs_number; j++)
                {
                    for (int i = 0; i < inputs_number; i++)
                    {
                        weights[i, j] += error[j]*input[i]*learning_speed;
                    }
                }
        }

        
        #endregion

    }
}