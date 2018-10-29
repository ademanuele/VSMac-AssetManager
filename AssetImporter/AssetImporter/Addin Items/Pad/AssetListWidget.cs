using System.Collections;
using AssetImporter.AssetAbstractionItems;
using Gdk;
using Gtk;

namespace AssetImporter.AddinItems.Pad
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class AssetListWidget : Bin
    {
        internal AssetTreeNodeStore Assets { get; }

        public AssetListWidget()
        {
            Build();

            Assets = new AssetTreeNodeStore();
            SetupNodeView();

            ShowAll();
        }

        void SetupNodeView()
        {
            assetNodeView.NodeStore = Assets;
            assetNodeView.EnableGridLines = TreeViewGridLines.Horizontal;
            assetNodeView.RowActivated += RowDoubleClicked;
            assetNodeView.AppendColumn("", new CellRendererPixbuf(), "pixbuf", 0);
            assetNodeView.AppendColumn("Name", new CellRendererText(), "text", 1);
            assetNodeView.AppendColumn("Projects", new CellRendererText(), "text", 2);
            assetNodeView.AppendColumn("Resolutions", new CellRendererText(), "text", 3);
        }

        void RowDoubleClicked(object sender, RowActivatedArgs e)
        {
            if (e.Path.Indices.Length == 1)
            {
                var clickedAsset = Assets.GetNode(e.Path) as AssetTreeNode;
                using (var dlg = new ExpandedAssetDialog(clickedAsset.Asset))
                    dlg.Run();
            }
        }

		internal class AssetTreeNodeStore : NodeStore
		{
			public AssetTreeNodeStore() : base(typeof(AssetTreeNode)) { }

			public void Add(Asset asset)
			{
				AddNode(new AssetTreeNode(asset));
			}

			public void AddAll(IList assets)
			{
				foreach (var asset in assets)
					Add(asset as Asset);
			}
		}

		class AssetTreeNode : TreeNode
		{
			const int PREVIEW_WIDTH = 50;
			const int PREVIEW_HEIGHT = 50;
			[TreeNodeValue(Column = 0)]
			public Pixbuf Preview => preview ?? (preview = PreviewImage());
			Pixbuf preview;

			[TreeNodeValue(Column = 1)]
			public string Name => Asset.Name;

			[TreeNodeValue(Column = 2)]
			public string ProjectsString => projectsString ?? (projectsString = ProjectsDisplayString());
			string projectsString;

			[TreeNodeValue(Column = 3)]
			public string ResolutionString => resolutionString ?? (resolutionString = ResolutionDisplayString());
			string resolutionString;

			public Asset Asset { get; }

			public AssetTreeNode(Asset item)
			{
				Asset = item;
			}

			public Pixbuf PreviewImage()
			{
				foreach (var asset in Asset.ProjectAssets)
					if (asset.Asset1x != null)
                        return new Pixbuf(asset.Asset1x.Path, PREVIEW_WIDTH, PREVIEW_HEIGHT, true);

				return null;
			}

			public string ProjectsDisplayString()
			{
				var assets = Asset.ProjectAssets;
				var displayString = assets[0].Project.Name;

				for (int i = 1; i < assets.Count; i++)
					displayString += '\n' + assets[i].Project.Name;

				return displayString;
			}

			public string ResolutionDisplayString()
			{
				var assets = Asset.ProjectAssets;
				var displayString = ResolutionDisplayStringForAsset(Asset.ProjectAssets[0]);

				for (int i = 1; i < assets.Count; i++)
					displayString += '\n' + ResolutionDisplayStringForAsset(assets[i]);

				return displayString;
			}

			string ResolutionDisplayStringForAsset(ProjectAsset asset)
			{
				var projectResolution = "{";
				projectResolution += asset.Asset1x == null ? "" : " x1 ";
				projectResolution += asset.Asset2x == null ? "" : " x2 ";
				projectResolution += asset.Asset3x == null ? "" : " x3 ";
				projectResolution += "}";

				return projectResolution;
			}
		}
    }
}
