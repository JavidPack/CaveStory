using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
    class NemesisLv3Shot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "NemesisLv3Shot";
            projectile.width = 32;
            projectile.height = 16;
            // projectile.aiStyle = 78;          
            projectile.friendly = true;
            //    projectile.alpha = (int)byte.MaxValue;
            //     projectile.scale = 6f;
            projectile.ranged = true;
            projectile.ignoreWater = true;

            projectile.penetrate = -1;
            //  projectile.extraUpdates = 1;

            //    Main.projFrames[projectile.type] = 4;
            projectile.timeLeft = 30;
        }

        public override void Kill(int timeLeft)
        {
            int dust = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("StarMuzzleFlash"));
            Main.dust[dust].scale = 2;
            Main.dust[dust].position = projectile.Center - Main.dust[dust].scale * new Vector2(4, 4);
        }

        public override void AI()
        {
            if (projectile.frameCounter % 10 == 0)
            {

                int dust = Dust.NewDust(projectile.Center, 0, 0, mod.DustType("NemesisSmoke"));
                Main.dust[dust].scale = 2;
                Main.dust[dust].position = projectile.Center - Main.dust[dust].scale * new Vector2(4, 4);
                if (projectile.frame == 0 || projectile.frame == 1 || projectile.frame == 4 || projectile.frame == 5)
                {
                    Main.dust[dust].velocity.X = projectile.velocity.X * .1f;
                    Main.dust[dust].velocity.Y = projectile.velocity.X * (Main.rand.NextFloat() - .5f) * .2f;
                }
                else
                {
                    Main.dust[dust].velocity.Y = projectile.velocity.Y * .1f;
                    Main.dust[dust].velocity.X = projectile.velocity.Y * (Main.rand.NextFloat() - .5f) * .2f;
                }
            }
            projectile.frameCounter++;
            if (projectile.frameCounter % 4 == 0)
            {
                if (projectile.frame % 2 == 0)
                {
                    projectile.frame = projectile.frame + 1;
                }
                else
                {
                    projectile.frame = projectile.frame - 1;
                }
                // projectile.frameCounter = 0;
            }
           

            float light = 0.35f * projectile.scale;// * (projectile.frame + 1 / 4f);
            Lighting.AddLight(projectile.Center, light, light, light);
        }

        // lv 3: 0,0
        // lv 2: 128, 0
        // lv 1: 0, 32
        // left: 0,0
        // up: 32,0
        // right: 64, 0
        // down : 96,0
        // 2ndA: 16,0
        // 2ndB: 0,16

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2();// = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            projectile.rotation = 0;
            Color color = projectile.GetAlpha(lightColor);// * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
            Rectangle? r;// = new Rectangle?(new Rectangle(0, projectile.frame * (projectile.height + 2), projectile.width, projectile.height));

            switch (projectile.frame)
            {
                case 0:
                    r = new Rectangle?(new Rectangle(0, 0, 32, 16));
                    drawOrigin = new Vector2(0, 8);
                    break;
                case 1:
                    r = new Rectangle?(new Rectangle(0, 16, 32, 16));
                    drawOrigin = new Vector2(0, 8);

                    break;
                case 2:
                    r = new Rectangle?(new Rectangle(34, 0, 16, 32));
                    //   drawOrigin = new Vector2(8, 0);
                    break;
                case 3:
                    r = new Rectangle?(new Rectangle(50, 0, 16, 32));
                    //    drawOrigin = new Vector2(8, 0);
                    break;
                case 4:
                    r = new Rectangle?(new Rectangle(68, 0, 32, 16));
                    drawOrigin = new Vector2(32, 8);

                    break;
                case 5:
                    r = new Rectangle?(new Rectangle(68, 16, 32, 16));
                    drawOrigin = new Vector2(32, 8);

                    break;
                case 6:
                    r = new Rectangle?(new Rectangle(102, 0, 16, 32));
                    drawOrigin = new Vector2(0, 32);
                    break;
                case 7:
                    r = new Rectangle?(new Rectangle(118, 0, 16, 32));
                    drawOrigin = new Vector2(0, 32);
                    break;
                default:
                    //ErrorLogger.Log("Problem");
                    r = new Rectangle?(new Rectangle(0, projectile.frame * (projectile.height + 2), projectile.width, projectile.height));
                    break;
            }
            //  drawOrigin = new Vector2();

            Vector2 drawPos = projectile.position - Main.screenPosition + drawOrigin;// + new Vector2(0f, projectile.gfxOffY);

            spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, r, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            //spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, new Rectangle?(new Rectangle(0, projectile.frame*(projectile.height+2), projectile.width,projectile.height)), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);

            return false;
        }
    }
}
