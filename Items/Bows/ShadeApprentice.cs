using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Bows
{
	public class ShadeApprentice : ModItem
	{
		public override void SetDefaults()  {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 14;
			Item.useTime = 14;
			Item.damage = 38;
			Item.width = 42;
			Item.height = 42;
			Item.knockBack = 1.75f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 10.5f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.value = Item.sellPrice(0, 4, 60);
			Item.rare = ItemRarityID.Pink;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			for (int i = 0; i < 2; i++) {
				float offset = MathHelper.ToRadians(Main.rand.NextFloat(-10f, 10f));
				Vector2 dist = Vector2.Normalize(velocity)*Main.rand.Next(375, 501);
				Projectile.NewProjectile(source, player.Center + dist.RotatedBy(offset), velocity.RotatedBy(offset)*-1f, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}