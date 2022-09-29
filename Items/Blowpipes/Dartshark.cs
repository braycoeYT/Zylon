using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Blowpipes
{
	public class Dartshark : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Maximum blowpipe charge: " + maxCharge + "\nBlowpipe charge speed: " + (chargeRate * 30) + "/s\nRight click to change modes.\nThe longer you inhale, the more speed, knockback, and damage the seed/dart deals, though you don't have to inhale to shoot.\nTake breaks from shooting to get your breath back.\nYou can inhale while in breath recovery.\nUses seeds as ammo\n33% chance to not consume ammo\n'Minishark's cousin'\nAt max charge, spawns several mini jellies to attack foes");
		}
		float maxCharge = 95;
		float charge;
		float chargeRate = 1.2f;
		bool modeCharge;
		int chargeCount;
		int origDamage;
		float origKnockback;
		float origShootSpeed;
		int origItemSpeed;
		int Timer;
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.Blowpipe);
			Item.damage = 11;
			Item.knockBack = 1f;
			Item.shootSpeed = 11f;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.UseSound = SoundID.Item64;
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
			if (Main.rand.NextBool(3)) return false;
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
					CombatText.NewText(player.getRect(), Color.Purple, "CHARGE");
                }
				else {
					Item.useTime = origItemSpeed;
					Item.useAnimation = origItemSpeed;
					if (charge != 0) {
						Item.damage = origDamage + (int)(11*((float)charge/(float)(maxCharge))) + (int)(p.blowpipeChargeDamage*((float)charge/(float)(maxCharge)));
			    		Item.knockBack = origKnockback + (1f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeKnockback*((float)charge/(float)(maxCharge)));
			    		Item.shootSpeed = origShootSpeed + (10f*((float)charge/(float)(maxCharge))) + (p.blowpipeChargeShootSpeed*((float)charge/(float)(maxCharge)));
                    }
					CombatText.NewText(player.getRect(), Color.Purple, "SHOOT");
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
					CombatText.NewText(player.getRect(), Color.Purple, (int)charge);
				else if (chargeCount % 10 == 0 && charge == maxCharge + p.blowpipeMaxInc)
					CombatText.NewText(player.getRect(), Color.Purple, "MAX!");
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
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!modeCharge) {
				player.AddBuff(ModContent.BuffType<Buffs.OutofBreath>(), Item.useTime + 1, false);
				if (charge == maxCharge + p.blowpipeMaxInc) {
					SoundEngine.PlaySound(SoundID.Item34, position);
					for (int i = 0; i < 5; i++)
						Projectile.NewProjectile(source, player.Center + new Vector2(Main.rand.Next(-240, 241), Main.rand.Next(-240, 241)), new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj2>(), (int)(Item.damage * 1.5f), Item.knockBack, Main.myPlayer);
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
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.OtherworldlyFang>(), 14);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}