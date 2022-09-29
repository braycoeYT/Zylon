using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Diskalibur : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'For valor!'\nCritical strikes have extremely high knockback");
		}
		public override void SetDefaults() {
			Item.damage = 21;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 64;
			Item.useTime = 47;
			Item.useAnimation = 47;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.1f;
			Item.value = Item.sellPrice(0, 0, 25);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = true;
			Item.crit = 12;
		}
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			if (!target.noKnockback && crit) {
				Vector2 vector1;
				vector1 = target.Center - player.Center - new Vector2(0, 150);
				vector1.Normalize();
				target.velocity = vector1*16f;
			}
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (target.knockBackResist > 0f && target.boss == false && crit) {
				Vector2 vector1;
				vector1 = target.Center - player.Center;
				vector1.Normalize();
				target.velocity = vector1*16f;
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.DiskiteCrumbles>(), 9);
			recipe.AddIngredient(ModContent.ItemType<Materials.RustedTech>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}