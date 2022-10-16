using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class DeterminationBreaker : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Does not give you a blue eye on use'\nBegins spinning and firing skulls after striking a foe");
		}
		public override void SetDefaults() {
			Item.damage = 65;
			Item.width = 44;
			Item.height = 42;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 17;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 loc = Main.MouseWorld - player.Center;
			if (Math.Abs(loc.Y) > Math.Abs(loc.X)) {
				if (loc.Y > 0) Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(0, Item.shootSpeed), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
				else Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(0, Item.shootSpeed*-1), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
            }
			else {
				if (loc.X > 0) Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(Item.shootSpeed, 0), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
				else Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Vector2(Item.shootSpeed*-1, 0), ModContent.ProjectileType<Projectiles.Tomes.DeterminationBreakerProj>(), Item.damage, Item.knockBack, Main.myPlayer);
            }
            return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BookofSkulls);
			recipe.AddIngredient(ItemID.SoulofFright, 20);
			recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}