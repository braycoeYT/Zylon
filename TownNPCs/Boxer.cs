using System;
using Zylon.Items;
using Zylon.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Boxer : ModNPC
	{
		public override string Texture => "Zylon/NPCs/TownNPCs/Boxer";
		public override bool Autoload(ref string name)
		{
			name = "Boxer";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boxer");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 125;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 100;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.HitSound = SoundID.NPCHit1;
			npc.scale = 1f;
			npc.DeathSound = SoundID.NPCDeath1;
			animationType = NPCID.Guide;
			npc.damage = 18;
			if (Main.hardMode)
			npc.defense = 60;
			else
			npc.defense = 30;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.3f;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (Main.dayTime && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].active)
			return ZylonWorld.downedDiscus;
			return false;
		}
		public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
		public override string TownNPCName()
		{
			int nameRan = WorldGen.genRand.Next(0, 10);
			if (nameRan == 0)
			return "Mike";
			if (nameRan == 1)
			return "Tyson";
			if (nameRan == 2)
			return "Muhammad";
			if (nameRan == 3)
			return "Ali";
			if (nameRan == 4)
			return "Armstrong";
			if (nameRan == 5)
			return "Jack";
			if (nameRan == 6)
			return "Sam";
			if (nameRan == 7)
			return "Mac";
			if (nameRan == 8)
			return "Rocky";
			if (nameRan == 9)
			return "Harry";
			return "Rocky";
		}
		
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			chat.Add("They call me 'Grasshead' in the ring.", 1);
			chat.Add("I'm ready to box.", 1.1);
			chat.Add("Knockout!", 0.9);
			chat.Add("I'm one of the most famous boxers in the world, you know.", 1.1);
			chat.Add("Have you ever got a bloody nose in a fight before? I have.", 0.9);
			chat.Add("Don't underestimate me.", 1);
			return chat;
		}
		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			if (firstButton)
			{
			shop = true;
			}
			else
			{
				Main.playerInventory = true;
				Main.npcChatText = "";
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.SpikyBall);
			shop.item[nextSlot].shopCustomPrice = 80;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Robe);
			shop.item[nextSlot].shopCustomPrice = 9000;
			nextSlot++;
			if (NPC.downedBoss3)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Spike);
				shop.item[nextSlot].shopCustomPrice = 100;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SharkToothNecklace);
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
			}
			if (Main.hardMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.KOCannon);
				shop.item[nextSlot].shopCustomPrice = 150000;
				nextSlot++;
			}
			if (NPC.downedGolemBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.GolemFist);
				shop.item[nextSlot].shopCustomPrice = 250000;
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 15;
			knockback = 7.2f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 7;
			randExtraCooldown = 3;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.BoxingGlove;
			attackDelay = 3;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 7f;
			randomOffset = 2f;
		}
	}
}