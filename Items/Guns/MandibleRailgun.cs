using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class MandibleRailgun : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 89);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 58;
			Item.useTime = 58;
			Item.damage = 41;
			Item.width = 66;
			Item.height = 30;
			Item.knockBack = 6f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 16f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item96;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Blue;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-20, 0);
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (type == ProjectileID.Bullet) type = ModContent.ProjectileType<Projectiles.Guns.MandibleRailgunProj>();
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 8);
            recipe.AddIngredient(ItemID.AntlionMandible, 12);
			recipe.AddIngredient(ItemID.HardenedSand, 25);
			recipe.AddIngredient(ItemID.Sandstone, 30);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}