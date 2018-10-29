using System.Collections.Generic;
using System.IO;
using System.Linq;
using MonoDevelop.Projects;
using static AssetImporter.AssetParsers.Android.Drawable;

namespace AssetImporter.AssetParsers.Android
{
    class AndroidProjectAssetParser
    {
        public Project Project { get; }
        public string ProjectPath { get; }
        string ResourcesRootPath { get; }

        const string ResourcesDirectory = "Resources";
        Dictionary<DrawableDPI, string> ResourceDirectories = new Dictionary<DrawableDPI, string> {
            { DrawableDPI.HDPI, "mipmap-hdpi" },
            { DrawableDPI.XHDPI, "mipmap-xhdpi" },
            { DrawableDPI.XXHDPI, "mipmap-xxhdpi" }
        };

        public AndroidProjectAssetParser(Project project)
        {
            Project = project;
            ProjectPath = Path.GetDirectoryName(project.FileName);
            ResourcesRootPath = ProjectPath + "/" + ResourcesDirectory;
        }

        public List<Drawable> Retreive()
        {
            Dictionary<string, Drawable> drawables = new Dictionary<string, Drawable>();

            foreach (var dpi in ResourceDirectories.Keys)
            {
                var resourceDirectory = ResourcesRootPath + "/" + ResourceDirectories[dpi];
                var assets = Directory.GetFiles(resourceDirectory);
                foreach (var asset in assets)
                {
                    var name = NameForAssetFile(asset);
                    if (!drawables.ContainsKey(name))
                        drawables[name] = new Drawable { Name = name };

                    drawables[name].AssetPaths[dpi] = asset;
                }
            }

            return drawables.Values.ToList();
        }

        string NameForAssetFile(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public void Delete(Drawable drawable)
        {
            foreach (var assetItem in drawable.AssetPaths)
            {
                Project.Files.Remove(assetItem.Value);
                File.Delete(assetItem.Value);
            }
        }

        public void Add(Drawable drawable)
        {

        }
    }

    class Drawable
    {
        public string Name { get; set; }
        public Dictionary<DrawableDPI, string> AssetPaths { get; }

        public Drawable()
        {
            AssetPaths = new Dictionary<DrawableDPI, string>();
        }

        public enum DrawableDPI
        {
            Drawable,
            HDPI,
            XHDPI,
            XXHDPI
        }
    }
}
