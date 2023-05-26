using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class ChlorophyteBlowspitter : ZylonBlowpipe
	{
		public ChlorophyteBlowspitter() : base(260, 2.6f, new Color(36, 137, 0), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Shoots many seeds at once depending on charge, consuming only one ammo\nAt max charge, replaces ammo with homing chlorophyte seeds\nRight click to disable and enable this effect");
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 39;
			Item.knockBack = 1.5f;
			Item.shootSpeed = 9.5f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = true;
		}
		int summonNum;
        public override void ChargeEvent(Player player) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
            summonNum = (int)(4*charge/(maxCharge + p.blowpipeMaxInc));
			if (summonNum == 4 && charge < maxCharge + p.blowpipeMaxInc) summonNum = 3;
			summonNum += 2;
        }
        public override void ShootAction(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!(charge >= maxCharge + p.blowpipeMaxInc && maxReplace))
				for (int i = 0; i < summonNum; i++) {
					Vector2 perturbedSpeed = vel.RotatedBy(MathHelper.ToRadians(i*2-(float)(summonNum)));
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, perturbedSpeed*tempSpd, tempType, tempDmg, tempKb, Main.myPlayer);
				}
			else {
				for (int i = 0; i < summonNum; i++) {
					Vector2 perturbedSpeed = vel.RotatedBy(MathHelper.ToRadians(i*2-(float)(summonNum)));
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, perturbedSpeed*tempSpd, ModContent.ProjectileType<Projectiles.Blowpipes.ChlorophyteBlowspitterProj>(), tempDmg, tempKb, Main.myPlayer);
				}
            }
			summonNum = 0;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -6);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Obsidian, 12);
			recipe.AddIngredient(ItemID.BeeWax, 15);
			recipe.AddIngredient(ItemID.Stinger, 6);
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
	public class ChlorophyteBlowspitter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("\nMaximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nCharge loss speed: " + chargeLossRate + "\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo\nShoots multiple seeds at once\nShoots even more seeds depending on the charge");
		}
		float maxCharge = 140;
		float charge;
		float chargeRate = 1.55f;
		float chargeLossRate = 30;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 46;
			Item.knockBack = 1.5f;
			Item.shootSpeed = 10f;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.value = Item.sellPrice(0, 4, 80);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			origItemSpeed = Item.useAnimation;
			Item.rare = ItemRarityID.Lime;
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
					CombatText.NewText(player.getRect(), Color.Lime, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)((Item.damage*2)*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamageAdd*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + ((Item.knockBack*1.2f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockbackAdd*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + ((Item.shootSpeed*0.8f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeedAdd*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.Lime, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.Lime, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.Lime, "MAX!");
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
				int numberProjectiles = 1 + Main.rand.Next(3);
				if (charge > 0) for (int j = 0; (j*45) < charge; j++)
					numberProjectiles += 1;
				for (int i = 0; i < numberProjectiles; i++) {
					Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(9)) * new Vector2(Main.rand.NextFloat(0.8f, 1.2f), Main.rand.NextFloat(0.8f, 1.2f));
					Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
				}
				if (charge == maxCharge + p.blowpipeMaxInc) {
					if (p.wadofSpores)
						Projectile.NewProjectile(source, position, Vector2.Normalize(velocity) * 9, ModContent.ProjectileType<Projectiles.WadofSpores>(), damage, knockback, player.whoAmI);
                }
				player.AddBuff(ModContent.BuffType<Buffs.Debuffs.OutofBreath>(), Item.useTime + 1, false);
				charge -= chargeLossRate;
				if (charge < 0) charge = 0;
				chargeCount = 0;
			}
			return !modeCharge;
        }
        public override Vector2? HoldoutOffset() {
			return new Vector2(4, -4);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}*/