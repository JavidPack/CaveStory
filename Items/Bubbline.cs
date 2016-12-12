using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	public class Bubbline : ModItem
	{
		static int MaxBubbles = 15;
		int[] bubbles = new int[MaxBubbles];
		int bubblesIndex = 0;
		bool overCap = false;
		int proj = 1;
		public override void SetDefaults()
		{
			// Bubbline
			item.name = "Bubbline";
			item.toolTip = "Cave Story weapon, level up by collecting Bubbline Exps";

			item.channel = true;

			// Xenopoper
			item.useStyle = 6;
			//  item.holdStyle = 4;

			item.useAnimation = 12;
			item.useTime = 12;//21; //12
			item.autoReuse = true;
			// item.name = "Xenopopper";
			item.width = 33;
			item.height = 15;
			//item.scale = 4;
			item.shoot = mod.ProjectileType("BubbleProjectile");
			//item.shoot = 444;
			// 444 projectile defaults to Ai style 78, extraUpdates 1
			item.useAmmo = AmmoID.Bullet;
			//Terraria.ID.ProjectileID.Bullet
			//     item.glowMask = (short)38;
			// where is the code to use this?
			//item.useSound = 126;//95;
			//item.useSound = mod.SoundType("BubblineFire");
			//item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/BubblineFire");
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BubblineFire");
			item.damage = 45;
			item.shootSpeed = 12f; //12
			item.noMelee = true;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.ranged = true;
			item.rare = 8;
			item.knockBack = 3f;

			//   ErrorLogger.Log("use" + item.useStyle);

		}

		private int CurrentLevel(Player player)
		{
			CaveStoryPlayer modPlayer = (CaveStoryPlayer)player.GetModPlayer(mod, "CaveStoryPlayer");
			return modPlayer.BubblineLevel;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int level = CurrentLevel(player);

			if (level == 1)
			{
				ShootLv1(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);

			}
			else if (level == 2)
			{
				ShootLv2(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
			else
			{
				ShootLv3(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}

			//Vector2 dustposition = position;
			//// Adapted from Player.cs(23066):   
			//Vector2 vector2_4 = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
			//if (Collision.CanHit(position, 0, 0, position + vector2_4, 0, 0))
			//    position += vector2_4;
			//float ai0 = Utils.ToRotation(new Vector2(speedX, speedY));
			//// ai0 = 0;
			//float num8 = 2.094395f;
			//int num9 = Main.rand.Next(4, 5);
			//if (Main.rand.Next(4) == 0)
			//    ++num9;
			//num9 = 1;
			//for (int index1 = 0; index1 < num9; ++index1)
			//{
			//    float num10 = (float)(Main.rand.NextDouble() * 0.200000002980232 + 0.0500000007450581);
			//    Vector2 vector2_5 = Utils.RotatedBy(new Vector2(speedX, speedY), (double)num8 * Main.rand.NextDouble() - (double)num8 / 2.0, new Vector2()) * num10;
			//    //  ..  vector2_5 = new Vector2();
			//    int index2 = Projectile.NewProjectile(position.X, position.Y, vector2_5.X, vector2_5.Y, mod.ProjectileType("BubbleProjectile"), item.damage, item.knockBack, Main.myPlayer, ai0, 0.0f);

			//    Main.projectile[index2].scale = 2;

			//    if (speedX - speedY > 0)
			//    {
			//        if (speedX + speedY > 0)
			//        {
			//            speedX = 1;
			//            speedY = 0;
			//        }
			//        else
			//        {
			//            speedX = 0;
			//            speedY = -1;
			//        }
			//    }
			//    else
			//    {
			//        if (speedX + speedY > 0)
			//        {
			//            speedX = 0;
			//            speedY = 1;
			//        }
			//        else
			//        {
			//            speedX = -1;
			//            speedY = 0;
			//        }
			//    }
			//    dustposition += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;

			//    int dust = ModDust.NewDust(dustposition, 0, 0, mod, "StarMuzzleFlash");
			//    Main.dust[dust].scale = 2;
			//    Main.dust[dust].position = dustposition - Main.dust[dust].scale * new Vector2(4, 4);

			//    //  ErrorLogger.Log("~platerpps" + Main.player[Main.projectile[index2].owner].position);
			//    //  ErrorLogger.Log("~playercnet" + Main.player[Main.projectile[index2].owner].Center);
			//    //    ErrorLogger.Log("~projectile.position.X, projectile.position.Y" + Main.projectile[index2].position);
			//    //   ErrorLogger.Log("~ppsition" + position);
			//    //  ErrorLogger.Log("~projectile.Center.X, projectile.Center.Y" + Main.projectile[index2].Center);

			//    // Terraria.ID.ProjectileID.Bubble - shoots bubbles that pop.  410
			//    // Terraria.ID.ProjectileID.Xenopopper - 444 - shoots small purple bubbles, that spawn bullets when pop.
			//    // mod.ProjectileType("BubbleProjectile") -- mine
			//    proj++;
			//    bool canShoot = false;
			//    int num3 = 0;
			//    float num4 = 0;
			//    float speed = 0;
			//    player.PickAmmo(item, ref item.shoot, ref speed, ref canShoot, ref num3, ref num4, true);

			//    Main.projectile[index2].localAI[0] = mod.ProjectileType("BubbleProjectileFlying");//(float)item.shoot;
			//    Main.projectile[index2].localAI[1] = item.shootSpeed;//speed;

			//    bubbles[bubblesIndex] = index2;
			//    bubblesIndex++;
			//    if (bubblesIndex >= MaxBubbles) { overCap = true; }
			//    bubblesIndex = bubblesIndex % MaxBubbles;
			//}

			//if (!overCap)
			//{
			//    for (int i = 0; i < bubblesIndex; i++)
			//    {
			//        Main.projectile[bubbles[i]].timeLeft = 30;
			//        //ErrorLogger.Log("" + bubblesIndex);
			//    }
			//}
			//else
			//{
			//    for (int i = 0; i < MaxBubbles; i++)
			//    {
			//        Main.projectile[bubbles[i]].timeLeft = 30;
			//        // ErrorLogger.Log("" + bubblesIndex);
			//    }
			//}

			//note: Terraria.ID.ProjectileID.Xenopopper == 444   ai 78
			// 442 at some point.
			//      Terraria.ID.ItemID.Xenopopper == 2797

			return false;
		}

		public void ShootLv1(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (speedX - speedY > 0)
			{
				if (speedX + speedY > 0)
				{
					speedX = item.shootSpeed / 5;
					speedY = 0;// (Main.rand.NextFloat() - .5f) * 1.4f;
				}
				else
				{
					speedY = -item.shootSpeed / 5;
					speedX = 0;//(Main.rand.NextFloat() - .5f) * 1f;

					//if (player.gravDir == -1f)
					//{
					//    player.velocity.Y += 3.5f;
					//    if (player.velocity.Y < 0)
					//        player.velocity.Y = 0;
					//}
				}
			}
			else
			{
				if (speedX + speedY > 0)
				{
					speedY = item.shootSpeed / 5;
					speedX = 0;//(Main.rand.NextFloat() - .5f) * .8f;
							   //
							   //if (player.gravDir == 1f)
							   //{
							   //    player.velocity.Y -= 3.5f;
							   //    if (player.velocity.Y > 0)
							   //        player.velocity.Y = 0;
							   //}
				}
				else
				{
					speedX = -item.shootSpeed / 5;
					speedY = 0;//(Main.rand.NextFloat() - .5f) * .6f;
				}
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
			int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BubblineLv1Shot"), item.damage, item.knockBack, item.owner, 0f, 0f);
			Main.projectile[a].scale = 2;
			Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();



			int dust = Dust.NewDust(position, 0, 0, mod.DustType("StarMuzzleFlash"));
			Main.dust[dust].scale = 2;// (Main.rand.Next() * 12f);//  2;
			Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);
		}

		public void ShootLv2(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (speedX - speedY > 0)
			{
				if (speedX + speedY > 0)
				{
					speedX = item.shootSpeed / 2;
					speedY = (Main.rand.NextFloat() - .5f) * 2f;
				}
				else
				{
					speedY = -item.shootSpeed / 2;
					speedX = (Main.rand.NextFloat() - .5f) * 2f;
				}
			}
			else
			{
				if (speedX + speedY > 0)
				{
					speedY = item.shootSpeed / 2;
					speedX = (Main.rand.NextFloat() - .5f) * 2f;
				}
				else
				{
					speedX = -item.shootSpeed / 2;
					speedY = (Main.rand.NextFloat() - .5f) * 2f;
				}
			}
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
			int a = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BubblineLv2Shot"), item.damage, item.knockBack, item.owner, 0f, 0f);
			Main.projectile[a].scale = 2;
			Main.projectile[a].rotation = Main.projectile[a].velocity.ToRotation();



			int dust = Dust.NewDust(position, 0, 0, mod.DustType("StarMuzzleFlash"));
			Main.dust[dust].scale = 2;// (Main.rand.Next() * 12f);//  2;
			Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);
		}

		// TODo, change to owned, or timer perfectly????
		public void ShootLv3(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 dustposition = position;
			// Adapted from Player.cs(23066):   
			Vector2 vector2_4 = Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;
			if (Collision.CanHit(position, 0, 0, position + vector2_4, 0, 0))
				position += vector2_4;
			float ai0 = Utils.ToRotation(new Vector2(speedX, speedY));
			// ai0 = 0;
			float num8 = 2.094395f;
			int num9 = Main.rand.Next(4, 5);
			if (Main.rand.Next(4) == 0)
				++num9;
			num9 = 1;
			for (int index1 = 0; index1 < num9; ++index1)
			{
				float num10 = (float)(Main.rand.NextDouble() * 0.200000002980232 + 0.0500000007450581);
				Vector2 vector2_5 = Utils.RotatedBy(new Vector2(speedX, speedY), (double)num8 * Main.rand.NextDouble() - (double)num8 / 2.0, new Vector2()) * num10;
				//  ..  vector2_5 = new Vector2();
				int index2 = Projectile.NewProjectile(position.X, position.Y, vector2_5.X, vector2_5.Y, mod.ProjectileType("BubbleProjectile"), item.damage, item.knockBack, Main.myPlayer, ai0, 0.0f);

				Main.projectile[index2].scale = 2;

				if (speedX - speedY > 0)
				{
					if (speedX + speedY > 0)
					{
						speedX = 1;
						speedY = 0;
					}
					else
					{
						speedX = 0;
						speedY = -1;
					}
				}
				else
				{
					if (speedX + speedY > 0)
					{
						speedX = 0;
						speedY = 1;
					}
					else
					{
						speedX = -1;
						speedY = 0;
					}
				}
				dustposition += Vector2.Normalize(new Vector2(speedX, speedY)) * 40f * item.scale;

				int dust = Dust.NewDust(dustposition, 0, 0, mod.DustType("StarMuzzleFlash"));
				Main.dust[dust].scale = 2;
				Main.dust[dust].position = dustposition - Main.dust[dust].scale * new Vector2(4, 4);

				//  ErrorLogger.Log("~platerpps" + Main.player[Main.projectile[index2].owner].position);
				//  ErrorLogger.Log("~playercnet" + Main.player[Main.projectile[index2].owner].Center);
				//    ErrorLogger.Log("~projectile.position.X, projectile.position.Y" + Main.projectile[index2].position);
				//   ErrorLogger.Log("~ppsition" + position);
				//  ErrorLogger.Log("~projectile.Center.X, projectile.Center.Y" + Main.projectile[index2].Center);

				// Terraria.ID.ProjectileID.Bubble - shoots bubbles that pop.  410
				// Terraria.ID.ProjectileID.Xenopopper - 444 - shoots small purple bubbles, that spawn bullets when pop.
				// mod.ProjectileType("BubbleProjectile") -- mine
				proj++;
				bool canShoot = false;
				int num3 = 0;
				float num4 = 0;
				float speed = 0;
				player.PickAmmo(item, ref item.shoot, ref speed, ref canShoot, ref num3, ref num4, true);

				Main.projectile[index2].localAI[0] = mod.ProjectileType("BubbleProjectileFlying");//(float)item.shoot;
				Main.projectile[index2].localAI[1] = item.shootSpeed;//speed;

				bubbles[bubblesIndex] = index2;
				bubblesIndex++;
				if (bubblesIndex >= MaxBubbles) { overCap = true; }
				bubblesIndex = bubblesIndex % MaxBubbles;
			}

			if (!overCap)
			{
				for (int i = 0; i < bubblesIndex; i++)
				{
					Main.projectile[bubbles[i]].timeLeft = 30;
					//ErrorLogger.Log("" + bubblesIndex);
				}
			}
			else
			{
				for (int i = 0; i < MaxBubbles; i++)
				{
					Main.projectile[bubbles[i]].timeLeft = 30;
					// ErrorLogger.Log("" + bubblesIndex);
				}
			}
		}

		public override void UseStyle(Player player)
		{
			player.itemLocation.X = player.position.X + (float)player.width * 0.5f;// - (float)Main.itemTexture[item.type].Width * 0.5f;// - (float)(player.direction * 2);
																				   // player.itemLocation.Y = player.MountedCenter.Y;// - (float)Main.itemTexture[item.type].Height * 0.5f;
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
					player.itemLocation.X += player.direction * 8;
					player.itemLocation.Y -= 10;
				}
			}
			else
			{
				if (relativeX + relativeY > 0)
				{
					player.itemRotation = player.direction * MathHelper.Pi / 2;
					player.itemLocation.X += player.direction * 8;
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
		

		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			WeaponUtilities.DrawExperienceBar(this);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddCraftGroup(CraftGroup.IronBar, 10);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(Terraria.ID.ItemID.Xenopopper);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(Terraria.ID.ItemID.MusketBall, 999);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(Terraria.ID.ItemID.IchorBullet, 999);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(Terraria.ID.ItemID.RobotHat);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(Terraria.ID.ItemID.Handgun);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(Terraria.ID.ItemID.SlimeCrown);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock);
			//recipe.SetResult(mod, "BubblineExp",10);
			//recipe.AddRecipe();

		}
	}
}
