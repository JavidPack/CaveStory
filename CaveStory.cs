using Terraria.ModLoader;

namespace CaveStory
{
	class CaveStory : Mod
	{
		public override void SetModInfo(out string name, ref ModProperties properties)
		{
			name = "CaveStory";
			properties.Autoload = true;
			properties.AutoloadGores = true;
			properties.AutoloadSounds = true;
		}
	}
}
