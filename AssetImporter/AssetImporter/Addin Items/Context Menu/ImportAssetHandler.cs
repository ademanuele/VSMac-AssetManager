using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using MonoDevelop.Projects;

namespace AssetImporter.AddinItems.ContextMenu
{
    class ImportAssetHandler : CommandHandler
    {
        protected override void Run()
        {
            base.Run();
            System.Diagnostics.Debug.WriteLine("Running asset import...");

            System.Threading.Tasks.Task.Run(() =>
            {
                //var solution = IdeApp.ProjectOperations.CurrentSelectedItem as Solution;
                //Runtime.RunInMainThread(
                //    () => new AssetDialog(solution).Show()
                //);
            });
        }
    }
}
