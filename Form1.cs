using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculadora_1.Clases;

namespace Calculadora_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Variables variables = new Variables();
            variables.datoCargado = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lbl_visor.Text = string.Empty;
            modificarElementos(this);
        }

        private static void modificarElementos(Form formulario, Enums.Accion operacion = Enums.Accion.Limpiar)
        {
            foreach (Control control in formulario.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    Label lbl_visor = (Label)formulario.Controls.Find("lbl_visor", false)[0];

                    if (control.Text == "C")
                    {
                        btn.Click += (sender, e) => { visor(btn.Text, lbl_visor, Enums.Accion.Limpiar); };
                    } 
                    else if(control.Text == "X" && control.Text == "+" && control.Text == "-" && control.Text == "÷")
                    {
                        Variables variables = new Variables();
                        if(variables.datoCargado == false)
                        {
                            btn.Click += (sender, e) => { visor(btn.Text, lbl_visor, Enums.Accion.Agregar); };
                            variables.datoCargado = true;
                        }
                        else
                        {
                            formulario.Controls.Find("erpDatoErroneo", false)[0].Show();
                        }
                       
                    }
                    else
                    {
                        btn.Click += (sender, e) => { visor(btn.Text, lbl_visor, Enums.Accion.Agregar); };
                    }
                    switch(control.Text)
                    {
                        case "C":
                            break;
                        case"":
                            btn.Height = 175;
                            break;

                    }
                    btn.BackColor = Color.FromArgb(69, 25 ,82);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(243, 159, 90);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(243, 159, 90);
                    
                }
                else if(control is Form)
                {
                    Form frm = (Form)control;
                    frm.BackColor = Color.FromArgb(25,0, 25);
                }
                else if(control is TextBox)
                {
                    TextBox txt = (TextBox)control;
                    txt.BackColor = Color.FromArgb(251, 228, 216);
                    txt.ForeColor = Color.Black;
                }
            }
        }

        public static void visor(String texto, Label visor, Enums.Accion accion)
        {
            switch(accion)
            {
                case Enums.Accion.Limpiar:
                    visor.Text = string.Empty;                    
                    break;
                case Enums.Accion.Agregar:
                    visor.Text += texto;
                    break;
                case Enums.Accion.Borrar:
                    
                    break;
            }
            
        }
    }
}
