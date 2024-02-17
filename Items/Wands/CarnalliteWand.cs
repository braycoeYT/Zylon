using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class CarnalliteWand : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Rains leaves from the sky at the cursor");
			Item.staff[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 21;
			Item.width = 28;
			Item.height = 30;
			Item.DamageType = DamageClass.Magic;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 0, 56, 0);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.CarnalliteWandProj>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 11;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float direc = Main.rand.NextFloat(MathHelper.TwoPi);
			Vector2 startPos = player.Center + new Vector2(Main.rand.Next(-120, 121), Main.rand.Next(-90, -29));

			//Was originally going to have them launch one at a time (i*20), but for some reason the projectiles break.
			//I also ended up liking this version better.
			for (int i = 0; i < 5; i++) {
				Projectile.NewProjectile(source, startPos+new Vector2(0, i*12).RotatedBy(direc), Vector2.Zero, type, damage, knockback, player.whoAmI);
            }
			return false;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}