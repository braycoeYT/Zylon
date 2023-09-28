using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class ForgottenFlame : ModItem
	{
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 58;
			Item.maxStack = 999;
			Item.value = 0;
			Item.rare = 2;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
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
			recipe.AddIngredient(ItemID.Sandstone, 8);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddIngredient(ModContent.ItemType<Materials.AdeniteCrumbles>(), 5);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}