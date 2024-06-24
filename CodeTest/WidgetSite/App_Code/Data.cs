using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class Data
{
    public string ConnectionString { get; set; }

	public Data(string connectionString)
	{
        ConnectionString = connectionString;
	}

    public void InsertWidget(string widgetName, string widgetDescription, string inventoryQty)
    {

        string queryString = "INSERT INTO tblWidgets (WidgetName, WidgetDescription, WidgetQuantity) VALUES(" + widgetName + "," + widgetDescription + "," + inventoryQty + ")";
        DatabaseAction(queryString, "Widgets");
    }

    public void UpdateWidget(string widgetPK, string widgetName, string widgetDescription, string inventoryQty)
    {
        List<string> setClauseAttributes = new List<string>();
        setClauseAttributes.Add(string.IsNullOrWhiteSpace(widgetName) ? "WidgetName = " + widgetName : string.Empty);
        setClauseAttributes.Add(string.IsNullOrWhiteSpace(widgetDescription) ? "WidgetDescription = " + widgetDescription : string.Empty);
        setClauseAttributes.Add(string.IsNullOrWhiteSpace(inventoryQty.ToString()) ? "WidgetQuantity = " + inventoryQty : string.Empty);

        string setClause = string.Join(", ", setClauseAttributes.Where(a => !string.IsNullOrWhiteSpace(a)).ToArray());

        if (string.IsNullOrWhiteSpace(widgetPK) || string.IsNullOrWhiteSpace(setClause))
        {
            throw new Exception("Please give at least one attribute to update");
        }
        if (!string.IsNullOrWhiteSpace(setClause))
        {
            string queryString = "UPDATE tblWidgets SET " + setClause + "WHERE WidgetPK = " + widgetPK;
            DataSet set = DatabaseAction(queryString, "Widgets");
        }
    }

    public List<Widget> GetWidgets(string widgetPK, string widgetName, string widgetDescription, string inventoryQty)
    {
        List<string> whereClauseAttributes = new List<string>();
        whereClauseAttributes.Add(string.IsNullOrWhiteSpace(widgetPK.ToString()) ? "WidgetPK = " + widgetPK : string.Empty);
        whereClauseAttributes.Add(string.IsNullOrWhiteSpace(widgetName) ? "WidgetName = " + widgetName : string.Empty);
        whereClauseAttributes.Add(string.IsNullOrWhiteSpace(widgetDescription) ? "WidgetDescription = " + widgetDescription : string.Empty);
        whereClauseAttributes.Add(string.IsNullOrWhiteSpace(inventoryQty.ToString()) ? "WidgetQuantity = " + inventoryQty : string.Empty);

        string whereClause = string.Join(" and ", whereClauseAttributes.Where(a => !string.IsNullOrWhiteSpace(a)).ToArray());

        if (!string.IsNullOrWhiteSpace(whereClause))
        {
            List<Widget> widgets = new List<Widget>();
            whereClause = "where " + whereClause;
            string queryString = "select * from tblWidgets " + whereClause;
            DataSet set = DatabaseAction(queryString, "Widgets");
            foreach (DataRow r in set.Tables["Widgets"].Rows)
            {
                widgets.Add(
                    new Widget()
                    {
                        WidgetPK = Convert.ToInt32(r["WidgetPK"].ToString()),
                        WidgetName = r["WidgetName"].ToString(),
                        WidgetDescription = r["WidgetDescription"].ToString(),
                        WidgetQuantity = Convert.ToInt32(r["WidgetQuantity"].ToString())
                    }
                );
            }
            return widgets;
        }
        else
        {
            throw new Exception("Please give at least one attribute to search on");
        }

    }

    public DataSet DatabaseAction(string queryString, string tableName)
    {
        DataSet widgetSet = null;
        SqlDataAdapter widgetAdapter = new SqlDataAdapter();
        string connectionString = this.ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);
        widgetAdapter.SelectCommand = new SqlCommand(queryString, connection);
        widgetAdapter.Fill(widgetSet, tableName);
        connection.Close();

        return widgetSet;
    }
}