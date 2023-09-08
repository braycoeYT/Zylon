using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class FusionBand : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It's too big for anyone's arm, let alone yours'\nIncreases life and mana regeneration\nIncreases max mana by 20\nIncreases the power of regeneration, magic power, magic regeneration, ironskin, and swiftness potions");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Lime;
			Item.defense = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.statManaMax2 += 20;
			player.lifeRegen += 2;
			player.manaRegen += 2;
			p.bandofRegen = true;
			p.bandofStarpower = true;
			p.bandofMagicRegen = true;
			p.bandofMetal = true;
			p.bandofZinc = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BandofRegeneration);
			recipe.AddIngredient(ItemID.BandofStarpower);
			recipe.AddIngredient(ModContent.ItemType<IronBand>());
			recipe.AddIngredient(ModContent.ItemType<ZincBand>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BandofRegeneration);
			recipe.AddIngredient(ItemID.BandofStarpower);
			recipe.AddIngredient(ModContent.ItemType<LeadBand>());
			recipe.AddIngredient(ModContent.ItemType<ZincBand>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ModContent.ItemType<IronBand>());
			recipe.AddIngredient(ModContent.ItemType<ZincBand>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ModContent.ItemType<LeadBand>());
			recipe.AddIngredient(ModContent.ItemType<ZincBand>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}