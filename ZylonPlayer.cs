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
		public bool slimePendant;
		public bool glazedLens;
		public bool deadlyToxins;
		public bool trueMelee10;
		public bool dirtballExpert;

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
			slimePendant = false;
			glazedLens = false;
			deadlyToxins = false;
			trueMelee10 = false;
			dirtballExpert = false;
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
			if (deadlyToxins) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 20;
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
			if (Player.npcTypeNoAggro[NPCID.MotherSlime]) {
				Player.npcTypeNoAggro[NPCType<NPCs.Dungeon.BoneSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Forest.DirtSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Forest.MechanicalSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Forest.OrangeSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Ocean.CyanSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Sky.StarpackSlime>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Snow.LivingMarshmallow>()] = true;
				Player.npcTypeNoAggro[NPCType<NPCs.Snow.RoastedLivingMarshmallow>()] = true;
            }
        }
		float trueMeleeBoost;
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {
			trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			damage += (int)(damage * trueMeleeBoost);
		}
        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit) {
            trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			damage += (int)(damage * trueMeleeBoost);
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
			if (glazedLens && crit && target.type != NPCID.TargetDummy) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, item.crit + Player.GetCritChance(item.DamageType));
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
			if (Player.HeldItem.type == ItemType<Items.Guns.GraveBuster>()) Player.AddBuff(BuffType<Buffs.GravelyPowers>(), 90);
			if (glazedLens && crit && target.type != NPCID.TargetDummy) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, proj.CritChance);
            }
		}
        public override void OnHitPvp(Item item, Player target, int damage, bool crit) {
            if (bloodVial && Main.rand.NextFloat() < .08f) {
				Player.statLife += 1;
				Player.HealEffect(1, true);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Main.myPlayer, item.crit + Player.GetCritChance(item.DamageType));
			if (diskbringerSet) {
				if (Main.rand.NextBool(3)) Player.AddBuff(BuffType<Buffs.DiskiteOffense>(), 90);
				else if (Main.rand.NextBool(2)) Player.AddBuff(BuffType<Buffs.DiskiteDefense>(), 90);
				else Player.AddBuff(BuffType<Buffs.DiskiteAgility>(), 90);
            }
			if (glazedLens && crit) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer);
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
			if (Player.HeldItem.type == ItemType<Items.Guns.GraveBuster>()) Player.AddBuff(BuffType<Buffs.GravelyPowers>(), 90);
			if (glazedLens && crit) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Main.myPlayer, proj.CritChance);
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
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit) {
            if ((proj.type == ProjectileType<Projectiles.Bosses.ADD.ADD_SpikeRingFriendly>()) && !Player.noKnockback) {
				Vector2 vector1;
				vector1 = proj.Center - Player.Center;
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
			if (slimePendant) {
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(-4.5f, -3), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(-1.5f, -5), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(1.5f, -5), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(4.5f, -3), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Main.myPlayer);
            }
			return true;
        }
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
            if (Main.player[(int)Player.FindClosest(Player.position, Player.width, Player.height)].ZoneRockLayerHeight && Main.rand.NextFloat() < .04f)
				itemDrop = ItemType<Items.Materials.LabyrinthFish>();
        }
    }
}