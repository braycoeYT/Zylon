using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class Shivercrown : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 58;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetCritChance(DamageClass.Generic) += 2;
			p.critExtraDmg += 0.1f;
			p.shivercrown = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldCrown);
			recipe.AddIngredient(ItemID.Shiverthorn, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumCrown);
			recipe.AddIngredient(ItemID.Shiverthorn, 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.EnchantedIceCube>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}