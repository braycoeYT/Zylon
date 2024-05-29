using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class TaleoftheEverlastingBlade : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 187;
			Item.DamageType = DamageClass.Magic;
			Item.width = 38;
			Item.height = 42;
			Item.useTime = 41;
			Item.useAnimation = 41;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8.2f;
			Item.value = Item.sellPrice(0, 15);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.EverlastingBladeProj>();
			Item.shootSpeed = 18f;
			Item.noMelee = true;
			Item.mana = 23;
			Item.UseSound = SoundID.Item43;
		}
	}
}