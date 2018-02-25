using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit(object sender, EventArgs e)
    {
        content.PostedFile.SaveAs(@"c:\Users\Jebin\source\repos\OnlineFS\Upload\"+content.FileName);
    }
}