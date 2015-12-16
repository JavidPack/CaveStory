using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
    class BubblineExp : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bubbline Exp";
            item.toolTip = "Carry 20+ for Bubbline level 2, 40+ for level 3";
            item.width = 20;
            item.height = 20;
            item.value = 100;
            item.rare = 1;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.maxStack = 99;
        }
    }
}
