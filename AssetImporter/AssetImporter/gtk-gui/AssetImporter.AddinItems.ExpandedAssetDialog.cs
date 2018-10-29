
// This file has been generated by the GUI designer. Do not modify.
namespace AssetImporter.AddinItems
{
	public partial class ExpandedAssetDialog
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.Frame frame5;

		private global::Gtk.Alignment GtkAlignment2;

		private global::Gtk.HBox hbox4;

		private global::Gtk.FileChooserButton filechooserbutton6;

		private global::Gtk.Button button15;

		private global::Gtk.Label GtkLabel2;

		private global::Gtk.ScrolledWindow scrolledwindow2;

		private global::Gtk.VBox ProjectAssetVBox;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Button buttonOk;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget AssetImporter.AddinItems.ExpandedAssetDialog
			this.Name = "AssetImporter.AddinItems.ExpandedAssetDialog";
			this.Title = global::Mono.Unix.Catalog.GetString("Asset Properties");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.BorderWidth = ((uint)(5));
			this.Gravity = ((global::Gdk.Gravity)(5));
			// Internal child AssetImporter.AddinItems.ExpandedAssetDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.frame5 = new global::Gtk.Frame();
			this.frame5.Name = "frame5";
			this.frame5.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame5.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment(0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			this.GtkAlignment2.LeftPadding = ((uint)(12));
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.filechooserbutton6 = new global::Gtk.FileChooserButton(global::Mono.Unix.Catalog.GetString("Select a File"), ((global::Gtk.FileChooserAction)(0)));
			this.filechooserbutton6.Name = "filechooserbutton6";
			this.hbox4.Add(this.filechooserbutton6);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.filechooserbutton6]));
			w2.Position = 0;
			// Container child hbox4.Gtk.Box+BoxChild
			this.button15 = new global::Gtk.Button();
			this.button15.CanFocus = true;
			this.button15.Name = "button15";
			this.button15.UseUnderline = true;
			this.button15.Label = global::Mono.Unix.Catalog.GetString("Import");
			this.hbox4.Add(this.button15);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.button15]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.GtkAlignment2.Add(this.hbox4);
			this.frame5.Add(this.GtkAlignment2);
			this.GtkLabel2 = new global::Gtk.Label();
			this.GtkLabel2.Name = "GtkLabel2";
			this.GtkLabel2.LabelProp = global::Mono.Unix.Catalog.GetString("<b>Replace All</b>");
			this.GtkLabel2.UseMarkup = true;
			this.frame5.LabelWidget = this.GtkLabel2;
			this.vbox4.Add(this.frame5);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.frame5]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox4.Gtk.Box+BoxChild
			this.scrolledwindow2 = new global::Gtk.ScrolledWindow();
			this.scrolledwindow2.CanFocus = true;
			this.scrolledwindow2.Name = "scrolledwindow2";
			this.scrolledwindow2.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow2.Gtk.Container+ContainerChild
			global::Gtk.Viewport w7 = new global::Gtk.Viewport();
			w7.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.ProjectAssetVBox = new global::Gtk.VBox();
			this.ProjectAssetVBox.Name = "ProjectAssetVBox";
			this.ProjectAssetVBox.Spacing = 6;
			w7.Add(this.ProjectAssetVBox);
			this.scrolledwindow2.Add(w7);
			this.vbox4.Add(this.scrolledwindow2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.scrolledwindow2]));
			w10.Position = 1;
			w1.Add(this.vbox4);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(w1[this.vbox4]));
			w11.Position = 0;
			// Internal child AssetImporter.AddinItems.ExpandedAssetDialog.ActionArea
			global::Gtk.HButtonBox w12 = this.ActionArea;
			w12.Name = "dialog1_ActionArea";
			w12.Spacing = 10;
			w12.BorderWidth = ((uint)(5));
			w12.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget(this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12[this.buttonCancel]));
			w13.Expand = false;
			w13.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget(this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w14 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w12[this.buttonOk]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
