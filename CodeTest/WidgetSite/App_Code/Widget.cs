using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Widget
/// </summary>
public class Widget
{
    public int WidgetPK{get;set;}
    public string WidgetName{get;set;}
    public string WidgetDescription { get; set; }
    public int WidgetQuantity { get; set; }

	public Widget()
	{
	}
}