using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class Matilda : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 29;
			Item.DamageType = DamageClass.Melee;
			Item.width = 28;
			Item.height = 32;
			Item.useTime = 15;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.5f;
			Item.value = Item.sellPrice(0, 1, 74);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.axe = 17;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tools.MatildaBolt>();
			Item.shootSpeed = 7f;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 3 != 1) return false;
			Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(-15)), type, damage/2, knockback/2, player.whoAmI);
			Projectile.NewProjectile(source, position-(velocity*8), velocity, type, damage/2, knockback/2, player.whoAmI, 8);
			Projectile.NewProjectile(source, position-(velocity.RotatedBy(MathHelper.ToRadians(15))*16), velocity.RotatedBy(MathHelper.ToRadians(15)), type, damage/2, knockback/2, player.whoAmI, 16);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 17);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.BlueBrick, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 17);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.GreenBrick, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.ObeliskShard>(), 17);
			recipe.AddRecipeGroup("Wood", 8);
			recipe.AddIngredient(ItemID.PinkBrick, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}