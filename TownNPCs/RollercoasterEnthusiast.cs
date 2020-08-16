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
	public class RollercoasterEnthusiast : ModNPC
	{
		public override string Texture => "Zylon/NPCs/TownNPCs/RollercoasterEnthusiast";
		public override bool Autoload(ref string name)
		{
			name = "Rollercoaster Enthusiast";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rollercoaster Enthusiast");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 550;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 45;
			NPCID.Sets.AttackAverageChance[npc.type] = 35;
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
			npc.damage = 16;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.knockBackResist = 0.5f;
		}
		public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			if (ZylonWorld.rollercoasterTown == true)
			return true;
			foreach (Item item in Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].inventory) {
				if (item.type == ItemID.MinecartTrack || item.type == ItemID.Minecart) {
					if (Main.dayTime && Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].active)
					return true;
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			int nameRan = WorldGen.genRand.Next(0, 9);
			if (nameRan == 0)
			return "Marcus";
			if (nameRan == 1)
			return "Nathan";
			if (nameRan == 2)
			return "Thompson";
			if (nameRan == 3)
			return "Joseph";
			if (nameRan == 4)
			return "Allen";
			if (nameRan == 5)
			return "John";
			if (nameRan == 6)
			return "Chris";
			if (nameRan == 7)
			return "Lewis";
			if (nameRan == 8)
			return "Aaron";
			return "Aaron";
		}
		
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			
			chat.Add("Where is the closest rollercoaster?", 1.2);
			chat.Add("Where can I buy a season pass to the closest rollercoaster park?", 1);
			chat.Add("I'll sell you the tracks, and you build the rollercoaster.", 0.9);
			chat.Add("I've rode almost every rollercoaster in the world.", 1.1);
			chat.Add("You should build another rollercoaster.", 0.8);
			chat.Add("Rollercoasters open to the public aren't dangerous.", 0.8);
			chat.Add("Rollercoasters are the best kind of entertainment, you know?", 1.1);
			return chat;
		}
		public override void AI()
		{
			if (ZylonWorld.rollercoasterTown == false)
				ZylonWorld.rollercoasterTown = true;
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
			shop.item[nextSlot].SetDefaults(ItemID.Minecart);
			shop.item[nextSlot].shopCustomPrice = 10000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.Wood);
			shop.item[nextSlot].shopCustomPrice = 10;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.IronHammer);
				shop.item[nextSlot].shopCustomPrice = 7500;
				nextSlot++;
			if (NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(ItemID.IronBar);
				shop.item[nextSlot].shopCustomPrice = 1500;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.LeadBar);
				shop.item[nextSlot].shopCustomPrice = 1500;
				nextSlot++;
			}
			if (NPC.downedMechBoss1 && Main.expertMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.MechanicalWagonPiece);
				shop.item[nextSlot].shopCustomPrice = 25000;
				nextSlot++;
			}
			if (NPC.downedMechBoss2 && Main.expertMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.MechanicalWheelPiece);
				shop.item[nextSlot].shopCustomPrice = 25000;
				nextSlot++;
			}
			if (NPC.downedMechBoss3 && Main.expertMode)
			{
				shop.item[nextSlot].SetDefaults(ItemID.MechanicalBatteryPiece);
				shop.item[nextSlot].shopCustomPrice = 25000;
				nextSlot++;
			}
			if (ZylonWorld.downedComVirus && Main.expertMode)
			{
				shop.item[nextSlot].SetDefaults(mod.ItemType("MechanicalGearPiece"));
				shop.item[nextSlot].shopCustomPrice = 25000;
				nextSlot++;
			}
			if (NPC.downedPlantBoss)
			{
				shop.item[nextSlot].SetDefaults(ItemID.NailGun);
				shop.item[nextSlot].shopCustomPrice = 350000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Nail);
				shop.item[nextSlot].shopCustomPrice = 75;
				nextSlot++;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 18;
			knockback = 2f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 7;
			randExtraCooldown = 3;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			if (Main.hardMode)
			projType = ProjectileID.NailFriendly;
			else
			projType = mod.ProjectileType("NailWeak");

			attackDelay = 3;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 10f;
			randomOffset = 2f;
		}
	}
}