using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Dusts
{
	class NemesisSmoke : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noGravity = true;
			dust.noLight = true;
			dust.frame = new Rectangle(0, 0, 16, 16);
			dust.alpha = 0;
		}

		const int frametime = 5;

		public override bool Update(Dust dust)
		{
			dust.alpha += 1;
			if (dust.alpha == frametime)
			{
				dust.frame = new Rectangle(0, 18, 16, 16);
			}
			if (dust.alpha == 2 * frametime)
			{
				dust.frame = new Rectangle(0, 36, 16, 16);
			}
			if (dust.alpha == 3 * frametime)
			{
				dust.frame = new Rectangle(0, 54, 16, 16);
			}
			if (dust.alpha == 4 * frametime)
			{
				dust.frame = new Rectangle(0, 72, 16, 16);
			}
			if (dust.alpha == 5 * frametime)
			{
				dust.frame = new Rectangle(0, 90, 16, 16);
			}
			if (dust.alpha == 6 * frametime)
			{
				dust.frame = new Rectangle(0, 108, 16, 16);
			}
			if (dust.alpha > 7 * frametime)
			{
				dust.active = false;
			}

			dust.position += dust.velocity;

			float light = 0.35f * dust.scale * ((20f - dust.alpha) / 20f);
			Lighting.AddLight(dust.position, light, light, light);

			return false;
		}
	}
}
