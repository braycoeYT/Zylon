using Zylon.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	[AutoloadEquip(EquipType.Wings)]
	public class GemstoneWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("How do these even let you fly?!");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 400000;
			item.rare = 11;
			item.accessory = true;
			item.expert = true;
			item.defense = 10;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 180;
		}
		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.5f;
			ascentWhenRising = 0.25f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.1f;
		}
		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9.5f;
			acceleration *= 2.5f;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 12);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}