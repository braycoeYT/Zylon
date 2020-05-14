using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.NPCs
{
	public class ZylonGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		//public bool viralInfection;
		
		//public override void ResetEffects(NPC npc)
		//{
			//viralInfection = false;
		//}
		
		//public override void UpdateLifeRegen(NPC npc, ref int damage)
		//{
		    //if (viralInfection)
			//{
				//if (npc.lifeRegen > 0)
				//{
					//npc.lifeRegen = 0;
				//}
				//npc.lifeRegen -= 1;
				//if (damage < 1)
				//{
					//damage = 1;
				//}
			//}
		//}
		
		public override void NPCLoot(NPC npc)
		{
			if (!WorldEdit.downedDirtball)
			{
				if (Main.rand.Next(100) == 1)
				Item.NewItem(npc.getRect(), ItemType<Items.BossSummon.CreepyMud>());
			}
			if (npc.type == 113)
			{
				if (!WorldEdit.hasConversationDrop)
				{
					Item.NewItem(npc.getRect(), ItemType<Items.OtherStory.MysteriousConversation>());
					WorldEdit.hasConversationDrop = true;
				}
			}
			if (npc.type == NPCID.LunarTowerSolar)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.LunarTowerVortex)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.LunarTowerNebula)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(4, 6));
			}
			if (npc.type == NPCID.LunarTowerStardust)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.DreamString>(), Main.rand.Next(4, 6));
			}
			if (npc.type == NPCID.IceSlime)
			{
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.IceBat)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			    if (Main.rand.Next(100) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.SpikedIceSlime)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.SnowFlinx)
			{
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Snow.CryoCrystal>());
			}
			if (npc.type == NPCID.KingSlime)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.KingSlicer>());
			}
			if (npc.type == 4)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.Stalkeye>());
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.GlazedLens>(), Main.rand.Next(2, 6));
			}
			if (npc.type == NPCID.Retinazer)
			{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.EyeThemed.EyeOfPrejudice>());
			}
			if (npc.type == NPCID.Spazmatism)
			{
				/*if (WorldEdit.voidDream == true)
				{
				if (Main.rand.Next(2) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.VoidDream.GreenSpicyMechanicalCurry>());
			    }*/
			}
			if (npc.type == NPCID.JungleBat)
			{
			    if (Main.rand.Next(100) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.GiantBat)
			{
			    if (Main.rand.Next(100) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Accessories.MagicalVaccine>());
			}
			if (npc.type == NPCID.SkeletronHead)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.PHBoss.OrganicBone>());
			}
			if (npc.type == NPCID.Plantera)
			{
				Item.NewItem(npc.getRect(), ItemType<Items.PlanteraTooth>(), Main.rand.Next(1, 5));
			}
			if (npc.type == NPCID.DukeFishron)
			{
				if (WorldEdit.voidDream)
				Item.NewItem(npc.getRect(), ItemType<Items.VoidDream.DukesWill>());
			}
			if (npc.type == NPCID.Mothron)
			{
				if (Main.rand.Next(3) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.OtherJavelances.AncientMedievalJavelance>(), Main.rand.Next(1, 6));
			}
			if (npc.type == NPCID.Drippler)
			{
				if (Main.rand.Next(8) == 0)
				Item.NewItem(npc.getRect(), ItemType<Items.Meatball.PlainNoodle>());
			Item.NewItem(npc.getRect(), ItemID.FleshBlock, Main.rand.Next(1, 9));
			}
		}
		
		/*public virtual bool PreNPC(NPC npc, ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if (WorldEdit.voidDream == true)
			{
				damage = (int)(damage * 2);
				defense = (int)(defense * 1.5);
			}
			return true;
		}*/
	}
}