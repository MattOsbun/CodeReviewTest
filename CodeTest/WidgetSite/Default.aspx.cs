using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public Data DatabaseManager = new Data("Data Source=(local);Initial Catalog=Widgets;"
            + "Integrated Security=true");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (isPostBack)
        {
            lblSearchTerm.Text = txtSearch.Text;

            try
            {
                Widget widget = GetWidgets(txtSearch.Text).FirstOrDefault();
                string widgetInfo = widget.WidgetName + '\n' + widget.WidgetDescription + '\n' + widget.WidgetQuantity;
                txtWidgetResults.Text = widgetInfo;
            }
            catch (Exception ex)
            {
            }

        }
    }

    private List<Widget> GetWidgets(string name)
    {
        return DatabaseManager.GetWidgets("", name, "", "");
    }
}