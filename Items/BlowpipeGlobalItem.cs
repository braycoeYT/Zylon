using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Zylon;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items
{
	public class BlowpipeGlobalItem : GlobalItem
	{
		public override bool InstancePerEntity => true;
		public static Item GetItem(int type, int stack = 1)
        {
            Item item = new Item();
            item.SetDefaults(type);
            item.stack = stack;
            return item;
        }
        public static Item GetItem(short type, int stack = 1)
        {
            Item item = new Item();
            item.SetDefaults(type);
            item.stack = stack;
            return item;
        }
        public Color textColor = new Color(127, 255, 0);
		public float maxCharge;
		public float charge;
		public float chargeRate;
		public float chargeRetain = 0f;
		public float minshootspeed = 0f;
		public int chargeCount;
		public int shootCount;
		public int shootMode;
		public bool maxReplace;
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
			if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			float temp3 = (chargeRate * 30);
			float temp4 = ((chargeRate + p.blowpipeChargeInc) * 30);
			if (ModContent.GetInstance<ZylonConfig>().advBlowpipe) {
				float newMult = (maxCharge+p.blowpipeMaxInc)/maxCharge;
				TooltipLine line = new TooltipLine(Mod, "Tooltip#0", "Maximum blowpipe charge: " + maxCharge + " (" + (maxCharge + p.blowpipeMaxInc) + ")");
				TooltipLine line2 = new TooltipLine(Mod, "Tooltip#1", "Blowpipe charge speed: " + temp3.ToString("0.00") + "/s (" + temp4.ToString("0.00") + "/s)");
				float temp1 = (item.knockBack + item.knockBack*1.2f)*p.blowpipeChargeKnockbackMult + p.blowpipeChargeKnockbackAdd;
				float temp2 = (item.shootSpeed + item.shootSpeed*0.5f)*p.blowpipeChargeShootSpeedMult + p.blowpipeChargeShootSpeedAdd;
				float temp5 = item.knockBack*2.2f;
				float temp6 = item.shootSpeed*1.5f;
				TooltipLine line3 = new TooltipLine(Mod, "Tooltip#2", "Blowpipe at max charge does: " + item.damage*3
					+ " (" + ((item.damage + (int)((item.damage*2f)*newMult)*p.blowpipeChargeDamageMult + p.blowpipeChargeDamageAdd*newMult) + ") DMG; "
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
				TooltipLine xline5 = new TooltipLine(Mod, "Tooltip#4", "Uses seeds as ammo");
				TooltipLine xline6 = new TooltipLine(Mod, "Tooltip#5", "Maximum blowpipe charge: " + maxCharge + " (" + ((int)maxCharge + (int)p.blowpipeMaxInc) + ")");
				TooltipLine xline7 = new TooltipLine(Mod, "Tooltip#6", "Blowpipe charge speed: " + temp3.ToString("0.00") + "/s (" + temp4.ToString("0.00") + "/s)");
				TooltipLine xline8 = new TooltipLine(Mod, "Tooltip#7", "Enable 'Advanced Blowpipe Display' in the config to show more stats");
				tooltips.Add(xline);
				tooltips.Add(xline2);
				tooltips.Add(xline3);
				tooltips.Add(xline4);
				tooltips.Add(xline5);
				tooltips.Add(xline6);
				tooltips.Add(xline7);
				tooltips.Add(xline8);
            }
			}
        }
		public override void SetDefaults(Item item) {
			if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) {
				item.autoReuse = true;
				item.useTime = 1;
				item.useAnimation = 1;
				if (item.type == ItemID.Blowpipe) {
					maxCharge = 110;
					chargeRate = 1f;
					item.damage = 9;
					item.knockBack = 2f;
					item.shootSpeed = 8.75f;
                }
				else {
					maxCharge = 175;
					chargeRate = 1.6f;
					item.damage = 39;
					item.knockBack = 2.5f;
					item.shootSpeed = 9.5f;
                }
			}
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
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) {
			if (player.altFunctionUse == 2) {
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
            }
			shootMode = 2;
			tempType = type;
			ammoDamage = damage - item.damage;
			ammoKb = knockback - item.knockBack;
			ammoSpd = velocity.Length() - item.shootSpeed;
			//Note: figure out how to get item so that ammo crit works.
			return false;
			}
			return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
        public override bool CanConsumeAmmo(Item item, Item ammo, Player player) {
			if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) {
				return shootCount == 0;
			}
			return base.CanConsumeAmmo(item, ammo, player);
        }
        public override void UpdateInventory(Item item, Player player) {
			if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) {
			reuseCounter--;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            if (shootMode == 2 && !Main.mouseLeft && aaa) { 
				//if (charge > maxCharge*p.blowpipeMaxOverflow) charge = maxCharge*p.blowpipeMaxOverflow;
				//Main.NewText(ammoDamage + "|" + ammoKb + "|" + ammoSpd);
				tempDmg = ammoDamage + (int)((item.damage + (int)(((item.damage*2f)*((float)charge/(float)(maxCharge))))*p.blowpipeChargeDamageMult) + (p.blowpipeChargeDamageAdd*((float)charge/(float)(maxCharge))));
				float tempCharge = charge;
				if (tempCharge > maxCharge) tempCharge = maxCharge;
				tempKb = ammoKb + (item.knockBack + ((item.knockBack*1.2f)*((float)tempCharge/(float)(maxCharge))))*p.blowpipeChargeKnockbackMult + p.blowpipeChargeKnockbackAdd;//*((float)tempCharge/(float)(maxCharge)));
				tempSpd = ammoSpd + (item.shootSpeed + ((item.shootSpeed*0.5f)*((float)tempCharge/(float)(maxCharge))))*p.blowpipeChargeShootSpeedMult + p.blowpipeChargeShootSpeedAdd;//*((float)tempCharge/(float)(maxCharge)));
				if (tempSpd < p.blowpipeMinShootSpeed + minshootspeed) tempSpd = p.blowpipeMinShootSpeed + minshootspeed;

				if (reuseCounter > 0) {
					tempDmg /= 10;
					tempKb = 0f;
                    tempSpd = 1f;
					CombatText.NewText(player.getRect(), textColor, "EXHAUSTION!");
                }

                vel = Main.MouseWorld - player.Center;
				vel.Normalize();
				if (!(charge >= maxCharge + p.blowpipeMaxInc && maxReplace))
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
				
				if (charge >= maxCharge) {
					if (doSpore) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Normalize(vel)*9f, ModContent.ProjectileType<Projectiles.WadofSpores>(), item.damage, item.knockBack, player.whoAmI);
                }
				
				charge = (int)(charge*p.blowpipeChargeRetain);
				shootCount = -1;
				reuseCounter = 45;
				aaa = false;
            }
			}
        }
		public override void PostUpdate(Item item) {
            charge = 0;
        }
    }
}