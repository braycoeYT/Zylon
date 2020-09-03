using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Infected
{
	public class DragonSneeze : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dragon's Sneeze");
			Tooltip.SetDefault("Launches several snot droplets randomly towards the cursor\nThe droplets make enemies sick, decreasing attack power by 20%");
		}

		public override void SetDefaults() 
		{
			item.value = 200000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 23;
			item.useTime = 23;
			item.damage = 18;
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.8f;
			item.shoot = mod.ProjectileType("DragonSnot");
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.LightRed;
			item.mana = 8;
			item.UseSound = SoundID.Item116;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8 + Main.rand.Next(2)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X + Main.rand.Next(0, 2), perturbedSpeed.Y + Main.rand.Next(0, 2), type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SpellTome);
			recipe.AddIngredient(mod.ItemType("InfectedBlood"), 20);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.AddTile(TileID.Bookcases);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}