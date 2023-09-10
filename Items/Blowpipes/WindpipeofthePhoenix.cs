using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class WindpipeofthePhoenix : ZylonBlowpipe
	{
		public WindpipeofthePhoenix() : base(185, 1.8f, new Color(252, 102, 25), true) { } //int maxChargeI, float chargeRateI, Color textColorI, bool maxReplaceI = false, float chargeRetainI = 0f, float minshootspeedI = 0f
		public override void SetStaticDefaults() {
<<<<<<< HEAD
			DisplayName.SetDefault("Windpipe of the Phoenix");
			Tooltip.SetDefault("At max charge, replaces ammo with a burst of flames\nRight click to disable and enable this effect");
=======
			// DisplayName.SetDefault("Windpipe of the Phoenix");
			// Tooltip.SetDefault("At max charge, replaces ammo with a burst of flames\nRight click to disable and enable this effect");
>>>>>>> ProjectClash
		}
        public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
            Item.damage = 34;
			Item.knockBack = 1f;
			Item.shootSpeed = 9.25f;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Orange;
			Item.autoReuse = true;
        }
		public override bool AltFunctionUse(Player player) {
			return true;
		}
		public override void AltClickEvent(Player player) {
			maxReplace = !maxReplace;
			if (maxReplace) CombatText.NewText(player.getRect(), textColor, "Enabled");
			else CombatText.NewText(player.getRect(), textColor, "Disabled");
        }
		public override void MaxChargeEvent(Player player, Vector2 vel, int tempType, int tempDmg, float tempKb, float tempSpd) {
			if (maxReplace) {
				SoundEngine.PlaySound(SoundID.Item34, player.position);
				for (int i = 0; i < 5; i++)
					Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, (vel*tempSpd).RotatedBy(MathHelper.ToRadians(-6+(i*3))), ProjectileID.Flames, tempDmg, tempKb, player.whoAmI);
			}
        }
		public override Vector2? HoldoutOffset() {
			return new Vector2(4, -8);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
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
	public class WindpipeofthePhoenix : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Windpipe of the Phoenix");
			Tooltip.SetDefault("Maximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo\nConverts seeds to molten seeds that can ignite enemies\nAt max charge, releases a massive flame burst to roast enemies");
		}
		float maxCharge = 90;
		float charge;
		float chargeRate = 1.1f;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		int Timer;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 27;
			Item.knockBack = 2.5f;
			Item.shootSpeed = 9f;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.value = Item.sellPrice(0, 2);
			Item.autoReuse = true;
			origDamage = Item.damage;
			origKnockback = Item.knockBack;
			origShootSpeed = Item.shootSpeed;
			origItemSpeed = Item.useAnimation;
			Item.rare = ItemRarityID.Orange;
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
					CombatText.NewText(player.getRect(), Color.OrangeRed, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						//Item.damage = origDamage + (int)((Item.damage*2)*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		//Item.knockBack = origKnockback + ((Item.knockBack*1.2f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		//Item.shootSpeed = origShootSpeed + ((Item.shootSpeed*0.8f)*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.OrangeRed, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.OrangeRed, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.OrangeRed, "MAX!");
            }
			else {
				Item.damage = origDamage;
				Item.knockBack = origKnockback;
				Item.shootSpeed = origShootSpeed;
				//p.blowpipeCharge = 0;
            }
            return true;
        }
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.Seed) {
				type = ModContent.ProjectileType<Projectiles.Ammo.MoltenSeed>();
			}
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!modeCharge) {
				player.AddBuff(ModContent.BuffType<Buffs.Debuffs.OutofBreath>(), Item.useTime + 1, false);
				if (charge == maxCharge + p.blowpipeMaxInc) {
					SoundEngine.PlaySound(SoundID.Item34, position);
					for (int i = 0; i < 5; i++)
						Projectile.NewProjectile(source, position, velocity.RotatedBy(MathHelper.ToRadians(-6+(i*3))), ProjectileID.Flames, (int)(damage*1.3f), knockback, player.whoAmI);
					if (p.wadofSpores)
						Projectile.NewProjectile(source, position, Vector2.Normalize(velocity) * 9, ModContent.ProjectileType<Projectiles.WadofSpores>(), damage, knockback, player.whoAmI);
					charge = 0;
					chargeCount = 0;
					return false;
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
			recipe.AddIngredient(ItemID.HellstoneBar, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}*/