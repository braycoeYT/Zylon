using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Items.Accessories
{
	public class RoundmastersKit : ModItem
	{
		public override void SetStaticDefaults() {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(7, 4)); //first is speed, second is amount of frames
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.width = 38;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 10, 50);
			Item.rare = ItemRarityID.Lime;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Ranged) += 0.12f;
			player.magicQuiver = true;
			p.roundmastersKit = true;
			p.blowpipeChargeRetain = 0.15f;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<MechanicsKit>());
			recipe.AddIngredient(ModContent.ItemType<AmmoSling>());
			recipe.AddIngredient(ModContent.ItemType<ContinuumWarper>());
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}