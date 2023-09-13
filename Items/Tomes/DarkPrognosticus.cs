using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Tomes
{
	public class DarkPrognosticus : ModItem //BTW feel free to give cool effects if there's ever nothing to do, I can't do it justice
	{
		public override void SetDefaults() { //Reference: Super Paper Mario my beloved.
			Item.damage = 687;
			Item.DamageType = DamageClass.Magic;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 100;
			Item.useAnimation = 100;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 7.8f;
			Item.value = Item.sellPrice(8, 23, 56);
			Item.rare = ItemRarityID.Purple;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Tomes.DarkPrognosticusChaosHeart>();
			Item.shootSpeed = 10f;
			Item.noMelee = true;
			Item.mana = 90;
			Item.stack = 1;
			Item.UseSound = SoundID.Item8;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine line = new TooltipLine(Mod, "Tooltip#0", "'It's said that anyone who has possessed this book has never found happiness.");
			TooltipLine line2 = new TooltipLine(Mod, "Tooltip#1", "After holding this, you thought you heard the faint tick of a faraway clock.'");
			tooltips.Add(line);
			tooltips.Add(line2);
			foreach (TooltipLine tooltipLine in tooltips) { //Couldn't figure out how to change actual tooltip AAAAA
                if (tooltipLine.Mod == "Terraria" && (tooltipLine.Text == "It's said that anyone who has possessed this book has never found happiness." || tooltipLine.Text == "After holding this, you thought you heard the faint tick of a faraway clock." || tooltipLine.Name == "ItemName")) {
                    tooltipLine.OverrideColor = new Color(75, 75, 75);
                }
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			Projectile.NewProjectile(source, Main.MouseWorld, Vector2.Zero, type, damage, knockback, player.whoAmI);
			return false;
		}
	}
}