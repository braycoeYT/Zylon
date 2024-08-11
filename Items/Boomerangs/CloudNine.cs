using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Boomerangs
{
	public class CloudNine : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 59;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 13;
			Item.useTime = 13;
			Item.shootSpeed = 16f;
			Item.knockBack = 6.5f;
			Item.width = 46;
			Item.height = 48;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 3, 56);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.Boomerangs.CloudNineProj>();
		}
		public override bool CanUseItem(Player player) {
			int total = 0;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				if (Main.projectile[i].type == Item.shoot && Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer) { 
					if (Main.projectile[i].ai[0] == 0f) return false;
					total++;
				}
			}
			return total < 8;
		}
		int shootCount;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            shootCount++;
			if (shootCount % 3 == 0) {
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 0, 1);
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Cloud, 23);
			recipe.AddIngredient(ItemType<Materials.WindEssence>(), 11);
			recipe.AddIngredient(ItemID.SoulofFlight, 9);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}