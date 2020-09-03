using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Carnallite
{
	public class Rosemary : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots several rosesparks that can confuse enemies");
		}
		public override void SetDefaults() {
			item.value = Item.sellPrice(0, 2, 75, 0);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 35;
			item.useTime = 35;
			item.damage = 37;
			item.width = 12;
			item.height = 24;
			item.knockBack = 2.1f;
			item.shoot = mod.ProjectileType("Rosespark");
			item.shootSpeed = 9f;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.rare = ItemRarityID.Yellow;
			item.mana = 9;
			item.UseSound = SoundID.Item116;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(8 + Main.rand.Next(2)));
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X + Main.rand.Next(0, 2), perturbedSpeed.Y + Main.rand.Next(0, 2), type, damage, knockBack, player.whoAmI);
			}
			return false;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("CarnalliteBar"), 12);
			recipe.AddIngredient(mod.ItemType("FloralUndergrowth"), 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}