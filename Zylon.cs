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
using Terraria.Localization;
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
					"AddMiniBoss",
					0.12f,
					new List<int> { ModContent.NPCType<NPCs.Minibosses.Dirtball>() },
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
					1.65f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.AncientDesertDiscus>() },
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
					9.01f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.ComputerVirus>(), ModContent.NPCType<NPCs.Bosses.ComputerVirusPha2>() },
					this,
					"$Mods.Zylon.NPCName.ComputerVirus",
					(Func<bool>)(() => WorldEdit.downedComVirus),
					ModContent.ItemType<Items.BossSummon.MechanicalDisc>(),
					new List<int> { ModContent.ItemType<Items.ComputerVirus.StoryComVirus>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Discus.ZylonianDesertCore>(), ModContent.ItemType<Items.Discus.DiscusGuardianPendant>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.BossSummon.MechanicalDisc>()}]  to taunt the cyber plague..."
				);
				bossChecklist.Call(
					"AddBoss",
					10.5f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.EmpressSlime>()},
					this,
					"$Mods.Zylon.NPCName.EmpressSlime",
					(Func<bool>)(() => WorldEdit.downedEmpress),
					ModContent.ItemType<Items.Empress.EmpressChalice>(),
					new List<int> { ModContent.ItemType<Items.ComputerVirus.StoryComVirus>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Discus.ZylonianDesertCore>(), ModContent.ItemType<Items.Discus.DiscusGuardianPendant>() }, //other
					$"Use a [i:{ModContent.ItemType<Items.Empress.EmpressChalice>()}]"
				);
				bossChecklist.Call(
					"AddBoss",
					14.75f,
					new List<int> { ModContent.NPCType<NPCs.Bosses.ZylonianMineralExtractor>(), ModContent.NPCType<NPCs.Bosses.ZylonianMineralExtractorPha2>() },
					this,
					"$Mods.Zylon.NPCName.ZylonianMineralExtractor",
					(Func<bool>)(() => WorldEdit.downedMineral),
					ModContent.ItemType<Items.BossSummon.MysteriousGemPink>(),
					new List<int> { ModContent.ItemType<Items.Mineral.StoryMineral>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Mineral.GalacticDiamondium>() }, //other
					$"Use any version of the [i:{ModContent.ItemType<Items.BossSummon.MysteriousGemPink>()}] at night to send its scanners out of control..."
				);
				bossChecklist.Call(
					"AddMiniBoss",
					14.8f,
					new List<int> { ModContent.NPCType<NPCs.Minibosses.XenicAcidpumper>() },
					this,
					"$Mods.Zylon.NPCName.XenicAcidpumper",
					(Func<bool>)(() => WorldEdit.downedXenic),
					ModContent.ItemType<Items.BossSummon.CreepyMud>(),
					new List<int> { ModContent.ItemType<Items.Dirtball.StoryDirtball>() }, //collectables
					new List<int> { ModContent.ItemType<Items.Dirtball.BrokenDirtballCopperShortsword>()}, //other
					$"A Xenic Acidpumper spawns rarely in the post-Zylonian Mineral Exctractor outer space at night."
				);
			}
		}

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Prehardmode Bar", new int[]
			{
			ItemID.CopperBar,
			ItemID.TinBar,
			ItemID.IronBar,
			ItemID.LeadBar,
			ItemID.SilverBar,
			ItemID.TungstenBar,
			ItemID.GoldBar,
			ItemID.PlatinumBar
			});
			RecipeGroup.RegisterGroup("Zylon:AnyPHBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", new int[]
			{
			ItemID.Amethyst,
			ItemID.Topaz,
			ItemID.Sapphire,
			ItemID.Emerald,
			ItemID.Amber,
			ItemID.Diamond,
			ItemID.Ruby
			});
			RecipeGroup.RegisterGroup("Zylon:AnyGem", group);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.AddIngredient(ItemID.RecallPotion, 5);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddIngredient(null, "GlazedLens", 5);
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
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.IronBar, 12);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(3352);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LeadBar, 12);
			recipe.AddIngredient(ItemID.Cobweb, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(3352);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.Spike, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.BreakerBlade);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.HallowedBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(ItemID.Pwnhammer);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 10);
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedSword);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 11);
			recipe.AddIngredient(ItemID.Diamond, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Arkhalis);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 9);
			recipe.AddIngredient(ItemID.Bone, 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Muramasa);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.MarbleBlock, 25);
			recipe.AddIngredient(ItemID.GoldBar, 5);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.PocketMirror);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(3354);
			recipe.AddIngredient(3355);
			recipe.AddIngredient(null, "MechanicalGearPiece");
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(3353);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "CyanixBar", 8);
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.EnchantedBoomerang);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(null, "MagentiteBar", 16);
			recipe.AddIngredient(ItemID.FallenStar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Starfury);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(null, "GlazedLens", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Aglet);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(null, "GlazedLens", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofRegeneration);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddIngredient(null, "GlazedLens", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.BandofStarpower);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldHelmet);
			recipe.AddIngredient(ItemID.Glass);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.MiningHelmet);
			recipe.AddRecipe();
			
			recipe = new ModRecipe(this);
			recipe.AddIngredient(ItemID.GoldBar, 10);
			recipe.AddIngredient(ItemID.Ruby);
			recipe.AddIngredient(ItemID.Seashell);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(ItemID.Trident);
			recipe.AddRecipe();

			recipe = new ModRecipe(this);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 5);
			recipe.AddRecipeGroup("Zylon:AnyGem");
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SlimeCrown);
			recipe.AddRecipe();
		}
	}
}