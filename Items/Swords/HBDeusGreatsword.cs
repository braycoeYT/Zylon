using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class HBDeusGreatsword : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("HBDeus's Greatsword");
			Tooltip.SetDefault("UNOBTAINABLE: Developer Item\nSurrounds the cursor with shattered swords");
		}
		public override void SetDefaults() {
			Item.damage = 819;
			Item.DamageType = DamageClass.Melee;
			Item.width = 112;
			Item.height = 112;
			Item.useTime = 7;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.8f;
			Item.value = Item.sellPrice(2, 0, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.ShatteredSword>();
			Item.shootSpeed = 14f;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
            foreach (TooltipLine tooltipLine in list) {
                if (tooltipLine.Mod == "Terraria" && tooltipLine.Name == "ItemName") {
                    tooltipLine.OverrideColor = new Color(224, 153, 0);
                }
            }
        }
		float spin;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            spin += 63;
			Vector2 vel2 = new Vector2(0, 15).RotatedBy(MathHelper.ToRadians(spin));
			Projectile.NewProjectile(source, Main.MouseWorld - (vel2 * 20), vel2, ModContent.ProjectileType<Projectiles.Swords.ShatteredSword>(), Item.damage, Item.knockBack / 2, Main.myPlayer);
			vel2 = vel2.RotatedBy(MathHelper.ToRadians(180));
			Projectile.NewProjectile(source, Main.MouseWorld - (vel2 * 20), vel2, ModContent.ProjectileType<Projectiles.Swords.ShatteredSword>(), Item.damage, Item.knockBack / 2, Main.myPlayer);

			return false;
        }
        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			int numberProjectiles = 2 + Main.rand.Next(3);
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-3, 3), 20);
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(Main.MouseWorld.X, position.Y - Main.rand.Next(500, 701), perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.75f), (int)(knockBack * 0.5f), player.whoAmI);
			}
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = new Vector2(Main.rand.NextFloat(-3, 3), -20);
				// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(Main.MouseWorld.X, position.Y + Main.rand.Next(500, 701), perturbedSpeed.X, perturbedSpeed.Y, type, (int)(damage * 0.75f), (int)(knockBack * 0.5f), player.whoAmI);
			}
			return false;
		}*/
    }
}