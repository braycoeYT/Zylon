using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class EnchantedDirtClump : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Summons a small army of dirt blocks to protect you\nDirt blocks are affected by the Dirt Regalia");
		}
		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 28;
			Item.accessory = true;
			Item.value = Item.sellPrice(0, 2);
			Item.rare = ItemRarityID.Gray;
			Item.expert = true;
			Item.damage = 1;
			Item.DamageType = DamageClass.Summon;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.dirtballExpert = true;
			player.AddBuff(ModContent.BuffType<Buffs.Minions.DirtBlock>(), 60);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()] < 5 && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>(), Item.damage, 0.5f, Main.myPlayer);
		}
	}
}