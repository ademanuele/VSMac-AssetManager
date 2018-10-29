using System;
using System.Collections.Generic;
using AssetImporter.AssetParsers.iOS;
using MonoDevelop.Projects;

namespace AssetImporter.AssetAbstractionItems
{
    class IOSAssetProject : AssetProject
    {
        IOSProjectAssetParser Parser { get; }

        public IOSAssetProject(Project project) : base(project)
        {
            Parser = new IOSProjectAssetParser(project);
        }

        internal override List<ProjectAsset> ParseAssets()
        {
            List<ProjectAsset> assets = new List<ProjectAsset>();
            var imageSets = Parser.Retreive();
            foreach (var imageSet in imageSets)
                assets.Add(new IOSProjectAsset(imageSet, Project));

            return assets;
        }

        internal override void Add(ProjectAsset image)
        {
            throw new NotImplementedException();
        }

        internal override void Delete(ProjectAsset asset)
        {
            throw new NotImplementedException();
        }
    }

    class IOSProjectAsset : ProjectAsset
    {
        public string Name => ImageSet.Name;
        public AssetItem Asset1x => new AssetItem { Path = ImageSet.UniversalX1Filename };
        public AssetItem Asset2x => new AssetItem { Path = ImageSet.UniversalX2Filename };
        public AssetItem Asset3x => new AssetItem { Path = ImageSet.UniversalX3Filename };

        public ImageSet ImageSet { get; }
        public Project Project { get; }

        public IOSProjectAsset(ImageSet imageset, Project project) {
            ImageSet = imageset;
            Project = project;
        }
    }
}
