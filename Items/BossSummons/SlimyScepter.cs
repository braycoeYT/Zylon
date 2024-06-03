using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.BossSummons
{
	public class SlimyScepter : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 3;
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 32;
			Item.maxStack = 999;
			Item.value = 0;
			Item.rare = 1;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.consumable = true;
		}
        public override bool CanUseItem(Player player) {
            return !Main.slimeRain;
        }
        public override bool? UseItem(Player player) {
			if (player.whoAmI == Main.myPlayer) {
				SoundEngine.PlaySound(SoundID.Item44, player.position);
				Main.StartSlimeRain(); //Thank god there's a function to do this
			}
			return true;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ItemID.Gel, 15);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}