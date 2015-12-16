using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
    public class BubblineLv2Shot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "BubblineLv2Shot";
            projectile.width = 8;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 60;
            Main.projFrames[projectile.type] = 4;
        }

        public override void Kill(int timeLeft)
        {
            int dust = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("BubblineLv12Pop"));
            Main.dust[dust].position = projectile.Center - new Vector2(2, 2);

            Main.dust[dust].scale = 2;// Main.rand.Next(1,5);
        }

      //  public override bool OnTileCollide(Vector2 oldVelocity)
      //  {
      //      bool xOK = false;
      //      bool yOK = false;
      //      //If incidental, zero out?
      //      if (projectile.velocity.X != oldVelocity.X)
      //      {
      //          if(projectile.oldVelocity.X * projectile.oldVelocity.X < projectile.oldVelocity.Y * projectile.oldVelocity.Y)
      //          {
      //              return false;
      //          }
      //      }
      //      if (projectile.velocity.Y != oldVelocity.Y)
      //      {
      //          if (projectile.velocity.X * projectile.velocity.X > projectile.oldVelocity.Y * projectile.oldVelocity.Y)
      //          {
      //              return false;
      //          }
      //      }
      ////      if (xOK && yOK)
      // //         return false;

      //      return false;
      //  }

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
            projectile.velocity = projectile.velocity * .98f;


            float light = 0.35f * projectile.scale;
            Lighting.AddLight(projectile.Center, light, light, light);

        }
    }
}