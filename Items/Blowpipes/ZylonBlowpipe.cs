using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public abstract class ZylonBlowpipe : ModItem
	{
		public Color textColor = new Color(0, 0, 0);
		public float maxCharge;
		public float charge;
		public float chargeRate;
		public float chargeRetain = 0f;
		public float minshootspeed = 0f;
		public int chargeCount;
		public int shootCount;
		public int shootMode;
		public bool maxReplace;
		public ZylonBlowpipe(int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f) {
			maxCharge = maxChargeI;
			chargeRate = chargeRateI;
			textColor = textColorI;
			chargeRetain = chargeRetainI;
			minshootspeed = minshootspeedI;
			maxReplace = maxReplaceI;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			float temp3 = (chargeRate * 30);
			float temp4 = ((chargeRate + p.blowpipeChargeInc) * 30);
			if (ModContent.GetInstance<ZylonConfig>().advBlowpipe) {
				float newMult = (maxCharge+p.blowpipeMaxInc)/maxCharge;
				TooltipLine line = new TooltipLine(Mod, "Tooltip#0", "Maximum blowpipe charge: " + maxCharge + " (" + (maxCharge + p.blowpipeMaxInc) + ")");
				TooltipLine line2 = new TooltipLine(Mod, "Tooltip#1", "Blowpipe charge speed: " + temp3.ToString("0.00") + "/s (" + temp4.ToString("0.00") + "/s)");
				float temp1 = (Item.knockBack + Item.knockBack*1.2f)*p.blowpipeChargeKnockbackMult + p.blowpipeChargeKnockbackAdd;
				float temp2 = (Item.shootSpeed + Item.shootSpeed*0.5f)*p.blowpipeChargeShootSpeedMult + p.blowpipeChargeShootSpeedAdd;
				float temp5 = Item.knockBack*2.2f;
				float temp6 = Item.shootSpeed*1.5f;
				TooltipLine line3 = new TooltipLine(Mod, "Tooltip#2", "Blowpipe at max charge does: " + Item.damage*3
					+ " (" + ((Item.damage + (int)((Item.damage*2f)*newMult)*p.blowpipeChargeDamageMult + p.blowpipeChargeDamageAdd*newMult) + ") DMG; "
					+ temp5.ToString("0.00") + " (" + temp1.ToString("0.00") + ") KB; "
					+ temp6.ToString("0.00") + " (" + temp2.ToString("0.00") + ") SPD; KB and SPD are limited to max charge."));
				TooltipLine line4 = new TooltipLine(Mod, "Tooltip#3", "Blowpipe charge retain: " + (chargeRetain + p.blowpipeChargeRetain) + "%");
				TooltipLine line5 = new TooltipLine(Mod, "Tooltip#4", "Minimum blowpipe shoot speed: " + (minshootspeed + p.blowpipeMinShootSpeed));
				//TooltipLine line6 = new TooltipLine(Mod, "Tooltip#5", );
				//TooltipLine line7 = new TooltipLine(Mod, "Tooltip#6", );
				tooltips.Add(line);
				tooltips.Add(line2);
				tooltips.Add(line3);
				tooltips.Add(line4);
				tooltips.Add(line5);
				//tooltips.Add(line6);
				//tooltips.Add(line7);
            }
			else {
				TooltipLine xline = new TooltipLine(Mod, "Tooltip#0", "Only usable in the player's inventory");
				TooltipLine xline2 = new TooltipLine(Mod, "Tooltip#1", "Hold down left click to inhale.");
				TooltipLine xline3 = new TooltipLine(Mod, "Tooltip#2", "The longer you inhale, the more speed, knockback, and damage the ammo deals.");
				TooltipLine xline4 = new TooltipLine(Mod, "Tooltip#3", "Shooting too quickly will cause exhaustion and greatly weaken your attacks.");
				TooltipLine xline5 = new TooltipLine(Mod, "Tooltip#4", "A sound will play at max charge, which can be disabled in the config; dust will also be released.");
				TooltipLine xline6 = new TooltipLine(Mod, "Tooltip#5", "Uses seeds as ammo");
				TooltipLine xline7 = new TooltipLine(Mod, "Tooltip#6", "Maximum blowpipe charge: " + maxCharge + " (" + ((int)maxCharge + (int)p.blowpipeMaxInc) + ")");
				TooltipLine xline8 = new TooltipLine(Mod, "Tooltip#7", "Blowpipe charge speed: " + temp3.ToString("0.00") + "/s (" + temp4.ToString("0.00") + "/s)");
				TooltipLine xline9 = new TooltipLine(Mod, "Tooltip#8", "Enable 'Advanced Blowpipe Display' in the config to show more stats");
				tooltips.Add(xline);
				tooltips.Add(xline2);
				tooltips.Add(xline3);
				tooltips.Add(xline4);
				tooltips.Add(xline5);
				tooltips.Add(xline6);
				tooltips.Add(xline7);
				tooltips.Add(xline8);
				tooltips.Add(xline9);
            }
        }
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			/*Item.damage = 15;
			Item.knockBack = 2.5f;
			Item.shootSpeed = 8f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 40, 5);*/
			Item.autoReuse = true;
			//Item.rare = 1;
		}
        public override void Update(ref float gravity, ref float maxFallSpeed) {
            charge = 0;
        }
        public Vector2 vel;
		public int tempDmg;
		public float tempKb;
		public float tempSpd;
		public int tempType;
		public int reuseCounter;
		public bool aaa;
		public bool doSpore;
		public int ammoDamage;
		public float ammoKb;
		public float ammoSpd;
		private bool setup;
		public bool noise = false;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (player.altFunctionUse == 2) {
				AltClickEvent(player);
				return false;
            }
			aaa = true;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			doSpore = p.wadofSpores;
			shootCount++;
			shootMode = 0;
            if (Main.mouseLeft) shootMode = 1;
			if (shootMode == 1) {
				charge += (chargeRate*p.blowpipeChargeMult + p.blowpipeChargeInc)/2;
				if (charge > maxCharge + p.blowpipeMaxInc) {
					charge = maxCharge + p.blowpipeMaxInc;
					if (!noise) {
						if (ModContent.GetInstance<ZylonConfig>().blowpipeNoise) SoundEngine.PlaySound(new SoundStyle("Zylon/Sounds/Items/BlowpipeMaxCharge"), position);
						for (int i = 0; i < 24; i++) {
							Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.Cloud);
							dust.noGravity = true;
							dust.scale = 2.5f;
							dust.velocity = new Vector2(0, 10).RotatedBy(i*15);
                        }
						CombatText.NewText(player.getRect(), textColor, "MAX!");
						noise = true;
					}
				}
				if (shootCount % 20 == 1) {
					if (charge == maxCharge + p.blowpipeMaxInc) {
						CombatText.NewText(player.getRect(), textColor, "MAX!");
					}
					else CombatText.NewText(player.getRect(), textColor, (int)charge);
                }
				ChargeEvent(player);
            }
			shootMode = 2;
			tempType = type;
			ammoDamage = damage - Item.damage;
			ammoKb = knockback - Item.knockBack;
			ammoSpd = velocity.Length() - Item.shootSpeed;
			//Note: figure out how to get item so that ammo crit works.
			return false;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount == 0; //this doesn't work
        }
        public override void UpdateInventory(Player player) {
			reuseCounter--;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            if (shootMode == 2 && !Main.mouseLeft && aaa) {
				noise = false;
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
				ShootEvent(player, vel, tempType, tempDmg, tempKb, tempSpd);
				ShootAction(player, vel, tempType, tempDmg, tempKb, tempSpd);
				
				if (charge >= maxCharge) {
					DefaultMaxChargeEvent(player, vel, tempType, tempDmg, tempKb, tempSpd);
					if (charge >= maxCharge + p.blowpipeMaxInc) MaxChargeEvent(player, vel, tempType, tempDmg, tempKb, tempSpd);
					if (doSpore) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Normalize(vel)*9f, ModContent.ProjectileType<Projectiles.WadofSpores>(), Item.damage, Item.knockBack, player.whoAmI);
                }
				
				charge = (int)(charge*p.blowpipeChargeRetain);
				shootCount = -1;
				reuseCounter = 45;
				aaa = false;
            }
        }
        public override void PostUpdate() {
            charge = 0;
        }
        public virtual void ChargeEvent(Player player) {

        }
		public virtual void DefaultMaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {

        }
		public virtual void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {

        }
		public virtual void AltClickEvent(Player player) {

        }
		public virtual void ShootEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {

        }
		public virtual void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!(charge >= maxCharge + p.blowpipeMaxInc && maxReplace))
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
		}
    }
}