using Gtk;
using System;
 
class SharpApp : Window {
 

    public SharpApp() : base("Toolbars")
    {
        SetDefaultSize(250, 200);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
        
        Toolbar upper = new Toolbar();
        upper.ToolbarStyle = ToolbarStyle.Icons;

        ToolButton newtb = new ToolButton(Stock.New);
        ToolButton opentb = new ToolButton(Stock.Open);
        ToolButton savetb = new ToolButton(Stock.Save);

        upper.Insert(newtb, 0);
        upper.Insert(opentb, 1);
        upper.Insert(savetb, 2);

        Toolbar lower = new Toolbar();
        lower.ToolbarStyle = ToolbarStyle.Icons;

        ToolButton quittb = new ToolButton(Stock.Quit);
        quittb.Clicked += OnClicked;
        lower.Insert(quittb, 0);

         
        VBox vbox = new VBox(false, 2);
        vbox.PackStart(upper, false, false, 0);
        vbox.PackStart(lower, false, false, 0);

        Add(vbox);

        ShowAll();
    }

    void OnClicked(object sender, EventArgs args)
    {
        Application.Quit();
    }


    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
