using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Projectiles
{
    class MachineGunLv3Shot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "MachineGunLv3Shot";
            projectile.width = 44;
            projectile.height = 8;
            // projectile.aiStyle = 78;          
            projectile.friendly = true;
            //    projectile.alpha = (int)byte.MaxValue;
            //     projectile.scale = 6f;
            projectile.ranged = true;
            projectile.ignoreWater = true;
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
            float light = 0.35f * projectile.scale;
            Lighting.AddLight(projectile.Center, light, light, light);
        }
    }
}
