using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Zylon
{
	public class ZylonSystems : ModSystem
	{
		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Basic Prehardmode Bar", new int[]
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

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Copper Bar", new int[]
			{
			ItemID.CopperBar,
			ItemID.TinBar
			});
			RecipeGroup.RegisterGroup("Zylon:AnyCopperBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Silver Bar", new int[]
			{
			ItemID.SilverBar,
			ItemID.TungstenBar
			});
			RecipeGroup.RegisterGroup("Zylon:AnySilverBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold Bar", new int[]
			{
			ItemID.GoldBar,
			ItemID.PlatinumBar
			});
			RecipeGroup.RegisterGroup("Zylon:AnyGoldBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gem", new int[]
			{
			ItemID.Amethyst,
			ItemID.Topaz,
			ItemID.Sapphire,
			ItemID.Emerald,
			ItemID.Amber,
			ItemID.Diamond,
			ItemID.Ruby,
			ModContent.ItemType<Items.Materials.Jade>()
			});
			RecipeGroup.RegisterGroup("Zylon:AnyGem", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Shadow Scale", new int[]
			{
			ItemID.ShadowScale,
			ItemID.TissueSample,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyShadowScale", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Demonite Bar", new int[]
			{
			ItemID.DemoniteBar,
			ItemID.CrimtaneBar,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyDemoniteBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Cobalt Bar", new int[]
			{
			ItemID.CobaltBar,
			ItemID.PalladiumBar,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyCobaltBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Mythril Bar", new int[]
			{
			ItemID.MythrilBar,
			ItemID.OrichalcumBar,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyMythrilBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Adamantite Bar", new int[]
			{
			ItemID.AdamantiteBar,
			ItemID.TitaniumBar,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyAdamantiteBar", group);

			if (RecipeGroup.recipeGroupIDs.ContainsKey("IronBar")) {
				int index = RecipeGroup.recipeGroupIDs["IronBar"];
				group = RecipeGroup.recipeGroups[index];
				group.ValidItems.Add(ModContent.ItemType<Items.Bars.ZincBar>());
			}
		}
        public override void AddRecipes() {
            Recipe recipe = Recipe.Create(ItemID.MagicMirror);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.Glass, 15);
			recipe.AddIngredient(ItemID.RecallPotion, 10);
			recipe.AddIngredient(ItemID.FallenStar, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WoodenBoomerang);
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 12);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Pwnhammer);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.PocketMirror);
			recipe.AddIngredient(ItemID.MarbleBlock, 25);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 5);
			recipe.AddIngredient(ItemID.Glass, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.MiningHelmet);
			recipe.AddIngredient(ItemID.GoldHelmet);
			recipe.AddIngredient(ItemID.Glass);
			recipe.AddIngredient(ItemID.Torch);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Trident);
			recipe.AddIngredient(ItemID.GoldBar, 9);
			recipe.AddRecipeGroup("Zylon:AnyGem");
			recipe.AddIngredient(ItemID.Seashell);
			recipe.AddIngredient(ItemID.Starfish);
			recipe.AddIngredient(ItemID.Coral);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SlimeCrown);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 5);
			recipe.AddRecipeGroup("Zylon:AnyGem");
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HandWarmer);
			recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddIngredient(ItemID.SnowBlock, 12);
			recipe.AddIngredient(ItemID.IceBlock, 8);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TruffleWorm);
			recipe.AddIngredient(ItemID.Worm);
			recipe.AddIngredient(ItemID.ShroomiteBar, 5);
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LihzahrdPowerCell);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
			recipe.AddIngredient(ItemID.Glass, 3);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WandofSparking);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddIngredient(ItemID.Torch, 5);
			recipe.AddRecipeGroup("Zylon:AnyCopperBar", 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IceBoomerang);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 9);
			recipe.AddIngredient(ItemID.IceBlock, 20);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BandofRegeneration);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.IronBand>());
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BandofRegeneration);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.LeadBand>());
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BandofRegeneration);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.ZincBand>());
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BandofStarpower);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.IronBand>());
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BandofStarpower);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.LeadBand>());
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BandofStarpower);
			recipe.AddIngredient(ModContent.ItemType<Items.Accessories.ZincBand>());
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ThornsPotion);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Cactus);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.BloodySpiderLeg>());
			recipe.AddIngredient(ItemID.Stinger);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BloodMoonStarter);
			recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 5);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.BloodDroplet>(), 10);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BrownDye, 2);
			recipe.AddIngredient(ModContent.ItemType<Items.Food.CocoaBeans>());
			recipe.AddTile(TileID.DyeVat);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FlyingCarpet);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 15);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CloudinaBottle);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.Cloud, 20);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BlizzardinaBottle);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.SnowBlock, 25);
			recipe.AddIngredient(ItemID.FlinxFur, 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 15);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SandstorminaBottle);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.SandBlock, 30);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.DiskiteCrumbles>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShinyRedBalloon);
			recipe.AddIngredient(ItemID.WhoopieCushion);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 15);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IronskinPotion);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(ItemID.Daybloom);
			recipe.AddIngredient(ModContent.ItemType<Items.Ores.ZincOre>());
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GreaterHealingPotion, 3);
			recipe.AddIngredient(ItemID.HealingPotion, 3);
			recipe.AddIngredient(ItemID.PixieDust);
			recipe.AddIngredient(ItemID.CrystalShard);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GreaterManaPotion, 15);
			recipe.AddIngredient(ItemID.ManaPotion, 15);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GiantHarpyFeather);
			recipe.AddIngredient(ItemID.Feather, 50);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 5);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Starfury);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 20);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(4978);
			recipe.AddIngredient(ItemID.Feather, 20);
			recipe.AddIngredient(ItemID.FallenStar, 20);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 20);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LuckyHorseshoe);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 10);
			recipe.AddIngredient(ItemID.SunplateBlock, 12);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SkyMill);
			recipe.AddIngredient(ItemID.SunplateBlock, 20);
			recipe.AddIngredient(ItemID.Feather, 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BoneSword);
			recipe.AddIngredient(ItemID.Bone, 26);
			recipe.AddRecipeGroup("Zylon:AnyCopperBar", 10);
			recipe.AddTile(TileID.BoneWelder);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ThunderStaff);
			recipe.AddRecipeGroup("Zylon:AnyCopperBar", 10);
			recipe.AddIngredient(ItemID.FossilOre, 8);
			recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BookofSkulls);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.Bone, 40);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(321);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(1173);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(1174);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(1175);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(1176);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(1177);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(3229);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddIngredient(ItemID.GoldCoin);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(3230);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddIngredient(ItemID.GoldCoin);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(3231);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddIngredient(ItemID.GoldCoin);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(3232);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddIngredient(ItemID.GoldCoin);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(3233);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 15);
			recipe.AddIngredient(ItemID.GoldCoin);
			recipe.AddTile(TileID.HeavyWorkBench);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TragicUmbrella);
			recipe.AddIngredient(ItemID.Umbrella);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 20);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Recipe.Condition.InGraveyardBiome);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GoldenDelight);
			recipe.AddIngredient(ItemID.GoldenCarp);
			recipe.AddTile(TileID.CookingPots);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ObsidianSwordfish);
			recipe.AddIngredient(ItemID.Swordfish);
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShadowKey);
			recipe.AddIngredient(ItemID.GoldenKey);
			recipe.AddIngredient(ItemID.Obsidian, 20);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IceSkates);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.SnowBlock, 20);
			recipe.AddIngredient(ItemID.IceBlock, 20);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();

			recipe = Recipe.Create(ItemID.AnkletoftheWind);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddIngredient(ItemID.PinkGel, 10);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Aglet);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HermesBoots);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.SwiftnessPotion, 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 12);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CobaltShield);
			recipe.AddRecipeGroup("Zylon:AnyCobaltBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ElementalGoop>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Hellforge);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.LavaBucket, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FiberglassFishingPole);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.CarnalliteBar>(), 18);
			recipe.AddIngredient(ItemID.Glass, 24);
			recipe.AddIngredient(ItemID.JungleSpores, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LavaCharm);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WaterWalkingBoots);
			recipe.AddIngredient(ItemID.Silk, 15);
			recipe.AddIngredient(ItemID.WaterWalkingPotion, 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 12);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.MagmaStone);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
        }
        public override void PostAddRecipes() {
            for (int i = 0; i < Recipe.numRecipes; i++) {
				Recipe recipe = Main.recipe[i];
				if (recipe.HasResult(ItemID.TerraBlade))
					recipe.AddIngredient(ModContent.ItemType<Items.Materials.ElementalGoop>(), 15);
				if (recipe.HasResult(ItemID.GravediggerShovel))
					recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 20);
				if (recipe.HasResult(ItemID.Sandgun))
					recipe.AddIngredient(ModContent.ItemType<Items.Materials.RustedTech>(), 15);
				if (recipe.HasResult(ItemID.MeteorStaff))
					recipe.AddIngredient(ModContent.ItemType<Items.Wands.MeteorHerder>());
			}
        }
    }
}