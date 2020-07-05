using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class AeroBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("This blade's most powerful weapon is breaking your ears\nShoots a barrage of yellow stars\n30% Chance of shooting a feather\n10% Chance of shooting a giant darkstar");
		}

		public override void SetDefaults() 
		{
			item.damage = 82;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 6.4f;
			item.value = 500000;
			item.rare = 8;
			item.scale = 1.6f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("Darkstar");
			item.shootSpeed = 35f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (Main.rand.NextFloat() < .3f)
			type = mod.ProjectileType("Feather");
			else if (Main.rand.NextFloat() < .1f)
			type = mod.ProjectileType("Darkstar");
			else
			type = 12;
			
			float numberProjectiles = 1;
			if (type == 12)
			numberProjectiles = Main.rand.Next(2, 5);
			else
			numberProjectiles = 1;
			if (numberProjectiles > 1)
			{
				float rotation = MathHelper.ToRadians(5);
				position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
			}
			return true;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("Astrafury"));
			recipe.AddIngredient(mod.ItemType("SpaceScourge"));
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ItemID.SoulofFlight, 25);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(mod.ItemType("SoulOfByte"));
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}