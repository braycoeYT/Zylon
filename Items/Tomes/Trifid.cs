using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class Trifid : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 71;
			Item.DamageType = DamageClass.Magic;
			Item.width = 36;
			Item.height = 48;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.25f;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ModContent.RarityType<RedModded>();
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.TrifidProj>();
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.mana = 5;
			Item.UseSound = SoundID.Item43;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(Main.rand.NextFloat(-7f, 7f))), type, damage, knockback, Main.myPlayer);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentNebula, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}