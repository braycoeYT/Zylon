using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class EyeofCthulhu : ModItem
	{
		public override void SetStaticDefaults() {
			string extra = "";
			if (ModContent.GetInstance<ZylonConfig>().infBossSum) extra = "\nNot Consumable";
			DisplayName.SetDefault("Eye of Cthulhu");
			Tooltip.SetDefault("'A suspicious looking eye summons the eye of cthulhu, but what does the eye of cthulhu summon?'"+extra);
		}
		public override void SetDefaults()  {
			Item.width = 152;
			Item.height = 110;
			Item.maxStack = 20;
			Item.value = 42069;
			Item.rare = ItemRarityID.Gray;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = !ModContent.GetInstance<ZylonConfig>().infBossSum;
		}
        public override bool CanUseItem(Player player) {
            return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.SuspiciousLookingEye>());
        }
        public override bool? UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.SuspiciousLookingEye>());
			SoundEngine.PlaySound(SoundID.Item16, player.position);
            return true;
        }
	}
}