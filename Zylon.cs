using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Zylon.Items.BossSummon;

namespace Zylon
{
	public class Zylon : Mod
	{
		public Zylon()
		{
			
		}
		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call(
					"AddBoss",
					0.12f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.Dirtball>(), ModContent.NPCType<NPCs.Bosses.Dirtball>() },
					this,
					"$Mods.Zylon.NPCName.Dirtball",
					(Func<bool>)(() => WorldEdit.downedDirtball),
					ModContent.ItemType<Items.BossSummon.CreepyMud>(),
					new List<int> { ModContent.ItemType<Items.Dirtball.StoryDirtball>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Dirtball.BrokenDirtballCopperShortsword>()}, //other
					$"Dirtball spawns rarely until it is defeated. It can be manually summoned with a [i:{ModContent.ItemType<Items.BossSummon.CreepyMud>()}], which can be crafted or rarely dropped from enemies."
				);
				bossChecklist.Call(
					"AddBoss",
					1.1f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.AncientDesertDiscus>(), ModContent.NPCType<NPCs.Bosses.AncientDesertDiscus>() },
					this,
					"$Mods.Zylon.NPCName.AncientDesertDiscus",
					(Func<bool>)(() => WorldEdit.downedDiscus),
					ModContent.ItemType<Items.BossSummon.SuspiciousLookingDisc>(),
					new List<int> { ModContent.ItemType<Items.Discus.StoryDiscus>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Discus.ZylonianDesertCore>(), ModContent.ItemType<Items.Discus.DiscusGuardianPendant>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.BossSummon.SuspiciousLookingDisc>()}]  to summon the discus leader in the desert night..."
				);
				bossChecklist.Call(
					"AddBoss",
					14.9f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.ZylonianMineralExtractor>(), ModContent.NPCType<NPCs.Bosses.ZylonianMineralExtractor>() },
					this,
					"$Mods.Zylon.NPCName.ZylonianMineralExtractor",
					(Func<bool>)(() => WorldEdit.downedMineral),
					ModContent.ItemType<Items.BossSummon.MysteriousGemPink>(),
					new List<int> { ModContent.ItemType<Items.Mineral.StoryMineral>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Mineral.GalacticDiamondium>() }, //other
					$"Use any version of the [i:{ModContent.ItemType<Items.BossSummon.MysteriousGemPink>()}] at night to send its scanners out of control..."
				);
			}
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "ContagionalistEmblem");
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddTile(114);
			recipe.SetResult(ItemID.AvengerEmblem);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.AddIngredient(ItemID.RecallPotion, 20);
			recipe.AddIngredient(ItemID.Gel, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.MagicMirror);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.PinkGel, 2);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.ThornsPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.PinkGel, 4);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.CalmingPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater, 10);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(null, "ZylonianDesertCore", 10);
			recipe.AddIngredient(ItemID.PinkGel, 30);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.HeartreachPotion, 10);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Moonglow);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.CobaltOre);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.AmmoReservationPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.PalladiumOre);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.InfernoPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Fireblossom);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.MythrilOre);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.RagePotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.OrichalcumOre);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.WrathPotion);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater, 10);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(null, "ZylonianDesertCore", 10);
			recipe.AddIngredient(ItemID.AdamantiteOre, 10);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.LifeforcePotion, 10);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddIngredient(ItemID.Waterleaf);
			recipe.AddIngredient(null, "ZylonianDesertCore");
			recipe.AddIngredient(ItemID.TitaniumOre);
			recipe.AddTile(13);
			recipe.SetResult(ItemID.EndurancePotion);
			recipe.AddRecipe();
		}
	}
}