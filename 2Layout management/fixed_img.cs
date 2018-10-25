using Gtk;
using System;
 
class SharpApp : Window {
 
    private Gdk.Pixbuf rotunda;
    private Gdk.Pixbuf bardejov;
    private Gdk.Pixbuf mincol;
    
    public SharpApp() : base("Fixed")
    {
        SetDefaultSize(300, 280);
        SetPosition(WindowPosition.Center);
        ModifyBg(StateType.Normal, new Gdk.Color(40, 40, 40));
        DeleteEvent += delegate { Application.Quit(); };

        try {
            bardejov = new Gdk.Pixbuf("bardejov.jpg");
            rotunda = new Gdk.Pixbuf("rotunda.jpg");
            mincol = new Gdk.Pixbuf("mincol.jpg");
        } catch {
            Console.WriteLine("Images not found");
            Environment.Exit(1);
        }
        
        Image image1 = new Image(bardejov);
        Image image2 = new Image(rotunda);
        Image image3 = new Image(mincol);
        
        
        Fixed fix = new Fixed();
        
        fix.Put(image1, 20, 20);
        fix.Put(image2, 40, 160);
        fix.Put(image3, 170, 50);
  
        Add(fix);
        ShowAll();
    }


    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
