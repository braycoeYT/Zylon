using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.Dirtball
{
    public class Dirtboi : ModNPC
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Dirtboi");
            Main.npcFrameCount[NPC.type] = 4;
            NPCID.Sets.ImmuneToRegularBuffs[Type] = true;
<<<<<<< HEAD
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
=======
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() {
>>>>>>> 326f346703fb34b35cfd658488658472ec038319
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.value = 0;
            NPC.width = 38;
            NPC.height = 36;
            NPC.damage = 0;
            NPC.defense = 25;
            NPC.lifeMax = 550;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath3;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.dontTakeDamage = true;
            NPC.netAlways = true;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            if (month == 12 && day > 14)
                num = 1;
            if ((month == 1 && day == 4) || (month == 9 && day == 28))
                num = 2;
            if (month == 4 && day == 1 && ModContent.GetInstance<ZylonConfig>().aprilFoolsChanges)
                num = 3;
        }
        public override void PostAI() {
            if (NPC.life > 0) NPC.life = NPC.lifeMax;
			if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) > 0) 
                for (int i = 0; i < 1; i++) {
			    	int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Dirt);
			    	Dust dust = Main.dust[dustIndex];
			    	dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
			    	dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
			    	dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			    }
		}
        int val;
        public override void FindFrame(int frameHeight) {
            val = 0;
            switch (num) {
                case 1:
                    val = 1;
                    NPC.frame.Y = 1 * frameHeight;
                    break;
                case 2:
                    val = 2;
                    NPC.frame.Y = 2 * frameHeight;
                    break;
                case 3:
                    val = 3;
                    NPC.frame.Y = 3 * frameHeight;
                    break;
            }
        }
        int Timer;
        int num;
        public override void AI() {
            Player target = Main.player[NPC.target];
            if (ZylonGlobalNPC.dirtballBoss < 0) {
                NPC.active = false;
                NPC.netUpdate = true;
                return;
            }
            if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) > 0) {
                NPC dirtball = Main.npc[ZylonGlobalNPC.dirtballBoss];
                Vector2 idlePosition = dirtball.Center;

			    float minionPositionOffsetX = 96 * -dirtball.direction;
			    idlePosition.X += minionPositionOffsetX;
			
		    	Vector2 vectorToIdlePosition = idlePosition - NPC.Center;
			    float distanceToIdlePosition = vectorToIdlePosition.Length();

                if (distanceToIdlePosition > 1000f) {
			        NPC.position = idlePosition;
			    	NPC.velocity *= 0.1f;
				    NPC.netUpdate = true;
			    }

                vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= 8f;
				NPC.velocity = (NPC.velocity * (10f - 1) + vectorToIdlePosition) / 10f;
                if (NPC.velocity == Vector2.Zero) {
					NPC.velocity.X = -0.15f;
					NPC.velocity.Y = -0.05f;
				}
            }
            if (NPC.CountNPCS(ModContent.NPCType<Dirtball>()) < 1) {
                NPC.velocity = new Vector2(0, 0);
                Timer++;
                if (Timer % 10 == 0 && Timer > 180)
                    ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center.X + Main.rand.Next(-15, 16), NPC.Center.Y + 20, 0, 10, ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DirtboiTears>(), 0, 0f, Main.myPlayer, 0f, 0f, BasicNetType: 2);
                if (Timer > 360) {
                    ProjectileHelpers.NewNetProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(), ModContent.ProjectileType<Projectiles.Bosses.Dirtball.DBoiSpirit>(), 0, 0f, BasicNetType: 2);
                    NPC.life = 0;
                    switch (val) {
                        case 0:
                            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-5, -3)), ModContent.GoreType<Gores.Bosses.Dirtball.DirtboiDie>());
                            return;
                        case 1:
                            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-5, -3)), ModContent.GoreType<Gores.Bosses.Dirtball.DirtboiDieChristmas>());
                            return;
                        case 2:
                            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-5, -3)), ModContent.GoreType<Gores.Bosses.Dirtball.DirtboiDie>());
                            Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-5, -3)), GoreID.PartyHatBlue);
                            return;
                        case 3:
                            for (int i = 0; i < 10; i++)
                                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, new Vector2(Main.rand.Next(-2, 3), Main.rand.Next(-5, -3)), ModContent.GoreType<Gores.Bosses.Dirtball.DirtChunkGore>());
                            return;
                    }
                }
            }
            NPC.rotation = NPC.velocity.X * 0.05f;
        }
        /*public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("A smaller drone of the same age as its master, also possessed by a forest spirit.")
			});
            bestiaryEntry.UIInfoProvider = new CommonEnemyUICollectionInfoProvider(ContentSamples.NpcBestiaryCreditIdsByNpcNetIds[NPC.type], quickUnlock: true);
		}*/
    }
}