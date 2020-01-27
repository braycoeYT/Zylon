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
	public class ZylonianMineralExtractorPha2 : ModNPC
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
			npc.defense = 27;
			npc.lifeMax = 145000;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 200000f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 32;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.boss = true;
			npc.scale = 1;
			npc.lavaImmune = true;
			music = MusicID.Boss2;
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
			bossBag = ItemType<MineralBag>();
        }
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 255000;
            npc.damage = 346;
			npc.defense = 59;
        }
		
        public float Timer
		{
	        get => npc.ai[0];
	        set => npc.ai[0] = value;
        }
		
        public override void AI()
		{
	        Timer++;
			if  (Timer % 450 == 0)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<Minions.SandGrainDiscus>(), 0, npc.whoAmI);
			}
        }
		
		
		public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + name;
			potionType = ItemID.SuperHealingPotion;
		}
		
	    public override void NPCLoot()
        {
			if(Main.expertMode)
			{
				Item.NewItem(npc.getRect(), mod.ItemType("MineralBag"));
			}
		    else
			{
				Item.NewItem(npc.getRect(), mod.ItemType("GalacticDiamondium"), Main.rand.Next(5, 9));
			}
        }
	}
}