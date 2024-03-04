using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class EerieStakeLauncher : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 2);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 31;
			Item.useTime = 31;
			Item.damage = 21;
			Item.width = 48;
			Item.height = 24;
			Item.knockBack = 4.5f;
			Item.shoot = ProjectileID.Stake;
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Stake;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Orange;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-2, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}