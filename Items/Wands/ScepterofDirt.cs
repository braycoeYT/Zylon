using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Wands
{
	public class ScepterofDirt : ModItem
	{
        public override void SetStaticDefaults() {
			Item.staff[Item.type] = true;
        }
        public override void SetDefaults() {
			Item.damage = 11;
			Item.DamageType = DamageClass.Magic;
			Item.width = 50;
			Item.height = 58;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3f;
			Item.value = Item.sellPrice(0, 0, 30);
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Wands.DirtBallScepter>();
			Item.shootSpeed = 8f;
			Item.mana = 5;
		}
    }
}