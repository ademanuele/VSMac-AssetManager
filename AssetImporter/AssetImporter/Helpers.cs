using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using AssetImporter.AssetAbstractionItems;

namespace AssetImporter
{
	static class Helpers
	{
		public static string FromResource(string resourceId)
		{
			var assembly = Assembly.GetExecutingAssembly();

			using (Stream stream = assembly.GetManifestResourceStream(resourceId))
			using (StreamReader reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
