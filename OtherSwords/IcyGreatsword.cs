using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.OtherSwords
{
	public class IcyGreatsword : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("True melee hits inflict frostburn");
		}
		public override void SetDefaults() 
		{
			item.damage = 89;
			item.melee = true;
			item.width = 54;
			item.height = 54;
			item.useTime = 41;
			item.useAnimation = 41;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 5.3f;
			item.value = 120000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
			item.shoot = ProjectileID.IceBolt;
			item.shootSpeed = 11f;
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(2, 5), false);
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(2, 5), false);
		}
		public override void PostUpdate() {
			if (Main.rand.NextBool()) {
				Dust dust = Dust.NewDustDirect(item.position, item.width, item.height, 80);
				dust.noGravity = true;
				dust.scale = 1.5f;
			}
		}
		public override void AddRecipes()  {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddIngredient(ItemID.AdamantiteBar, 6);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlade);
			recipe.AddIngredient(ItemID.SoulofNight, 4);
			recipe.AddIngredient(ItemID.TitaniumBar, 6);
			recipe.AddIngredient(ItemID.FrostCore);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}