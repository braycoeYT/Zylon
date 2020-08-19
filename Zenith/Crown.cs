using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Zenith
{
	public class Crown : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Shoot four arrows at once\nTwo ichor bolts are shot in random directions");
		}

		public override void SetDefaults() 
		{
			item.useStyle = 5;
			item.useAnimation = 8;
			item.useTime = 8;
			item.damage = 31; //118
			item.width = 12;
			item.height = 24;
			item.knockBack = 0;
			item.shoot = 1;
			item.shootSpeed = 20f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.value = 1000000;
			item.rare = 10;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 4;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 1.5f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY).RotatedByRandom(MathHelper.TwoPi), 280, damage, knockBack, Main.myPlayer);
			Projectile.NewProjectile(player.Center, new Vector2(speedX, speedY).RotatedByRandom(MathHelper.TwoPi), 280, damage, knockBack, Main.myPlayer);
			return false;
		}
		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Phantasm);
			recipe.AddIngredient(ItemID.Tsunami);
			recipe.AddIngredient(ItemID.PulseBow);
			recipe.AddIngredient(mod.ItemType("TwinOpticbow"));
			recipe.AddIngredient(ItemID.ShadowFlameBow);
			recipe.AddIngredient(ItemID.DaedalusStormbow);
			recipe.AddIngredient(ItemID.MoltenFury);
			recipe.AddIngredient(ItemID.BeesKnees);
			recipe.AddIngredient(ItemID.WoodenBow);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}