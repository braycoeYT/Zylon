using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class DirtFunnel : ZylonBlowpipe
	{
		public DirtFunnel() : base(125, 1.4f, new Color(125, 63, 0)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Converts ammo to up to four dirt balls (depending on charge), of which only the first consumes ammo");
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 6;
			Item.knockBack = 0f;
			Item.shootSpeed = 7.1f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Gray;
			Item.autoReuse = true;
        }
        public override bool CanUseItem(Player player) {
            return moreShots < 1;
        }
		int moreShots;
		int moreShotsCount;
		int reShotCounter;
        public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            moreShotsCount = 1 + (int)(3*charge/(maxCharge + p.blowpipeMaxInc));
			if (moreShotsCount == 4 && charge < maxCharge + p.blowpipeMaxInc) moreShotsCount = 3;
        }
        public override void UpdateInventory(Player player) {
			//Main.NewText(reShotCounter + "|" + moreShots + "|" + shootMode);
			reuseCounter--;
			reShotCounter--;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!Main.mouseLeft && moreShotsCount > 0) {
				moreShots = moreShotsCount;
				moreShotsCount = 0;
            }
            if (shootMode == 2 && !Main.mouseLeft && moreShots > 0 && reShotCounter <= 0) {
				reShotCounter = 5;
				moreShots--;
				//if (charge > maxCharge*p.blowpipeMaxOverflow) charge = maxCharge*p.blowpipeMaxOverflow;
				//Main.NewText(ammoDamage + "|" + ammoKb + "|" + ammoSpd);
				tempDmg = ammoDamage + (int)((Item.damage + (int)(((Item.damage*2f)*((float)charge/(float)(maxCharge))))*p.blowpipeChargeDamageMult) + (p.blowpipeChargeDamageAdd*((float)charge/(float)(maxCharge))));
				float tempCharge = charge;
				if (tempCharge > maxCharge) tempCharge = maxCharge;
				tempKb = ammoKb + (Item.knockBack + ((Item.knockBack*1.2f)*((float)tempCharge/(float)(maxCharge))))*p.blowpipeChargeKnockbackMult + p.blowpipeChargeKnockbackAdd;//*((float)tempCharge/(float)(maxCharge)));
				tempSpd = ammoSpd + (Item.shootSpeed + ((Item.shootSpeed*0.5f)*((float)tempCharge/(float)(maxCharge))))*p.blowpipeChargeShootSpeedMult + p.blowpipeChargeShootSpeedAdd;//*((float)tempCharge/(float)(maxCharge)));
				if (tempSpd < p.blowpipeMinShootSpeed + minshootspeed) tempSpd = p.blowpipeMinShootSpeed + minshootspeed;

				if (reuseCounter > 0) {
					tempDmg /= 10;
					tempKb = 0f;
                    tempSpd = 1f;
					CombatText.NewText(player.getRect(), textColor, "EXHAUSTION!");
                }

                vel = Main.MouseWorld - player.Center;
				vel.Normalize();
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.DirtBallFunnel>(), tempDmg, tempKb, Main.myPlayer);
				
				if (charge >= maxCharge) {
					DefaultMaxChargeEvent(player, vel, tempType, tempDmg, tempKb, tempSpd);
					if (charge >= maxCharge + p.blowpipeMaxInc) MaxChargeEvent(player, vel, tempType, tempDmg, tempKb, tempSpd);
					if (doSpore && moreShots == 1) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Normalize(vel)*9f, ModContent.ProjectileType<Projectiles.WadofSpores>(), Item.damage, Item.knockBack, player.whoAmI);
                }
				
				if (moreShots > 0) return;

				charge = (int)(charge*p.blowpipeChargeRetain);
				shootCount = -1;
				reuseCounter = 45;
				aaa = false;
            }
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
    }
}