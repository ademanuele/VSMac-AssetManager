using Gtk;

namespace AssetImporter.AddinItems
{
    public static class ImageFileFilter
    {
        static string[] ImageFormats = { "jpg", "png", "bmp" };

        public static FileFilter Filter => MakeImageFileFilter();

        static FileFilter MakeImageFileFilter() {
            FileFilter filter = new FileFilter();
            foreach (string format in ImageFormats)
                filter.AddPattern("*." + format);

            return filter;
        }

    }
}
