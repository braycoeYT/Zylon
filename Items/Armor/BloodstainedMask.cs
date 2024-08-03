using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BloodstainedMask : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<SlimePrinceBreastplate>() && legs.type == ModContent.ItemType<SlimePrinceLeggings>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.summonCritBoost += 0.03f;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.slimePrinceArmor = true;
			player.setBonus = "Double tap down to gain the 'Bloodbath' buff\nWhile the buff is active, all minions gain lifesteal\n45 second cooldown";
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 8);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}