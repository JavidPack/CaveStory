using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	class CaveStoryExperience : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "CaveStoryExperience";
			item.width = 20;
			item.height = 20;
			item.value = 100;
			item.rare = 1;
			//   ItemID.Sets.ItemNoGravity[item.type] = true;
			item.maxStack = 99;
		}

		public override bool OnPickup(Player player)
		{
			if (player.inventory[player.selectedItem].type == mod.ItemType("Fireball"))
			{
				player.QuickSpawnItem(mod.GetItem("FireballExp").item.type, this.item.stack);
			}
			if (player.inventory[player.selectedItem].type == mod.ItemType("MachineGun"))
			{
				player.QuickSpawnItem(mod.GetItem("MachineGunExp").item.type, this.item.stack);
			}
			if (player.inventory[player.selectedItem].type == mod.ItemType("Nemesis"))
			{
				player.QuickSpawnItem(mod.GetItem("NemesisExp").item.type, this.item.stack);
			}
			if (player.inventory[player.selectedItem].type == mod.ItemType("Bubbline"))
			{
				player.QuickSpawnItem(mod.GetItem("BubblineExp").item.type, this.item.stack);
			}

			return false;
		}
	}
}
