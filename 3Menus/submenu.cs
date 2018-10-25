using Gtk;
using System;
 
class SharpApp : Window {
 

    public SharpApp() : base("Submenu")
    {
        SetDefaultSize(250, 200);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
        
        MenuBar mb = new MenuBar();

        Menu filemenu = new Menu();
        MenuItem file = new MenuItem("File");
        file.Submenu = filemenu;

        // submenu creation
        Menu imenu = new Menu();

        MenuItem import = new MenuItem("Import");
        import.Submenu = imenu;

        MenuItem inews = new MenuItem("Import news feed...");
        MenuItem ibookmarks = new MenuItem("Import bookmarks...");
        MenuItem imail = new MenuItem("Import mail...");

        imenu.Append(inews);
        imenu.Append(ibookmarks);
        imenu.Append(imail);

        // exit menu item
        MenuItem exit = new MenuItem("Exit");
        exit.Activated += OnActivated;
       
        filemenu.Append(import);
        filemenu.Append(exit);
        mb.Append(file);

        VBox vbox = new VBox(false, 2);
        vbox.PackStart(mb, false, false, 0);
        vbox.PackStart(new Label(), false, false, 0);

        Add(vbox);

        ShowAll();
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
