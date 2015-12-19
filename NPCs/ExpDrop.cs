using System;
using Terraria;
using Terraria.ModLoader;

namespace ExampleMod.NPCs
{
	public class ExpDrop : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			// Will this cause problems with multiplayer?
			if (npc.lifeMax > 5 && npc.value > 0f /*&&  Main.player[Main.myPlayer].HasItem(Terraria.ID.ItemID.RobotHat)*/)
			{
				// TODO and wearing robot hat.
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CaveStoryExperience"), npc.lifeMax / 10);
			}
		}
	}
}