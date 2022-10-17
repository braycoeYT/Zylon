using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class IcyGreatblade : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots several rapid icy bolts");
		}
		public override void SetDefaults() {
			Item.damage = 59;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.3f;
			Item.value = Item.sellPrice(0, 5, 50, 0);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.IceBoltRanged>();
			Item.shootSpeed = 23f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 11), false);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 11), false);
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int numberProjectiles = 2 + Main.rand.Next(2);
			SoundEngine.PlaySound(SoundID.Item9, position);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(velocity.X * Main.rand.NextFloat(0.8f, 1.2f), velocity.Y * Main.rand.NextFloat(0.9f, 1.1f)).RotatedByRandom(MathHelper.ToRadians(20));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, (int)(damage * 0.65f), knockback * 0.5f, player.whoAmI, 1f);
			}
			Projectile.NewProjectile(source, position, velocity, type, (int)(damage * 0.65f), knockback * 0.5f, player.whoAmI, 1f);
			return false;
		}
        public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(Item.position, Item.width, Item.height, DustID.Ice);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes()  {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddIngredient(ItemID.AdamantiteBar, 6);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddIngredient(ItemID.TitaniumBar, 6);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}