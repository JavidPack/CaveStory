using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CaveStory.Items
{
	public class PolarStar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("PolarStar"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("It carries the mark of the Northern Star");
		}

		public override void SetDefaults() 
		{
			item.damage = 4;
			item.ranged = true;
			item.width = 48;
			item.height = 32;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.knockBack = 1;
			item.noMelee = true;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("PolarStarBullet");
			item.shootSpeed = 10f;

		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}