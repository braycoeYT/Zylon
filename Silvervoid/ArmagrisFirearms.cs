using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Silvervoid
{
	public class ArmagrisFirearms : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Armagris Firearms");
			Tooltip.SetDefault("That pink gun's little brother\nThere is a 10% chance of a silvervoid pellet to be shot with the bullet\n10% chance to not consume ammo");
		}

		public override void SetDefaults() {
			item.value = 150000;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 6;
			item.useTime = 6;
			item.damage = 87;
			item.width = 60;
			item.height = 45;
			item.knockBack = 1.1f;
			item.shoot = ProjectileID.Bullet;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = ItemRarityID.Red;
			item.noMelee = true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-3, 0);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (Main.rand.NextFloat() < .1f)
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("SilvervoidPellet"), damage, knockBack, player.whoAmI);
			return true;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .1f)
            return false;
			else
			return true;
        }
		
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("SilvervoidCore"), 11);
			recipe.AddIngredient(ItemID.LunarBar, 9);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}