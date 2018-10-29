using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Imaging;
using MonoDevelop.Projects;

namespace AssetImporter.AssetAbstractionItems
{
    class UnpersistedProjectAsset : ProjectAsset
    {
        static ImageFormat IMAGE_FORMAT = ImageFormat.Png;

        string name;
        public string Name { get => throw new NotImplementedException(); private set => name = value; }
        public AssetItem Asset1x => assetItems[0];
        public AssetItem Asset2x => assetItems[1];
        public AssetItem Asset3x => assetItems[2];

        public Image BaseImage { get; private set; }
		public Project Project => null;

        AssetItem[] assetItems;

        UnpersistedProjectAsset() { }

        public static UnpersistedProjectAsset FromImage(string name, Image image)
        {
            var asset = new UnpersistedProjectAsset { Name = name, BaseImage = image };
            asset.assetItems = new AssetItem[3];

            var tempPath = Path.GetTempPath();
            var resolutions = ResolutionsForImage(image);

            for (int i = resolutions.Count - 1; i > -1; i--)
            {
                var assetBitmap = ImageService.ResizeImage(image, resolutions[i]);
                var path = tempPath + FilenameForResolution(name, i);
                assetBitmap.Save(path, IMAGE_FORMAT);
                asset.assetItems[i] = new AssetItem { Path = path };
            }

            return asset;
        }

        static string FilenameForResolution(string assetName, int resolution) {
            return assetName + resolution + IMAGE_FORMAT;
        }

        static List<ImageService.Resolution> ResolutionsForImage(Image image)
        {
            var resolutions = new List<ImageService.Resolution>();
            for (int i = 1; i < 4; i++)
            {
                resolutions.Add(new ImageService.Resolution
                {
                    Width = image.Width / i,
                    Height = image.Height / i
                });
            }

            return resolutions;
        }
    }
}
