using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MagicGuns
{
	public class SpaceMachineGun : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Not to be confused with the S.D.M.G.'\nFires red blasts at random speeds\nIs not affected by the meteor armor set bonus");
		}
		public override void SetDefaults() {
			Item.damage = 28;
			Item.DamageType = DamageClass.Magic;
			Item.width = 64;
			Item.height = 24;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 6, 18);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.MagicGuns.SMGBlast>();
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.mana = 9;
			Item.UseSound = SoundID.Item91;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Item.reuseDelay = Main.rand.Next(13);
			return true;
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpaceGun);
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 12);
			recipe.AddIngredient(ItemID.FallenStar, 9);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}