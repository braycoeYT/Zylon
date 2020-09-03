using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Gems
{
	public class EmeraldBow : ModItem
	{
		public override void SetDefaults() {
			item.value = Item.buyPrice(0, 1, 30, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 41;
			item.useTime = 41;
			item.damage = 15;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.8f;
			item.shoot = ProjectileID.WoodenArrowFriendly;
			item.shootSpeed = 7.8f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.rare = ItemRarityID.Blue;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("BasicBowMold"));
			recipe.AddIngredient(ItemID.Emerald, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}