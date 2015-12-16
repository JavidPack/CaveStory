using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
    class MachineGunExp : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Machinegun Exp";
            item.toolTip = "No use yet. Stay tuned.";
            item.width = 20;
            item.height = 20;
            item.value = 100;
            item.rare = 1;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.maxStack = 99;
        }
    }
}
