using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
    class FireballLv3Shot : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FireballLv3Shot");
        }
        public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			//  projectile.aiStyle = 8;          
			projectile.friendly = true;
			//    projectile.alpha = (int)byte.MaxValue;
			projectile.ranged = true;
			projectile.ignoreWater = true;

			Main.projFrames[projectile.type] = 29;

			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5 * a;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;

			// ErrorLogger.Log("~" + projectile.type);
			// projectile.extraUpdates = 3;

			projectile.timeLeft = 140;
		}

		public override void Kill(int timeLeft)
		{
			int dust = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("StarMuzzleFlash"));
			Main.dust[dust].scale = 2;
			Main.dust[dust].position = projectile.Center - Main.dust[dust].scale * new Vector2(4, 4);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//      projectile.penetrate--;
			//if (projectile.penetrate <= 0)
			//{
			//    projectile.Kill();
			//}
			//else
			//{
			//   projectile.ai[0] += 0.1f;
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
				if (projectile.velocity.Y < -3)
				{
					projectile.velocity.Y = -3;
				}
			}
			//   projectile.velocity *= .7f;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			//  }
			return false;
		}

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter == 2)
			{
				projectile.frame = 1;
			}
			if (projectile.frameCounter == 4)
			{
				projectile.frame = 2;
			}
			if (projectile.frameCounter == 6)
			{
				projectile.frame = 0;
				projectile.frameCounter = 0;
			}
			// Gravity
			projectile.velocity.Y += .1f;
			//  projectile.

			float light = 0.35f * projectile.scale;// * (projectile.frame + 1 / 4f);
			Lighting.AddLight(projectile.Center, light, light, light);
		}

		// 1 solid white 0,1,2
		//  1  white
		//  2 light blue
		// 2  blue
		//
		const int a = 2;

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k += a)
			{
				//if (k % a != 0)
				//{
				//    continue;
				//}
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor);// * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				Rectangle? r;// = new Rectangle?(new Rectangle(0, projectile.frame * (projectile.height + 2), projectile.width, projectile.height));
				switch (k)
				{
					case 0:
						r = new Rectangle?(new Rectangle(0, projectile.frame * (projectile.height + 2), projectile.width, projectile.height));
						break;
					case a:
						r = new Rectangle?(new Rectangle(0, ((projectile.frame + 1) % 3 + 12) * (projectile.height + 2), projectile.width, projectile.height));
						break;
					case 2 * a:
						r = new Rectangle?(new Rectangle(0, ((projectile.frame + 2) % 3 + 15) * (projectile.height + 2), projectile.width, projectile.height));
						break;
					case 3 * a:
						r = new Rectangle?(new Rectangle(0, ((projectile.frame + 3) % 3 + 15) * (projectile.height + 2), projectile.width, projectile.height));
						break;
					case 4 * a:
						r = new Rectangle?(new Rectangle(0, ((projectile.frame + 1) % 3 + 18) * (projectile.height + 2), projectile.width, projectile.height));
						break;
					case 5 * a:
						r = new Rectangle?(new Rectangle(0, ((projectile.frame + 2) % 3 + 18) * (projectile.height + 2), projectile.width, projectile.height));
						break;
					default:
						//   ErrorLogger.Log("Problem");
						r = new Rectangle?(new Rectangle(0, projectile.frame * (projectile.height + 2), projectile.width, projectile.height));
						break;
				}
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, r, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
				//spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle?(new Rectangle(0, projectile.frame*(projectile.height+2), projectile.width,projectile.height)), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}

		//public override bool Autoload(ref string name, ref string texture)
		//{
		//    texture = "CaveStory/Projectiles/FireballLv3Shot";
		//    name = "FireballLv3Shot";
		//    return false;
		//}
	}
}
