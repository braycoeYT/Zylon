using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class StarstruckMeteorChunk : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults()  {
			Item.width = 28;
			Item.height = 40;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Green;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}
        public override bool CanUseItem(Player player) {
            return player.ZoneMeteor && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Metelord.MetelordHead>());
        }
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer)
			{
				SoundEngine.PlaySound(SoundID.Roar, player.position);
				int type = ModContent.NPCType<NPCs.Bosses.Metelord.MetelordHead>();

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
			recipe.AddIngredient(ItemID.Meteorite, 11);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 4);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}