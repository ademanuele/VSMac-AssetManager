using System;
using System.Collections.Generic;
using MonoDevelop.Projects;

namespace AssetImporter.AssetAbstractionItems
{
	abstract class AssetProject
	{
		public static readonly Dictionary<string, Type> Supported = new Dictionary<string, Type>{
			{ "Xamarin.iOS", typeof(IOSAssetProject) },
			{ "MonoAndroid", typeof(AndroidAssetProject) }
		};

		public Project Project { get; }

        List<ProjectAsset> assets;
        public List<ProjectAsset> Assets => assets ?? (assets = ParseAssets());

		public AssetProject(Project project)
		{
			Project = project;
		}

		internal abstract List<ProjectAsset> ParseAssets();
        internal abstract void Add(ProjectAsset image);
        internal abstract void Delete(ProjectAsset asset);

        public static AssetProject ForProject(Project project)
        {
            if (!IsSupported(project))
                throw new NotSupportedException("Project does not target any supported framework.");

			var type = Supported[ProjectFrameworkId(project as DotNetProject)];
			return (AssetProject)Activator.CreateInstance(type, project);
		}

		static bool IsSupported(Project project)
		{
			if (!(project is DotNetProject))
				return false;

			var frameworkId = ProjectFrameworkId(project as DotNetProject);
            if (!Supported.ContainsKey(frameworkId))
				return false;

			return true;
		}

		static string ProjectFrameworkId(DotNetProject project)
		{
			return project.TargetFramework.Id.Identifier;
		}
	}
}
