using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class DiscoCanister : ModItem
	{
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 26;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 5);
			Item.rare = ItemRarityID.Lime;
			Item.damage = 60;
			//Item.DamageType = DamageClass.Summon;
			//Item.defense = 1;
		}
		/*public override void ModifyTooltips(List<TooltipLine> tooltips) {
            foreach (var line in tooltips) {
				if (line.Mod == "Terraria" && line.Name == "Defense") {
					line.Hide();
				}
			}
        }*/
		public override void UpdateAccessory(Player player, bool hideVisual) {
			//player.statDefense -= 1;
			player.GetCritChance(DamageClass.Generic) += 5;
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.discoCanister = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.DiscoCanisterProj>()] < 4)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Accessories.DiscoCanisterProj>(), Item.damage, 0.5f, Main.myPlayer, player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Accessories.DiscoCanisterProj>()]);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DiscoBall, 5);
			recipe.AddIngredient(ItemID.CrystalShard, 12);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}