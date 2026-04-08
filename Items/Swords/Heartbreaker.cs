using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Heartbreaker : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 20;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 54;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}
		int healedNum;
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (target.type != NPCID.TargetDummy) {
				int rand = Main.rand.Next(1, 3);
				if (Main.rand.NextBool(100)) rand = 20;
				player.statLife += rand;
				player.HealEffect(rand, true);

				if (rand == 20) {
					SoundEngine.PlaySound(SoundID.Shatter, target.Center);
					for (int i = 0; i < 12; i++) {
						int dustType = DustID.RedTorch;
						int dustIndex = Dust.NewDust(target.position, target.width, target.height, dustType);
						Dust dust = Main.dust[dustIndex];
						dust.velocity = new Microsoft.Xna.Framework.Vector2(0, -10).RotatedBy(MathHelper.ToRadians(i*20));
						dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
					}
				}

				healedNum += rand;
				while (healedNum > 9) {
					healedNum -= 10;

					Vector2 offset = new Vector2(Main.rand.Next(160, 341), Main.rand.Next(160, 341));
					if (Main.rand.NextBool()) offset.X *= -1;
					if (Main.rand.NextBool()) offset.Y *= -1;

					if (Main.myPlayer == player.whoAmI) Projectile.NewProjectile(player.GetSource_FromThis(), target.Center + offset, Vector2.Zero, ModContent.ProjectileType<Projectiles.Swords.HeartbreakerProj>(), damageDone, 3f, player.whoAmI, target.whoAmI);
				}
			}
		}
		public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			player.statLife += 2;
			player.HealEffect(2, true);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBroadsword);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddRecipeGroup("Zylon:AnyGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LeadBroadsword);
			recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddRecipeGroup("Zylon:AnyGem", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}