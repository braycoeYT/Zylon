using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class CrystalTsunami : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 51;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.25f;
			Item.value = Item.sellPrice(0, 6, 17);
			Item.rare = ItemRarityID.Lime;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.CrystalTsunamiProj>();
			Item.shootSpeed = 13f;
			Item.noMelee = true;
			Item.mana = 5;
			Item.UseSound = SoundID.Item73;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Item.reuseDelay = Main.rand.Next(0, 3);
			Projectile.NewProjectile(source, position, (velocity*Main.rand.NextFloat(0.6f, 1.4f)).RotatedByRandom(MathHelper.ToRadians(13)), type, damage, knockback, player.whoAmI);
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SapphireSpellbook>());
			recipe.AddIngredient(ItemID.CrystalStorm);
			recipe.AddIngredient(ModContent.ItemType<Materials.SpectralFairyDust>(), 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}