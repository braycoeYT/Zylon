using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class LobbingLog : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Maximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo");
		}
		float maxCharge = 40;
		float charge;
		float chargeRate = 0.5f;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 4;
			Item.knockBack = 1f;
			Item.shootSpeed = 6f;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.value = Item.sellPrice(0, 0, 0, 18);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			origItemSpeed = Item.useAnimation;
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
					CombatText.NewText(player.getRect(), Color.Brown, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)(10*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + (2f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + (6f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.Brown, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.Brown, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.Brown, "MAX!");
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
				player.AddBuff(ModContent.BuffType<Buffs.OutofBreath>(), Item.useTime + 1, false);
				charge = 0;
				chargeCount = 0;
			}
			return !modeCharge;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -8);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}