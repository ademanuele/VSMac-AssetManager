
// This file has been generated by the GUI designer. Do not modify.
namespace AssetImporter.AddinItems.Pad
{
	public partial class AssetsPadWidget
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action addAction;

		private global::Gtk.VBox RootVBox;

		private global::Gtk.Toolbar toolbar1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget AssetImporter.AddinItems.Pad.AssetsPadWidget
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach(this);
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup("Default");
			this.addAction = new global::Gtk.Action("addAction", null, null, "gtk-add");
			w2.Add(this.addAction, null);
			this.UIManager.InsertActionGroup(w2, 0);
			this.Name = "AssetImporter.AddinItems.Pad.AssetsPadWidget";
			// Container child AssetImporter.AddinItems.Pad.AssetsPadWidget.Gtk.Container+ContainerChild
			this.RootVBox = new global::Gtk.VBox();
			this.RootVBox.Name = "RootVBox";
			this.RootVBox.Spacing = 6;
			// Container child RootVBox.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString("<ui><toolbar name=\'toolbar1\'><toolitem name=\'addAction\' action=\'addAction\'/></too" +
					"lbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.RootVBox.Add(this.toolbar1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.RootVBox[this.toolbar1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			this.Add(this.RootVBox);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			w1.SetUiManager(UIManager);
			this.Hide();
		}
	}
}
