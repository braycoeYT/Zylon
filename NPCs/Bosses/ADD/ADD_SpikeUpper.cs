using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.NPCs.Bosses.ADD
{
    public class ADD_SpikeUpper : ModNPC
    {
        public override void SetStaticDefaults() {
            //DisplayName.SetDefault("Ancient Diskite Director");
            NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData {
				ImmuneToAllBuffsThatAreNotWhips = true
			};
			NPCID.Sets.DebuffImmunitySets[Type] = debuffData;
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Hide = true
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
        }
        public override void SetDefaults() {
            NPC.value = 0;
            NPC.width = 76;
            NPC.height = 122;
            NPC.damage = 41;
            NPC.defense = 999;
            NPC.lifeMax = 9999;
            NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.dontTakeDamage = true;
            NPC.netAlways = true;
            NPC.alpha = 255;
            NPC.dontCountMe = true;
        }
        public override void PostAI() {
            if (NPC.life > 0) NPC.life = NPC.lifeMax;
		}
        int Timer;
        int num;
        public override void AI() {
            Timer++;
            if (Timer < 3) return;
            NPC.alpha = 0;
            NPC main = Main.npc[ZylonGlobalNPC.diskiteBoss];
            if (main.whoAmI < 0 || !main.active) NPC.life = 0;
            NPC.Center = main.Center - new Vector2(0, 80).RotatedBy(main.rotation);
            NPC.rotation = main.rotation;
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