using System;
using System.Collections.Generic;

using System.Windows.Forms;
using opera;
namespace APPopera
{
    public partial class Form1 : Form
    {
        private List<float> _notes = new List<float>();
        private bool [] valid= new bool[4];
        public Form1()
        {
            InitializeComponent();
            btncalcular.Enabled = false;
            
        }
        

        private void addNote(float note)
        {
            _notes.Add(note);
        }

        private void Btncalcular_Click(object sender, EventArgs e)
        {
            handleCalc();
        }

        private void Txt1_TextChanged(object sender, EventArgs e)
        {
            valid[0] = validInput(txt1.Text);
            handleCalcAu(validFields());
          
        }
        
        private bool validFields()
        {
            bool temp = true;
            foreach (bool n in valid)
            {
                if (!n)
                {
                    temp= false;

                }
            }
            btncalcular.Enabled = temp;
            return temp;
        }

        private bool validInput(string val)
        {
            float n = 0;

            var value = float.TryParse(val,out n);
            if (value)
            {
                if (n < 0||n>5)
                {
                    txtError.Text = "Los numeros deben ser mayores de 0 y menores que 5.0";
                    return false;
                }
                txtError.Text = "";
                return true;
            }
            txtError.Text = "No se puede ingresar Texto";
            return false;
        }

        private void Txt2_TextChanged(object sender, EventArgs e)
        {
            
                valid[1] = validInput(txt2.Text);
            handleCalcAu(validFields());

        }



        private void Txt3_TextChanged(object sender, EventArgs e)
        {
            valid[2] = validInput(txt3.Text);
            handleCalcAu(validFields());
        }

        private void Txt4_TextChanged(object sender, EventArgs e)
        {
            valid[3] = validInput(txt4.Text);
            handleCalcAu(validFields());
        }
        private void handleCalc()
        {
            //instanciar la logica de negocio 
            Operacion objO = new Operacion();

            try
            {


                _notes.Clear();

                addNote(float.Parse(txt1.Text));
                addNote(float.Parse(txt2.Text));
                addNote(float.Parse(txt3.Text));
                addNote(float.Parse(txt4.Text));

                

                objO.setNotas = _notes;

                if (objO.calcular())
                {
                    txrsuma.Text = objO.getSum.ToString();
                    return;
                }
                MessageBox.Show(objO.getError);
                _notes.Clear();
                objO = null;
            }
            catch (Exception _)
            {
                txrsuma.Text = "No puede ser Texto";
            }
        }

        private void handleCalcAu(bool isValid)
        {
            if (isValid)
            {
                handleCalc();
            }
            else
            {
                txrsuma.Text = null;
            }
        }
    }
}

