using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Zylon.Items.Accessories
{
	public class EnchantedDirtClump : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Not sure how it stays together, but it does!'\nSummons a small army of dirt blocks to protect you");
		}
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 38;
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
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>()] < 5)
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Minions.DirtBlockExp>(), Item.damage, 0.5f, Main.myPlayer);
		}
	}
}