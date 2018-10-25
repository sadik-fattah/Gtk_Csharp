using Gtk;
using System;
 
class SharpApp : Window {
 
    private Statusbar statusbar;

    public SharpApp() : base("Check menu item")
    {
        SetDefaultSize(250, 200);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
        
        MenuBar mb = new MenuBar();

        Menu filemenu = new Menu();
        MenuItem file = new MenuItem("File");
        file.Submenu = filemenu;

        Menu viewmenu = new Menu();
        MenuItem view = new MenuItem("View");
        view.Submenu = viewmenu;

        CheckMenuItem stat = new CheckMenuItem("View Statusbar");
        stat.Toggle();
        stat.Toggled += OnStatusView;
        viewmenu.Append(stat);
       
        MenuItem exit = new MenuItem("Exit");
        exit.Activated += OnActivated;
        filemenu.Append(exit);

        mb.Append(file);
        mb.Append(view);

        statusbar = new Statusbar();
        statusbar.Push(1, "Ready");

        VBox vbox = new VBox(false, 2);
        vbox.PackStart(mb, false, false, 0);
        vbox.PackStart(new Label(), true, false, 0);
        vbox.PackStart(statusbar, false, false, 0);

        Add(vbox);

        ShowAll();
    }

    void OnStatusView(object sender, EventArgs args)
    {
        CheckMenuItem item = (CheckMenuItem) sender;

        if (item.Active) {
            statusbar.Show();
        } else {
            statusbar.Hide();
        }
    }
 
    void OnActivated(object sender, EventArgs args)
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
