using System;
using System.IO;
using Terraria.ModLoader;

namespace CaveStory
{
	public class CaveStoryPlayer : ModPlayer
	{
		private const int saveVersion = 0;

		private int _BubblineExp;
		internal int BubblineExp
		{
			get { return _BubblineExp; }
			set { _BubblineExp = Math.Max(Math.Min(value, BubblineLevelMax), 0); }
		}

		private int _NemesisExp;
		internal int NemesisExp
		{
			get { return _NemesisExp; }
			set { _NemesisExp = Math.Max(Math.Min(value, NemesisLevelMax), 0); }
		}

		private int _FireballExp;
		internal int FireballExp
		{
			get { return _FireballExp; }
			set { _FireballExp = Math.Max(Math.Min(value, FireballLevelMax), 0); }
		}

		private int _MachineGunExp;
		internal int MachineGunExp
		{
			get { return _MachineGunExp; }
			set { _MachineGunExp = Math.Max(Math.Min(value, MachineGunLevelMax), 0); }
		}

		const int MachineGunLevel2 = 20;
		const int MachineGunLevel3 = 40;
		const int MachineGunLevelMax = 80;

		const int NemesisLevel2 = 20;
		const int NemesisLevel3 = 40;
		const int NemesisLevelMax = 80;

		const int FireballLevel2 = 20;
		const int FireballLevel3 = 40;
		const int FireballLevelMax = 80;

		const int BubblineLevel2 = 20;
		const int BubblineLevel3 = 40;
		const int BubblineLevelMax = 80;

		public int MachineGunLevel
		{
			get
			{
				if (MachineGunExp >= MachineGunLevel3)
				{
					return 3;
				}
				else if (MachineGunExp >= MachineGunLevel2)
				{
					return 2;
				}
				else
					return 1;
			}
		}
		public int FireballLevel
		{
			get
			{
				if (FireballExp >= 40)
				{
					return 3;
				}
				else if (FireballExp >= 20)
				{
					return 2;
				}
				else
					return 1;
			}
		}
		public int BubblineLevel
		{
			get
			{
				if (BubblineExp >= BubblineLevel3)
				{
					return 3;
				}
				else if (BubblineExp >= BubblineLevel2)
				{
					return 2;
				}
				else
					return 1;
			}
		}
		public int NemesisLevel
		{
			get
			{
				if (NemesisExp >= 40)
				{
					return 3;
				}
				else if (NemesisExp >= 20)
				{
					return 2;
				}
				else
					return 1;
			}
		}

		public float BubblineLvUpPercent
		{
			get
			{
				if(BubblineLevel == 1)
					return (float)BubblineExp / BubblineLevel2;
				if (BubblineLevel == 2)
					return (float)BubblineExp / BubblineLevel3;
				if (BubblineLevel == 3)
					return (float)BubblineExp / BubblineLevelMax;
				return .5f;
			}
		}
		public float NemesisLvUpPercent
		{
			get
			{
				if (NemesisLevel == 1)
					return (float)NemesisExp / NemesisLevel2;
				if (NemesisLevel == 2)
					return (float)NemesisExp / NemesisLevel3;
				if (NemesisLevel == 3)
					return (float)NemesisExp / NemesisLevelMax;
				return .5f;
			}
		}
		public float FireballLvUpPercent
		{
			get
			{
				if (FireballLevel == 1)
					return (float)FireballExp / FireballLevel2;
				if (FireballLevel == 2)
					return (float)FireballExp / FireballLevel3;
				if (FireballLevel == 3)
					return (float)FireballExp / FireballLevelMax;
				return .5f;
			}
		}
		public float MachineGunLvUpPercent
		{
			get
			{
				if (MachineGunLevel == 1)
					return (float)MachineGunExp / MachineGunLevel2;
				if (MachineGunLevel == 2)
					return (float)MachineGunExp / MachineGunLevel3;
				if (MachineGunLevel == 3)
					return (float)MachineGunExp / MachineGunLevelMax;
				return .5f;
			}
		}



		public override void SaveCustomData(BinaryWriter writer)
		{
			writer.Write(saveVersion);
			writer.Write(MachineGunExp);
			writer.Write(BubblineExp);
			writer.Write(FireballExp);
			writer.Write(NemesisExp);
		}

		public override void LoadCustomData(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			MachineGunExp = reader.ReadInt32();
			int a = reader.ReadInt32();
			ErrorLogger.Log("Exp: "+a + " PlayerName" + player.name + " objectID:" +  GetHashCode() + " Modname: " + mod.Name);
			BubblineExp = a;
			FireballExp = reader.ReadInt32();
			NemesisExp = reader.ReadInt32();
		}

		public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			LoseExperience(damage);
		}

		public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref string deathText)
		{
			LoseExperience(damage);
			return true;
		}

		private void LoseExperience(double damage)
		{
			if (player.inventory[player.selectedItem].type == mod.ItemType("Bubbline"))
			{
				BubblineExp -= (int)damage;
			}
			else if (player.inventory[player.selectedItem].type == mod.ItemType("MachineGun"))
			{
				MachineGunExp -= (int)damage;
			}
			else if (player.inventory[player.selectedItem].type == mod.ItemType("Nemesis"))
			{
				NemesisExp -= (int)damage;
			}
			else if (player.inventory[player.selectedItem].type == mod.ItemType("Fireball"))
			{
				FireballExp -= (int)damage;
			}
		}
	}
}
