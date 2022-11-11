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
        float maxCharge = 75;
		float charge;
		float chargeRate = 1f;
		bool modeCharge;
		int chargeCount;
        int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
        Color tooltipColor = Color.LawnGreen;
        public override void SetDefaults(Item item) {
			if (item.type == ItemID.Blowpipe) {
                item.damage = 10;
                item.autoReuse = true;
                origDamage = item.damage;
			    origKnockback = item.knockBack;
			    origShootSpeed = item.shootSpeed;
			    origItemSpeed = item.useAnimation;
                maxCharge = 50;
            }
			if (item.type == ItemID.Blowgun) {
                item.damage = 28;
                item.autoReuse = true;
                origDamage = item.damage;
			    origKnockback = item.knockBack;
			    origShootSpeed = item.shootSpeed;
			    origItemSpeed = item.useAnimation;
            }
            if (item.type == ItemID.DartPistol) {
                item.damage = 42;
                item.autoReuse = true;
                origDamage = item.damage;
			    origKnockback = item.knockBack;
			    origShootSpeed = item.shootSpeed;
			    origItemSpeed = item.useAnimation;
                maxCharge = 110;
                tooltipColor = Color.DarkRed;
            }
            if (item.type == ItemID.DartRifle) {
                item.damage = 78;
                item.autoReuse = true;
                origDamage = item.damage;
			    origKnockback = item.knockBack;
			    origShootSpeed = item.shootSpeed;
			    origItemSpeed = item.useAnimation;
                maxCharge = 110;
                tooltipColor = Color.Purple;
                chargeRate = 1.5f;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Maximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo");
				tooltips.Add(line);
			}
            if (item.type == ItemID.DartPistol || item.type == ItemID.DartRifle) {
				TooltipLine line = new TooltipLine(Mod, "Tooltip#1", "Maximum dart gun charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you charge, the more speed, knockback, and damage the seed/dart deals, though you don't have to charge to shoot.\nUses seeds as ammo");
				tooltips.Add(line);
			}
        }
        public override bool AltFunctionUse(Item item, Player player) {
            if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun || item.type == ItemID.DartPistol || item.type == ItemID.DartRifle)
                return true;
            return base.AltFunctionUse(item, player);
        }
        public override bool CanConsumeAmmo(Item weapon, Item ammo, Player player) {
            if (weapon.type == ItemID.Blowpipe || weapon.type == ItemID.Blowgun || weapon.type == ItemID.DartPistol || weapon.type == ItemID.DartRifle)
                return !(player.altFunctionUse == 2) && !modeCharge;
            return base.CanConsumeAmmo(weapon, ammo, player);
        }
        public override bool CanUseItem(Item item, Player player) {
            if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun || item.type == ItemID.DartPistol || item.type == ItemID.DartRifle) {
                ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			    if (player.altFunctionUse == 2) {
			    	modeCharge = !modeCharge;
			    	SoundEngine.PlaySound(SoundID.MaxMana, player.position);
			    	if (modeCharge) {
			    		item.useTime = 2;
			    		item.useAnimation = 2;
                        if (item.type == ItemID.DartPistol || item.type == ItemID.DartRifle) item.UseSound = SoundID.Item64;
			    		CombatText.NewText(player.getRect(), tooltipColor, "CHARGE");
                    }
			    	else {
			    		item.useTime = origItemSpeed;
			    		item.useAnimation = origItemSpeed;
                        if (item.type == ItemID.DartPistol) item.UseSound = SoundID.Item98;
                        if (item.type == ItemID.DartRifle) item.UseSound = SoundID.Item99;
			    		if (charge != 0) {
			    		    item.damage = origDamage + (int)(origDamage*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		    item.knockBack = origKnockback + (2f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		    item.shootSpeed = origShootSpeed + (7f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                        }
			    	    CombatText.NewText(player.getRect(), tooltipColor, "SHOOT");
                    }
				    return false;
                }
                return true;
            }
            return base.CanUseItem(item, player);
        }
        public override bool? UseItem(Item item, Player player) {
            if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun || item.type == ItemID.DartPistol || item.type == ItemID.DartRifle) {
                ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			    if (modeCharge) {
				    chargeCount++;
				    charge += chargeRate + p.blowpipeChargeInc;
				    if (charge > maxCharge + p.blowpipeMaxInc)
				        charge = maxCharge + p.blowpipeMaxInc;
			        if (chargeCount % 10 == 0 && charge != maxCharge + p.blowpipeMaxInc)
				        CombatText.NewText(player.getRect(), tooltipColor, (int)charge);
				    else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
				        CombatText.NewText(player.getRect(), tooltipColor, "MAX!");
                }
			    else {
			    	charge = 0;
                    chargeCount = 0;
			    	item.damage = origDamage;
			    	item.knockBack = origKnockback;
			    	item.shootSpeed = origShootSpeed;
                }
                return true;
            }
            return base.UseItem(item, player);
        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun || item.type == ItemID.DartPistol || item.type == ItemID.DartRifle) {
                if (!modeCharge && !(item.useTime == 2)) {
                    if (charge == maxCharge + p.blowpipeMaxInc) {
					    if (p.wadofSpores)
					    	Projectile.NewProjectile(source, position, Vector2.Normalize(velocity) * 9, ModContent.ProjectileType<Projectiles.WadofSpores>(), damage, knockback, player.whoAmI);
                    }
                    if (item.type == ItemID.Blowpipe || item.type == ItemID.Blowgun) player.AddBuff(BuffType<Buffs.Debuffs.OutofBreath>(), item.useTime + 1, false);
                }
			    return !modeCharge;
            }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
        }
    }
}