using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estágio_segunda
{

    public partial class FormPrincipal : Form
    {
        List<string> colaboradores = new List<string>();
        List<string> convidados = new List<string>();
        public FormPrincipal()
        {
            InitializeComponent();

            lbColaboradores.DataSource = colaboradores; //Carrega lista de nomes Colaboradores 
            lbConvidados.DataSource = convidados;

            checkBox2.Checked = true; //Já inicia com o checkBox do convidado marcado
            checkBox5.Checked = true; //Já inicia com o checkBox da bebida do colaborado habilitado
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) //Checa o campo dos convidados
            {
                if (tbConvidado.Text == "" || !checkBox3.Checked && !checkBox4.Checked)
                {
                    MessageBox.Show("Preencha os campos.");
                    tbColaborador.Focus();
                    return;
                }
            }
            if (tbColaborador.Text == "" && !! checkBox5.Checked || !! checkBox6.Checked) //Checa os campos do colaborador
            {
                MessageBox.Show("Preencha os campos.");
                tbColaborador.Focus();
                return;
            }
            //Coloca os participantes nas listas
        
                

             colaboradores.Add(tbColaborador.Text);
             tbColaborador.Clear();
                
             lbColaboradores.DataSource = null;
             lbColaboradores.DataSource = colaboradores;

             convidados.Add(tbConvidado.Text);
             tbConvidado.Clear();
                
             lbConvidados.DataSource = null;
             lbConvidados.DataSource = convidados;    
            
        }
        private void btnRemover_Click(object sender, EventArgs e) //remove participantes
        {
            if (colaboradores.Count < 1)
            {
                MessageBox.Show("Não há nada para remover da lista.");
                tbColaborador.Focus();
                return;
            }

            colaboradores.RemoveAt(lbColaboradores.SelectedIndex);
            lbColaboradores.DataSource = null;
            lbColaboradores.DataSource = colaboradores;

            convidados.RemoveAt(lbConvidados.SelectedIndex);
            lbConvidados.DataSource = null;
            lbConvidados.DataSource = convidados;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) //Função para bloquear a área de convidado se não tiver um convidado
        {
            if (checkBox2.Checked)
            {
                tbConvidado.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox1.Checked = false;
                tbConvidado.Clear();
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //Libera a área de convidados
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                tbConvidado.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox3.Checked = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) //Código para CheckBox3 e 4, 5 e 6, não estarem marcados ao mesmo tempo 
        {
            if (checkBox3.Checked)
            {
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox6.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox5.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e) //total de gastos com comida
        {

            int comidaSoma = 10;

            if (checkBox1.Checked)
            {
                comidaSoma = 10 + 10;
            }
            comidaSoma = comidaSoma * colaboradores.Count;
            
            MessageBox.Show("O gasto com comida foi " + comidaSoma + "$.");
            tbColaborador.Focus();
        }

        private void button2_Click(object sender, EventArgs e) //total de gastos com bebida
        {
            int bebidaSoma = 0;

            if (checkBox5.Checked)
            {
                bebidaSoma = bebidaSoma + 10;
            }
            if (checkBox1.Checked)
            {
                if(checkBox3.Checked)
                {
                    bebidaSoma = bebidaSoma + 10;
                }
            }
            bebidaSoma = bebidaSoma * colaboradores.Count;

            MessageBox.Show("O gasto com bebida foi " + bebidaSoma + "$.");
            tbColaborador.Focus();
        }

        private void button3_Click(object sender, EventArgs e) //total gasto
        {
            int bebidaSoma = 0;

            if (checkBox5.Checked)
            {
                bebidaSoma = bebidaSoma + 10;
            }
            if (checkBox1.Checked)
            {
                if (checkBox3.Checked)
                {
                    bebidaSoma = bebidaSoma + 10;
                }
            }
            bebidaSoma = bebidaSoma * colaboradores.Count;

            int comidaSoma = 10;

            if (checkBox1.Checked)
            {
                comidaSoma = 10 + 10;
            }
            comidaSoma = comidaSoma * colaboradores.Count;

            int totalgasto = comidaSoma + bebidaSoma;

            MessageBox.Show("O valor total foi " + totalgasto + "$.");
            tbColaborador.Focus();
        }
    }
}
