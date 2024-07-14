using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Zylon.Items.BossSummons
{
	public class AwakenedRiftCalibrator : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 44;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Purple;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			/*string temp = "He will not hold back.";
			int a = Convert.ToInt32(Main.GameUpdateCount) - (Convert.ToInt32(Main.GameUpdateCount) % 20);
			//Main.rand.SetSeed(a);
			for (int i = 0; i < temp.Length; i++) {
				String randChar = "-";
				switch (Main.rand.Next(5)) {
					case 0:
						randChar = "!";
						break;
					case 1:
						randChar = "#";
						break;
					case 2:
						randChar = "/";
						break;
					case 3:
						randChar = "*";
						break;
                }
				if (Main.rand.NextBool(3)) temp = temp.Remove(i, 1).Insert(i, randChar); //Cool text effect.
			}*/
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "He will not hold back.");
			xline.OverrideColor = new Color(127, 127, 127);
			list.Add(xline);
        }
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.SaburRex.SaburRex>());
		}
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer)
			{
				SoundEngine.PlaySound(SoundID.Roar, player.position);
				int type = ModContent.NPCType<NPCs.Bosses.SaburRex.SaburRex>();
				Zylon.noHitSabur = true;

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else
				{
					NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
				}
			}
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 13);
			recipe.AddIngredient(ModContent.ItemType<Materials.WolfPelt>(), 15);
			recipe.AddIngredient(ItemID.RainbowBrick, 50);
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>(), 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}