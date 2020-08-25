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
	public class Hitman : ModNPC
	{
		public override string Texture => "Zylon/NPCs/TownNPCs/Hitman";
		public override bool Autoload(ref string name)
		{
			name = "Hitman";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hitman");
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
			npc.damage = 49;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.3f;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (!Main.dayTime && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].active)
			return NPC.downedMechBossAny;
			return false;
		}
		public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
		public override string TownNPCName()
		{
			int nameRan = WorldGen.genRand.Next(0, 8);
			if (nameRan == 0)
			return "James";
			if (nameRan == 1)
			return "Bond";
			if (nameRan == 2)
			return "Richard";
			if (nameRan == 3)
			return "Julius";
			if (nameRan == 4)
			return "Charles";
			if (nameRan == 5)
			return "Jorge";
			if (nameRan == 6)
			return "Sidney";
			if (nameRan == 7)
			return "Morris";
			return "Morris";
		}
		
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			chat.Add("Do you need my... services?", 1);
			chat.Add("You look as if you need my help.", 0.8);
			chat.Add("I'll be back...", 1);
			chat.Add("I've got more guns on me than you could ever own.", 1.1);
			chat.Add("Don't tell anyone about me.", 0.9);
			chat.Add("I like exploding bullets, they get the job done quickly.", 0.9);
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
			shop.item[nextSlot].SetDefaults(ItemID.Grenade);
			shop.item[nextSlot].shopCustomPrice = 75;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.HighVelocityBullet);
			shop.item[nextSlot].shopCustomPrice = 40;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ExplodingBullet);
			shop.item[nextSlot].shopCustomPrice = 40;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.RifleScope);
			shop.item[nextSlot].shopCustomPrice = 60000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IllegalGunParts);
			shop.item[nextSlot].shopCustomPrice = 100000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ClockworkAssaultRifle);
			shop.item[nextSlot].shopCustomPrice = 150000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Uzi);
			shop.item[nextSlot].shopCustomPrice = 280000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(mod.ItemType("HitmansBlowscope"));
			shop.item[nextSlot].shopCustomPrice = 325000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.DartPistol);
			shop.item[nextSlot].shopCustomPrice = 400000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.DartRifle);
			shop.item[nextSlot].shopCustomPrice = 400000;
			nextSlot++;
			if (NPC.downedMechBoss1)
			{
				shop.item[nextSlot].SetDefaults(ItemID.Megashark);
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.GrenadeLauncher);
				shop.item[nextSlot].shopCustomPrice = 280000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SniperRifle);
				shop.item[nextSlot].shopCustomPrice = 400000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.TacticalShotgun);
				shop.item[nextSlot].shopCustomPrice = 400000;
				nextSlot++;
			}
			if (NPC.downedMoonlord)
			{
				shop.item[nextSlot].SetDefaults(ItemID.SDMG);
				shop.item[nextSlot].shopCustomPrice = 500000;
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 49;
			knockback = 1.4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 1;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ProjectileID.Grenade;
			attackDelay = 3;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 10f;
			randomOffset = 0f;
		}
	}
}