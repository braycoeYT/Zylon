using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ZincHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.defense = 3;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<ZincBreastplate>() && legs.type == ItemType<ZincLeggings>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases move speed by 10%";
			//player.runAcceleration += 0.1f;
			//player.maxRunSpeed += 0.1f;
			player.moveSpeed += 0.1f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.ZincBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}