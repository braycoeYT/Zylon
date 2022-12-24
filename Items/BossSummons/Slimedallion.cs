using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class Slimedallion : ModItem
	{
		public override void SetStaticDefaults() {
			string extra = "";
			if (ModContent.GetInstance<ZylonConfig>().infBossSum) extra = "\nNot Consumable";
			Tooltip.SetDefault("Summons a different gigaslime depending on the biome\nCan only be used after the elemental goop has been unleashed"+extra);
		}
		public override void SetDefaults()  {
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 20;
			Item.value = 0;
			Item.rare = ItemRarityID.Lime;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = !ModContent.GetInstance<ZylonConfig>().infBossSum;
		}
        public override bool CanUseItem(Player player) {
            return NPC.downedPlantBoss;
        }
        public override bool? UseItem(Player player) {
			if (player.ZoneBeach) NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Ocean.LittoralGigaslime>());
			else if (player.ZoneDesert) NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Desert.DustbowlGigaslime>());
			else NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Forest.VerdureGigaslime>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Gel, 20);
			recipe.AddIngredient(ItemID.SoulofLight, 2);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}