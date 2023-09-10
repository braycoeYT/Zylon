using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class SaberToothNecklace : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases critical strike chance and armor penetration by 8\nCritical strikes deal 33% more damage\nDoes not stack with downgrades");
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
			if (!p.stncheck) {
				player.GetArmorPenetration(DamageClass.Generic) += 8;
				p.stncheck = true;
			}
			if (!p.st2check) {
				player.GetCritChance(DamageClass.Generic) += 8;
				p.critExtraDmg += 0.33f;
				p.st2check = true;
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