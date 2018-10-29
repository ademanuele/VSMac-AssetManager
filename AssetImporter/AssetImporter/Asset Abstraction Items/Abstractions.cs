using System.Collections.Generic;
using MonoDevelop.Projects;

namespace AssetImporter.AssetAbstractionItems
{
    class Asset
    {
        public string Name { get; private set; }
        public List<ProjectAsset> ProjectAssets { get; private set; }

        public Asset(string name)
        {
            Name = name;
            ProjectAssets = new List<ProjectAsset>();
        }

        public Asset MakeCopyForModification() {
            var copy = new Asset(Name);
            foreach (var asset in ProjectAssets)
                copy.ProjectAssets.Add(ModifiedProjectAsset.FromAsset(asset));

            return copy;
        }
    }

    interface ProjectAsset
    {
        string Name { get; }
        Project Project { get; }
        AssetItem Asset1x { get; }
        AssetItem Asset2x { get; }
        AssetItem Asset3x { get; }
    }

    class ModifiedProjectAsset : ProjectAsset
    {
        public string Name { get; private set; }
        public Project Project { get; private set; }
        public AssetItem Asset1x { get; private set; }
        public AssetItem Asset2x { get; private set; }
        public AssetItem Asset3x { get; private set; }

        public static ModifiedProjectAsset FromAsset(ProjectAsset asset) {
            return new ModifiedProjectAsset
            {
                Name = asset.Name,
                Project = asset.Project,
                Asset1x = asset.Asset1x,
                Asset2x = asset.Asset2x,
                Asset3x = asset.Asset3x
            };
        }
    }

    class AssetItem {
        public string Path { get; set; }
    }
}
