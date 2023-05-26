using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class EnchantedEye : ModItem
	{
		public override void SetStaticDefaults() {
			string extra = "";
			if (ModContent.GetInstance<ZylonConfig>().infBossSum) extra = "\nNot Consumable";
			Tooltip.SetDefault("Summons the Ancient Diskite Director\nCan only be used in the desert at night\nEnrages outside of the desert\nFlees during the day"+extra);
		}
		public override void SetDefaults()  {
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 20;
			Item.value = 0;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = !ModContent.GetInstance<ZylonConfig>().infBossSum;
		}
        public override bool CanUseItem(Player player) {
            return !Main.dayTime && player.ZoneDesert && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.ADD.ADD_Center>());
        }
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer)
			{
				SoundEngine.PlaySound(SoundID.Roar, player.position);
				int type = ModContent.NPCType<NPCs.Bosses.ADD.ADD_Setup>();

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					NPC.SpawnOnPlayer(player.whoAmI, type);
				}
				else
				{
					NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
				}
			}
			return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 2);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar");
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 8);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}