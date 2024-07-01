using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Audio;

namespace Zylon.Items.Accessories
{
	public class ClawofInsanity : ModItem
	{
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 54;
			Item.value = Item.sellPrice(0, 3, 19);
			Item.rare = ItemRarityID.Orange;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetAttackSpeed(DamageClass.SummonMeleeSpeed) += 0.12f;
			player.whipRangeMultiplier += 0.2f;
			p.vengefulSpirit = true;
            
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FeralClaws);
			recipe.AddIngredient(ModContent.ItemType<ToyClaw>());
			recipe.AddIngredient(ModContent.ItemType<VengefulSpirit>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}