using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	class Nemesis : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Nemesis";
			item.toolTip = "Cave Story weapon";

			item.useStyle = 6;
			item.useAnimation = 9;
			item.useTime = 8;
			// item.autoReuse = true;
			item.width = 33;
			item.height = 15;
			item.shoot = mod.ProjectileType("NemesisLv3Shot");
			item.useAmmo = 14;
			item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/NemesisSound");
			//  ErrorLogger.Log("~" + item.shoot);
			item.damage = 45;
			item.shootSpeed = 12f; //12
			item.noMelee = true;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.ranged = true;
			item.rare = 8;
			item.knockBack = 3f;
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
			Main.projectile[a].scale = 2;
			Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();
			Main.projectile[a].frame = dir * 2;
			//Main.projectile[a].width = 1;
			//Main.projectile[a].height = 1;

			int dust = Dust.NewDust(position, 0, 0, mod.DustType("StarMuzzleFlash"));
			Main.dust[dust].scale = 2;
			Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);

			return false;
		}

		public override void UseStyle(Player player)
		{
			player.itemLocation.X = player.position.X + (float)player.width * 0.5f;// - (float)Main.itemTexture[item.type].Width * 0.5f;// - (float)(player.direction * 2);
			player.itemLocation.Y = player.MountedCenter.Y + player.gravDir * (float)Main.itemTexture[item.type].Height * 0.5f;

			float relativeX = (float)Main.mouseX + Main.screenPosition.X - player.Center.X;
			float relativeY = (float)Main.mouseY + Main.screenPosition.Y - player.Center.Y;
			if (player.gravDir == -1f)
			{
				relativeY = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - player.Center.Y;
			}

			if (relativeX - relativeY > 0)
			{
				if (relativeX + relativeY > 0)
				{
					player.itemRotation = 0;
				}
				else
				{

					player.itemRotation = player.direction * -MathHelper.Pi / 2;
					player.itemLocation.X += player.direction * 6;
					player.itemLocation.Y -= 10;
				}
			}
			else
			{
				if (relativeX + relativeY > 0)
				{
					player.itemRotation = player.direction * MathHelper.Pi / 2;
					player.itemLocation.X += player.direction * 6;
				}
				else
				{
					player.itemRotation = 0;
				}
			}
		}

		public override bool UseItemFrame(Player player)
		{
			float num18 = player.itemRotation * (float)player.direction;
			player.bodyFrame.Y = player.bodyFrame.Height * 3;
			if ((double)num18 < -0.75)
			{
				player.bodyFrame.Y = player.bodyFrame.Height * 2;
				if (player.gravDir == -1f)
				{
					player.bodyFrame.Y = player.bodyFrame.Height * 4;
				}
			}
			if ((double)num18 > 0.6)
			{
				player.bodyFrame.Y = player.bodyFrame.Height * 4;
				if (player.gravDir == -1f)
				{
					player.bodyFrame.Y = player.bodyFrame.Height * 2;
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 10);
			//recipe.AddCraftGroup(CraftGroup.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
