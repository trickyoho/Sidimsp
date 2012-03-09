
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox1;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Button StartButton;
	private global::Gtk.HBox hbox2;
	private global::Gtk.HBox hbox3;
	private global::Gtk.Button StopButton;
	private global::Gtk.HBox hbox4;
	private global::Gtk.Label SidimspLabel;
	private global::Gtk.Button AboutButton;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView textview1;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.StartButton = new global::Gtk.Button ();
		this.StartButton.CanFocus = true;
		this.StartButton.Name = "StartButton";
		this.StartButton.UseUnderline = true;
		this.StartButton.Label = global::Mono.Unix.Catalog.GetString ("Start");
		this.hbox1.Add (this.StartButton);
		global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.StartButton]));
		w1.Position = 0;
		w1.Expand = false;
		w1.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.hbox3 = new global::Gtk.HBox ();
		this.hbox3.Name = "hbox3";
		this.hbox3.Spacing = 6;
		// Container child hbox3.Gtk.Box+BoxChild
		this.StopButton = new global::Gtk.Button ();
		this.StopButton.CanFocus = true;
		this.StopButton.Name = "StopButton";
		this.StopButton.UseUnderline = true;
		this.StopButton.Label = global::Mono.Unix.Catalog.GetString ("Stop");
		this.hbox3.Add (this.StopButton);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.StopButton]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		this.hbox2.Add (this.hbox3);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.hbox3]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		this.hbox1.Add (this.hbox2);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.hbox2]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.hbox4 = new global::Gtk.HBox ();
		this.hbox4.Name = "hbox4";
		this.hbox4.Spacing = 6;
		// Container child hbox4.Gtk.Box+BoxChild
		this.SidimspLabel = new global::Gtk.Label ();
		this.SidimspLabel.WidthRequest = 400;
		this.SidimspLabel.Name = "SidimspLabel";
		this.SidimspLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Sidimsp");
		this.hbox4.Add (this.SidimspLabel);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.SidimspLabel]));
		w5.Position = 0;
		// Container child hbox4.Gtk.Box+BoxChild
		this.AboutButton = new global::Gtk.Button ();
		this.AboutButton.CanFocus = true;
		this.AboutButton.Name = "AboutButton";
		this.AboutButton.UseUnderline = true;
		this.AboutButton.Label = global::Mono.Unix.Catalog.GetString ("About");
		this.hbox4.Add (this.AboutButton);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.AboutButton]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		this.hbox1.Add (this.hbox4);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.hbox4]));
		w7.Position = 2;
		w7.Expand = false;
		w7.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w8.Position = 0;
		w8.Expand = false;
		w8.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.textview1 = new global::Gtk.TextView ();
		this.textview1.Name = "textview1";
		this.textview1.Editable = false;
		this.textview1.CursorVisible = false;
		this.GtkScrolledWindow.Add (this.textview1);
		this.vbox1.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.GtkScrolledWindow]));
		w10.Position = 1;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 542;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.StartButton.Clicked += new global::System.EventHandler (this.OnStartButtonClicked);
		this.StopButton.Clicked += new global::System.EventHandler (this.OnStopButtonClicked);
		this.AboutButton.Clicked += new global::System.EventHandler (this.OnAboutButtonClicked);
	}
}
