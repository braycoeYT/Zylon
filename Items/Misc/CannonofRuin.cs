using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class CannonofRuin : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 10);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 4;
			Item.useTime = 4;
			Item.damage = 60;
			Item.width = 84;
			Item.height = 34;
			Item.knockBack = 6f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Misc.DirtPlaceBlocks>();
			Item.shootSpeed = 21f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = ModContent.ItemType<Dirtthrower>();
			Item.UseSound = SoundID.Item98;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Lime;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(10f)), type, damage, knockback, Main.myPlayer);
			return false;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(-28, -8);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Dirtthrower>());
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 36);
			recipe.AddIngredient(ItemID.Glass, 20);
			recipe.AddIngredient(ItemID.DirtBlock, 100);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}