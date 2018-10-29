using MonoDevelop.Components;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide;

namespace AssetImporter.AddinItems.Pad
{
    class AssetsPad : PadContent
    {
        AssetsPadWidget PadWidget { get; set; }

        public override Control Control => PadWidget = PadWidget ?? new AssetsPadWidget();

        public override string Id
        {    
            get { return "AssetImporter.AddinItems.Pad.AssetsPad"; }
        }

        protected override void Initialize(IPadWindow window)
        {
            base.Initialize(window);
            StartListeningToProjectChanges();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public void StartListeningToProjectChanges()
        {
            IdeApp.Workspace.SolutionLoaded += (s, e) => PadWidget.LoadAssets();
            IdeApp.Workspace.SolutionUnloaded += (sender, e) => PadWidget.AssetList.Assets.Clear();
        }
    }
}
