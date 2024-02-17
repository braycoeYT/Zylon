using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class LimePhasesaber : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 48;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.LightRed;
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
			recipe.AddIngredient(ModContent.ItemType<LimePhaseblade>());
			recipe.AddIngredient(ItemID.CrystalShard, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}