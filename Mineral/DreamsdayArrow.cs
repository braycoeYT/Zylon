using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class DreamsdayArrow : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dreamsday Arrow");
			Tooltip.SetDefault("An arrow of the cosmos and crystals.\nCan inflict venom and frostburn.");
        }
		public override void SetDefaults()
		{
			item.damage = 46;
			item.ranged = true;
			item.width = 14;
			item.height = 39;
			item.maxStack = 9999;
			item.consumable = true;
			item.knockBack = 4f;
			item.value = 150;
			item.rare = 9;
			item.shoot = ProjectileType<Projectiles.Gemstone.DreamsdayArrow>();
			item.shootSpeed = 6f;
			item.ammo = AmmoID.Arrow;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenArrow, 500);
			recipe.AddIngredient(ItemType<GalacticDiamondium>(), 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 500);
			recipe.AddRecipe();
		}
	}   
}