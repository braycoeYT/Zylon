using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class Crystalizer : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 4, 12);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.damage = 38;
			Item.width = 54;
			Item.height = 52;
			Item.knockBack = 1.5f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 9.25f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.LightRed;
		}
		int shootCount;
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            shootCount++;
			if (shootCount % 3 == 0) type = ModContent.ProjectileType<Projectiles.Bows.CrystalizerProj>();
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalShard, 29);
			recipe.AddRecipeGroup("Zylon:AnyCobaltBar", 8);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.Glass, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}