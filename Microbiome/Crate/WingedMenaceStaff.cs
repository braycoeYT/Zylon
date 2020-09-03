using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Microbiome.Crate
{
	public class WingedMenaceStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Winged Menace Staff");
			Tooltip.SetDefault("Summons a winged menace to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 12;
			item.knockBack = 1.8f;
			item.mana = 10;
			item.width = 44;
			item.height = 44;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 75000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item44;

			item.noMelee = true;
			item.summon = true;
			item.buffType = BuffType<Buffs.Minions.WingedMenace>();
			item.shoot = ProjectileType<Projectiles.Minions.WingedMenace>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}