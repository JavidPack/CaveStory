using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace CaveStory
{
	class CaveStory : Mod
	{
		//public override void SetModInfo(out string name, ref ModProperties properties)
		//{
		//	name = "CaveStory";
		//	properties.Autoload = true;
		//	properties.AutoloadGores = true;
		//	properties.AutoloadSounds = true;
		//}

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
