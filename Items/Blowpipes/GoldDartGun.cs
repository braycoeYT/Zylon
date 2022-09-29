using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class GoldDartGun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("\nMaximum dart gun charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you charge, the more speed, knockback, and damage the seed/dart deals, though you don't have to charge to shoot.\nUses seeds as ammo");
		}
		float maxCharge = 50;
		float charge;
		float chargeRate = 0.7f;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 11;
			Item.knockBack = 2.25f;
			Item.shootSpeed = 9.75f;
			Item.useTime = 31;
			Item.useAnimation = 31;
			Item.value = Item.sellPrice(0, 0, 16);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			origItemSpeed = Item.useAnimation;
			Item.width = 34;
			Item.height = 24;
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
					CombatText.NewText(player.getRect(), Color.Gold, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)(10*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + (2f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + (7f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.Gold, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.Gold, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.Gold, "MAX!");
            }
			else {
				charge = 0;
				chargeCount = 0;
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
				charge = 0;
				chargeCount = 0;
			}
			return !modeCharge;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}