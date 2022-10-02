using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class LimePhaseblade : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 26;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 0, 54);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item15;
			Item.autoReuse = false;
			Item.useTurn = true;
		}
        public override void UseStyle(Player player, Rectangle heldItemFrame) {
            Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.3f, 0.5f, 0f);
        }
        /*public override bool? UseItem(Player player) {
			Lighting.AddLight((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f), 0.3f, 0.5f, 0f);
            return true;
        }*/
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 15);
			recipe.AddIngredient(ModContent.ItemType<Materials.Jade>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}