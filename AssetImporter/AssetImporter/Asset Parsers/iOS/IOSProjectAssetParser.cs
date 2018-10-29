using System;
using System.Collections.Generic;
using System.IO;
using MonoDevelop.Projects;

namespace AssetImporter.AssetParsers.iOS
{
    class IOSProjectAssetParser
	{
        const string AssetCatalogName = "Assets.xcassets";
        const string ImageSetName = ".imageset";

        public Project Project { get; }
        public string ProjectPath { get; }
        public string AssetCatalogue { get; }

        public IOSProjectAssetParser(Project project)
        {
            Project = project;
            ProjectPath = Path.GetDirectoryName(project.FileName);
            AssetCatalogue = ProjectPath += "/" + AssetCatalogName;

            if (!Directory.Exists(AssetCatalogue))
                throw new NotSupportedException("iOS at " + project + "Project does not contain an Asset Catalogue.");
        }

        public List<ImageSet> Retreive()
        {
            var imageSetPaths = Directory.GetDirectories(AssetCatalogue, "*" + ImageSetName);

            var imageSets = new List<ImageSet>();
            foreach (var path in imageSetPaths)
                imageSets.Add(new ImageSet(path));

            return imageSets;
        }

        public void Delete(ImageSet imageSet) {
            
        }
    }
}
