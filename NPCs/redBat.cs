using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.NPCs
{
	public class RedBat : ModNPC
	{
    public override void SetDefaults()
		{
			npc.name = "Red Bat";
			npc.displayName = "Red Bat";
			npc.aiStyle = -1;
			npc.lifeMax = 150;
			npc.damage = 60;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = false;
			npc.alpha = 255;
			npc.width = 15;
			npc.height = 18;
			Main.npcFrameCount[npc.type] = 6;
			npc.value = Item.buyPrice(0, 0, 30, 0);
			npc.npcSlots = 5f;
			npc.boss = false;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = false;
			npc.soundHit = 5;
      // I don't have the desired sound file here
			npc.soundKilled = 7;
      // I don't have the sound files I want to put here in npc.soundKilled
			bannerItem = mod.ItemType("RedBatBanner");
		}
  }
}
