using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GlassHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("-3 Defense\n'Make sure no one throws any stones at you'\nIncreases critical strike damage by 20%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = -3;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<GlassBreastplate>() && legs.type == ModContent.ItemType<GlassLeggings>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.critExtraDmg += 0.2f;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "Decreases max life by 10%\nTaking damage releases shards of glass\nThe more damage taken, the more powerful the effect is";
			player.statLifeMax2 = (int)(player.statLifeMax2 * 0.9f);
			p.glassArmor = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.AddIngredient(ItemID.Obsidian);
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();
		}
	}
}