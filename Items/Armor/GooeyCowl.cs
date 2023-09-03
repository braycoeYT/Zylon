using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GooeyCowl : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Somehow just as strong as metal, but I wouldn't question it\nIncreases damage by 3%");
		}
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.White;
			Item.defense = 4;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<GooeyCover>() && legs.type == ItemType<GooeyLeggings>();
		}
		public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "Every third projectile releasing swing/shot/use also releases an explosive marshmallow (excluding certain weapons)";
			p.gooeySetBonus = true;
		}
		public override void UpdateEquip(Player player) {
			player.GetDamage(DamageClass.Generic) += 0.03f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Food.Smore>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}