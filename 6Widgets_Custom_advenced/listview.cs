using System;
using System.Collections;
using Gtk;

public class Actress
{
    public string Name;
    public string Place;
    public int Year;

    public Actress(string name, string place, int year)
    {
        Name = name;
        Place = place;
        Year = year;
    }
}

public class SharpApp : Window
{
    ListStore store;
    Statusbar statusbar;
    
    enum Column
    {
        Name,
        Place,
        Year
    }

    Actress[] actresses =
    {
        new Actress("Jessica Alba", "Pomona", 1981),
        new Actress("Sigourney Weaver", "New York", 1949),
        new Actress("Angelina Jolie", "Los Angeles", 1975),
        new Actress("Natalie Portman", "Jerusalem", 1981),
        new Actress("Rachel Weissz", "London", 1971),
        new Actress("Scarlett Johansson", "New York", 1984) 
    };

    public SharpApp() : base ("ListView")
    {
        BorderWidth = 8;

        SetDefaultSize(350, 250);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };

        VBox vbox = new VBox(false, 8);
        

        ScrolledWindow sw = new ScrolledWindow();
        sw.ShadowType = ShadowType.EtchedIn;
        sw.SetPolicy(PolicyType.Automatic, PolicyType.Automatic);
        vbox.PackStart(sw, true, true, 0);

        store = CreateModel();

        TreeView treeView = new TreeView(store);
        treeView.RulesHint = true;
        treeView.RowActivated += OnRowActivated;
        sw.Add(treeView);

        AddColumns(treeView);
        
        statusbar = new Statusbar();
        
        vbox.PackStart(statusbar, false, false, 0);

        Add(vbox);
        ShowAll();
    }

    void OnRowActivated (object sender, RowActivatedArgs args) {

        TreeIter iter;        
        TreeView view = (TreeView) sender;   
        
        if (view.Model.GetIter(out iter, args.Path)) {
            string row = (string) view.Model.GetValue(iter, (int) Column.Name );
            row += ", " + (string) view.Model.GetValue(iter, (int) Column.Place );
            row += ", " + view.Model.GetValue(iter, (int) Column.Year );
            statusbar.Push(0, row);
        }
    }

    void AddColumns(TreeView treeView)
    {
        CellRendererText rendererText = new CellRendererText();
        TreeViewColumn column = new TreeViewColumn("Name", rendererText,
            "text", Column.Name);
        column.SortColumnId = (int) Column.Name;
        treeView.AppendColumn(column);

        rendererText = new CellRendererText();
        column = new TreeViewColumn("Place", rendererText, 
            "text", Column.Place);
        column.SortColumnId = (int) Column.Place;
        treeView.AppendColumn(column);

        rendererText = new CellRendererText();
        column = new TreeViewColumn("Year", rendererText, 
            "text", Column.Year);
        column.SortColumnId = (int) Column.Year;
        treeView.AppendColumn(column);
    }


    ListStore CreateModel()
    {
        ListStore store = new ListStore( typeof(string),
            typeof(string), typeof(int) );

        foreach (Actress act in actresses) {
            store.AppendValues(act.Name, act.Place, act.Year );
        }

        return store;
    }
    
    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
} 
