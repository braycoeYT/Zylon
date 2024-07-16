using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class TribalCharm : ModItem
	{
		public override void SetDefaults() {
			Item.width = 38;
			Item.height = 38;
			Item.value = Item.sellPrice(0, 10);
			Item.rare = ItemRarityID.Lime;
			Item.accessory = true;
		}
        public override void UpdateAccessory(Player player, bool hideVisual) {
            ZylonPlayer p = Main.LocalPlayer.GetModPlayer<ZylonPlayer>();
			if (!p.CHECK_PygmyNecklace) player.maxMinions += 1;
			p.CHECK_PygmyNecklace = true;
			player.GetDamage(DamageClass.Summon) += 0.12f;
			p.summonCritBoost += 0.08f;
			p.tribalCharm = true;
			if (player.HasMinionAttackTargetNPC) if (Main.npc[player.MinionAttackTargetNPC].active) {
				if (player.whoAmI == Main.myPlayer && Main.GameUpdateCount % 25 == 0) Projectile.NewProjectile(player.GetSource_FromThis(), Main.npc[player.MinionAttackTargetNPC].Center - new Vector2(Main.rand.Next(-300, 301), Main.rand.Next(1000, 1100)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Accessories.TribalCharmProjFall>(), 50, 3f, player.whoAmI, player.MinionAttackTargetNPC);
			}
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ConstructedCharm>());
			recipe.AddIngredient(ItemID.PygmyNecklace);
			recipe.AddIngredient(ModContent.ItemType<Materials.ElementalGoop>(), 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
	}
}