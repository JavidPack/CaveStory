using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace CaveStory.Projectiles
{
	public class PolarStarBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Polar Star Bullet");     //The English name of the projectile
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}

		public override void SetDefaults()
		{
			projectile.width = 16;               //The width of projectile hitbox
			projectile.height = 32;              //The height of projectile hitbox
			projectile.aiStyle = 0;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 120;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.alpha = 0;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			projectile.light = 1f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			projectile.velocity.Y = projectile.velocity.Y + 0.0f; // 0.1f for arrow gravity, 0.4f for knife gravity
			if (projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
			{
				projectile.velocity.Y = 16f;
			}
		}

	}
}