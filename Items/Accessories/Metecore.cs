using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Accessories
{
	public class Metecore : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Spawns a mini inferno ring around your cursor to roast enemies\nIncreases your life regen and defense when on fire");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 20;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.White;
			Item.expert = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.metelordExpert = true;
			//player.AddBuff(ModContent.BuffType<Buffs.ADDSpikeRing>(), 60);
			//if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Bosses.Metelord.MiniCursorInfernoRing>()] < 1 && player.whoAmI == Main.myPlayer)
			//	Projectile.NewProjectile(player.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Bosses.Metelord.MiniCursorInfernoRing>(), 0, 0f, Main.myPlayer);
		}
	}
}