using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Boomerangs
{
	public class Barfarang : ModItem
	{
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine xline = new TooltipLine(Mod, "Tooltip#0", "Hold down to charge boomerang throw\nCamera movement can be changed in the config");
			if (ModContent.GetInstance<ZylonConfig>().experimentalBoomerangs) tooltips.Add(xline);
		}
        public override void SetDefaults() {
			Item.damage = 25;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4.5f;
			Item.value = Item.sellPrice(0, 0, 48, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.useTurn = true;
			if (ModContent.GetInstance<ZylonConfig>().experimentalBoomerangs) Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.Barfarang>();
			else Item.shoot = ModContent.ProjectileType<Projectiles.Boomerangs.BarfarangOG>();
			Item.shootSpeed = 13f;
			Item.noUseGraphic = true;
			Item.channel = true;
		}
		public override bool CanUseItem(Player player) {
            for (int i = 0; i < 1000; ++i) {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == Item.shoot) {
                    return false;
                }
            }
            return true;
        }
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}