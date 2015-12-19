using Terraria.ID;
using Terraria.ModLoader;

namespace CaveStory.Items
{
	public class TowRope : ModItem
	{
		public override void SetDefaults()
		{

			item.useStyle = 1;
			item.name = "Tow Rope";
			item.width = 16;
			item.height = 30;
			item.useSound = 81;
			item.useAnimation = 20;
			item.toolTip = "Use to tow a special robot";
			item.useTime = 20;
			item.rare = 8;
			item.noMelee = true;
			item.mountType = mod.MountType("CurlyBrace");
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddCraftGroup(CraftGroup.GetVanillaGroup("IronBar"), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.DirtBlock);
			//recipe.SetResult(ItemID.CloudinaBalloon);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.DirtBlock);
			//recipe.SetResult(ItemID.BrainScrambler);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.DirtBlock);
			//recipe.SetResult(ItemID.SuspiciousLookingEye);
			//recipe.AddRecipe();

			//recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.DirtBlock);
			//recipe.SetResult(ItemID.Jetpack);
			//recipe.AddRecipe();
		}
	}

}
