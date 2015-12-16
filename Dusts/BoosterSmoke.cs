using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Dusts
{
    class BoosterSmoke : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
            dust.frame = new Rectangle(0, 0, 8, 8);
            dust.alpha = 0;
        }

        const int frametime = 5;

        public override bool Update(Dust dust)
        {
            dust.alpha += 1;
            if (dust.alpha == frametime)
            {
                dust.frame = new Rectangle(0, 10, 8, 8);
            }
            if (dust.alpha == 2 * frametime)
            {
                dust.frame = new Rectangle(0, 20, 8, 8);
            }
            if (dust.alpha == 3 * frametime)
            {
                dust.frame = new Rectangle(0, 30, 8, 8);
            }
            if (dust.alpha == 4 * frametime)
            {
                dust.frame = new Rectangle(0, 40, 8, 8);
            }
            if (dust.alpha == 5 * frametime)
            {
                dust.frame = new Rectangle(0, 50, 8, 8);
            }
            if (dust.alpha == 6 * frametime)
            {
                dust.frame = new Rectangle(0, 60, 8, 8);
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
