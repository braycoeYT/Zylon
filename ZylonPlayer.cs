using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon
{
	public class ZylonPlayer : ModPlayer
	{
		public bool severeBleeding;
		public bool outofBreath;
		public bool shroomed;
		public bool wadofSpores;
		public bool bandofMetal;
		public bool bandofRegen;
		public bool bandofMagicRegen;
		public bool bandofStarpower;
		public bool trueMelee15;
		public bool bloodVial;
		public bool stealthPotion;
		public bool gooeySetBonus;
		public bool bandofZinc;
		public bool jellyExpert;
		public bool ADDExpert;
		public bool diskbringerSet;

		public int blowpipeMaxInc;
		public float blowpipeChargeInc;
		public int blowpipeChargeDamage;
		public int blowpipeChargeKnockback;
		public int blowpipeChargeShootSpeed;
		/*public bool blowpipeShowUI;
		public int blowpipeMinCharge;
		public int blowpipeCharge;*/
		public override void ResetEffects() {
			severeBleeding = false;
			outofBreath = false;
			shroomed = false;
			wadofSpores = false;
			bandofMetal = false;
			bandofRegen = false;
			bandofMagicRegen = false;
			bandofStarpower = false;
			trueMelee15 = false;
			bloodVial = false;
			stealthPotion = false;
			gooeySetBonus = false;
			bandofZinc = false;
			jellyExpert = false;
			ADDExpert = false;
			diskbringerSet = false;
			blowpipeMaxInc = 0;
			blowpipeChargeInc = 0;
			blowpipeChargeDamage = 0;
			blowpipeChargeKnockback = 0;
			blowpipeChargeShootSpeed = 0;
		}
		public override void UpdateDead() {
			severeBleeding = false;
			outofBreath = false;
			shroomed = false;
		}
		public override void UpdateBadLifeRegen() {
			if (severeBleeding) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 20;
			}
			if (outofBreath) {
				if (Player.lifeRegen > 0) {
					Player.lifeRegen = 0;
				}
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 12;
			}
			if (shroomed) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 4;
			}
		}
        public override void UpdateEquips() {
            if (GetInstance<ZylonConfig>().bandBuffs) {
				if (bandofRegen && Player.HasBuff(BuffID.Regeneration))
					Player.lifeRegen += 1;
				if (bandofStarpower && Player.HasBuff(BuffID.MagicPower))
					Player.GetDamage(DamageClass.Magic) += 0.05f;
				if (bandofMagicRegen && Player.HasBuff(BuffID.ManaRegeneration))
					Player.manaRegen += 1;
				if (bandofMetal && Player.HasBuff(BuffID.Ironskin))
					Player.statDefense += 4;
				if (bandofZinc && Player.HasBuff(BuffID.Swiftness)) {
					if (Player.accRunSpeed > 0)
						Player.accRunSpeed += 0.75f;
					Player.moveSpeed += 0.15f;
                }
            }
        }
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {	
			if (trueMelee15) damage += (int)(damage * .15f);
		}
        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit) {
            if (trueMelee15) damage += (int)(damage * .15f);
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
            if (bloodVial && Main.rand.NextFloat() < .08f && target.type != NPCID.TargetDummy) {
				Player.statLife += 1;
				Player.HealEffect(1, true);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer);
			if (diskbringerSet && target.type != NPCID.TargetDummy) {
				if (Main.rand.NextBool(3)) Player.AddBuff(BuffType<Buffs.DiskiteOffense>(), 90);
				else if (Main.rand.NextBool(2)) Player.AddBuff(BuffType<Buffs.DiskiteDefense>(), 90);
				else Player.AddBuff(BuffType<Buffs.DiskiteAgility>(), 90);
            }
		}
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
            if (bloodVial && Main.rand.NextFloat() < .08f && target.type != NPCID.TargetDummy) {
				Player.statLife += 1;
				Player.HealEffect(1, true);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer);
			if (diskbringerSet && target.type != NPCID.TargetDummy) {
				if (Main.rand.NextBool(3)) Player.AddBuff(BuffType<Buffs.DiskiteOffense>(), 60);
				else if (Main.rand.NextBool(2)) Player.AddBuff(BuffType<Buffs.DiskiteDefense>(), 60);
				else Player.AddBuff(BuffType<Buffs.DiskiteAgility>(), 60);
            }
		}
        public override void OnHitPvp(Item item, Player target, int damage, bool crit) {
            if (bloodVial && Main.rand.NextFloat() < .08f) {
				Player.statLife += 1;
				Player.HealEffect(1, true);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer);
			if (diskbringerSet) {
				if (Main.rand.NextBool(3)) Player.AddBuff(BuffType<Buffs.DiskiteOffense>(), 90);
				else if (Main.rand.NextBool(2)) Player.AddBuff(BuffType<Buffs.DiskiteDefense>(), 90);
				else Player.AddBuff(BuffType<Buffs.DiskiteAgility>(), 90);
            }
		}
        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit) {
            if (bloodVial && Main.rand.NextFloat() < .08f) {
				Player.statLife += 1;
				Player.HealEffect(1, true);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer);
			if (diskbringerSet) {
				if (Main.rand.NextBool(3)) Player.AddBuff(BuffType<Buffs.DiskiteOffense>(), 60);
				else if (Main.rand.NextBool(2)) Player.AddBuff(BuffType<Buffs.DiskiteDefense>(), 60);
				else Player.AddBuff(BuffType<Buffs.DiskiteAgility>(), 60);
            }
		}
        public override void OnHitByNPC(NPC npc, int damage, bool crit) {
            if ((npc.type == NPCType<NPCs.Bosses.ADD.ADD_SpikeRing>() || npc.type == NPCType<NPCs.Bosses.ADD.ADD_Center>()) && !Player.noKnockback) {
				Vector2 vector1;
				vector1 = npc.Center - Player.Center;
				vector1.Normalize();
				Player.velocity = vector1*-12f;
            }
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter) {
			if (stealthPotion && Main.rand.NextFloat() < .04f) {
				damage = 0;
				Player.NinjaDodge();
				return false;
			}
			return true;
        }
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
            if (Main.player[(int)Player.FindClosest(Player.position, Player.width, Player.height)].ZoneRockLayerHeight && Main.rand.NextFloat() < .04f)
				itemDrop = ItemType<Items.Materials.LabyrinthFish>();
        }
    }
}