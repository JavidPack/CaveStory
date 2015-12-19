using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	public class BoosterVPointEight : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Wings);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Booster v.0.8";
			item.width = 22;
			item.height = 20;
			item.toolTip = "Push the jump button again in midair to fly even higher.";
			item.value = 10000;
			item.rare = 2;
			item.accessory = true;
			item.useSound = mod.GetSoundSlot(SoundType.Item, "Sounds/Item/BoosterSound");



			//item.wingSlot = ??
			//item.useSound = mod.SoundType("BoosterSound");
		}

		//these wings use the same values as the solar wings

		public override void UpdateAccessory(Player player)
		{
			player.wingTimeMax = 180;
		}

		public override void VerticalWingSpeeds(ref float ascentWhenFalling, ref float ascentWhenRising,
		   ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		//public override void Update(ref float gravity, ref float maxFallSpeed)
		//{
		//    Main.PlaySound(2, mod.SoundType("BoosterSound"));

		//}

		public override void WingUpdate(Player player, bool inUse)
		{
			// ErrorLogger.Log("WingUpdate");
			if (inUse || player.jump > 0)
			{
				player.rocketDelay2--;
				if (player.rocketDelay2 <= 0)
				{
					Main.PlaySound(2, Style: mod.GetSoundSlot(SoundType.Item, "Sounds/Item/BoosterSound"));
					//Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 13);
					player.rocketDelay2 = 10;
				}
				int num84 = 2;
				if (player.controlUp)
				{
					num84 = 4;
				}
				num84 = 1;
				for (int num85 = 0; num85 < num84; num85++)
				{
					//    int type = 6;
					if (player.head == 41)
					{
						int arg_5D0E_0 = player.body;
					}
					/// float scale = 1.75f;
					float x3 = player.position.X + (float)(player.width / 2) + 16f;
					if (player.direction > 0)
					{
						x3 = player.position.X + (float)(player.width / 2) - 26f;
					}
					float num86 = player.position.Y + (float)player.height - 18f;
					if (num85 == 1 || num85 == 3)
					{
						x3 = player.position.X + (float)(player.width / 2) + 8f;
						if (player.direction > 0)
						{
							x3 = player.position.X + (float)(player.width / 2) - 20f;
						}
						num86 += 6f;
					}
					if (num85 > 1)
					{
						num86 += player.velocity.Y;
					}

					int dust = Dust.NewDust(new Vector2(x3, num86), 8, 8, mod.DustType("BoosterSmoke"));
					Main.dust[dust].scale = 2;
					//  Main.dust[dust].position = position - Main.dust[dust].scale * new Vector2(4, 4);

					//  int num87 = Dust.NewDust(new Vector2(x3, num86), 8, 8, type, 0f, 0f, alpha, default(Color), scale);
					Dust expr_5E21_cp_0 = Main.dust[dust];
					expr_5E21_cp_0.velocity.X = expr_5E21_cp_0.velocity.X * 0.1f;
					Main.dust[dust].velocity.Y = Main.dust[dust].velocity.Y * 1f + 2f * player.gravDir - player.velocity.Y * 0.3f;
					Main.dust[dust].noGravity = true;
					//   Main.dust[num87].shader = GameShaders.Armor.GetSecondaryShader(player.cWings, this);
					if (num84 == 4)
					{
						Dust expr_5EB9_cp_0 = Main.dust[dust];
						expr_5EB9_cp_0.velocity.Y = expr_5EB9_cp_0.velocity.Y + 6f;
					}
				}
				player.wingFrameCounter++;
				if (player.wingFrameCounter > 4)
				{
					player.wingFrame++;
					player.wingFrameCounter = 0;
					if (player.wingFrame >= 3)
					{
						player.wingFrame = 0;
					}
				}
			}
			else if (!player.controlJump || player.velocity.Y == 0f)
			{
				player.wingFrame = 3;
			}
		}

		public override void HorizontalWingSpeeds(ref float speed, ref float acceleration)
		{
			speed = 9f;
			acceleration *= 2.5f;

			//Main.PlaySound(2, Style: mod.GetSoundSlot(SoundType.Item, "Sounds/Item/BoosterSound"));

			//ErrorLogger.Log("HWS");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddCraftGroup(CraftGroup.GetVanillaGroup("IronBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(Terraria.ID.ItemID.DirtBlock, 1);
			//recipe.SetResult(ItemID.Jetpack);
			//recipe.AddRecipe();
		}
	}
}
