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
			// Tooltip.SetDefault("'We back in Meteor Herd'\nRains tiny meteors from above");
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 13;
			Item.DamageType = DamageClass.Magic;
			Item.width = 42;
			Item.height = 46;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 3, 12);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.MeteorHerderProj>();
			Item.shootSpeed = 18f;
			Item.mana = 4;
			Item.noMelee = true;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            Vector2 spawn = new Vector2(Main.MouseWorld.X + Main.rand.Next(-260, 261), player.position.Y - 500);
			Vector2 target2 = spawn - Main.MouseWorld;
			target2.Normalize();
			Projectile.NewProjectile(Item.GetSource_FromThis(), spawn, target2*(Item.shootSpeed*Main.rand.NextFloat(-1.2f, -0.7f)), type, damage, knockback, Main.myPlayer);
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