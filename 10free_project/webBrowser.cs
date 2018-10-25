using System;
using Gtk;
using WebKit;

namespace monobrowser {
    class coolbrowser {

        public static void Main () {
            Application.Init ();
            Window window = new Window ("a browser in 13 lines...");
			window.SetDefaultSize(800,600);
            window.Destroyed += delegate (object sender, EventArgs e) {
                Application.Quit ();
            };
            ScrolledWindow scrollWindow = new ScrolledWindow ();
            WebView webView = new WebView ();
            webView.Open ("http://www.guercifzone.com/");
            scrollWindow.Add (webView);
            window.Add (scrollWindow);
            window.ShowAll ();
            Application.Run ();
        }
    }
}
