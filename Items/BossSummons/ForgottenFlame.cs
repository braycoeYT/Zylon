using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

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
        public override bool CanUseItem(Player player) {
            return !Terraria.GameContent.Events.Sandstorm.Happening;
        }
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				SoundEngine.PlaySound(SoundID.Item29, player.position);
				Terraria.GameContent.Events.Sandstorm.StartSandstorm();
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