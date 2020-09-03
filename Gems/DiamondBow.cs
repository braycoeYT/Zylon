using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Gems
{
	public class DiamondBow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 47;
			item.useTime = 47;
			item.damage = 17;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 8f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BasicBowMold"));
			recipe.AddIngredient(ItemID.Diamond, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}