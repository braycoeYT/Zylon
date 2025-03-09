using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class DarkenedRifle : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 4, 60);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 64;
			Item.useTime = 64;
			Item.damage = 31;
			Item.width = 86;
			Item.height = 28;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item36;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Pink;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-14, -6);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            float rand = Main.rand.NextFloat(MathHelper.TwoPi);
			for (int i = 0; i < 8; i++)
				Projectile.NewProjectile(source, position + new Vector2(0, 24).RotatedBy(rand+MathHelper.ToRadians(i*40)), velocity, type, damage, knockback, Main.myPlayer);
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