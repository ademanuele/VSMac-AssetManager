using System.Linq;
using Gtk;
using MonoDevelop.Ide;

namespace AssetImporter.AddinItems.Pad
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class AssetsPadWidget : Bin
    {
        public AssetListWidget AssetList { get; private set; }

        AssetService Manager { get; set; }

        public AssetsPadWidget()
        {
            Build();
            SetupAssetList();
            SetupToolbar();
            LoadAssets();

            ShowAll();
        }

        private void SetupAssetList()
        {
            AssetList = new AssetListWidget();
            RootVBox.Add(AssetList);
        }

        void SetupToolbar() {
            addAction.Activated += (sender, e) => {
                using (var dialog = new ExpandedAssetDialog())
                    dialog.Run();
            };
        }

		public void LoadAssets()
		{
			var solutions = IdeApp.Workspace.GetAllSolutions();
			if (solutions.Any())
			{
				Manager = new AssetService(solutions.First());
				var assets = Manager.ParseAssets();

				foreach (var asset in assets)
				{
					AssetList.Assets.Add(asset);
				}
			}
		}
    }
}
