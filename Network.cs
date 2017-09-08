using System;
using System.Collections.Generic;
using System.Text;

namespace MPL_testing
{
    class Network
    {
        int iterations_number =0;
        int result_vector_lenght;
        string last_output = "";
        string last_error = "";
      
        MPL_Layer mpl_first;
        MPL_Layer mpl_second;
        OutPutLayer output;

        //input is a picture's matrix
        public Network(int inputs_count,int input_w, int input_h,int mpl1_neurons_number,int mpl2_neurons_number, int result_vector_lenght)
        {
            mpl_first = new MPL_Layer(inputs_count, input_w, input_h, mpl1_neurons_number, mpl2_neurons_number);
            mpl_second = new MPL_Layer(mpl_first, mpl2_neurons_number, result_vector_lenght);
            output = new OutPutLayer(mpl_second, result_vector_lenght);
            this.result_vector_lenght = result_vector_lenght;
        }

        public string Recognize(List<float[,]> inputs)
        {
            string result ="";
            connect_inputs(inputs);
        //    connect_input(input);
            send_signal_front();
            for (int i = 0; i < result_vector_lenght; i++)
            {
                result  += Math.Round(output.output[i],1).ToString() + " | ";
            }
          
         /*   MatrixOperations.print_vector("mpl hidden input: ", mpl.full_input, mpl.full_inputs_number);
            MatrixOperations.print_vector("mpl hidden output: ", mpl.output, mpl.outputs_number);
            MatrixOperations.print_vector("outp_layer input: ", output.input, mpl.outputs_number);
          */ 
            MatrixOperations.print_vector("outp_layer output: ", output.output, result_vector_lenght);
           
          
            return result;
        }

        public void Learn(List<LearningPair> learning_pairs, float precision, float safe_counter)
        {
            iterations_number = 0;
            float prec = 0.1f;
            string err = "";
            string outp = "";
            string expected = "";

       

            while (iterations_number < safe_counter && prec > precision)
            {

                for (int lp = 0; lp < learning_pairs.Count; lp++)
                {

          //          MatrixOperations.print_matrix("current input: " + lp.ToString(), FirstLayer.feature_maps[0].inputs[0], 16, 16);
                    connect_inputs(learning_pairs[lp].inputs);
         
                    iterations_number++;
                    send_signal_front();
                
                /*    MatrixOperations.print_vector("outp_layer input: ", output.input, mpl.outputs_number);
                    MatrixOperations.print_vector("outp_layer output: ", output.output, result_vector_lenght);
                 */
                    
                    send_signal_back(learning_pairs[lp].expected_output);
                    correct_weights();
                  
                /*    err = "";
                    expected = "";
                    outp = "";

                    for (int i = 0; i < result_vector_lenght; i++)
                    {
                        err += output.error[i].ToString() + " | ";
                        outp += output.output[i].ToString() + " | ";
                        expected += learning_pairs[lp].expected_output[i].ToString() + " | ";

                    }
                    Console.WriteLine("\r\n + output: " + outp + "\r\n + expected: " + expected + "\r\n error: " + err+ "\r\n");
                  */
                    prec = Math.Abs(learning_pairs[lp].expected_output[0] - output.output[0]);
                    for (int i = 1; i < result_vector_lenght; i++)
                    {
                        float currprec = Math.Abs(learning_pairs[lp].expected_output[i] - output.output[i]);
                        if (currprec > prec)
                            prec = currprec;
                    }
                }
            }

            for (int i = 0; i < result_vector_lenght; i++)
            {
                last_error += Math.Round(output.error[i], 6).ToString() + " | ";
                last_output += Math.Round(output.output[i], 6).ToString() + " | ";
            }

            Console.WriteLine();
            Console.WriteLine("\r\n output: " + last_output + "\r\n" + "\r\n error: " + last_error +
                "\r\n precision: " + prec.ToString() + "\r\n total iterations number: " + iterations_number.ToString() + "\r\n");

        }

        public void connect_inputs(List<float[,]> inputs)
        {         
            //connect input with first layer
            mpl_first.inputs.Clear();
            for (int i = 0; i < inputs.Count; i++)
                mpl_first.inputs.Add(inputs[i]);
        }

        public void send_signal_front()
        {
            mpl_first.get_outputs_from_maps();
            mpl_second.get_outputs_from_mpl();
            output.get_output();
        }

        public void send_signal_back(float[] expected_output)
        {
            output.getError(expected_output);
       //     MatrixOperations.print_vector("output error ", output.error, result_vector_lenght);   
            mpl_second.getError(output.error, output.weights);
        //    MatrixOperations.print_vector("mpl hidden error ", mpl.errors, mpl.outputs_number);
            mpl_first.getError(mpl_second.errors, mpl_second.weights);
            mpl_first.pack_error_for_subs();
              
        }

        public void correct_weights()
        {
           // FirstLayer.correct_weights();
           // ThirdLayer.correct_weights();
            mpl_first.correct_weights();
            mpl_second.correct_weights();
            output.correct_weights();
        }

      
    }
}
