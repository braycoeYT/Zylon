using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class ConstructedCharm : ModItem
	{
		public override void SetDefaults() {
			Item.width = 36;
			Item.height = 36;
			Item.value = Item.sellPrice(0, 8, 35);
			Item.rare = ItemRarityID.LightPurple;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Summon) += 0.12f;
			p.summonCritBoost += 0.08f;
			p.shadeCharm = true;
			p.shadowsWink = true;
			if (player.HasMinionAttackTargetNPC) if (Main.npc[player.MinionAttackTargetNPC].active) {
				if (player.whoAmI == Main.myPlayer && Main.GameUpdateCount % 30 == 0) Projectile.NewProjectile(player.GetSource_FromThis(), Main.npc[player.MinionAttackTargetNPC].Center - new Vector2(Main.rand.Next(-300, 301), Main.rand.Next(1000, 1100)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Accessories.ShadowsWinkProj>(), 30, 3f, player.whoAmI, player.MinionAttackTargetNPC);
			}
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShadeCharm>());
			recipe.AddIngredient(ItemID.AvengerEmblem);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}