using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class BlazingBacklasher : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Moves around erratically\nLeaves an explosive trail behind itself\nRight click for a shorter range attack");
		}
		public override void SetDefaults() {
			Item.damage = 241;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.width = 30;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8f;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.BlazingBacklasher>();
			Item.shootSpeed = 18f;
			Item.noUseGraphic = true;
		}
		public override bool AltFunctionUse(Player player) {
            return true;
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			if (player.altFunctionUse == 2) {
				Projectile.NewProjectile(source, player.Center, player.DirectionTo(Main.MouseWorld) * 7f, type, damage, knockback, Main.myPlayer);
				return false;
			}
			return true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}