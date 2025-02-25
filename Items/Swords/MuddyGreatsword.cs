using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class MuddyGreatsword : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 48;
			Item.useAnimation = 24;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.8f;
			Item.value = Item.sellPrice(0, 0, 50, 0);
			Item.rare = ItemRarityID.Gray;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.MuddyGreatswordProj>();
			Item.shootSpeed = 9f;
		}
	}
}