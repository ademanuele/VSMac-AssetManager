using Gtk;
using AssetImporter.AssetAbstractionItems;
using Pango;

namespace AssetImporter.AddinItems
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class AssetProjectExpandedWidget : Bin
    {
        ProjectAsset Asset { get; }

        internal AssetProjectExpandedWidget(ProjectAsset asset)
        {
            Build();

            Asset = asset;

            ProjectNameLabel.ModifyFont(new FontDescription { Weight = Weight.Bold });
			ProjectNameLabel.Text = Asset.Project.Name;

            PopulateAssetItems();

            ShowAll();
        }

        void PopulateAssetItems() {
            ProjectAssetVBox.Add(new AssetItemWidget(Asset.Asset1x));
            ProjectAssetVBox.Add(new AssetItemWidget(Asset.Asset2x));
            ProjectAssetVBox.Add(new AssetItemWidget(Asset.Asset3x));
        }
    }
}
 