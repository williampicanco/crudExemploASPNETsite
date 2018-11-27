using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //** SELECT ** //
    protected void Button1_Click(object sender, EventArgs e)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        conection.Open();
        NpgsqlCommand comand = new NpgsqlCommand("SELECT * FROM public.crudtb", conection);
        NpgsqlDataAdapter ad = new NpgsqlDataAdapter(comand);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        grid1.DataSource = dt;
        grid1.DataBind();
        conection.Close();
    }

    //** INSERT **//
    protected void Button2_Click(object sender, EventArgs e)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        conection.Open();
        NpgsqlCommand comand = new NpgsqlCommand("INSERT INTO public.crudtb(objeto, descricao) VALUES ('" + txtObjeto.Text + "','" + txtDescricao.Text + "')", conection);
        comand.ExecuteNonQuery();
        conection.Close();
    }

    //** UPDATE **//
    protected void Button3_Click(object sender, EventArgs e)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        conection.Open();
        NpgsqlCommand comand = new NpgsqlCommand("UPDATE public.crudtb SET descricao='" + txtDescricao.Text + "' WHERE objeto='" + txtObjeto.Text + "'",  conection);
        comand.ExecuteNonQuery();
        conection.Close();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["postgres"].ConnectionString);
        conection.Open();
        NpgsqlCommand comand = new NpgsqlCommand("DELETE FROM public.crudtb WHERE objeto='" + txtObjeto.Text + "'", conection);
        comand.ExecuteNonQuery();
        conection.Close();
    }
}
