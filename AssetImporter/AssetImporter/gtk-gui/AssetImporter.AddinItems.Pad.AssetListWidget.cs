
// This file has been generated by the GUI designer. Do not modify.
namespace AssetImporter.AddinItems.Pad
{
	public partial class AssetListWidget
	{
		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView assetNodeView;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget AssetImporter.AddinItems.Pad.AssetListWidget
			global::Stetic.BinContainer.Attach(this);
			this.Name = "AssetImporter.AddinItems.Pad.AssetListWidget";
			// Container child AssetImporter.AddinItems.Pad.AssetListWidget.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.assetNodeView = new global::Gtk.NodeView();
			this.assetNodeView.CanFocus = true;
			this.assetNodeView.Name = "assetNodeView";
			this.GtkScrolledWindow.Add(this.assetNodeView);
			this.Add(this.GtkScrolledWindow);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
