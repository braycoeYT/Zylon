using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;

namespace Zylon.Items.Boomerangs
{
	public class FireandIce : ModItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine xline = new TooltipLine(Mod, "Tooltip#0", "Hold down to charge boomerang throw\nCamera movement can be changed in the config");
			if (ModContent.GetInstance<ZylonConfig>().experimentalBoomerangs) tooltips.Add(xline);
		}
		public override void SetDefaults() {
			Item.damage = 41;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 12;
			Item.useTime = 14;
			Item.shootSpeed = 15f;
			Item.knockBack = 6.3f;
			Item.width = 18;
			Item.height = 32;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 0, 80);
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			if (GetInstance<ZylonConfig>().experimentalBoomerangs) Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.FireandIce>();
			else Item.shoot = ProjectileType<Projectiles.Boomerangs.FireandIceOG>();
			Item.channel = true;
		}
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AshBlock, 50);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddIngredient(ItemID.HellstoneBar, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}