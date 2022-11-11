using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class RoxinBlowgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("\nMaximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nCharge loss speed: " + chargeLossRate + "\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo\n50% chance not to conusme ammo\n'Who else will I have ice cream with?'\nEvery shot spawns a homing Sigil of Nobodyism near the player\nAt max charge, shoots incredibly faster");
		}
		float maxCharge = 200;
		float charge;
		float chargeRate = 2.5f;
		float chargeLossRate = 15;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 96;
			Item.knockBack = 2.5f;
			Item.shootSpeed = 10f;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.value = Item.sellPrice(0, 4, 80);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			origItemSpeed = Item.useAnimation;
			Item.rare = ItemRarityID.Red;
			Item.width = 64;
			Item.height = 24;
		}
		public override bool AltFunctionUse(Player player) {
			return true;
		}
        public override bool CanConsumeAmmo(Item ammo, Player player) {
			if (Main.rand.NextBool(2)) return false;
            return !(player.altFunctionUse == 2) && !modeCharge;
        }
		Color roxa = Color.White;
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
					if (Main.rand.NextBool(2)) roxa = Color.Black;
					else roxa = Color.White;
					CombatText.NewText(player.getRect(), roxa, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)(20*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + (2.5f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + (12f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					if (Main.rand.NextBool(2)) roxa = Color.Black;
					else roxa = Color.White;
					CombatText.NewText(player.getRect(), roxa, "SHOOT");
                }
				return false;
            }
			if (!modeCharge) {
				Item.useTime = 15 - (int)(13*charge/maxCharge);
				Item.useAnimation = 15 - (int)(13*charge/maxCharge);
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
				if (Main.rand.NextBool(2)) roxa = Color.Black;
					else roxa = Color.White;
				if (chargeCount % 10 == 0 && charge != maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), roxa, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), roxa, "MAX!");
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
				charge -= chargeLossRate;
				if (charge < 0) charge = 0;
				chargeCount = 0;

				Projectile.NewProjectile(source, player.Center + new Vector2(Main.rand.Next(-320, 321), Main.rand.Next(-320, 321)), new Vector2(), ModContent.ProjectileType<Projectiles.Blowpipes.SigilofNobodyism>(), (int)(Item.damage * 0.75f), Item.knockBack / 2, Main.myPlayer);
			}
			return !modeCharge;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -8);
		}
	}
}