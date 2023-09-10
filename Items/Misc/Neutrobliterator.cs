using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class Neutrobliterator : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Shoots multiple short ranged Neutron Blasts that chase your enemies");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 6;
			Item.useTime = 6;
			Item.damage = 35;
			Item.width = 58;
			Item.height = 28;
			Item.knockBack = 0.4f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Misc.NeutronBlast>();
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item93;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Red;
			Item.DamageType = DamageClass.Generic;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            int numberProjectiles = 5;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}