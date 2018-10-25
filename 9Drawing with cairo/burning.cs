using Gtk;
using Cairo;
using System;
 
class Burning : DrawingArea
{

    string[] num = new string[] { "75", "150", "225", "300", 
        "375", "450", "525", "600", "675" };

    public Burning() : base()
    {
        SetSizeRequest(-1, 30);
    }

    protected override bool OnExposeEvent(Gdk.EventExpose args)
    {
        
        Cairo.Context cr = Gdk.CairoHelper.Create(args.Window);
        cr.LineWidth = 0.8;

        cr.SelectFontFace("Courier 10 Pitch", 
            FontSlant.Normal, FontWeight.Normal);
        cr.SetFontSize(11);

        int width = Allocation.Width;

        SharpApp parent = (SharpApp) GetAncestor (Gtk.Window.GType);        
        int cur_width = parent.CurValue;

        int step = (int) Math.Round(width / 10.0);

        int till = (int) ((width / 750.0) * cur_width);
        int full = (int) ((width / 750.0) * 700);

        if (cur_width >= 700) {
            
            cr.SetSourceRGB(1.0, 1.0, 0.72);
            cr.Rectangle(0, 0, full, 30);
            cr.Clip();
            cr.Paint();
            cr.ResetClip();
            
            cr.SetSourceRGB(1.0, 0.68, 0.68);
            cr.Rectangle(full, 0, till-full, 30);    
            cr.Clip();
            cr.Paint();
            cr.ResetClip();

        } else { 
             
            cr.SetSourceRGB(1.0, 1.0, 0.72);
            cr.Rectangle(0, 0, till, 30);
            cr.Clip();
            cr.Paint();
            cr.ResetClip();
       }  

       cr.SetSourceRGB(0.35, 0.31, 0.24);
       
       for (int i=1; i<=num.Length; i++) {
           
           cr.MoveTo(i*step, 0);
           cr.LineTo(i*step, 5);    
           cr.Stroke();
           
           TextExtents extents = cr.TextExtents(num[i-1]);
           cr.MoveTo(i*step-extents.Width/2, 15);
           cr.TextPath(num[i-1]);
           cr.Stroke();
       }
        
        ((IDisposable) cr.Target).Dispose();                                      
        ((IDisposable) cr).Dispose();

        return true;
    }
}


class SharpApp : Window {
 
    int cur_value = 0;
    Burning burning;
    
    public SharpApp() : base("Burning")
    {
        SetDefaultSize(350, 200);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };
       
        VBox vbox = new VBox(false, 2);
        
        HScale scale = new HScale(0, 750, 1);
        scale.SetSizeRequest(160, 35);
        scale.ValueChanged += OnChanged;
        
        Fixed fix = new Fixed();
        fix.Put(scale, 50, 50);
        
        vbox.PackStart(fix);
        
        burning = new Burning();
        vbox.PackStart(burning, false, false, 0);

        Add(vbox);

        ShowAll();
    }
    
    void OnChanged(object sender, EventArgs args)
    {
        Scale scale = (Scale) sender;
        cur_value = (int) scale.Value;
        burning.QueueDraw();
    }
    
    public int CurValue {
        get { return cur_value; }
    }


    public static void Main()
    {
        Application.Init();
        new SharpApp();
        Application.Run();
    }
}
