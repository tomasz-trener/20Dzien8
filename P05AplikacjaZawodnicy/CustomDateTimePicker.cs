using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P01AplikacjaZawodnicy
{
    public partial class CustomDateTimePicker : UserControl
    {
        public DateTime? Value
        { 
            get
            {
                if(dtpData.Visible)
                {
                    return dtpData.Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == null) 
                { 
                    txtData.Visible = true;
                    dtpData.Visible = false;
                }
                else
                {
                    txtData.Visible = false;
                    dtpData.Visible = true;
                    dtpData.Value = (DateTime)value;
                }
            }
        }
        public CustomDateTimePicker()
        {
            InitializeComponent();
        }

        private void dtpData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Value = null;
            }
        }

        private void txtData_Click(object sender, EventArgs e)
        {
            Value = DateTime.Now;
        }
    }
}
