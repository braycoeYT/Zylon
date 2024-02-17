using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class ChlorophyteBlowspitter : ZylonBlowpipe
	{
		public ChlorophyteBlowspitter() : base(260, 2.6f, new Color(36, 137, 0), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Shoots many seeds at once depending on charge, consuming only one ammo\nAt max charge, replaces ammo with homing chlorophyte seeds\nRight click to disable and enable this effect");
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 39;
			Item.knockBack = 1.5f;
			Item.shootSpeed = 9.5f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
		}
		int summonNum;
        public override void ChargeEvent(Player player) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(4*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 4 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 3;
			summonNum += 2;
        }
        public override void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!(charge >= maxCharge + p.blowpipeMaxInc && maxReplace))
				for (int i = 0; i < summonNum; i++) {
					Vector2 perturbedSpeed = vel.RotatedBy(MathHelper.ToRadians(i*2-(float)(summonNum)));
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, perturbedSpeed*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
				}
			else {
				for (int i = 0; i < summonNum; i++) {
					Vector2 perturbedSpeed = vel.RotatedBy(MathHelper.ToRadians(i*2-(float)(summonNum)));
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, perturbedSpeed*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.ChlorophyteBlowspitterProj>(), tempDmg, tempKb, Main.myPlayer);
				}
            }
			summonNum = 0;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}