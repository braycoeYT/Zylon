using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class SapphireSpellbook : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 2.5f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.SapphireSpellbookProj>();
			Item.shootSpeed = 9f;
			Item.noMelee = true;
			Item.mana = 8;
			Item.UseSound = SoundID.Item20;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Item.reuseDelay = Main.rand.Next(0, 7);
			Projectile.NewProjectile(source, position, (velocity*Main.rand.NextFloat(0.6f, 1.4f)).RotatedByRandom(MathHelper.ToRadians(12)), type, damage, knockback, player.whoAmI);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.Cerussite>(), 15);
			recipe.AddIngredient(ItemID.Sapphire, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}