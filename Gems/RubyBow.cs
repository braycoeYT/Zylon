using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Gems
{
	public class RubyBow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.buyPrice(0, 1, 60, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 44;
			item.useTime = 44;
			item.damage = 16;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.9f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7.9f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BasicBowMold"));
			recipe.AddIngredient(ItemID.Ruby, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}