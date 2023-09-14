using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class Solmelt : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 84;
			Item.height = 74;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.5f;
			Item.value = Item.sellPrice(0, 1, 37);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.SolmeltFireblast>();
			Item.shootSpeed = 5f;
		}
        /*public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            base.OnHitNPC(player, target, hit, damageDone);
        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            base.OnHitPvp(player, target, hurtInfo);
        }*/
		int s;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            s++;
			return s % 2 == 0;
        }
        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.SearedStone>(), 30);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}