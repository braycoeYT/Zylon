using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Gems
{
	public class SapphireBow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.buyPrice(0, 1, 0, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 38;
			item.useTime = 38;
			item.damage = 14;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.7f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7.7f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BasicBowMold"));
			recipe.AddIngredient(ItemID.Sapphire, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}