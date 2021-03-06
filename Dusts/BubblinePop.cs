﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Dusts
{
	internal class BubblinePop : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			// Projectiles:
			// 1. set default
			// 2. this.width = (int)((float)this.width * this.scale);  this.height = (int)((float)this.height * this.scale);
			// 3. projectile.position.X = X - (float)projectile.width * 0.5f;  projectile.position.Y = Y - (float)projectile.height * 0.5f;

			dust.noGravity = true;
			dust.noLight = true;
			//   dust.scale = Main.rand.Next(1, 6);
			dust.frame = new Rectangle(0, 0, 16, 16);
			dust.alpha = 0;
			dust.velocity = new Vector2(0, -1);
			//  dust.position.X -= 4;
			//  dust.position.Y -= 4;

			//   dust.position -= dust.scale * new Vector2(8, 8);
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;

			dust.alpha += 1;
			if (dust.alpha == 10)
			{
				dust.frame = new Rectangle(0, 18, 16, 16);
			}
			if (dust.alpha == 20)
			{
				dust.frame = new Rectangle(0, 36, 16, 16);
			}
			if (dust.alpha == 30)
			{
				dust.frame = new Rectangle(0, 54, 16, 16);
			}
			if (dust.alpha > 40)
			{
				dust.active = false;
			}

			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, light, light, light);

			// dust.rotation += dust.velocity.X;
			//// dust.scale -= 0.1f;
			// if (dust.scale < 0.5f)
			// {
			//     dust.active = false;
			// }
			// else
			// {
			//     float strength = dust.scale / 2f;
			//     Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), dust.color.R / 255f * 0.5f * strength, dust.color.G / 255f * 0.5f * strength, dust.color.B / 255f * 0.5f * strength);
			// }

			return false;
		}
	}
}