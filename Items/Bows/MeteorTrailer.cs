using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class MeteorTrailer : ModItem
	{
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1, 52);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 49;
			Item.useTime = 49;
			Item.damage = 17;
			Item.width = 20;
			Item.height = 46;
			Item.knockBack = 5f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Green;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Vector2 temp = velocity;
			temp.Normalize();
			temp *= 60f;
			for (int i = 0; i < 3; i++)
				Projectile.NewProjectile(source, position-(temp*(i+1)), velocity, ModContent.ProjectileType<Projectiles.Bows.TrailMeteorite>(), (int)(damage*0.7f), knockback*0.5f, Main.myPlayer, i);
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<Bars.HaxoniteBar>(), 8);
			recipe.AddIngredient(ItemID.MeteoriteBar, 4);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}