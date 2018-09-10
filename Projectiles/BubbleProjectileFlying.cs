using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
	public class BubbleProjectileFlying : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BubbleProjectileFlying");
        }
        public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			// projectile.aiStyle = 0;
			projectile.friendly = true;
			//  projectile.alpha = (int)byte.MaxValue;
			//   projectile.scale = 4f;
			projectile.ranged = true;
			projectile.ignoreWater = true;

			Main.projFrames[projectile.type] = 4;
			//  projectile.extraUpdates = 1;
			//     ErrorLogger.Log("1 projectile.position" + projectile.position);
			//  projectile.position += projectile.scale * new Vector2(4, 4);
			//   ErrorLogger.Log("2 projectile.position" + projectile.position);
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter > 4)
			{
				if (projectile.velocity.X != 0)
				{
					projectile.frame = projectile.frame == 2 ? 3 : 2;
				}
				else
				{
					projectile.frame = projectile.frame == 0 ? 1 : 0;
				}
				projectile.frameCounter = 0;
			}

			float light = 0.35f * projectile.scale;
			Lighting.AddLight(projectile.Center, light, light, light);

		}

	}
}
