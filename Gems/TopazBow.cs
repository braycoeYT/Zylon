using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Gems
{
	public class TopazBow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.buyPrice(0, 0, 70, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 35;
			item.useTime = 35;
			item.damage = 13;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.6f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7.6f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BasicBowMold"));
			recipe.AddIngredient(ItemID.Topaz, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}