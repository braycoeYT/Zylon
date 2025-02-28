using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class Metecore : ModItem
	{
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 46;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Green;
			Item.damage = 40;
			Item.knockBack = 3f;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.metelordExpert = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.MetecoreMain>()] < 1 && p.metecoreFloat == 1f && player.active)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Accessories.MetecoreMain>(), Item.damage, Item.knockBack, Main.myPlayer);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.HaxoniteBar>(), 15);
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}