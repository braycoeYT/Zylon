using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Mineral
{
	public class ArmarosaHypergun : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Armarosa Hypergun");
			Tooltip.SetDefault("En...en...enchanted...\nThere is a 25% chance of a crystal to be shot with the bullet\n20% chance to not consume ammo");
		}

		public override void SetDefaults()  {
			item.value = 300000;
			item.useStyle = 5;
			item.useAnimation = 5;
			item.useTime = 5;
			item.damage = 98;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2.2f;
			item.shoot = 14;
			item.shootSpeed = 10f;
			item.noMelee = true;
			item.ranged = true;
			item.useAmmo = AmmoID.Bullet;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.rare = 11;
			item.noMelee = true;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(-3, 0);
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (Main.rand.NextFloat() < .25f)
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("GemstoneSpike"), damage, knockBack, player.whoAmI);
			return true;
		}
		public override bool ConsumeAmmo(Player player) {
			if (Main.rand.NextFloat() < .2f)
            return false;
			else
			return true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("ArmagrisFirearms"));
			recipe.AddIngredient(mod.ItemType("GalacticDiamondium"), 10);
			recipe.AddIngredient(mod.ItemType("EctojeweloBar"), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}