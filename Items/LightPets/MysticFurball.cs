using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.LightPets
{
	public class MysticFurball : ModItem
	{
		public override void SetDefaults() {
			Item.width = 46;
			Item.height = 38;
			Item.rare = RarityType<BraycoeDev>();
			Item.value = Item.sellPrice(0, 10);
			Item.UseSound = SoundID.Item2;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.noMelee = true;
			Item.shoot = ProjectileType<Projectiles.LightPets.SoulCompanion>();
			Item.buffType = BuffType<Buffs.LightPets.SoulCompanion>();
			Item.damage = 0;
			Item.useStyle = ItemUseStyleID.Swing;
		}
		public override void ModifyTooltips(List<TooltipLine> list) {
			TooltipLine xline = new TooltipLine(Mod, "Tooltip0", "Unleash the spirits of light and dark to achieve its fullest potential");
			xline.OverrideColor = new Color(255, 0, 0);
			if (!Main.hardMode) list.Add(xline);
			TooltipLine xline2 = new TooltipLine(Mod, "Tooltip1", "~Developer Item (Braycoe)~");
			xline2.OverrideColor = new Color(116, 179, 237);
			list.Add(xline2);
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			player.AddBuff(Item.buffType, 2);
			return false;
		}
	}
}