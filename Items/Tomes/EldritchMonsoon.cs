using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class EldritchMonsoon : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Summons three jellyfish to dash at enemies");
		}
		public override void SetDefaults() {
			Item.damage = 21;
			Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 46;
			Item.useAnimation = 46;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.MonsoonProj>();
			Item.shootSpeed = 0.1f;
			Item.noMelee = true;
			Item.mana = 14;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        	for (int i = 0; i < 3; i++) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.position + new Vector2(Main.rand.Next(-160, 161), Main.rand.Next(-160, 161)), Vector2.Zero, type, damage, knockback, Main.myPlayer);
			}
			return false;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}