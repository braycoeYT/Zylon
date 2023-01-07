using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;

namespace Zylon
{
	public class ZylonPlayer : ModPlayer
	{
		public bool Heartdaze;
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
		public bool dirtRegalia;
		public bool elemDegen;
		public bool nightmareCatcher;
		public bool shadowflameMagic;
		public bool metelordExpert;
		public bool stncheck;
		public bool st2check;

		public float critExtraDmg;
		public int blowpipeMaxInc;
		public float blowpipeChargeInc;
		public int blowpipeChargeDamage;
		public int blowpipeChargeKnockback;
		public int blowpipeChargeShootSpeed;
		/*public bool blowpipeShowUI;
		public int blowpipeMinCharge;
		public int blowpipeCharge;*/
		public override void ResetEffects() {
			Heartdaze = false;
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
			dirtRegalia = false;
			elemDegen = false;
			nightmareCatcher = false;
			shadowflameMagic = false;
			metelordExpert = false;
			stncheck = false;
			st2check = false;
			critExtraDmg = 0f;
			blowpipeMaxInc = 0;
			blowpipeChargeInc = 0;
			blowpipeChargeDamage = 0;
			blowpipeChargeKnockback = 0;
			blowpipeChargeShootSpeed = 0;
		}
		public override void UpdateDead() {
			Heartdaze = false;
			outofBreath = false;
			shroomed = false;
			deadlyToxins = false;
			elemDegen = false;
		}
		public override void UpdateBadLifeRegen() {
			if (Heartdaze) {
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
			if (elemDegen) {
				if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
				Player.lifeRegenTime = 0;
				Player.lifeRegen -= 16;
			}
			if (Player.HasBuff(BuffID.OnFire) && metelordExpert) Player.lifeRegen += 6;
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
				if (metelordExpert && Player.HasBuff(BuffID.OnFire))
					Player.statDefense += 5;
            }
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (Player.HasBuff(BuffID.MagicPower)) {
					Player.GetDamage(DamageClass.Magic) -= 0.15f*Player.statLife/Player.statLifeMax2;
					Player.GetDamage(DamageClass.MagicSummonHybrid) -= 0.15f*Player.statLife/Player.statLifeMax2;
					Player.manaRegen -= 2;
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
		float critBoost;
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {
			critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
			trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			damage = (int)(damage * trueMeleeBoost * critBoost);
		}
        public override void ModifyHitPvp(Item item, Player target, ref int damage, ref bool crit) {
			critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
            trueMeleeBoost = 1f;
			if (trueMelee10) trueMeleeBoost += 0.1f;
			if (trueMelee15) trueMeleeBoost += 0.15f;
			damage = (int)(damage * trueMeleeBoost * critBoost);
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
			damage = (int)(damage * critBoost);
        }
        public override void ModifyHitPvpWithProj(Projectile proj, Player target, ref int damage, ref bool crit) {
            critBoost = 1f;
			if (crit) critBoost += critExtraDmg;
			damage = (int)(damage * critBoost);
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit) {
			OnHitNPCGlobal(item, null, target, damage, knockback, crit, target.type == NPCID.TargetDummy, true);
		}
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
			OnHitNPCGlobal(null, proj, target, damage, knockback, crit, target.type == NPCID.TargetDummy, false);
		}
        public override void OnHitPvp(Item item, Player target, int damage, bool crit) {
			OnHitPVPGlobal(item, null, target, damage, crit, true);
		}
        public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit) {
			OnHitPVPGlobal(null, proj, target, damage, crit, false);
		}
		public void OnHitNPCGlobal(Item item, Projectile proj, NPC target, int damage, float knockback, bool crit, bool isDummy, bool TrueMelee) {
			if (!isDummy) {
				if (TrueMelee) {
					if (diskbringerSet)
						DiskiteBuffs(90);
					if (glazedLens && crit)
						ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Player.whoAmI, item.crit + Player.GetCritChance(item.DamageType));
					if (nightmareCatcher && Main.rand.NextFloat() < .2f)
						Item.NewItem(target.GetSource_FromThis(), target.getRect(), ModContent.ItemType<Items.Misc.LostNightmare>());
				} else {
					// To encourage more true melee play, this only has a 75% chance of applying instead of 100
					if (diskbringerSet)
						DiskiteBuffs(60, 75);
					if (glazedLens && crit)
						ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Player.whoAmI, proj.CritChance);
					if (nightmareCatcher && Main.rand.NextFloat() < .07f)
						Item.NewItem(target.GetSource_FromThis(), target.getRect(), ModContent.ItemType<Items.Misc.LostNightmare>());
				}
				if (bloodVial && Main.rand.NextFloat() < .1f)
					Player.Heal(1);
			}
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Player.whoAmI);
			if (shadowflameMagic) {
				if (item != null)
					if (item.DamageType == DamageClass.Magic)
						target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
				if (proj != null)
					if (proj.DamageType == DamageClass.Magic)
						target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(5, 11)*60);
            }
		}
		public void OnHitPVPGlobal(Item item, Projectile proj, Player target, int damage, bool crit, bool TrueMelee) {
			if (TrueMelee) {
				if (diskbringerSet)
					DiskiteBuffs(90);
				if (glazedLens && crit)
					ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Player.whoAmI, item.crit + Player.GetCritChance(item.DamageType));

			} else {
				// To encourage more true melee play, this only has a 75% chance of applying instead of 100
				if (diskbringerSet)
					DiskiteBuffs(60, 75);
				if (glazedLens && crit)
					ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Accessories.DemonEyeRotate>(), 20, 5f, Player.whoAmI, proj.CritChance);
			}
			if (bloodVial && Main.rand.NextFloat() < .1f)
				Player.Heal(1);
			if (jellyExpert && crit && Player.ownedProjectileCounts[ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>()] < 2)
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(), ProjectileType<Projectiles.Bosses.Jelly.JellyExpertProj>(), damage, 1f, Player.whoAmI);
		}
		public void DiskiteBuffs(int Bufftime) {
			switch (Main.rand.Next(3)) {
				case 0:
					Player.AddBuff(BuffType<Buffs.Armor.DiskiteOffense>(), Bufftime);
					return;
				case 1:
					Player.AddBuff(BuffType<Buffs.Armor.DiskiteDefense>(), Bufftime);
					return;
				case 2:
					Player.AddBuff(BuffType<Buffs.Armor.DiskiteAgility>(), Bufftime);
					return;
            }
		}
		public void DiskiteBuffs(int Bufftime, int PercentChance) {
			if (Main.rand.Next(1, 100) <= PercentChance)
				DiskiteBuffs(Bufftime);
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
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(-4.5f, -3), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Player.whoAmI);
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(-1.5f, -5), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Player.whoAmI);
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(1.5f, -5), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Player.whoAmI);
				ProjectileHelpers.NewNetProjectile(Player.GetSource_FromThis(), Player.Center, new Vector2(4.5f, -3), ProjectileType<Projectiles.Accessories.SlimeSpikeFriendly>(), 15, 2f, Player.whoAmI);
            }
			return true;
        }
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition) {
            Player owner = Main.player[(int)Player.FindClosest(Player.position, Player.width, Player.height)];
			if ((owner.ZoneDirtLayerHeight || owner.ZoneRockLayerHeight) && Main.rand.NextFloat() < .04f)
				itemDrop = ItemType<Items.Materials.Fish.LabyrinthFish>();
			if (owner.ZoneRockLayerHeight && Main.rand.NextFloat() < .07f && Player.HasBuff(BuffID.Hunter))
				itemDrop = ItemType<Items.Materials.Fish.PaintedGlassTetra>();
        }
    }
}