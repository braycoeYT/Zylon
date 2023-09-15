using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class MeteorHerder : ModItem
	{
        public override void SetStaticDefaults() {
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 19;
			Item.DamageType = DamageClass.Magic;
			Item.width = 42;
			Item.height = 46;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 3, 12);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.MeteorHerderProj>();
			Item.shootSpeed = 18f;
			Item.mana = 8;
			Item.noMelee = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			for (int x = 0; x < 3; x++) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center + new Vector2(0, 48).RotatedByRandom(MathHelper.TwoPi), Vector2.Zero, ModContent.ProjectileType<Projectiles.Wands.MeteorHerderProj>(), Item.damage, Item.knockBack, Main.myPlayer, 25*(x+1));
            }
			return false;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 4);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}