using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
	public class BubblineLv1Shot : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "BubblineLv1Shot";
			//projectile.name = "Xenopopper";
			projectile.width = 8;
			projectile.height = 8;
			// projectile.aiStyle = 78;          
			projectile.friendly = true;
			//   projectile.alpha = (int)byte.MaxValue;
			//     projectile.scale = 6f;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			//  projectile.extraUpdates = 1;
			projectile.timeLeft = 40;
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
			int dust = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("BubblineLv12Pop"));
			Main.dust[dust].position = projectile.Center - new Vector2(2, 2);

			Main.dust[dust].scale = 2;// Main.rand.Next(1,5);
		}

		//public override bool OnTileCollide(Vector2 oldVelocity)
		//{
		//    //      projectile.penetrate--;
		//    if (projectile.penetrate <= 0)
		//    {
		//        projectile.Kill();
		//    }
		//    else
		//    {
		//        //   projectile.ai[0] += 0.1f;
		//        if (projectile.velocity.X != oldVelocity.X)
		//        {
		//            projectile.velocity.X = -oldVelocity.X;
		//        }
		//        if (projectile.velocity.Y != oldVelocity.Y)
		//        {
		//            projectile.velocity.Y = -oldVelocity.Y;
		//        }
		//        projectile.velocity *= .7f;
		//        Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		//    }
		//    return false;
		//}


		public override void AI()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter == 5)
			{
				projectile.frame = 1;
			}
			if (projectile.frameCounter == 10)
			{
				projectile.frame = 2;
			}
			if (projectile.frameCounter == 15)
			{
				projectile.frame = 3;
			}

			projectile.position += projectile.velocity;
			projectile.velocity = projectile.velocity * .93f;


			float light = 0.35f * projectile.scale;
			Lighting.AddLight(projectile.Center, light, light, light);

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