using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void Fill()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("select * from emp", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "emp");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Fill();
            }
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in GridView1.Rows)
            {
                var chk = row.FindControl("CheckBox1") as CheckBox;
                if (chk.Checked)
                {
                    var lblid = row.FindControl("Label1") as Label;
                    Response.Write(lblid.Text + "<br>");
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
                    con.Open();
                    int id = Convert.ToInt32(lblid.Text);
                    SqlCommand cmd = new SqlCommand("delete from emp where eno='"+id+"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("emp is deleted");
                    Fill();
                }
            }
        }

        

        protected void CheckBox2_CheckedChanged1(object sender, EventArgs e)
        {
            if(CheckBox2.Checked==true)
            {
                foreach(GridViewRow row1 in GridView1.Rows)
                {
                    var chk1 = row1.FindControl("CheckBox1") as CheckBox;
                    bool allcheckbox = true;
                    chk1.Checked = allcheckbox;
                    if(chk1.Checked)
                    {
                        var lblid = row1.FindControl("Label1") as Label;
                        Response.Write(lblid.Text + "<br>");
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
                        con.Open();
                        int id = Convert.ToInt32(lblid.Text);
                        SqlCommand cmd = new SqlCommand("delete from emp where eno='" + id + "'", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("emp is deleted");
                        Fill();
                    }
                }
            }
        }
    }
}