using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    public Data DatabaseManager = new Data("Data Source=(local);Initial Catalog=Widgets;"
            + "Integrated Security=true");

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void AddWidget(string widgetName, string widgetDescription, string inventoryQty)
    {
        DatabaseManager.InsertWidget(widgetName, widgetDescription, inventoryQty);
    }

    public void UpdateWidget(string widgetPK, string widgetName, string widgetDescription, string inventoryQty)
    {
        DatabaseManager.UpdateWidget(widgetPK, widgetName, widgetDescription, inventoryQty);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Widget existingWidget = DatabaseManager.GetWidgets("", txtWidgetName.Text, txtDescription.Text, txtQuantity.Text).FirstOrDefault();
        if (existingWidget != null)
        {
            AddWidget(txtWidgetName.Text, txtDescription.Text, txtQuantity.Text);
        }
        else
        {
            UpdateWidget(existingWidget.WidgetPK.ToString(), txtWidgetName.Text, txtDescription.Text, txtQuantity.Text.ToString());
        }
    }
}