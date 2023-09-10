using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class CarnallitePickaxe : ModItem
	{
		public override void SetStaticDefaults() {
			// Tooltip.SetDefault("Struck enemies are inflicted with a natural curse");
		}
		public override void SetDefaults() {
			Item.damage = 14;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 14;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5.2f;
			Item.value = Item.sellPrice(0, 0, 64, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.pick = 90;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
			target.AddBuff(BuffID.DryadsWardDebuff, Main.rand.Next(5, 11)*60);
		}
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
			target.AddBuff(BuffID.DryadsWardDebuff, Main.rand.Next(5, 11)*60);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}