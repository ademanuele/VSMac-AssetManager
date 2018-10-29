using System;
using System.Collections.Generic;
using System.Linq;
using AssetImporter.AssetAbstractionItems;
using MonoDevelop.Projects;

namespace AssetImporter
{
    class AssetService
    {
        public Solution Solution { get; }

        List<AssetProject> SupportedProjects { get; set; }

        public AssetService(Solution solution)
        {
            Solution = solution;
            PopulateProjects();
        }

        void PopulateProjects()
        {
            SupportedProjects = new List<AssetProject>();
            foreach (var item in Solution.Items)
            {
                try
                {
                    if (item is Project)
                        SupportedProjects.Add(AssetProject.ForProject(item as Project));
                }
                catch (NotSupportedException) { }
            }
        }

        public List<Asset> ParseAssets() {
            Dictionary<string, Asset> assets = new Dictionary<string, Asset>();

            foreach(var project in SupportedProjects) {
                var projectAssets = project.ParseAssets();
                foreach(var projectAsset in projectAssets) {
                    if (assets.ContainsKey(projectAsset.Name)) {
                        assets[projectAsset.Name].ProjectAssets.Add(projectAsset);
                    } else {
                        var asset = new Asset(projectAsset.Name);
                        asset.ProjectAssets.Add(projectAsset);
                        assets.Add(projectAsset.Name, asset);
                    }
                }
            }

            return assets.Values.ToList();
        }

        public void Delete(Asset asset) {
            foreach (var project in SupportedProjects)
                foreach (var projectAsset in asset.ProjectAssets)
                    project.Delete(projectAsset);
        }
    }
}
