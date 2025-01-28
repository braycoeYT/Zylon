using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Items.BossSummons
{
	public class ForgottenFlame : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults() {
			Item.width = 48;
			Item.height = 72;
			Item.maxStack = 1;
			Item.value = 0;
			Item.rare = ItemRarityID.Green;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = false;
		}
		/*public override Vector2? HoldoutOffset() {
			return new Vector2(-24, -12);
		}*/
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				if (Terraria.GameContent.Events.Sandstorm.Happening) {
					SoundEngine.PlaySound(SoundID.Item29.WithPitchOffset(-1f), player.position);
					Terraria.GameContent.Events.Sandstorm.StopSandstorm();
					Main.NewText(Language.GetTextValue("Mods.Zylon.Items.ForgottenFlame.StopMessage"), 209, 185, 23);
				}
				else {
					SoundEngine.PlaySound(SoundID.Item29, player.position);
					Terraria.GameContent.Events.Sandstorm.StartSandstorm();
					Main.NewText(Language.GetTextValue("Mods.Zylon.Items.ForgottenFlame.StartMessage"), 209, 185, 23);
				}
			}
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Sandstone, 20);
			recipe.AddIngredient(ItemID.AntlionMandible, 6);
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}