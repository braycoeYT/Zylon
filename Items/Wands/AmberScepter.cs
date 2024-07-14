using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class AmberScepter : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 11;
			Item.DamageType = DamageClass.Magic;
			Item.width = 58;
			Item.height = 58;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.AmberScepterProj>();
			Item.shootSpeed = 3f;
			Item.mana = 5;
			Item.noMelee = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position+Vector2.Normalize(velocity)*70f, velocity.RotatedByRandom(MathHelper.ToRadians(60)), type, damage, knockback, Main.myPlayer);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Cerussite>(), 15);
			recipe.AddIngredient(ItemID.Amber, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}