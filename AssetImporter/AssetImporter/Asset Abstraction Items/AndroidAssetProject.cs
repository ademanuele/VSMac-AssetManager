using System.Collections.Generic;
using MonoDevelop.Projects;
using AssetImporter.AssetParsers.Android;

namespace AssetImporter.AssetAbstractionItems
{
    class AndroidAssetProject : AssetProject
    {
        AndroidProjectAssetParser Parser { get; }

        public AndroidAssetProject(Project project) : base(project)
        {
            Parser = new AndroidProjectAssetParser(project);
        }

        internal override List<ProjectAsset> ParseAssets()
        {
            List<ProjectAsset> assets = new List<ProjectAsset>();
            var drawables = Parser.Retreive();

            foreach (var drawable in drawables)
                assets.Add(new AndroidProjectAsset(drawable, Project));

            return assets;
        }

        internal override void Add(ProjectAsset asset)
        {
			var drawable = new Drawable { Name = asset.Name };
            drawable.AssetPaths.Add(Drawable.DrawableDPI.HDPI, asset.Asset1x.Path);
            drawable.AssetPaths.Add(Drawable.DrawableDPI.XHDPI, asset.Asset2x.Path);
            drawable.AssetPaths.Add(Drawable.DrawableDPI.XXHDPI, asset.Asset3x.Path);
            Parser.Add(drawable);
        }

        internal override void Delete(ProjectAsset asset)
        {
            var androidAsset = asset as AndroidProjectAsset;
			Parser.Delete(androidAsset.Drawable);
        }
    }

    class AndroidProjectAsset : ProjectAsset
    {
        public string Name => Drawable.Name;
        public AssetItem Asset1x => new AssetItem { Path = Drawable.AssetPaths[Drawable.DrawableDPI.HDPI] };
        public AssetItem Asset2x => new AssetItem { Path = Drawable.AssetPaths[Drawable.DrawableDPI.XXHDPI] };
        public AssetItem Asset3x => new AssetItem { Path = Drawable.AssetPaths[Drawable.DrawableDPI.XXHDPI] };

        public Drawable Drawable { get; }
        public Project Project { get; }

        public AndroidProjectAsset(Drawable drawable, Project project) {
            Project = project;
            Drawable = drawable;
        }
    }
}
