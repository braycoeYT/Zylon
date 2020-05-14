using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class GemstoneBottle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstone Bottle");
			Tooltip.SetDefault("'The jar hasn't been cleaned for aeons'\nInflicts various debuffs");
		}

		public override void SetDefaults()
		{
			item.damage = 209;
			item.width = 33;
			item.height = 33;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 800000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("GemstoneMinivirus");
			item.shootSpeed = 10;
			item.mana = 14;
			item.magic = true;
			item.noMelee = true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 13);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}