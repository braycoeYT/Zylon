using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DiskbringerHeadpiece : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Increases mining speed by 12%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<DiskbringerTorso>() && legs.type == ModContent.ItemType<DiskbringerLegpieces>();
		}
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "Striking enemies will buff the player's offense, defense, or agility temporarily\nTrue melee strikes have increased buff time";
			p.diskbringerSet = true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}