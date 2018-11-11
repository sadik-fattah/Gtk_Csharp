using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mono.Data.Sqlite;
using System.Data;
using System.Text;

namespace pc_game
{

    public partial class Default : System.Web.UI.Page
    {
        SqliteDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmltable = new StringBuilder();
        SqliteConnection con = new SqliteConnection();
        SqliteCommand cmd = new SqliteCommand();
        protected void Page_PreRender(object sender,EventArgs args)
        {
            con.ConnectionString = @"Data Source=App_Data/test.db";
            lb_id.Text = "Game ID";
            lb_name.Text = "Game NAME";
            lb_image.Text = "Game IMAGE";
            lb_link.Text = "Game LINK";
            lb_type.Text = "Game TYPE";
            if (!Page.IsPostBack)
            {
                Load_data();
            }
        }

        protected void Load_data()
        {
            SqliteCommand cmd = new SqliteCommand("SELECT * FROM ota", con);
            da = new SqliteDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            htmltable.Append("<table border='1' width='100%'");
            htmltable.Append("<tr><th>game id</th><th>game name</th><th>game image</th><th>game link</th><th>game type</th></tr>");
            if(!object.Equals(ds.Tables[0],null))
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
                    {
                        htmltable.Append("<tr style='color:black;'>");
                        htmltable.Append("<td>" + ds.Tables[0].Rows[i]["id"] + "</td>");
                        htmltable.Append("<td>" + ds.Tables[0].Rows[i]["name"] + "</td>");
                        htmltable.Append("<td><img style='width:100px;height:100px;'src='image/" + ds.Tables[0].Rows[i]["image"] + "'/></td>");
                        htmltable.Append("<td>" + ds.Tables[0].Rows[i]["link"] + "</td>");
                        htmltable.Append("<td>" + ds.Tables[0].Rows[i]["type"] + "</td>");
                        htmltable.Append("</tr>");

                    }
                    htmltable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmltable.ToString() });
                }
                else
                {
                    htmltable.Append("<tr>");
                    htmltable.Append("<td align='center' colspan='4'> there is no  record</td>");
                    htmltable.Append("<tr>");
                }
            }
        }

        protected void btn_save_Click(object sender,EventArgs args)
        {
            con.ConnectionString = @"Data Source=App_Data/test.db";
            btn_save.Click -= new EventHandler(btn_save_Click);
            if(txt_id.Text == string.Empty &&  txt_name.Text == string.Empty && txt_image.Text == string.Empty &&txt_link.Text == string.Empty &&txt_type.Text == string.Empty){
                txt_id.Text = "do not leace the  field emty";
                txt_name.Text = "do not leace the  field emty";
                txt_image.Text = "do not leace the  field emty";
                txt_link.Text = "do not leace the  field emty";
                txt_type.Text = "do not leace the  field emty";
            }
            else
            {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "insert into ota (id,name,image,link,type) values('"+ txt_id.Text.Trim()+ "','" + txt_name.Text.Trim() + "','" + txt_image.Text.Trim() + "','" + txt_link.Text.Trim() + "','" + txt_type.Text.Trim() + "')";
                cmd.ExecuteNonQuery();
                txt_id.Text = "";
                txt_name.Text = "";
                txt_image.Text = "";
                txt_link.Text = "";
                txt_type.Text = "";
                con.Close();
                Load_data();
            }catch(SqliteException ex)
            {
                ex.ToString();
            }
        }
        }
        protected void btn_Clear_Click(object sender, EventArgs args)
        {
         btn_clear.Click -= new EventHandler(btn_Clear_Click);
           txt_id.Text = "";
            txt_name.Text = "";
            txt_image.Text = "";
            txt_link.Text = "";
            txt_type.Text = "";
            Load_data();
        }
    }
}
