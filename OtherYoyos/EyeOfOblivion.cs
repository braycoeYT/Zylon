using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherYoyos
{
	public class EyeOfOblivion : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Eye of Oblivion");
			Tooltip.SetDefault("Powered by the sun!\nShoots two yoyos, the second one orbits around the first\nBoth yoyos can burn enemies");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 4f;
			item.damage = 145;
			item.rare = 9;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = 1000000;
			item.shoot = ProjectileType<Projectiles.OtherYoyos.EyeOfOblivion>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(position.X, position.Y, speedX * -1, speedY * -1, type, damage, knockBack, player.whoAmI);
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DirtYoyo"));
			recipe.AddIngredient(mod.ItemType("Stalkeye"));
			recipe.AddIngredient(mod.ItemType("TheMeatbringer"));
			recipe.AddIngredient(ItemID.TheEyeOfCthulhu);
			recipe.AddIngredient(ItemID.FragmentSolar, 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}