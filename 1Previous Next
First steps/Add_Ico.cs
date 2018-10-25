using Gtk;
using System;
 
class SharpApp : Window {
 
    public SharpApp() : base("Icon")
    {
        SetDefaultSize(250, 160);
        SetPosition(WindowPosition.Center);
        SetIconFromFile("web.png");
        
        DeleteEvent += new DeleteEventHandler(OnDelete);
        
        Show();      
    }
    
    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }

    void OnDelete(object obj, DeleteEventArgs args)
    {
        Application.Quit();
    }
}
