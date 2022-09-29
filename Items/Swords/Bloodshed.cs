using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Bloodshed : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'There will be'\nStruck enemies release rapid blood orbs");
		}
		public override void SetDefaults() {
			Item.damage = 31;
			Item.DamageType = DamageClass.Melee;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3.6f;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
		}
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			Projectile.NewProjectile(new EntitySource_TileBreak((int)target.position.X, (int)target.position.Y), target.Center, new Vector2(0, -10).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<Projectiles.Swords.BloodOrb>(), Item.damage, Item.knockBack / 2, Main.myPlayer);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			Projectile.NewProjectile(new EntitySource_TileBreak((int)target.position.X, (int)target.position.Y), target.Center, new Vector2(0, -10).RotatedByRandom(MathHelper.ToRadians(360)), ModContent.ProjectileType<Projectiles.Swords.BloodOrb>(), Item.damage, Item.knockBack / 2, Main.myPlayer);
		}
		public override void AddRecipes() { //finish
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BoneSword);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 30);
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 10);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}