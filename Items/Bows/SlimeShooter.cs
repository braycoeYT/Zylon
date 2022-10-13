using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Bows
{
	public class SlimeShooter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Turns regular arrows into slime arrows");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 0, 30, 0);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 26;
			Item.useTime = 26;
			Item.damage = 13;
			Item.width = 12;
			Item.height = 24;
			Item.knockBack = 2f;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
			Item.shootSpeed = 6f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.rare = ItemRarityID.Blue;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (type == ProjectileID.WoodenArrowFriendly) type = ProjectileType<Projectiles.Ammo.SlimeArrow>();
			return true;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (type == ProjectileID.WoodenArrowFriendly)
				type = mod.ProjectileType("SlimeArrow");
			return true;
		}*/
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 8);
			recipe.AddIngredient(ItemType<Materials.SlimyCore>(), 5);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}