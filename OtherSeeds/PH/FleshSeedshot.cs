using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.OtherSeeds.PH
{
	public class FleshSeedshot : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use with blowpipes\nEach seedshot shoots a flesh clump in the oppisite after breaking");
        }
		public override void SetDefaults() {
			item.damage = 10; //3
			item.ranged = true;
			item.width = 12;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f; //0
			item.value = 15; //0
			item.rare = ItemRarityID.Orange;
			item.shoot = ProjectileType<Projectiles.OtherSeeds.PH.FleshSeedshot>();
			item.shootSpeed = 0f; //0
			item.ammo = AmmoID.Dart;
		}
	}
}