using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	public class WeaponUtilities
	{
		const int barHeight = 15;
		public static void DrawExperienceBar(ModItem modItem)
		{
			if (Main.playerInventory)
				return;

			Player player = Main.player[modItem.item.owner];
			CaveStoryPlayer modPlayer = (CaveStoryPlayer)player.GetModPlayer(modItem.mod, "CaveStoryPlayer");
			if (player.inventory[player.selectedItem].type == modItem.item.type)
			{
				if (!Main.ingameOptionsWindow && !Main.playerInventory && !Main.achievementsWindow)
				{
					int xPos = 50;
					int yPos = 140;

					Color color = Color.White;
					string text = "Ooops";
					int level = 0;
					float percentage = 0;
					if (modItem.item.type == modItem.mod.ItemType("Bubbline"))
					{
						percentage = modPlayer.BubblineLvUpPercent;
						level = modPlayer.BubblineLevel;
					}
					else if (modItem.item.type == modItem.mod.ItemType("Fireball"))
					{
						percentage = modPlayer.FireballLvUpPercent;
						level = modPlayer.FireballLevel;
					}
					else if (modItem.item.type == modItem.mod.ItemType("MachineGun"))
					{
						percentage = modPlayer.MachineGunLvUpPercent;
						level = modPlayer.MachineGunLevel;
					}
					else if (modItem.item.type == modItem.mod.ItemType("Nemesis"))
					{
						percentage = modPlayer.NemesisLvUpPercent;
						level = modPlayer.NemesisLevel;
					}
					text = "Lv " + level;

					Texture2D white = modItem.mod.GetTexture("UI/white");
					Texture2D yellow = modItem.mod.GetTexture("UI/yellow");
					Texture2D darkyellow = modItem.mod.GetTexture("UI/darkyellow");
					Texture2D black = modItem.mod.GetTexture("UI/black");

					// Black Shadow
					Main.spriteBatch.Draw(black, new Vector2(xPos + 1, yPos), null, color, 0f, Vector2.Zero, new Vector2(100, barHeight+4), SpriteEffects.None, 0f);
					// Back
					Main.spriteBatch.Draw(darkyellow, new Vector2(xPos, yPos), null, color, 0f, Vector2.Zero, new Vector2(100, barHeight), SpriteEffects.None, 0f);
					// Bar
					Main.spriteBatch.Draw(yellow, new Vector2(xPos, yPos+3), null, color, 0f, Vector2.Zero, new Vector2(100*percentage, barHeight-3), SpriteEffects.None, 0f);
					// WhiteBars
					Main.spriteBatch.Draw(white, new Vector2(xPos, yPos), null, color, 0f, Vector2.Zero, new Vector2(100, 2), SpriteEffects.None, 0f);
					Main.spriteBatch.Draw(white, new Vector2(xPos, yPos+ barHeight), null, color, 0f, Vector2.Zero, new Vector2(100, 2), SpriteEffects.None, 0f);

					//Lv 3[||||||   ]
					Main.spriteBatch.DrawString(Main.fontMouseText, text, new Vector2(xPos- 33, yPos), color, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);

					if(percentage >= 1f)
					{
						Main.spriteBatch.DrawString(Main.fontMouseText, "MAX", new Vector2(xPos - 20 + 50, yPos), Color.DarkOrange, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
					}
				}
			}
		}
	}
}
