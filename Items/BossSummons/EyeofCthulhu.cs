using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class EyeofCthulhu : ModItem
	{
		public override void SetDefaults()  {
			Item.width = 152;
			Item.height = 110;
			Item.maxStack = 69;
			Item.value = Item.sellPrice(42, 22, 69, 34);
			Item.rare = ItemRarityID.Gray;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}
        public override bool CanUseItem(Player player) {
            return Main.zenithWorld && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.SusEye.SuspiciousLookingEye>());
        }
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer)
			{
				SoundEngine.PlaySound(SoundID.Item16, player.position);
				int type = ModContent.NPCType<NPCs.Bosses.SusEye.SuspiciousLookingEye>();

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
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.SuspiciousLookingEye);
			recipe.AddIngredient(ItemID.LunarBar, 69);
			recipe.AddIngredient(ItemID.PlatinumCoin, 5);
			recipe.AddIngredient(ItemID.Gel);
			recipe.AddIngredient(ItemID.TopHat);
			recipe.AddIngredient(ItemID.Diamond);
			recipe.AddIngredient(ItemID.Ruler);
			recipe.AddIngredient(ItemID.GoldenShower);
			recipe.AddIngredient(ItemID.TerraToilet);
			recipe.AddIngredient(ModContent.ItemType<Materials.BloodDroplet>(), 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.AddTile(TileID.Dirt);
			recipe.AddTile(TileID.RubyBunnyCage);
			recipe.AddTile(TileID.Emerald);
			recipe.Register();
		}
	}
}