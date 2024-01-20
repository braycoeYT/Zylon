using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Items.BossSummons
{
	public class EnchantedEye : ModItem
	{
		public override void SetStaticDefaults() {
			//Tooltip.SetDefault("Summons the Ancient Diskite Director\nCan only be used in the desert\nNot consumable");
		}
		public override void SetDefaults()  {
			Item.width = 28;
			Item.height = 28;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}
        public override bool CanUseItem(Player player) {
            return player.ZoneDesert && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.Adeneb.Adeneb>());
        }
        public override bool? UseItem(Player player) {
			Vector2 rand = player.Center + new Vector2(0, 600); //600
			//Boss renders bottom to top
			if (Main.netMode == NetmodeID.SinglePlayer || Main.netMode == NetmodeID.Server)
            {
				NPC.NewNPC(Item.GetSource_FromThis(), (int)rand.X, (int)rand.Y, ModContent.NPCType<NPCs.Bosses.Adeneb.Adeneb>());
			}
			//NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<NPCs.Bosses.Adeneb.Adeneb_Setup>());
			SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddRecipeGroup("Zylon:AnyShadowScale", 3);
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 12);
			recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
		}
	}
}