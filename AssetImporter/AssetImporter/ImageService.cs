using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace AssetImporter
{
    public static class ImageService
    {
        public struct Resolution {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public static List<Bitmap> DuplicateWithResolutions(Image image, List<Resolution> resolutions) {
            List<Bitmap> duplicates = new List<Bitmap>();
            foreach (var resolution in resolutions)
                duplicates.Add(ResizeImage(image, resolution.Width, resolution.Height));

            return duplicates;
        }

        public static Bitmap ResizeImage(Image image, Resolution resolution) {
            return ResizeImage(image, resolution.Width, resolution.Height);
        }

		public static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}
    }
}
