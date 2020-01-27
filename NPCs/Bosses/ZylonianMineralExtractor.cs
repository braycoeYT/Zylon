using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Zylon.Items;

namespace Zylon.NPCs.Bosses
{
	[AutoloadBossHead]
	public class ZylonianMineralExtractor : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Zylonian Mineral Extractor");
		}

        public override void SetDefaults()
		{
			npc.width = 360;
			npc.height = 480;
			npc.damage = 640;
			npc.defense = 67;
			npc.lifeMax = 355000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 200000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 51;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 1;
			npc.lavaImmune = true;
			music = MusicID.Boss3;
			npc.netAlways = true;
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Cursed] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.Slow] = true;
			npc.buffImmune[BuffID.Weak] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Chilled] = true;
			npc.buffImmune[BuffID.Frozen] = true;
			npc.buffImmune[BuffID.Burning] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.Venom] = true;
			bossBag = ItemType<DiscusBag>();
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 415000;
            npc.damage = 246;
			npc.defense = 89;
        }
		
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("ZylonianMineralExtractorPha2"));
            }
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }

        public override void AI()
		{
	        Timer++;
			if  (Timer % 360 == 0)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.AquaSapphire>(), 0, npc.whoAmI);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.FlameGarnet>(), 0, npc.whoAmI);
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SproutingEmerald>(), 0, npc.whoAmI);
			}
        }
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + name + "'s Outer Armor";
			potionType = ItemID.SuperHealingPotion;
		}
	}
}