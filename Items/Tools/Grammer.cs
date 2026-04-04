using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class Grammer : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 74;
			Item.DamageType = DamageClass.Melee;
			Item.width = 62;
			Item.height = 62;
			Item.useTime = 15;
			Item.useAnimation = 43;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 9.25f;
			Item.value = Item.sellPrice(0, 4, 40);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.hammer = 88;
			Item.tileBoost = 1;
			Item.crit = 6;
			Item.scale = 1.3f;
		}
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			if (player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(player.GetSource_FromThis(), target.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Tools.GrammerStagger>(), hit.Damage/4, hit.Knockback/2f, player.whoAmI, target.whoAmI, hit.Crit.ToInt(), hit.HitDirection);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.DarkronBar>(), 18);
			recipe.AddIngredient(ModContent.ItemType<Materials.SoulofByte>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}