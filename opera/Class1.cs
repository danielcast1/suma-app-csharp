using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opera
{
    public class Operacion
    {
        #region atributos
        private List<float> notes;
        private float sum;
        private string error;
        #endregion

        #region propiedades

        public List<float> setNotas { set { notes = value; } }

        public float getSum { get { return sum; } }
        public string getError { get { return error; } }




        #endregion

        #region metodos privados 

        private bool checkIValidNumber(float nota)
        {
            if (nota > 0.0 && nota <= 5) return true;
            return false;
        }


        private bool validar()
        {
            bool opt = true;

            foreach (var note in notes)
            {
                if (!checkIValidNumber(note) && opt)
                {
                    error = "as ingresado valores incorrectos : " + note.ToString();
                    opt = false;
                }

            }
            return opt;

        }
        #endregion

        #region metodos publicos
        public Operacion()
        {
            notes = new List<float>();
            sum = 0;
            error = "";
        }
        public bool calcular()
        {
            float sumNote = 0;
            if (!validar())
                return false;

            foreach (float note in notes)
            {
                sumNote += note;
            }

            sum = sumNote / notes.Count;
            return true;
        }
        #endregion
    }
}
