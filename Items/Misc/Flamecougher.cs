using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class Flamecougher : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 4, 89);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.damage = 43;
			Item.width = 36;
			Item.height = 22;
			Item.knockBack = 1f;
			Item.shoot = ModContent.ProjectileType<Projectiles.CursedFlamesMelee>();
			Item.shootSpeed = 19f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Gel;
			Item.UseSound = SoundID.Item95;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.LightRed;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, 1f);
			return false;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnyHMBar", 10);
			recipe.AddIngredient(ItemID.Chain, 4);
			recipe.AddIngredient(ItemID.CursedFlame, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}