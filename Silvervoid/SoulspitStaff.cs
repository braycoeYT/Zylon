using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Silvervoid
{
	public class SoulspitStaff : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Summons two lost souls to chase your enemies");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 143;
			item.magic = true;
			item.width = 33;
			item.height = 33;
			item.useTime = 17;
			item.useAnimation = 17;
			item.useStyle = 5;
			item.knockBack = 1;
			item.value = 250000;
			item.rare = 10;
			item.autoReuse = true;
			item.useTurn = false;
			item.shoot = 297;
			item.shootSpeed = 6f;
			item.noMelee = true;
			item.mana = 16;
			item.stack = 1;
			item.UseSound = SoundID.Item43;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 2;
			float rotation = MathHelper.ToRadians(11f);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpectreStaff);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 11);
			recipe.AddIngredient(ItemID.LunarBar, 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}