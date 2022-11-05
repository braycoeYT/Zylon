using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Stone
{
	public class StoneSword : ModItem
	{
		bool SwingSide = false;
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 31;
			Item.useAnimation = 31;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 5.25f;
			Item.value = 150;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Stone.StoneSwordProj>();
			Item.shootSpeed = 5.7f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (SwingSide == true)
			{
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Stone.StoneSwordProj>(), damage, knockback, player.whoAmI, 0, 0);
			}
			else
			{
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Stone.StoneSwordProj>(), damage, knockback, player.whoAmI, 0, 1);
			}

			SwingSide = !SwingSide;

			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 12);
			recipe.AddIngredient(ItemID.Gel, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}