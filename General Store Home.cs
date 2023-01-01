using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using General_Store;

namespace General_Store
{
    public partial class Form1 : Form
    {
        Products product = new Products();
        public Form1()
        {
            InitializeComponent();
            product.GetDetails();
            label3.Visible = false;
            textBox1.Visible = false;
            button8.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            button6.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            label3.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "";
            label4.Visible = false;
            button7.Visible = false;
            dataGridView1.DataSource = null;
            ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
            var dt = listtoDataTableConverter.ToDataTable(product.Fruits);
            dataGridView1.DataSource = dt;
            var i = dataGridView1.SelectedRows;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            label3.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "";
            label4.Visible = false;
            button7.Visible = false;
            dataGridView1.DataSource = null;
            ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
            var dt = listtoDataTableConverter.ToDataTable(product.Vegetables);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            label3.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "";
            label4.Visible = false;
            button7.Visible = false;
            dataGridView1.DataSource = null;
            ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
            var dt = listtoDataTableConverter.ToDataTable(product.Cosmetics);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            label3.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "";
            label4.Visible = false;
            button7.Visible = false;
            dataGridView1.DataSource = null;
            ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
            var dt = listtoDataTableConverter.ToDataTable(product.Toys);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            label3.Visible = true;
            textBox1.Visible = true;
            textBox1.Text = "";
            label4.Visible = false;
            button7.Visible = false;
            dataGridView1.DataSource = null;
            ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
            var dt = listtoDataTableConverter.ToDataTable(product.Gadgets);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "";
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["SrNo"].Value);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var total = 0;
            product.Cart.ForEach(it => {
                total = total + it.Price;
            });

            label4.Text = "";
            if (product.Cart.Count > 0)
            {
                label4.Text = "Your Grand Total = " + total + " Rs" + " Thank You For Shopping With Us.";
                label4.Visible = true;
            }
            else {
                label4.Text = "You Have Not Selected Any Item , Please Choose Any Item To Proceed.";
                label4.Visible = true;
            }

            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                //label4.Visible = true;
                dataGridView2.Show();
                var q = "";
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int srNo = Convert.ToInt32(selectedRow.Cells["SrNo"].Value);
                string name = Convert.ToString(selectedRow.Cells["Name"].Value);
                int price = Convert.ToInt32(selectedRow.Cells["Price"].Value);
                string quantity = Convert.ToString(selectedRow.Cells["Quantity"].Value);
                var selectedValue = Convert.ToInt32(textBox1.Text);
                if (quantity.ToLower().Contains("kg"))
                {
                    q = "Kg";
                }
                else
                {
                    q = "Unit";
                }

                var alreadyPresent = product.Cart.FirstOrDefault(it => it.ProductName == name && it.Price == selectedValue * Convert.ToInt32(price) && it.Quantity == selectedValue + ' ' + q);

                if (alreadyPresent == null)
                {
                    product.Cart.Add(new CartSpecification
                    {
                        SrNo = product.Cart.Count + 1,
                        ProductName = name,
                        Price = selectedValue * Convert.ToInt32(price),
                        Quantity = Convert.ToString(selectedValue) + ' ' + q
                    });
                }

                dataGridView2.DataSource = null;
                ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
                var dt = listtoDataTableConverter.ToDataTable(product.Cart);
                dataGridView2.DataSource = dt;
                button8.Show();
                button6.Show();

                //label4.Text = "Your Total   " + selectedValue * Convert.ToInt32(cellValue);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button7.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                int cellValue = Convert.ToInt32(selectedRow.Cells["SrNo"].Value);
                product.Cart.Remove(product.Cart.FirstOrDefault(it => it.SrNo == cellValue));
                var count = 0;
                product.Cart.ForEach(it =>
                {
                    it.SrNo = count + 1;
                    count++;
                });
                dataGridView2.DataSource = null;
                ListtoDataTableConverter listtoDataTableConverter = new ListtoDataTableConverter();
                var dt = listtoDataTableConverter.ToDataTable(product.Cart);
                dataGridView2.DataSource = dt;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
