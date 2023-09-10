using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MagicGuns
{
	public class EerieGlove : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Barrages enemies with tracking jellies");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 2);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 9;
			Item.useTime = 9;
			Item.damage = 19;
			Item.width = 28;
			Item.height = 32;
			Item.knockBack = 1.6f;
			Item.shoot = ModContent.ProjectileType<Projectiles.MagicGuns.EerieGloveProj>();
			Item.shootSpeed = 12f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Orange;
			Item.mana = 6;
			Item.UseSound = SoundID.Item116;
			Item.noUseGraphic = true;
		}
		Vector2 track;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			track = velocity;
			return true;
		}
        public override void UseStyle(Player player, Rectangle heldItemFrame) {
			Projectile.NewProjectile(Item.GetSource_FromThis(), player.position, track, ModContent.ProjectileType<Projectiles.MagicGuns.EerieGloveHand>(), 0, 0f, Main.myPlayer);
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