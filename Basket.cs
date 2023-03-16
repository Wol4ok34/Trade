﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace New_work_1
{
    public partial class Basket : Form
    {

        static string connectionString = "Data Source=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=DESKTOP-KHHNR3V\\SQLEXPRESS;Initial Catalog=TradeExam;Data Source=DESKTOP-KHHNR3V\\SQLEXPRESS";
        static SqlConnection connection = new SqlConnection(connectionString);

        Dictionary<string, int> order = new Dictionary<string, int>();

        

        public int order_Cost()
        {
            int sum = 0;
            int quantity;
            int price;
            for(int i = 0; i<orderGrid.RowCount;i++)
            {
                price = Convert.ToInt32(orderGrid.Rows[i].Cells[2].Value);
                quantity = Convert.ToInt32(orderGrid.Rows[i].Cells[1].Value);
                sum += price * quantity;
            }
            return sum;
        }
        public Basket(Dictionary<string, int> ord)
        {
            InitializeComponent();
            order = ord;


        }

        List<product> orderList = new List<product>();
        public Basket(List<product> orb_list)
        {
            InitializeComponent();
            orderList = orb_list;
        }

        private void Basket_Load(object sender, EventArgs e)
        {   
            foreach (product record in orderList)
            orderGrid.Rows.Add(record.articule, record.price, record.quantity);

        }

        private void orderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                int NewVal = Convert.ToInt32(orderGrid.Rows[e.RowIndex].Cells[2].Value) + 1;
            orderGrid.Rows[e.RowIndex].Cells[2].Value = NewVal;
            label2.Text = order_Cost().ToString();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
