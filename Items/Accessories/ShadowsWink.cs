using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Zylon.Items.Accessories
{
	public class ShadowsWink : ModItem
	{
		public override void SetStaticDefaults() {
			Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.width = 26;
			Item.height = 30;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 4, 53);
			Item.rare = ItemRarityID.Pink;
		}
		int Timer;
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.shadowsWink = true;

			if (player.HasMinionAttackTargetNPC) if (Main.npc[player.MinionAttackTargetNPC].active) {
				if (player.whoAmI == Main.myPlayer && Main.GameUpdateCount % 30 == 0) Projectile.NewProjectile(player.GetSource_FromThis(), Main.npc[player.MinionAttackTargetNPC].Center - new Vector2(Main.rand.Next(-300, 301), Main.rand.Next(1000, 1100)), Vector2.Zero, ModContent.ProjectileType<Projectiles.Accessories.ShadowsWinkProj>(), 30, 3f, player.whoAmI, player.MinionAttackTargetNPC);
			}
		}
	}
}