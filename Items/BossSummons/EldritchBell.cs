using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class EldritchBell : ModItem
	{
<<<<<<< HEAD
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'It calls for the ocean...'\nSummons the Eldritch Jellyfish\nEnrages outside of the ocean\nNot Consumable");
			ItemID.Sets.SortingPriorityBossSpawns[Item.type] = 3;
		}
=======
>>>>>>> ProjectClash
		public override void SetDefaults() {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 20;
			Item.value = 0;
			Item.rare = ItemRarityID.Orange;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
			Item.UseSound = SoundID.Item35.WithPitchOffset(4f);
		}
		public override bool CanUseItem(Player player) {
			return !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Jelly.EldritchJellyfish>()) && player.ZoneBeach;
		}
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer)
			{
				SoundEngine.PlaySound(SoundID.Roar, player.position);
				int type = ModContent.NPCType<NPCs.Bosses.Jelly.EldritchJellyfish>();

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
			recipe.AddIngredient(ModContent.ItemType<Materials.MetallicBell>());
			recipe.AddIngredient(ModContent.ItemType<Materials.EerieBell>(), 8);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}