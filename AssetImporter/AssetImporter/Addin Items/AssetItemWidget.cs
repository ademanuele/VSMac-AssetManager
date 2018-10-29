using Gdk;
using Gtk;
using AssetImporter.AssetAbstractionItems;

namespace AssetImporter.AddinItems
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class AssetItemWidget : Bin
    {
        AssetItem AssetItem { get; }

        string AssetPath
        {
            get => AssetItem.Path;
            set
            {
                AssetItem.Path = value;
                UpdatePreview();
            }
        }

        internal AssetItemWidget(AssetItem item)
        {
            Build();

            AssetItem = item;
            InitAssetData();

            ShowAll();
        }

        void InitAssetData()
        {
            if (!string.IsNullOrEmpty(AssetPath))
            {
                InitFileChooser();
                UpdatePreview();
            }
        }

		void InitFileChooser()
		{
            AssetPathChooser.SetFilename(AssetPath);
            AssetPathChooser.Filter = ImageFileFilter.Filter;
			AssetPathChooser.SelectionChanged += OnAssetPathChanged;
		}

		void OnAssetPathChanged(object sender, System.EventArgs e)
		{
            AssetPath = AssetPathChooser.Filename;
		}

        void UpdatePreview() {
			AssetPreviewImage.Pixbuf = new Pixbuf(AssetPath, 50, 50, true);
			var image = System.Drawing.Image.FromFile(AssetPath);
			AssetResolutionLabel.Text = image.Width + " x " + image.Height;
        }
    }
}
