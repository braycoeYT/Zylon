using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace Zylon.Items.Swords
{
    public class Excalipoor : ModItem
    {
		public override void SetDefaults() {
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.width = 52;
			Item.height = 52;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 0.1f;
			Item.value = Item.sellPrice(0, 0, 0, 1);
			Item.rare = ModContent.RarityType<ExcalipoorRarity>();
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Swords.ExcalipoorProj1>();
			Item.shootSpeed = 25f;
		}
        public override bool CanReforge() {
            return false;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (target.type != NPCID.TargetDummy && !target.SpawnedFromStatue) p.excalipoorPower += 1;
        }
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.excalipoorPower += 1;
        }
        public override void UpdateInventory(Player player) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			Item.damage = p.excalipoorPower;
			int i = 60;
			while (p.excalipoorPower > Math.Pow(2, (61-i)/4) && i > 0) {
				i--;
			}
			Item.useTime = i;
			Item.useAnimation = i;
			if (Item.useTime < 1) {
				Item.useTime = 1;
				Item.useAnimation = 1;
			}

			Item.knockBack = 0.1f + p.excalipoorPower*0.01f;
			if (Item.knockBack > 6f) Item.knockBack = 6f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			if (p.excalipoorPower > 49) {
				Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<Projectiles.Swords.ExcalipoorProj1>(), damage, knockback, Main.myPlayer, Item.useTime);
			}
			return false;
        }
	}
}