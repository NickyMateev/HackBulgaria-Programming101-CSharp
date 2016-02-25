using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClickCounter
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            Session["username"] = TextBox1.Text;
            if (Application[TextBox1.Text] == null)
                Application[TextBox1.Text] = 0;
            Response.Redirect("ClickCounter.aspx");
        }
    }
}