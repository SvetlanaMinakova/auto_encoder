using System;
using System.Collections.Generic;
using System.Text;

namespace MPL_testing
{
    public class MPL_Layer
    {
        public int full_inputs_number;
        public int outputs_number;
        float[] bj_prev;
        public List<float[,]> inputs;
        public float[] full_input;
        public float[,] weights;
        public float[] errors;
        public float[] output;
        public float[] non_activated_stages;
        public List<float[,]> packed_errors_for_prev_subs;
        int input_w;
        int input_h;
        int next_layer_outputs_number;
        float learning_speed = 0.5f;

        #region Creation

        public MPL_Layer(int inps_number,int inp_w,int inp_h, int neurons_number,int next_layer_neurons_number)
        {
            this.input_w = inp_w;
            this.input_h = inp_h;
            //total number of previous layer's neurons
            this.full_inputs_number = inps_number * inp_w * inp_h;
            //full-connected layer
            this.full_input = new float[full_inputs_number];

            this.inputs = new List<float[,]>();
            this.packed_errors_for_prev_subs = new List<float[,]>();
            for (int i = 0; i < inps_number; i++)
            {
                packed_errors_for_prev_subs.Add(new float[inp_w, inp_h]);
            }

            this.outputs_number = neurons_number;
        //    this.bj_prev = prev_subsampling.bj;
            this.next_layer_outputs_number=next_layer_neurons_number;
            this.output = new float[outputs_number];
            this.non_activated_stages = new float[outputs_number];
            this.errors = new float[outputs_number];
            this.weights = new float[full_inputs_number, outputs_number];
            //
            MatrixOperations.init_matrix_random(weights, full_inputs_number, outputs_number);
        }

        public MPL_Layer(MPL_Layer prev_mpl,int neurons_number,int next_layer_neurons_number)
        {
           
            //total number of previous layer's neurons
            this.full_inputs_number = prev_mpl.outputs_number;
            //full-connected layer
            this.full_input = prev_mpl.output;
            this.outputs_number = neurons_number;
            //    this.bj_prev = prev_subsampling.bj;
            this.next_layer_outputs_number = next_layer_neurons_number;
            this.output = new float[outputs_number];
            this.non_activated_stages = new float[outputs_number];
            this.errors = new float[outputs_number];
            this.weights = new float[full_inputs_number, outputs_number];
            //
            MatrixOperations.init_matrix_random(weights, full_inputs_number, outputs_number);
        }
            
        //full-connected layer
        public void repack_outputs()
        {
            int inp_id = 0;
            for (int k = 0; k < inputs.Count; k++)
            {
                for (int j = 0; j < input_h; j++)
                {
                    for (int i = 0; i < input_w; i++)
                    {
                        full_input[inp_id] = inputs[k][i, j];
                        inp_id++;
                    }
                }
            }
        }


        public void get_outputs()
        {
          
            for (int j = 0; j < outputs_number; j++)
            {//clear
                non_activated_stages[j] = 0;
                for (int i = 0; i < full_inputs_number; i++)
                {
                    non_activated_stages[j] += full_input[i] * weights[i, j];
                }
                output[j] = ActFuncs.f_act(non_activated_stages[j]);
                }
        }

        public void get_outputs_from_maps()
        {
            repack_outputs();
            get_outputs();
        }

        public void get_outputs_from_mpl()
        {
            get_outputs();
        }

        #endregion

        #region Learning
        public void getError(float[] sigma_next_layer, float[,] weights_next_layer)
        {//W transp*sigma_next_layer*f_derived(ul)

            float part_summ_error;
            for (int p = 0; p < outputs_number; p++)
            {
                part_summ_error = 0;
                for (int q = 0; q < next_layer_outputs_number; q++)
                {
                    part_summ_error += sigma_next_layer[q] * weights_next_layer[p, q];
                }
                errors[p] = part_summ_error * ActFuncs.f_act_deriv(non_activated_stages[p]);
            }

        }

        public void pack_error_for_subs()
        {

            int id = 0;
            //count and pack errors for previous subsampling layer's maps
            for (int psn = 0; psn < packed_errors_for_prev_subs.Count; psn++)
            {
                for (int j = 0; j < input_h; j++)
                {
                    for (int i = 0; i < input_w; i++)
                    {
                        packed_errors_for_prev_subs[psn][i, j] = 0;
                        for (int u = 0; u < outputs_number; u++)
                        {
                            packed_errors_for_prev_subs[psn][i, j] += errors[u] * weights[id, u];
                        }
                        id++;
                    }
                }
            }
        }


        public void correct_weights()
        {
                for (int j = 0; j < outputs_number; j++)
                {
                    for (int i = 0; i < full_inputs_number; i++)
                    {
                        weights[i, j] += errors[j] * full_input[i]*learning_speed;
                    }
                }
        }
        #endregion
    }
     
}

