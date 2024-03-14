using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class SporeShooter : ZylonBlowpipe
	{
		public SporeShooter() : base(155, 1.25f, new Color(5, 185, 30)) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 24;
			Item.knockBack = 2.5f;
			Item.shootSpeed = 8.75f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 0, 54);
			Item.autoReuse = true;
		}
		int summonNum;
		public override void ChargeEvent(Player player) {
			ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(3*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 3 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 2;
        }
        public override void ShootEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            if (charge >= (int)(maxCharge/3)) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), tempDmg, tempKb, player.whoAmI);
			if (charge >= (int)(maxCharge/3*2)) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), tempDmg, tempKb, player.whoAmI);
			if (charge >= maxCharge) Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), tempDmg, tempKb, player.whoAmI);
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.JungleSpores, 14);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}
/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class SporeShooter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Maximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo\nDepending on the charge, shoots up to 3 spores");
		}
		float maxCharge = 70;
		float charge;
		float chargeRate = 0.75f;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 17;
			Item.knockBack = 3f;
			Item.shootSpeed = 9f;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.value = Item.sellPrice(0, 0, 54);
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
					CombatText.NewText(player.getRect(), Color.LimeGreen, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						//Item.damage = origDamage + (int)((Item.damage*2)*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		//Item.knockBack = origKnockback + ((Item.knockBack*1.2f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		//Item.shootSpeed = origShootSpeed + ((Item.shootSpeed*0.8f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.LimeGreen, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.LimeGreen, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.LimeGreen, "MAX!");
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
				player.AddBuff(ModContent.BuffType<Buffs.Debuffs.OutofBreath>(), Item.useTime + 1, false);
				if (charge >= 23) Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), damage, knockback, player.whoAmI);
				if (charge >= 46) Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), damage, knockback, player.whoAmI);
				if (charge >= 70) Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<Projectiles.JungleSporeRanged>(), damage, knockback, player.whoAmI);
				if (charge == maxCharge + p.blowpipeMaxInc) {
					if (p.wadofSpores)
						Projectile.NewProjectile(source, position, Vector2.Normalize(velocity) * 9, ModContent.ProjectileType<Projectiles.WadofSpores>(), damage, knockback, player.whoAmI);
                }
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
			recipe.AddIngredient(ItemID.JungleSpores, 14);
			recipe.AddIngredient(ItemID.Stinger, 10);
			recipe.AddIngredient(ItemID.Vine);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}*/