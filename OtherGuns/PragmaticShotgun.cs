using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherGuns
{
	public class PragmaticShotgun : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pragmatic Shotgun");
			Tooltip.SetDefault("Every shot fires a volley of bullets and an onyx blast");
		}

		public override void SetDefaults()  {
			item.value = 650000;
			item.useStyle = 5;
			item.useAnimation = 54;
			item.useTime = 54;
			item.damage = 294;
			item.width = 12;
			item.height = 24;
			item.knockBack = 0.1f;
			item.shoot = 14;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item36;
			item.autoReuse = true;
			item.rare = 11;
			item.noMelee = true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-10, -6);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians(5);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 125f;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			Projectile.NewProjectile(player.Center.X, player.Center.Y, (int)(speedX * 0.9), (int)(speedY * 0.9), 661, damage, knockBack, Main.myPlayer);
			return false;
		}
		
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .65f)
            return false;
			else
			return true;
        }
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OnyxBlaster);
			recipe.AddIngredient(ItemID.TacticalShotgun);
			recipe.AddIngredient(mod.ItemType("InfectedOnyx"), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}