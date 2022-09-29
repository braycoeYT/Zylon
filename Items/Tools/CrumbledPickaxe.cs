using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class CrumbledPickaxe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 13;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1.8f;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.pick = 55;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}