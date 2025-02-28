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

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Herb", new int[]
			{
			ItemID.Blinkroot,
			ItemID.Daybloom,
			ItemID.Deathweed,
			ItemID.Fireblossom,
			ItemID.Moonglow,
			ItemID.Shiverthorn,
			ItemID.Waterleaf,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyHerb", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Basic Hardmode Bar", new int[]
			{
			ItemID.CobaltBar,
			ItemID.PalladiumBar,
			ItemID.MythrilBar,
			ItemID.OrichalcumBar,
			ItemID.AdamantiteBar,
			ItemID.TitaniumBar,
			});
			RecipeGroup.RegisterGroup("Zylon:AnyHMBar", group);

			group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Lottery Ticket", new int[]
			{
			ModContent.ItemType<Items.Bags.LotteryTicketTier1>(),
			ModContent.ItemType<Items.Bags.LotteryTicketTier2>(),
			ModContent.ItemType<Items.Bags.LotteryTicketTier3>()
			});
			RecipeGroup.RegisterGroup("Zylon:AnyLotteryTicket", group);
		}
        public override void AddRecipes() {
            Recipe recipe = Recipe.Create(ItemID.MagicMirror);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 8);
			recipe.AddIngredient(ItemID.Glass, 10);
			recipe.AddIngredient(ItemID.RecallPotion, 3);
			recipe.AddIngredient(ItemID.FallenStar, 5);
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
			recipe.AddIngredient(ItemID.ShroomiteBar, 3);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LihzahrdPowerCell);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 8);
			recipe.AddIngredient(ItemID.Glass, 2);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WandofSparking);
			recipe.AddRecipeGroup("Wood", 11);
			recipe.AddIngredient(ItemID.Torch, 9);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IceBoomerang);
			recipe.AddIngredient(ItemID.WoodenBoomerang);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.EnchantedIceCube>(), 12);
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

			recipe = Recipe.Create(ItemID.BloodMoonStarter);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.BloodDroplet>(), 10);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BrownDye, 2);
			recipe.AddIngredient(ModContent.ItemType<Items.Food.CocoaBeans>());
			recipe.AddTile(TileID.DyeVat);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FlyingCarpet);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 10);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CloudinaBottle);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.Cloud, 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 6);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BlizzardinaBottle);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.SnowBlock, 15);
			recipe.AddIngredient(ItemID.FlinxFur, 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SandstorminaBottle);
			recipe.AddIngredient(ItemID.Bottle);
			recipe.AddIngredient(ItemID.SandBlock, 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.AdeniteCrumbles>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 12);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShinyRedBalloon);
			recipe.AddIngredient(ItemID.WhoopieCushion);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 5);
			recipe.AddTile(TileID.SkyMill);
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
			recipe.AddIngredient(ItemID.Feather, 35);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 7);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 7);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Starfury);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddIngredient(ItemID.FallenStar, 9);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 16);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CreativeWings);
			recipe.AddIngredient(ItemID.Cloud, 15);
			recipe.AddIngredient(ItemID.Feather, 12);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LuckyHorseshoe);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 8);
			recipe.AddIngredient(ItemID.SunplateBlock, 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SkyMill);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddIngredient(ItemID.Feather, 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SpeckledStardust>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BoneSword);
			recipe.AddIngredient(ItemID.Bone, 45);
			recipe.AddIngredient(ItemID.Cobweb, 50);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ThunderStaff);
			recipe.AddRecipeGroup("Zylon:AnyCopperBar", 8);
			recipe.AddIngredient(ItemID.FossilOre, 6);
			recipe.AddIngredient(ItemID.Lens);
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
			recipe.AddCondition(Condition.InGraveyard);
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
			recipe.AddIngredient(ItemID.Obsidian, 10);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IceSkates);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddIngredient(ItemID.SnowBlock, 20);
			recipe.AddIngredient(ItemID.IceBlock, 20);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();

			recipe = Recipe.Create(ItemID.AnkletoftheWind);
			recipe.AddIngredient(ItemID.Vine, 3);
			recipe.AddIngredient(ItemID.JungleSpores, 9);
			recipe.AddIngredient(ItemID.PinkGel, 5);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Aglet);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HermesBoots);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddIngredient(ItemID.SwiftnessPotion);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 10);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.HermesBoots);
			recipe.AddIngredient(ItemID.TatteredCloth, 23);
			recipe.AddIngredient(ItemID.SwiftnessPotion);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CobaltShield);
			recipe.AddRecipeGroup("Zylon:AnyCobaltBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddIngredient(ItemID.SoulofLight, 6);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.ElementalGoop>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Hellforge);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 12);
			recipe.AddIngredient(ItemID.LavaBucket, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FiberglassFishingPole);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.CarnalliteBar>(), 14);
			recipe.AddIngredient(ItemID.Glass, 18);
			recipe.AddIngredient(ItemID.JungleSpores, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LavaCharm);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WaterWalkingBoots);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddIngredient(ItemID.WaterWalkingPotion);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 10);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WaterWalkingBoots);
			recipe.AddIngredient(ItemID.TatteredCloth, 23);
			recipe.AddIngredient(ItemID.WaterWalkingPotion);
			recipe.AddTile(TileID.Loom);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ObsidianRose);
			recipe.AddIngredient(ItemID.JungleRose);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ObsidianRose);
			recipe.AddRecipeGroup("Zylon:AnyHerb", 2);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.MagmaStone);
			recipe.AddIngredient(ItemID.StoneBlock, 40);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(ModContent.ItemType<Items.Bars.HaxoniteBar>(), 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IceBlade);
			recipe.AddIngredient(ItemID.WoodenSword);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 6);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.EnchantedIceCube>(), 12);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WhoopieCushion);
			recipe.AddIngredient(ItemID.Leather);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.WindEssence>(), 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Leather);
			recipe.AddIngredient(ItemID.Vertebrae, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TurtleHelmet);
			recipe.AddIngredient(ItemID.ChlorophyteMask);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TurtleScaleMail);
			recipe.AddIngredient(ItemID.ChlorophytePlateMail);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.TurtleLeggings);
			recipe.AddIngredient(ItemID.ChlorophyteGreaves);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FrozenTurtleShell);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LivingLoom);
			recipe.AddRecipeGroup("Wood", 18);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.LivingBranch>(), 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SlimeStaff);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddIngredient(ItemID.Gel, 32);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SandBoots);
			recipe.AddIngredient(ItemID.HermesBoots);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.SearedStone>(), 16);
			recipe.AddIngredient(ItemID.SandBlock, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WaterBolt);
			recipe.AddIngredient(ItemID.Book);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NearWater);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Handgun);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.AquaScepter);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Bone, 20);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NearWater);
			recipe.Register();

			recipe = Recipe.Create(ItemID.MagicMissile);
			recipe.AddRecipeGroup("IronBar", 6);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BlueMoon);
			recipe.AddIngredient(ItemID.Mace);
			recipe.AddIngredient(ItemID.Bone, 16);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NearWater);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Muramasa);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.AddCondition(Condition.NearWater);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Valor);
			recipe.AddIngredient(ItemID.WoodYoyo);
			recipe.AddRecipeGroup("IronBar", 4);
			recipe.AddIngredient(ItemID.Bone, 22);
			recipe.AddIngredient(ItemID.FallenStar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ClothierVoodooDoll);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.TatteredCloth, 8);
			recipe.AddIngredient(ItemID.Bone, 15);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.GuideVoodooDoll);
			recipe.AddIngredient(ItemID.Silk, 10);
			recipe.AddIngredient(ItemID.TatteredCloth, 8);
			recipe.AddIngredient(ItemID.AshBlock, 15);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Sextant);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar", 10);
			recipe.AddIngredient(ItemID.Glass, 8);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FishermansGuide);
			recipe.AddIngredient(ItemID.Silk, 8);
			recipe.AddRecipeGroup("Zylon:AnyGoldBar");
			recipe.AddIngredient(ItemID.BlueDye);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.WeatherRadio);
			recipe.AddRecipeGroup("IronBar", 8);
			recipe.AddIngredient(ItemID.Glass, 3);
			recipe.AddIngredient(ItemID.Wire, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Radar);
			recipe.AddRecipeGroup("IronBar", 9);
			recipe.AddIngredient(ItemID.Glass, 8);
			recipe.AddRecipeGroup("Zylon:AnyGem");
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LifeFruit);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 4);
			recipe.AddIngredient(ItemID.SoulofLight);
			recipe.AddIngredient(ItemID.SoulofNight);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CombatWrench);
			recipe.AddIngredient(ItemID.Wrench);
			recipe.AddIngredient(ItemID.Wire, 10);
			recipe.AddIngredient(ItemID.Bone, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.LesserManaPotion, 2);
			recipe.AddIngredient(ItemID.Bottle, 2);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.EnchantedIceCube>());
			recipe.AddIngredient(ItemID.Gel, 2);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.RestorationPotion, 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Potions.LesserRestorationPotion>(), 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.EerieBell>());
			recipe.AddIngredient(ItemID.JungleSpores);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BoneArrow, 25);
			recipe.AddIngredient(ItemID.WoodenArrow, 25);
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CelestialMagnet);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 9);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(ItemID.SunplateBlock, 12);
			recipe.AddTile(TileID.SkyMill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShroomiteHeadgear);
			recipe.AddIngredient(ItemID.ChlorophyteHelmet);
			recipe.AddIngredient(ItemID.GlowingMushroom, 180);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShroomiteMask);
			recipe.AddIngredient(ItemID.ChlorophyteHelmet);
			recipe.AddIngredient(ItemID.GlowingMushroom, 180);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShroomiteHelmet);
			recipe.AddIngredient(ItemID.ChlorophyteHelmet);
			recipe.AddIngredient(ItemID.GlowingMushroom, 180);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShroomiteBreastplate);
			recipe.AddIngredient(ItemID.ChlorophytePlateMail);
			recipe.AddIngredient(ItemID.GlowingMushroom, 360);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShroomiteLeggings);
			recipe.AddIngredient(ItemID.ChlorophyteGreaves);
			recipe.AddIngredient(ItemID.GlowingMushroom, 270);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Uzi);
			recipe.AddIngredient(ItemID.HallowedBar, 8);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 6);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.IceSickle);
			recipe.AddRecipeGroup("Zylon:AnyAdamantiteBar", 10);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.DeerThing);
			recipe.AddIngredient(ItemID.FlinxFur, 3);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 2);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SpectreMask);
			recipe.AddIngredient(ItemID.ChlorophyteHeadgear);
			recipe.AddIngredient(ItemID.Ectoplasm, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SpectreHood);
			recipe.AddIngredient(ItemID.ChlorophyteHeadgear);
			recipe.AddIngredient(ItemID.Ectoplasm, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SpectreRobe);
			recipe.AddIngredient(ItemID.ChlorophytePlateMail);
			recipe.AddIngredient(ItemID.Ectoplasm, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.SpectrePants);
			recipe.AddIngredient(ItemID.ChlorophyteGreaves);
			recipe.AddIngredient(ItemID.Ectoplasm, 9);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Nazar);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 8);
			recipe.AddIngredient(ItemID.Bone, 50);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CandyCaneSword);
			recipe.AddIngredient(ItemID.CandyCaneBlock, 32);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CnadyCanePickaxe);
			recipe.AddIngredient(ItemID.CandyCaneBlock, 36);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.CandyCaneHook);
			recipe.AddIngredient(ItemID.CandyCaneBlock, 50);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.BloodyMachete);
			recipe.AddRecipeGroup("Zylon:AnyPHBar", 10);
			recipe.AddIngredient(ModContent.ItemType<Items.Materials.BloodDroplet>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.FeralClaws);
			recipe.AddIngredient(ItemID.Leather, 2);
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ClimbingClaws);
			recipe.AddIngredient(ItemID.BlackDye);
			recipe.AddRecipeGroup("IronBar", 9);
			recipe.AddTile(TileID.Sawmill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.ShoeSpikes);
			recipe.AddIngredient(ItemID.BlackDye);
			recipe.AddRecipeGroup("IronBar", 9);
			recipe.AddTile(TileID.Sawmill);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Shroomerang);
			recipe.AddRecipeGroup("Zylon:AnySilverBar", 10);
			recipe.AddIngredient(ItemID.GlowingMushroom, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = Recipe.Create(ItemID.Bananarang);
			recipe.AddIngredient(ItemID.Banana);
			recipe.AddRecipeGroup("Zylon:AnyMythrilBar", 11);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.UnholyArrow);
			recipe.AddIngredient(ItemID.WoodenArrow, 10);
			recipe.AddIngredient(ItemID.WormTooth);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

			recipe = Recipe.Create(ItemID.PanicNecklace);
			recipe.AddIngredient(ItemID.Chain, 8);
			recipe.AddIngredient(ItemID.LifeCrystal);
			recipe.AddIngredient(ItemID.Ruby, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
        }
        public override void PostAddRecipes() {
            if (ModContent.GetInstance<ZylonConfig>().zylonianBalancing) for (int i = 0; i < Recipe.numRecipes; i++) {
				Recipe recipe = Main.recipe[i];
				if (recipe.HasResult(ItemID.GravediggerShovel))
					recipe.AddIngredient(ModContent.ItemType<Items.Materials.ObeliskShard>(), 20);
				if (recipe.HasResult(ItemID.Sandgun))
					recipe.AddIngredient(ModContent.ItemType<Items.Materials.SearedStone>(), 18);
				if (recipe.HasResult(ItemID.EnchantedBoomerang)) {
					recipe.RemoveIngredient(ItemID.FallenStar);
					recipe.AddRecipeGroup("IronBar", 5);
					recipe.AddIngredient(ItemID.ManaCrystal);
					recipe.AddTile(TileID.Anvils);
				}
				if (recipe.HasResult(ItemID.Zenith))
					recipe.AddIngredient(ModContent.ItemType<Items.Materials.FantasticalFinality>(), 13);
				if (recipe.HasResult(ItemID.RestorationPotion) && recipe.HasIngredient(ItemID.Mushroom))
					recipe.DisableRecipe();
				if (recipe.HasResult(ItemID.UnholyArrow) && recipe.HasIngredient(ItemID.Vertebrae))
					recipe.DisableRecipe();
			}
        }
    }
}