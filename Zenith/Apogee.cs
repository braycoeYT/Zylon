using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Zenith
{
	public class Apogee : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Apogee");
			Tooltip.SetDefault("Shoots three bullets forward, and an inaccurate high velocity bullet.\nPoisonous gel rains above your cursor while in use");
		}

		public override void SetDefaults() 
		{
			item.value = 1000000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 6;
			item.useTime = 6;
			item.damage = 65; //116
			item.width = 12;
			item.height = 24;
			item.knockBack = 1.6f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Purple;
			item.noMelee = true;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(7);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 75f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Vector2 mouseOffset;
			mouseOffset.X = Main.MouseWorld.X + Main.rand.Next(-100, 101);
			mouseOffset.Y = Main.MouseWorld.Y + Main.rand.Next(-100, 101);
			Vector2 offset = Vector2.Normalize(player.Center - mouseOffset) * -item.shootSpeed;
			Projectile.NewProjectile(position.X, position.Y, offset.X, offset.Y, ProjectileID.BulletHighVelocity, damage, knockBack, player.whoAmI);
			Projectile.NewProjectile(Main.MouseWorld.X, player.position.Y - 600, Main.rand.Next(-3, 3), 25, mod.ProjectileType("VenomousGel"), damage / 2, knockBack, player.whoAmI);
			return false;
		}
		
		public override bool ConsumeAmmo(Player player)
        {
			if (Main.rand.NextFloat() < .2f)
            return false;
			else
			return true;
        }

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SDMG);
			recipe.AddIngredient(ItemID.VortexBeater);
			recipe.AddIngredient(ItemID.Xenopopper);
			recipe.AddIngredient(ItemID.ChainGun);
			recipe.AddIngredient(ItemID.VenusMagnum);
			recipe.AddIngredient(ItemID.Uzi);
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.PhoenixBlaster);
			recipe.AddIngredient(mod.ItemType("DeadlockPistol"));
			recipe.AddIngredient(mod.ItemType("DirtyPistol"));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}