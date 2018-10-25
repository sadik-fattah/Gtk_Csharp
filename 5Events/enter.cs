using Gtk;
using System;
 
class SharpApp : Window {
 

    public SharpApp() : base("Enter")
    {
        SetDefaultSize(200, 150);
        SetPosition(WindowPosition.Center);

        DeleteEvent += delegate { Application.Quit(); };

        Button button = new Button("Button");
        button.EnterNotifyEvent += OnEnter;

        Fixed fix = new Fixed();
        fix.Put(button, 20, 20);

        Add(fix);

        ShowAll();
    }


    void OnEnter(object sender, EnterNotifyEventArgs args)
    {
        Button button = (Button) sender;
        button.ModifyBg(StateType.Prelight, new Gdk.Color(220, 220, 220));
    }


    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
