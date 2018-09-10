using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
	public class BubbleProjectile : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BubbleProjectile");
        }
        public override void SetDefaults()
		{
			//projectile.name = "Xenopopper";
			projectile.width = 8;
			projectile.height = 8;
			// projectile.aiStyle = 78;          
			projectile.friendly = true;
			projectile.alpha = (int)byte.MaxValue;
			//     projectile.scale = 6f;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			//  projectile.extraUpdates = 1;

			Main.projFrames[projectile.type] = 4;

			//  projectile.position -= projectile.scale * new Vector2(4, 4);


			// 1. set default
			// 2. this.width = (int)((float)this.width * this.scale);  this.height = (int)((float)this.height * this.scale);
			// 3. projectile.position.X = X - (float)projectile.width * 0.5f;  projectile.position.Y = Y - (float)projectile.height * 0.5f;
			// i want at 5,5
			// scale = 10, position = 0,0? width 10,10
			//  width = 100, height = 100
			// position = -50, -50

		}


		public override void Kill(int timeLeft)
		{
			if (timeLeft <= 0)
				if (projectile.owner == Main.myPlayer)
				{
					Vector2 value13 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
					if (Main.player[projectile.owner].gravDir == -1f)
					{
						value13.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y;
					}
					Vector2 value14 = Vector2.Normalize(value13 - Main.player[projectile.owner].Center /*projectile.Center*/);

					// Main.player[projectile.owner].position

					value14 *= projectile.localAI[1];
					if (value14.X + value14.Y > 0)
					{
						if (value14.Y > value14.X)
						{
							//   ErrorLogger.Log("!  projectile.Center" + projectile.Center);
							int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, projectile.localAI[1], (int)projectile.localAI[0], projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
							//   ErrorLogger.Log("!2  projectile.Center" + Main.projectile[a].Center);
							//  Main.projectile[a].Center = projectile.Center;
							//   dust.position -= dust.scale * new Vector2(8, 8);
							//       ErrorLogger.Log("!2  projectile.Center" + Main.projectile[a].Center);
							Main.projectile[a].scale = 2;
						}
						else
						{
							int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.localAI[1], 0f, (int)projectile.localAI[0], projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
							// Main.projectile[a].Center = projectile.Center;
							Main.projectile[a].scale = 2;
						}
					}
					else
					{
						if (value14.Y > value14.X)
						{
							int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -projectile.localAI[1], 0f, (int)projectile.localAI[0], projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
							Main.projectile[a].scale = 2;
						}
						else
						{
							int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -projectile.localAI[1], (int)projectile.localAI[0], projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
							Main.projectile[a].scale = 2;
						}
					}
					//ErrorLogger.Log("platerpps" + Main.player[projectile.owner].position);
					//ErrorLogger.Log("playercnet" + Main.player[projectile.owner].Center);
					//ErrorLogger.Log("projectile.position.X, projectile.position.Y" + projectile.position);
					//ErrorLogger.Log("projectile.Center.X, projectile.Center.Y" + projectile.Center);
					//ErrorLogger.Log("projectile.w" + projectile.width);
					//ErrorLogger.Log("projectile.h" + projectile.height);
					//ErrorLogger.Log("projectile.s" + projectile.scale);

					//  Dust.NewDust(projectile.Center, 16, 16, mod., )

					int dust = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("BubblinePop"));
					Main.dust[dust].scale = 2;
					Main.dust[dust].position = projectile.Center - Main.dust[dust].scale * new Vector2(4, 4);

					Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/BubblinePopSound"));

					// x>y
					//  Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value14.X, value14.Y, (int)projectile.localAI[0], projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
				}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//      projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				//   projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= .7f;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}

		float m = 1f; // Mass 
		float R = 100f; // Rest length of spring
		float k = .0005f; // spring constant
		float b = .0f; // damping constant
		float g = .00f; // gravitational constant

		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter == 10)
			{
				projectile.frame = 1;
			}
			if (projectile.frameCounter == 20)
			{
				projectile.frame = 2;
			}
			if (projectile.frameCounter == 30)
			{
				projectile.frame = 3;
			}

			float light = 0.15f * projectile.scale * (projectile.frame + 1 / 4f);
			Lighting.AddLight(projectile.Center, light, light, light);

			float S; // Spring stretch, displacement from rest lenght
			float L; // length of spring
			L = Vector2.Distance(Main.player[projectile.owner].position, projectile.position);
			S = L - R;
			if (S > 0)
			{
				//  ErrorLogger.Log("projectile.Center" + projectile.Center);
				//   ErrorLogger.Log("Main.player[projectile.owner].Center" + Main.player[projectile.owner].Center);
				Vector2 value14 = Vector2.Normalize(Main.player[projectile.owner].position - projectile.position);
				//  Vector2 value14 = Vector2.Normalize(projectile.position - Main.player[projectile.owner].position);
				// A - B is from B to A
				// projectile.velocity.Y *=
				projectile.velocity += value14 * .1f;

				//   float ax = (-k / m) * S * value14.X - (b/m) * projectile.velocity.X;
				//   float ay = g+(-k / m) * S * value14.Y - (b / m) * projectile.velocity.Y;

				//  projectile.velocity.X += ax;
				//   projectile.velocity.Y += ay;
				// ErrorLogger.Log("projectile.velocity" + projectile.velocity);
				//      projectile.rotation = projectile.velocity.ToRotation();
			}
			else
			{
				if (projectile.velocity.Length() > 1f)
					projectile.velocity = projectile.velocity * .99f;
			}
			projectile.velocity.Y += .01f;
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 30;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}

			if (!Main.player[projectile.owner].channel)
			{
				projectile.timeLeft = 0;
			}
			if (Main.myPlayer == projectile.owner && projectile.timeLeft > 60)
			{
				projectile.timeLeft = 60;
				return;
			}
		}
	}
}




//public override void AI()
//{
//   // projectile.velocity.Y += projectile.ai[0];
//    if (Main.rand.Next(3) == 0)
//    {
//  //      ModDust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod, "Sparkle", projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
//    }
//}
//public override bool OnTileCollide(Vector2 oldVelocity)
//{
//    projectile.penetrate--;
//    if (projectile.penetrate <= 0)
//    {
//        projectile.Kill();
//    }
//    else
//    {
//        projectile.ai[0] += 0.1f;
//        if (projectile.velocity.X != oldVelocity.X)
//        {
//            projectile.velocity.X = -oldVelocity.X;
//        }
//        if (projectile.velocity.Y != oldVelocity.Y)
//        {
//            projectile.velocity.Y = -oldVelocity.Y;
//        }
//        projectile.velocity *= 0.75f;
//        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
//    }
//    return false;
//}

//public override void Kill(int timeLeft)
//{
//    for (int k = 0; k < 5; k++)
//    {
//        ModDust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod, "Sparkle", projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
//    }
//    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
//}

//public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
//{
//    projectile.ai[0] += 0.1f;
//    projectile.velocity *= 0.75f;
//}