﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace Gtu_E_Con
{
    public partial class About : Page
    {
        OracleConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            String conStr = "USER ID=lelo;Password=123;Data Source=localhost:1521/xe";
            con = new OracleConnection();
            con.ConnectionString = conStr;
            con.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            OracleCommand Query = con.CreateCommand();

            Query.CommandText = "select * from users";
            OracleDataReader Reader = Query.ExecuteReader();
            int rowcount = 0;

            while (Reader.Read())
            {
                ++rowcount;
            }


            Query.CommandText = "INSERT INTO USERS VALUES("
                + rowcount +
                ",'" + mailbox.Text
                + "','" + namebox.Text
                + "','" + bdbox.Text
                + "'," + pwbox.Text
                + ",'" + typelist.Text
                + "')";
            Query.ExecuteReader();

            if (typelist.Text == "regular"|| typelist.Text == "onstage")
            {
                Query.CommandText = "INSERT INTO PARTICIPATES VALUES(" + rowcount + "," + DropDownList1.Text + ",NULL)";
                Query.ExecuteReader();
            }

        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }

        protected void delbutton_Click(object sender, EventArgs e)
        {
            OracleCommand Query = con.CreateCommand();

            Query.CommandText = "DELETE FROM USERS WHERE MAIL='" + mailbox.Text + "' AND PASSWORD='" + pwbox.Text+"'";
            Query.ExecuteReader();

        }

        protected void typelist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}