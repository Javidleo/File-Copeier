using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFile
{
    public static class Helper
    {
        public static void ClearTextBoxes(Form form)
        {
            foreach (Control control in form.Controls)
            {

                if (control.GetType() == typeof(TextBox))
                {

                    control.Text = "";

                }

            }
        }
    }
}
