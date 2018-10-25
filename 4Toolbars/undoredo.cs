using Gtk;
using System;
 
class SharpApp : Window {
 
    private int count = 2;
    private ToolButton undo;
    private ToolButton redo;

    public SharpApp() : base("Undo redo")
    {
        SetDefaultSize(250, 200);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
        
        Toolbar toolbar = new Toolbar();
        toolbar.ToolbarStyle = ToolbarStyle.Icons;

        undo = new ToolButton(Stock.Undo);
        redo = new ToolButton(Stock.Redo);
        SeparatorToolItem sep = new SeparatorToolItem();
        ToolButton quit = new ToolButton(Stock.Quit);

        toolbar.Insert(undo, 0);
        toolbar.Insert(redo, 1);
        toolbar.Insert(sep, 2);
        toolbar.Insert(quit, 3);

        undo.Clicked += OnUndo;
        redo.Clicked += OnRedo;
        quit.Clicked += OnClicked;
         
        VBox vbox = new VBox(false, 2);
        vbox.PackStart(toolbar, false, false, 0);
        vbox.PackStart(new Label(), false, false, 0);

        Add(vbox);

        ShowAll();
    }

    void OnUndo(object sender, EventArgs args)
    {
        count -= 1;

        if (count <= 0) {
            undo.Sensitive = false;
            redo.Sensitive = true;
        }
    }

    void OnRedo(object sender, EventArgs args)
    {
        count += 1;

        if (count >= 5) {
            redo.Sensitive = false;
            undo.Sensitive = true;
        }
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
