using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class FamiliarFoamDartPistol : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("\nMaximum dart gun charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you charge, the more speed, knockback, and damage the seed/dart deals, though you don't have to charge to shoot.\nUses seeds as ammo\n'It's this or nothin', they said...'");
		}
		float maxCharge = 100;
		float charge;
		float chargeRate = 1.25f;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		int Timer;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 33;
			Item.knockBack = 3f;
			Item.shootSpeed = 12f;
			Item.useTime = 23;
			Item.useAnimation = 23;
			Item.value = Item.sellPrice(0, 3);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			origItemSpeed = Item.useAnimation;
			Item.rare = ItemRarityID.LightRed;
			Item.useStyle = ItemUseStyleID.Shoot;
		}
		public override bool AltFunctionUse(Player player) {
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
					CombatText.NewText(player.getRect(), Color.DeepSkyBlue, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)(20*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + (2f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + (7f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.DeepSkyBlue, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.DeepSkyBlue, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.DeepSkyBlue, "MAX!");
            }
			else {
				Item.damage = origDamage;
				Item.knockBack = origKnockback;
				Item.shootSpeed = origShootSpeed;
				//p.blowpipeCharge = 0;
            }
            return true;
        }
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.Seed) {
				type = ModContent.ProjectileType<Projectiles.Ammo.MoltenSeed>();
			}
		}*/
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!modeCharge) {
				/*if (charge == maxCharge + p.blowpipeMaxInc) {
					charge = 0;
					chargeCount = 0;
					return false;
                }*/
				charge = 0;
				chargeCount = 0;
            }
			return !modeCharge;
        }
	}
}