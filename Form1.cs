using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFiveElements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            BaseParqueaderoEntities contexto = new BaseParqueaderoEntities();
            grid.DataSource = contexto.ClientesParqueadero.ToList();
        }
        private void llenar()
        {
            this.textCliente.Text = grid.SelectedRows[0].Cells[0].Value.ToString();
            this.textNombre.Text = grid.SelectedRows[0].Cells[1].Value.ToString();
            this.textTelefono.Text = grid.SelectedRows[0].Cells[2].Value.ToString();
            this.textDireccion.Text = grid.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.textCliente.Text);
            string Nombre = textNombre.Text;
            string telefono = textTelefono.Text;
            string Direccion = textDireccion.Text;

            using (BaseParqueaderoEntities contexto = new BaseParqueaderoEntities())
            {
                ClientesParqueadero c = new ClientesParqueadero
                {
                    idCliente = id,
                    Nombre = Nombre,
                    Teléfono = telefono,
                    Dirección = Direccion
                };
                contexto.ClientesParqueadero.Add(c);
                contexto.SaveChanges();
                cargar();
            }
        }

        private void grid_Click(object sender, EventArgs e)
        {
            llenar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(this.textCliente.Text);
            string Nombre = textNombre.Text;
            string telefono = textTelefono.Text;
            string direccion = textDireccion.Text;

            using (BaseParqueaderoEntities contexto = new BaseParqueaderoEntities())
            {
                ClientesParqueadero c = contexto.ClientesParqueadero.FirstOrDefault(x => x.idCliente == id);
                c.Nombre = Nombre;
                c.Teléfono = telefono;
                c.Dirección = direccion;
                contexto.SaveChanges();
                cargar();
                
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(this.textCliente.Text);
            using (BaseParqueaderoEntities contexto = new BaseParqueaderoEntities())
            {
                ClientesParqueadero c = contexto.ClientesParqueadero.FirstOrDefault(x => x.idCliente == id);
                contexto.ClientesParqueadero.Remove(c);
                contexto.SaveChanges();
                cargar();

            }
        }
    }
}
