using AssetImporter.AssetAbstractionItems;
using Gtk;

namespace AssetImporter.AddinItems
{
    public partial class ExpandedAssetDialog : Dialog
    {
        Asset Asset { get; set; }
        Asset ModifiedAsset { get; set; }

        public ExpandedAssetDialog() {
            Build();
        }

        internal ExpandedAssetDialog(Asset asset)
        {
            Build();

            Asset = asset;
            ModifiedAsset = asset.MakeCopyForModification();
                
            PopulateAssetProjects();

            ShowAll();
        }

        void PopulateAssetProjects()
        {
            foreach (var projectAsset in ModifiedAsset.ProjectAssets)
                ProjectAssetVBox.Add(new AssetProjectExpandedWidget(projectAsset));
        }

        protected override void OnResponse(ResponseType response_id)
        {
            base.OnResponse(response_id);

            switch(response_id) {
                case ResponseType.Cancel:
                    OnCancelled();
                    break;
                case ResponseType.Ok:
                    OnOk();
                    break;
            }
        }

        void OnCancelled() {
            ModifiedAsset = null;
			Asset = null;

            Destroy();
        }

        void OnOk() {
            //Asset.PersistChanges(ModifiedAsset);

            Destroy();
        }
    }
}
