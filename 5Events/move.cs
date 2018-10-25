using Gtk;
using System;
 
class SharpApp : Window {
 

    public SharpApp() : base("")
    {
        SetDefaultSize(250, 150);
        SetPosition(WindowPosition.Center);

        DeleteEvent += delegate { Application.Quit(); };
        Show();
    }

    protected override bool OnConfigureEvent(Gdk.EventConfigure args)
    {
        base.OnConfigureEvent(args);
        Title = args.X + ", " + args.Y;
        return true;
    }

    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
