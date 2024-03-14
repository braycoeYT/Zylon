using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Zylon.Items.Guns
{
	public class HeavyLobster : ModItem
	{
		public override void SetDefaults() { //Reference to Heavy Lobster from Kirby.
			Item.value = Item.sellPrice(0, 5, 82, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 32;
			Item.useTime = 32;
			Item.damage = 65;
			Item.width = 26;
			Item.height = 24;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Pink;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-8, -4);
		}
        int shootNum;
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			shootNum++;
			if (shootNum % 3 == 0) {
				if (shootNum % 6 == 3) {
					SoundEngine.PlaySound(SoundID.Item96, position);
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Guns.HeavyLobsterProjBlob>(), (int)(damage*1.5f), knockback, Main.myPlayer);
                }
				else {
					SoundEngine.PlaySound(SoundID.Item96, position);
					Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Guns.HeavyLobsterProjFlame>(), (int)(damage*1.5f), knockback, Main.myPlayer);
                }
			}
			return shootNum % 3 != 0;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.RockLobster);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddIngredient(ItemID.LivingFireBlock, 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}