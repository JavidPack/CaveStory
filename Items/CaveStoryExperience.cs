using Terraria;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	internal class CaveStoryExperience : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cave Story Experience");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 100;
			item.rare = 1;
			item.maxStack = 99;
		}

		public override bool OnPickup(Player player)
		{
			CaveStoryPlayer modPlayer = (CaveStoryPlayer)player.GetModPlayer(mod, "CaveStoryPlayer");
			if (player.inventory[player.selectedItem].type == mod.ItemType("Fireball"))
			{
				modPlayer.FireballExp += this.item.stack;
			}
			if (player.inventory[player.selectedItem].type == mod.ItemType("MachineGun"))
			{
				modPlayer.MachineGunExp += this.item.stack;
			}
			if (player.inventory[player.selectedItem].type == mod.ItemType("Nemesis"))
			{
				modPlayer.NemesisExp += this.item.stack;
			}
			if (player.inventory[player.selectedItem].type == mod.ItemType("Bubbline"))
			{
				modPlayer.BubblineExp += this.item.stack;
			}

			return false;
		}
	}
}