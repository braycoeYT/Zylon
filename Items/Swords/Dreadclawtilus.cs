using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Dreadclawtilus : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Steals life on enemy hits");
		}
		public override void SetDefaults() {
			Item.damage = 51;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 30;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1.2f;
			Item.value = Item.sellPrice(0, 3);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
		}
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (target.type != NPCID.TargetDummy) {
				player.statLife += 1;
				player.HealEffect(1, true);
			}
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			player.statLife += 1;
			player.HealEffect(1, true);
		}
	}
}