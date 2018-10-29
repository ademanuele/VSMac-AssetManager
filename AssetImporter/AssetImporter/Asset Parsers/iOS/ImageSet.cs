using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Globalization;

namespace AssetImporter.AssetParsers.iOS
{
    class ImageSet
    {
        const string ContentsName = "Contents.json";

        public string Name { get; }
        public string Path { get; private set; }
        public string ContentsPath { get => Path + "/" + ContentsName; }
        public bool Valid { get => Contents != null; }
        public ImageSetContents Contents { get; private set; }

        public string UniversalX1Filename
        {
            get => GetFilepathForIdiomAndScale("universal", "1x");
            set => SetFileNameForIdiomAndScale(value, "universal", "1x");
        }

        public string UniversalX2Filename
        {
            get => GetFilepathForIdiomAndScale("universal", "2x");
            set => SetFileNameForIdiomAndScale(value, "universal", "2x");
        }

        public string UniversalX3Filename
        {
            get => GetFilepathForIdiomAndScale("universal", "3x");
            set => SetFileNameForIdiomAndScale(value, "universal", "3x");
        }

        ImageSet() { }

        public ImageSet(string path)
        {
            Name = NameFromPath(path);
            Path = path;
            ParseContents();
        }

        string NameFromPath(string path) {
            return System.IO.Path.GetFileNameWithoutExtension(path);
        }

        void ParseContents()
        {
            try
            {
                var contents = File.ReadAllText(ContentsPath);
                Contents = JsonConvert.DeserializeObject<ImageSetContents>(contents);
            }
            catch (Exception)
            {
                Contents = null;
            }
        }

        string GetFilepathForIdiomAndScale(string idiom, string scale) {
            var imagePath = ImageForIdiomAndScale(idiom, scale).filename;
            if (string.IsNullOrEmpty(imagePath))
                return null;

            return Path + "/" + imagePath;
        }

        string GetFilenameForIdiomAndScale(string idiom, string scale)
        {
            return ImageForIdiomAndScale(idiom, scale).filename;
        }

        void SetFileNameForIdiomAndScale(string filename, string idiom, string scale)
        {
            ImageForIdiomAndScale(idiom, scale).filename = filename;
        }

        ImageSetContents.Image ImageForIdiomAndScale(string idiom, string scale)
        {
            var t = Contents.images.FirstOrDefault(i => (i.idiom != null && i.idiom == idiom && i.scale != null && i.scale == scale));
            return t;
        }

        void CheckValid()
        {
            if (!Valid)
                throw new InvalidOperationException("Attempting to perform operation on invalid iOS ImageSet.");
        }

        public static ImageSet MakeDefaultForPath(string path)
        {
            return new ImageSet
            {
                Path = path,
                Contents = ImageSetContents.Default
            };
        }
    }

    class ImageSetContents
    {
        public List<Image> images { get; set; }
        public Info info { get; set; }

        public class Image
        {
            public string idiom { get; set; }
            public string filename { get; set; }
            public string scale { get; set; }
            public string subtype { get; set; }
            public string screenWidth { get; set; }
        }

        public class Info
        {
            public int version { get; set; }
            public string author { get; set; }
        }

        static string defaultContentsId = "AssetImporter.Asset_Retreivers.iOS.default_contents.json";
        static ImageSetContents defaultContents;
        public static ImageSetContents Default
        {
            get
            {
                if (defaultContents == null)
                {
                    var defaultJson = Helpers.FromResource(defaultContentsId);
                    defaultContents = JsonConvert.DeserializeObject<ImageSetContents>(defaultJson);
                }
                return defaultContents;
            }
        }
    }
}
