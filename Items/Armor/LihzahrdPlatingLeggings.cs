using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LihzahrdPlatingLeggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.defense = 16;
		}
		public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Summon) += 0.08f;
			p.summonCritBoost += 0.08f;
			player.maxMinions += 1;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LihzahrdBrick, 30);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}