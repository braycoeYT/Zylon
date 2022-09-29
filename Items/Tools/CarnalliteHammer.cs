using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tools
{
	public class CarnalliteHammer : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Struck enemies are inflicted with a natural curse");
		}
		public override void SetDefaults() {
			Item.damage = 24;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 7.3f;
			Item.value = Item.sellPrice(0, 0, 60, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.hammer = 65;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
			target.AddBuff(BuffID.DryadsWardDebuff, Main.rand.Next(5, 11)*60);
		}
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(BuffID.DryadsWardDebuff, Main.rand.Next(5, 11)*60);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Bars.CarnalliteBar>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}