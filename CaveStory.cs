using Terraria.ModLoader;

namespace CaveStory
{
	class CaveStory : Mod
	{
		public CaveStory()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
