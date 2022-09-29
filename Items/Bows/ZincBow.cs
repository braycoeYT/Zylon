using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class ZincBow : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 14;
			Item.useTime = 14;
			Item.damage = 7;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 0;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 6.8f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.ZincBar>(), 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}