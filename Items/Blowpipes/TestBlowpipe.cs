using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class TestBlowpipe : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("");
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips) { //reminder: move this and finish shivercrown; limit max charge
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			/*float max = maxCharge + p.blowpipeMaxInc;
			bool cor;
			float tempvar;
			if (max / maxCharge > p.blowpipeMaxOverflow) { //fix this please
				max = p.blowpipeMaxOverflow*maxCharge;
				cor = true;
			}*/
			float temp3 = (chargeRate * 30);
			float temp4 = ((chargeRate + p.blowpipeChargeInc) * 30);
			if (ModContent.GetInstance<ZylonConfig>().advBlowpipe) {
				float newMult = (maxCharge+p.blowpipeMaxInc)/maxCharge;
				TooltipLine line = new TooltipLine(Mod, "Tooltip#0", "Maximum blowpipe charge: " + maxCharge + " (" + (maxCharge + p.blowpipeMaxInc) + ")");
				TooltipLine line2 = new TooltipLine(Mod, "Tooltip#1", "Blowpipe charge speed: " + temp3.ToString("0.00") + "/s (" + temp4.ToString("0.00") + "/s)");
				float temp1 = (Item.knockBack + ((Item.knockBack*p.blowpipeChargeKnockbackMult)) + (p.blowpipeChargeKnockbackAdd));
				float temp2 = (Item.shootSpeed + ((Item.shootSpeed*p.blowpipeChargeShootSpeedMult) + (p.blowpipeChargeShootSpeedAdd)));
				float temp5 = Item.knockBack*2.2f;
				float temp6 = Item.shootSpeed*1.8f;
				TooltipLine line3 = new TooltipLine(Mod, "Tooltip#2", "Blowpipe at max charge does: " + Item.damage*3
					+ " (" + (Item.damage + (int)(((Item.damage*p.blowpipeChargeDamageMult)*newMult) + (p.blowpipeChargeDamageAdd*newMult)) + ") DMG; "
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
        Color textColor = new Color(0, 0, 0);
		float maxCharge = 150;
		float charge;
		float chargeRate = 1.75f;
		float chargeRetain = 0f;
		float minshootspeed = 0f;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		//int origItemSpeed;
		int shootCount;
		int shootMode;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 15;
			Item.knockBack = 2.5f;
			Item.shootSpeed = 8f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 0, 40, 5);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			//origItemSpeed = Item.useAnimation;
			Item.rare = 1;
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4);
		}
        /*public override bool CanShoot(Player player) {
            shootMode = 0; //if (Main.mouseLeft) shootMode = 0;
            if (Main.mouseLeftRelease) shootMode = 1;
			return shootMode == 1;
        }*/
		Vector2 vel;
		int tempDmg;
		float tempKb;
		float tempSpd;
		int tempType;
		int reuseCounter;
		bool aaa;
		bool doSpore;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            aaa = true;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			doSpore = p.wadofSpores;
			shootCount++;
			shootMode = 0; //if (Main.mouseLeft) shootMode = 0;
            if (Main.mouseLeft) shootMode = 1;
			if (shootMode == 1) {
				charge += (chargeRate + p.blowpipeChargeInc)/2;
				if (charge > maxCharge + p.blowpipeMaxInc) charge = maxCharge + p.blowpipeMaxInc;
				if (shootCount % 20 == 1) {
					if (charge == maxCharge + p.blowpipeMaxInc) CombatText.NewText(player.getRect(), textColor, "MAX!");
					else CombatText.NewText(player.getRect(), textColor, (int)charge);
                }
            }
			//if (Main.mouseExit) Main.NewText("mouseTEST"); Terraria.GameInput.
			//else if (Main.mouseLeft) Main.NewText("mouseLeft");
			shootMode = 2;
			tempType = type;
			return false;
        }
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return shootCount == 0;
        }
        public override void UpdateInventory(Player player) {
			reuseCounter--;
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            if (shootMode == 2 && !Main.mouseLeft && aaa) {
				//if (charge > maxCharge*p.blowpipeMaxOverflow) charge = maxCharge*p.blowpipeMaxOverflow;
				tempDmg = Item.damage + (int)(((Item.damage*p.blowpipeChargeDamageMult)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeDamageAdd*((float)charge/(float)(maxCharge))));
				float tempCharge = charge;
				if (tempCharge > maxCharge) tempCharge = maxCharge;
				tempKb = Item.knockBack + ((Item.knockBack*p.blowpipeChargeKnockbackMult)*((float)tempCharge/(float)(maxCharge))) + (p.blowpipeChargeKnockbackAdd*((float)charge/(float)(maxCharge)));
				tempSpd = Item.shootSpeed + ((Item.shootSpeed*p.blowpipeChargeShootSpeedMult)*((float)tempCharge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeedAdd*((float)charge/(float)(maxCharge)));
				if (tempSpd < p.blowpipeMinShootSpeed + minshootspeed) tempSpd = p.blowpipeMinShootSpeed + minshootspeed;

				if (reuseCounter > 0) {
					tempDmg /= 10;
					tempKb = 0f;
                    tempSpd = 1f;
					CombatText.NewText(player.getRect(), textColor, "EXHAUSTION!");
                }

                vel = Main.MouseWorld - player.Center;
				vel.Normalize();
				Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, vel*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
				
				if (charge >= maxCharge) {
					if (doSpore) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, Vector2.Normalize(vel)*9f, ModContent.ProjectileType<Projectiles.WadofSpores>(), Item.damage, Item.knockBack, player.whoAmI);
                }
				
				charge = (int)(charge*p.blowpipeChargeRetain);
				shootCount = -1;
				reuseCounter = 45;
				aaa = false;
            }
        }
        /*public override bool AltFunctionUse(Player player) {
			return true;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return !(player.altFunctionUse == 2) && !modeCharge;
        }
        public override bool CanUseItem(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (player.altFunctionUse == 2) {
				modeCharge = !modeCharge;
				SoundEngine.PlaySound(SoundID.MaxMana, player.position);
				//p.blowpipeMinCharge = minCharge;
				//p.blowpipeShowUI = modeCharge;
				if (modeCharge) {
					Item.useTime = 2;
					Item.useAnimation = 2;
					CombatText.NewText(player.getRect(), Color.MediumPurple, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)((Item.damage*2)*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamageAdd*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + ((Item.knockBack*1.2f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockbackAdd*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + ((Item.shootSpeed*0.8f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeedAdd*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.MediumPurple, "SHOOT");
                }
				return false;
            }
            return true;
        }
        public override bool? UseItem(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (modeCharge) {
				chargeCount++;
				charge += chargeRate + p.blowpipeChargeInc;
				if (charge > maxCharge + p.blowpipeMaxInc)
					charge = maxCharge + p.blowpipeMaxInc;
				//p.blowpipeCharge = charge;
				if (chargeCount % 10 == 0 && charge != maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.MediumPurple, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.MediumPurple, "MAX!");
            }
			else {
				Item.damage = origDamage;
				Item.knockBack = origKnockback;
				Item.shootSpeed = origShootSpeed;
				//p.blowpipeCharge = 0;
            }
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            if (!modeCharge) {
				ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
				if (charge == maxCharge + p.blowpipeMaxInc) {
					if (p.wadofSpores)
						Projectile.NewProjectile(source, position, Vector2.Normalize(velocity) * 9, ModContent.ProjectileType<Projectiles.WadofSpores>(), damage, knockback, player.whoAmI);
                }
				player.AddBuff(ModContent.BuffType<Buffs.Debuffs.OutofBreath>(), Item.useTime + 1, false);
				charge = 0;
				chargeCount = 0;
			}
			return !modeCharge;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}*/
    }
}