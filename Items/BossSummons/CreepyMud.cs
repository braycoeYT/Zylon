using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class CreepyMud : ModItem
	{
		public override void SetStaticDefaults() {
			string extra = "";
			if (ModContent.GetInstance<ZylonConfig>().infBossSum) extra = "\nNot Consumable";
			Tooltip.SetDefault("'It melts in your hand...'\nSummons Dirtball"+extra);
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 0;
		}
		public override void SetDefaults() {
			Item.width = 38;
			Item.height = 68;
			Item.maxStack = 20;
			Item.value = 0;
			Item.rare = -1;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = !ModContent.GetInstance<ZylonConfig>().infBossSum;
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Dirtball.Dirtball>());
		}
        public override bool? UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Dirtball.Dirtball>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddIngredient(ItemID.MudBlock, 10);
			recipe.AddIngredient(ItemID.Gel, 5);
			recipe.AddIngredient(ItemID.Lens);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}