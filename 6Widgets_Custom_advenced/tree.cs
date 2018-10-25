using Gtk;


public class SharpApp : Window
{
    
    public SharpApp() : base ("Tree")
    {
        SetDefaultSize(400, 300);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
 
        TreeView tree = new TreeView();
        
        TreeViewColumn languages = new TreeViewColumn();
        languages.Title = "Programming languages";
 
        CellRendererText cell = new CellRendererText();
        languages.PackStart(cell, true);
        languages.AddAttribute(cell, "text", 0);
 
        TreeStore treestore = new TreeStore(typeof(string), typeof(string));
 
        TreeIter iter = treestore.AppendValues("Scripting languages");
        treestore.AppendValues(iter, "Python");
        treestore.AppendValues(iter, "PHP");
        treestore.AppendValues(iter, "Perl");
        treestore.AppendValues(iter, "Ruby");
 
        iter = treestore.AppendValues("Compiling languages");
        treestore.AppendValues(iter, "C#");
        treestore.AppendValues(iter, "C++");
        treestore.AppendValues(iter, "C");
        treestore.AppendValues(iter, "Java");
 
        tree.AppendColumn(languages);
        tree.Model = treestore;
        
        Add(tree);
        ShowAll();
    }
    
    public static void Main()
    {
        Gtk.Application.Init();
        new SharpApp();
        Gtk.Application.Run();
    }
}
