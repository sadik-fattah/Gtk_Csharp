using Gtk;
using System;
 
class SharpApp : Window {
 
    Button button;

    public SharpApp() : base("Disconnect")
    {
        SetDefaultSize(250, 150);
        SetPosition(WindowPosition.Center);

        DeleteEvent += delegate { Application.Quit(); };

        button = new Button("Button");

        CheckButton cb = new CheckButton("connect");
        cb.Toggled += OnToggled;

        Fixed fix = new Fixed();
        fix.Put(button, 30, 50);
        fix.Put(cb, 130, 50);

        Add(fix);

        ShowAll();
    }


    void OnClick(object sender, EventArgs args)
    {
        Console.WriteLine("Click");
    }

    void OnToggled(object sender, EventArgs args)
    {
        CheckButton cb = (CheckButton) sender;
        if (cb.Active) {
            button.Clicked += OnClick;
        } else {
            button.Clicked -= OnClick;
        }
    }

    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
