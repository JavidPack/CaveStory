using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.NPCs
{
	public class GreenCritter : ModNPC
	{
		public override void SetDefaults()
		{
			npc.name = "Green Critter";
			npc.displayName = "Green Critter";
			npc.aiStyle = -1;
			npc.lifeMax = 250;
			npc.damage = 60;
			npc.defense = 15;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = false;
			npc.width = 16;
			npc.height = 16;
			Main.npcFrameCount[npc.type] = 6;
			npc.value = Item.buyPrice(0, 0, 30, 0);
			npc.npcSlots = .5f;
			npc.scale = 2f;
			//npc.boss = false;
			//npc.lavaImmune = true;
			//npc.noGravity = true;
			npc.noTileCollide = false;
			npc.soundHit = mod.GetSoundSlot(SoundType.NPCHit, "Sounds/NPCHit/EnemyHurtSqueak");
			//npc.soundKilled = mod.GetSoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/???");
			//bannerItem = mod.ItemType("RedBatBanner");
			//banner = npc.type;
		}

		public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.spawnTileY < Main.worldSurface + 100 ? .3f : 0f;
			//return 1000f;
		}

		public override void AI()
		{
			if (npc.ai[3] == (int)States.Asleep)
			{
				npc.frame.Y = 0;
				npc.TargetClosest(true);
				if (npc.HasValidTarget && Main.player[npc.target].Distance(npc.Center) < 500f)
				{
					npc.ai[3] = (int)States.Notice;
				}
			}
			else if (npc.ai[3] == (int)States.Notice)
			{
				
				if (Main.player[npc.target].Distance(npc.Center) < 250f)
				{
					// wind up
					npc.frameCounter++;
					if (npc.frameCounter < 10)
					{
						npc.frame.Y = 18;
					}
					else if (npc.frameCounter < 20)
					{
						npc.frame.Y = 0;
					}
					else if (npc.frameCounter < 30)
					{
						npc.frameCounter = 0;
						npc.ai[3] = (int)States.Jump;
					}
				}
				else
				{
					// reset
					npc.frame.Y = 18;
					npc.frameCounter = 0;
					npc.TargetClosest(true);
					if (!npc.HasValidTarget ||  Main.player[npc.target].Distance(npc.Center) > 500f)
					{
						npc.ai[3] = (int)States.Asleep;
					}
				}
			}
			else if (npc.ai[3] == (int)States.Jump)
			{
				npc.frame.Y = 36;
				npc.frameCounter++;
				if (npc.frameCounter == 1)
				{
					npc.velocity = new Vector2(npc.direction * 2, -10f);
				}
				else if (npc.frameCounter < 20)
				{
				}
				else if (npc.frameCounter > 40)
				{
					npc.frameCounter = 0;
					npc.ai[3] = (int)States.Hover;
				}
			}
			else if (npc.ai[3] == (int)States.Hover)
			{
				npc.ai[2] += 1;
				npc.velocity += new Vector2(0, -.35f);
				 // 54, 72, 90
				npc.frameCounter++;
				if (npc.frameCounter < 10)
				{
					npc.frame.Y = 54;
				}
				else if (npc.frameCounter < 20)
				{
					npc.frame.Y = 72;
				}
				else if (npc.frameCounter < 30)
				{
					npc.frame.Y = 90;
				}
				else
				{
					npc.frameCounter = 0;
				}
				if(npc.ai[2] > 100)
				{
					npc.ai[2] = 0;
					npc.frameCounter = 0;
					npc.ai[3] = (int)States.Fall;
				} 
			}
			else if (npc.ai[3] == (int)States.Fall)
			{
				npc.frame.Y = 34;

				if(npc.velocity.Y == 0)
				{
					npc.velocity.X = 0;
					npc.ai[3] = (int)States.Asleep;
				}
			}
		}

		

		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = npc.direction;
		}

		enum States
		{
			Asleep,
			Notice,
			Jump,
			Hover,
			Fall
		}

		//public override void FindFrame(int frameHeight)
		//{
		//	if (npc.velocity.X > 0f)
		//	{
		//		npc.spriteDirection = 1;
		//	}
		//	if (npc.velocity.X < 0f)
		//	{
		//		npc.spriteDirection = -1;
		//	}
		//	//npc.rotation = npc.velocity.X * 0.1f;

		//	npc.frameCounter += 1.0;
		//	if (npc.frameCounter >= 6.0)
		//	{
		//		npc.frame.Y = npc.frame.Y + frameHeight;
		//		npc.frameCounter = 0.0;
		//	}
		//	if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
		//	{
		//		npc.frame.Y = 0;
		//	}
		//}
	}
}
