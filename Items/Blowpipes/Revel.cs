using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Revel : ZylonBlowpipe
	{
		public Revel() : base(165, 1.55f, new Color(30, 0, 90), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			Tooltip.SetDefault("Fire two seeds at once and for the price of one\nAt max charge, replaces ammo with deadly toxin darts");
=======
			// Tooltip.SetDefault("Fire two seeds at once and for the price of one\nAt max charge, replaces ammo with deadly toxin darts");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 13;
			Item.knockBack = 1.5f;
			Item.shootSpeed = 9.5f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
		}
        public override void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			for (int i = 0; i < 2; i++) {
				Vector2 perturbedSpeed = vel.RotatedBy(MathHelper.ToRadians(i-0.5f));
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, perturbedSpeed*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.DeadlyToxinDart>(), tempDmg, tempKb, Main.myPlayer);
			}
			//Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.DeadlyToxinDart>(), tempDmg, tempKb, player.whoAmI);
		}
        public override void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!(charge >= maxCharge + p.blowpipeMaxInc && maxReplace))
				for (int i = 0; i < 2; i++) {
					Vector2 perturbedSpeed = vel.RotatedBy(MathHelper.ToRadians(i-0.5f));
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, perturbedSpeed*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
				}
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 12);
			recipe.AddIngredient(ItemID.BeeWax, 15);
			recipe.AddIngredient(ItemID.Stinger, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}