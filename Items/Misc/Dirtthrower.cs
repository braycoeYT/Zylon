using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Misc
{
	public class Dirtthrower : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Talk about terraforming!'\nUses dirt blocks as ammo");
		}
		public override void SetDefaults() {
			Item.value = Item.sellPrice(0, 1);
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.damage = 12;
			Item.width = 52;
			Item.height = 18;
			Item.knockBack = 7f;
			Item.shoot = ModContent.ProjectileType<Projectiles.Misc.DirtPlaceBlocks>();
			Item.shootSpeed = 15f;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Generic;
			Item.useAmmo = Item.type;
			Item.UseSound = SoundID.Item98;
			Item.autoReuse = true;
			Item.rare = ItemRarityID.Blue;
		}
        public override Vector2? HoldoutOffset() {
			return new Vector2(-4, 0);
		}
	}
}