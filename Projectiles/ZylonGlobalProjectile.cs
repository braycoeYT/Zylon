using Microsoft.Build.Execution;
using Microsoft.Xna.Framework;
using Steamworks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Zylon.NPCs;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Projectiles
{
	public class ZylonGlobalProjectile : GlobalProjectile
	{
		int damageCooldown;
		int npcBounceCount;
		int tileBounceCount;
		public override bool InstancePerEntity => true;
		public override void SetDefaults(Projectile projectile) {
			if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (projectile.type == ProjectileID.Flare || projectile.type == ProjectileID.BlueFlare || projectile.type == ProjectileID.SpelunkerFlare || projectile.type == ProjectileID.CursedFlare || projectile.type == ProjectileID.RainbowFlare || projectile.type == ProjectileID.ShimmerFlare)
					projectile.timeLeft = 3600;
			}
		}
		bool init;
        public override bool PreAI(Projectile projectile) {
            Player player = Main.player[projectile.owner];
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();

			if (!init && p != null) {
				if (player.HeldItem.useAmmo == AmmoID.Bullet || player.HeldItem.useAmmo == ItemType<Items.Ammo.AdeniteShrapnel>()) {
					if (p.illusoryBulletPolish || p.maraudersKit) {
						npcBounceCount = 1;
						tileBounceCount = 2;
					}
					if (p.roundmastersKit) {
						npcBounceCount = 2;
						tileBounceCount = 3;
					}
				}
				if (player.HeldItem.useAmmo == AmmoID.Arrow) {
					if (p.roundmastersKit)
						projectile.damage = (int)(projectile.damage*1.0181818f);
				}
				init = true;
			}

			if (p.hexNecklace) {
				if (projectile.type == ProjectileID.WandOfSparkingSpark) {
					if (Main.myPlayer == player.whoAmI)
						Projectile.NewProjectile(projectile.GetSource_Death(), projectile.position, projectile.velocity, ProjectileType<Projectiles.Wands.WandofHexingProj>(), projectile.damage, projectile.knockBack, Main.myPlayer);
					projectile.Kill();
                }
				if ((projectile.type >= 121 && projectile.type <= 126) || projectile.type == ProjectileID.AmberBolt || projectile.type == ModContent.ProjectileType<Projectiles.Wands.JadeBolt>()) {
					if (Main.myPlayer == player.whoAmI)
						Projectile.NewProjectile(projectile.GetSource_Death(), projectile.position, projectile.velocity, ProjectileType<Projectiles.Wands.HexOreStaffProj>(), projectile.damage, projectile.knockBack, Main.myPlayer);
					projectile.Kill();
                }
            }
			return true;
        }
        int Timer;
        public override void PostAI(Projectile projectile) {
			Timer++;
			Player player = Main.player[projectile.owner];
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.dirtRegalia && (projectile.minion || projectile.type == ProjectileType<Minions.DirtBlockExp>()) && Timer % 90 == 60) {
				float distanceFromTarget = 160f;
				Vector2 targetCenter = projectile.position;
				bool foundTarget = false;
					
				if (!foundTarget) {
					for (int i = 0; i < Main.maxNPCs; i++) {
						NPC npc = Main.npc[i];

						if (npc.CanBeChasedBy()) {
							float between = Vector2.Distance(npc.Center, projectile.Center);
							bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
							bool inRange = between < distanceFromTarget;
							bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
							bool closeThroughWall = false; //between < 100f;

							if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
								distanceFromTarget = between;
								targetCenter = npc.Center;
								foundTarget = true;
							}
						}
					}
				}
				if (foundTarget) {
					Vector2 projDir = Vector2.Normalize(targetCenter - projectile.Center) * 7f;
					ProjectileHelpers.NewNetProjectile(projectile.GetSource_FromThis(), projectile.Center, projDir, ProjectileType<Accessories.DirtBallAcc>(), (int)(projectile.damage*0.6f), projectile.knockBack/2, projectile.owner);
                }
            }
			if (damageCooldown > 0) { //only use this if you are sure that projectiles inflicted are friendly
				projectile.friendly = false;
				damageCooldown--;
				if (damageCooldown == 0) projectile.friendly = true;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone) {
            if (target.type == NPCType<NPCs.Bosses.Dirtball.DirtBlock>() && (projectile.penetrate < 0 || projectile.penetrate > 3) && projectile.minion == false && Main.expertMode)
				projectile.penetrate = 3;
			if (target.type == NPCType<NPCs.Bosses.Metelord.MetelordHead>() || target.type == NPCType<NPCs.Bosses.Metelord.MetelordBody>() || target.type == NPCType<NPCs.Bosses.Metelord.MetelordTail>()) {
				if ((projectile.DamageType != DamageClass.Summon && projectile.DamageType != DamageClass.MagicSummonHybrid && projectile.aiStyle != 19) || projectile.type == ProjectileType<Minions.DirtBlockExp>())
					damageCooldown = 30;
            }
			if (projectile.penetrate == 1 && npcBounceCount > 0 && !(target.type == NPCID.DungeonGuardian && projectile.type == ProjectileID.ChlorophyteBullet)) {
				npcBounceCount--;
				projectile.penetrate = 2;
				projectile.velocity *= -1f;
				projectile.damage = (int)(projectile.damage*0.7f);
				if (projectile.type == ProjectileID.ChlorophyteBullet) projectile.damage = (int)(projectile.damage*0.3f);
				if (projectile.damage < 1) projectile.damage = 1;
			}
        }
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity) {
			if (tileBounceCount > 0) {
				tileBounceCount--;
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
				return false;
			}
            return true;
        }
        public override void OnKill(Projectile projectile, int timeLeft) {
            if (GetInstance<ZylonConfig>().zylonianBalancing) {
				if (projectile.type == ProjectileID.BoneArrow && Main.rand.NextBool(5) && Main.myPlayer == projectile.owner)
					for (int i = 0; i < 3; i++) Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center - new Vector2(0, 4), new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-9f, -7f)), ProjectileType<Ammo.BoneArrowProj>(), projectile.damage/2, projectile.knockBack/2, projectile.owner);
				
				//The funny
				if (projectile.type == ProjectileID.SlimeGun || projectile.type == ProjectileID.WaterGun) {
					NPC target = Main.npc[0];
					float distanceFromTarget = 26f;
					bool foundTarget = false;
					Vector2 targetCenter = projectile.position;
					if (!foundTarget) {
						for (int i = 0; i < Main.maxNPCs; i++) {
							NPC npc = Main.npc[i];
							if (npc.CanBeChasedBy()) {
								float between = Vector2.Distance(npc.Center, projectile.Center);
								bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
								bool inRange = between < distanceFromTarget;
								bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
								bool closeThroughWall = between < 100f; //closest &&            || !foundTarget
								if ((( inRange) ) && (lineOfSight || closeThroughWall) && npc.life > 0 && npc.type != NPCID.TargetDummy && npc.friendly == false) {
									distanceFromTarget = between;
									target = npc;
									targetCenter = npc.Center;
									foundTarget = true;
								}
					       }
						}
					}
					if (foundTarget == false) return;

					//Note: DO NOT include slimeling bc on death they will spawn more slimelings if they are big.
					if (target.type == -25 || target.type == -24 || (target.type > -11 && target.type < 0) || target.type == NPCID.BlueSlime || target.type == NPCID.IceSlime || target.type == NPCID.SpikedIceSlime || target.type == NPCID.SandSlime || target.type == NPCID.SpikedJungleSlime || target.type == NPCID.BabySlime || target.type == NPCID.LavaSlime || target.type == NPCID.GoldenSlime || target.type == NPCID.SlimeSpiked || target.type == NPCID.ShimmerSlime || target.type == NPCID.SlimeMasked || (target.type > 332 && target.type < 337) || target.type == NPCID.Crimslime || target.type == NPCID.IlluminantSlime || target.type == NPCID.RainbowSlime || target.type == NPCID.QueenSlimeMinionBlue || target.type == NPCID.QueenSlimeMinionPink || target.type == NPCID.QueenSlimeMinionPurple || target.type == ModContent.NPCType<NPCs.Forest.DirtSlime>() || target.type == ModContent.NPCType<NPCs.Forest.OrangeSlime>() || target.type == ModContent.NPCType<ElemSlime>() || target.type == ModContent.NPCType<NPCs.Sky.Stratoslime>() || target.type == NPCID.Slimer2 || target.type == ModContent.NPCType<NPCs.Dungeon.BoneSlime>()) {
						/*int tempHeight = (int)(target.height/target.scale);
						int tempWidth = (int)(target.width/target.scale);

						int tempHeight2 = target.height;*/
						
						target.scale += 0.1f;
						if (target.scale > 2.5f) target.scale = 2.5f;
						//else target.position.Y -= target.height*target.scale;

						/*target.height = (int)(tempHeight*target.scale);
						target.width = (int)(tempWidth*target.scale);

						target.position.Y -= target.height - tempHeight2;*/
					}
					if (target.type == NPCID.MotherSlime || target.type == NPCID.DungeonSlime || target.type == NPCID.UmbrellaSlime || target.type == NPCID.ToxicSludge || target.type == NPCID.CorruptSlime || target.type == NPCID.Slimer || target.type == NPCID.HoppinJack) {
						/*int tempHeight = (int)(target.height/target.scale);
						int tempWidth = (int)(target.width/target.scale);

						int tempHeight2 = target.height;*/

						target.scale += 0.075f;
						if (target.scale > 2f) target.scale = 2f;
						//else target.position.Y -= target.height*target.scale;

						/*target.height = (int)(tempHeight*target.scale);
						target.width = (int)(tempWidth*target.scale);

						target.position.Y -= target.height - tempHeight2;*/
					}
				}
			}
        }
    }
}