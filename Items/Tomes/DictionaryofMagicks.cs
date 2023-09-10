using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class DictionaryofMagicks : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Dictionary of Magicks");
			// Tooltip.SetDefault("'There's a lot of latin in this!'\nAlternates between fireballs, snowflakes, water bolts, lightning strikes, and chaos balls");
		}
		public override void SetDefaults() {
			Item.damage = 38;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 4);
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.SnowfallProj>();
			Item.shootSpeed = 11f;
			Item.noMelee = true;
			Item.mana = 11;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
        }
        int shootCount;
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            shootCount++;
			if (shootCount % 5 == 1) type = ProjectileID.BallofFire;
			if (shootCount % 5 == 3) type = ProjectileID.WaterBolt;
			if (shootCount % 5 == 4) {
				type = ProjectileID.ThunderStaffShot;
				velocity *= 1.5f;
            }
			if (shootCount % 5 == 0) type = ModContent.ProjectileType<Projectiles.Tomes.ChaosBallFriendly>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (shootCount % 5 == 2) {
                for (int i = 0; i < 3; i++) {
					Vector2 spawn = new Vector2(Main.MouseWorld.X + Main.rand.Next(-160, 161), player.position.Y - 400);
					Vector2 target = spawn - Main.MouseWorld;
					target.Normalize();
					Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target*-12f, type, (int)(damage * 0.8f), knockback, Main.myPlayer);
				}
				return false;
            }
            return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FlowerofFire);
			recipe.AddIngredient(ModContent.ItemType<Snowfall>());
			recipe.AddIngredient(ItemID.WaterBolt);
			recipe.AddIngredient(ItemID.ThunderStaff);
			recipe.AddIngredient(ModContent.ItemType<ChaosCaster>());
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}