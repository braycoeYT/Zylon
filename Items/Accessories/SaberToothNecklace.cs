using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SaberToothNecklace : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 16;
			Item.height = 22;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (!p.CHECK_SharkToothNecklace) {
				player.GetArmorPenetration(DamageClass.Generic) += 8;
				p.CHECK_SharkToothNecklace = true;
			}
			if (!p.CHECK_SaberTooth) {
				player.GetCritChance(DamageClass.Generic) += 8;
				p.critExtraDmg += 0.33f;
				p.CHECK_SaberTooth = true;
            }
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SharkToothNecklace);
			recipe.AddIngredient(ModContent.ItemType<SaberTooth>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddIngredient(ItemID.SoulofMight, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}