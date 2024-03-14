using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Guns
{
	public class OvergrownHandgunFragment : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Only at 0.1% of its true power'");
		}
		public override void SetDefaults() {
			Item.value = 1;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 27;
			Item.useTime = 27;
			Item.damage = 1;
			Item.width = 26;
			Item.height = 24;
			Item.knockBack = 0.5f;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.rare = ItemRarityID.Gray;
		}
        public override void UpdateInventory(Player player) {
            if (Main.remixWorld) {
				Item.damage = 98;
				Item.knockBack = 4.5f;
				Item.shoot = ModContent.ProjectileType<Projectiles.DirtGlobFriendly>();
				Item.shootSpeed = 20f;
				Item.rare = ItemRarityID.Yellow;
				Item.value = Item.sellPrice(0, 5);
            }
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (Main.remixWorld) type = ModContent.ProjectileType<Projectiles.DirtGlobFriendly>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (Main.remixWorld) {
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1f);
				return false;
            }
			return true;
        }
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Dirt);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<AdeniteSecurityHandgun>());
			recipe.AddIngredient(ItemID.DirtBlock, 100);
            recipe.AddIngredient(ItemID.Ectoplasm, 13);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddCondition(Condition.RemixWorld);
			recipe.Register();
		}
	}
}