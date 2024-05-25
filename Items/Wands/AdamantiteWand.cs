using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class AdamantiteWand : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 55;
			Item.DamageType = DamageClass.Magic;
			Item.width = 66;
			Item.height = 66;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.1f;
			Item.value = Item.sellPrice(0, 2, 76);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.AdamantiteWandProj>();
			Item.shootSpeed = 32f;
			Item.mana = 6;
			Item.noMelee = true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8f));
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position+Vector2.Normalize(velocity)*50f, velocity, type, damage, knockback, Main.myPlayer);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
    }
}