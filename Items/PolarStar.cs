using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	public class PolarStar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("PolarStar"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It carries the mark of the Northern Star");
		}

		public override void SetDefaults() 
		{
			item.damage = 7;
			item.ranged = true;
			item.width = 48;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 1;
			item.noMelee = true;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("PolarStarBullet");
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PolarStarShoot");
			item.shootSpeed = 10f;

		}
		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			WeaponUtilities.DrawExperienceBar(this);
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int dir = 0;
			if (speedX - speedY > 0)
			{
				if (speedX + speedY > 0)
				{
					dir = 2;
					speedX = item.shootSpeed;
					speedY = 0;
				}
				else
				{
					dir = 1;
					speedY = -item.shootSpeed;
					speedX = 0;
				}
			}
			else
			{
				if (speedX + speedY > 0)
				{
					dir = 3;
					speedY = item.shootSpeed;
					speedX = 0;
					//    position.X += player.direction * 10f * item.scale;
				}
				else
				{
					dir = 0;
					speedX = -item.shootSpeed;
					speedY = 0;
				}
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
			int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, item.shoot, item.damage, item.knockBack, item.owner, 0f, 0f);
			Main.projectile[a].scale = 1;
			Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();
			Main.projectile[a].frame = dir * 2;
			//Main.projectile[a].width = 1;
			//Main.projectile[a].height = 1;

			int dust = Dust.NewDust(position, 0, 0, mod.DustType("StarMuzzleFlash"));
			Main.dust[dust].scale = 2;
			Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);

			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}