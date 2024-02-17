using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.MagicGuns
{
	public class TacticalMegaphone : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("'Unethically tactical, for your pleasure.'\nProjectile slowly gains size for every struck enemy");
		}
		public override void SetDefaults() {
			Item.damage = 41;
			Item.DamageType = DamageClass.Magic;
			Item.width = 30;
			Item.height = 36;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 3.4f;
			Item.value = Item.sellPrice(0, 3, 21, 0);
			Item.rare = ItemRarityID.Pink;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.MagicGuns.Megawave>();
			Item.shootSpeed = 15f;
			Item.noMelee = true;
			Item.mana = 9;
			Item.UseSound = SoundID.Item47;
			//Item.UseSound = new SoundStyle("Zylon/Sounds/MegaphoneNoise.ogg");
		}
		public override Vector2? HoldoutOffset() {
			return new Vector2(8, -4);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Megaphone);
			recipe.AddIngredient(ItemID.SoulofNight, 6);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}