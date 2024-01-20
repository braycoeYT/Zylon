using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class NeutronHood : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 7);
			Item.rare = ItemRarityID.Red;
			Item.defense = 13;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<NeutronJacket>() && legs.type == ModContent.ItemType<NeutronTracers>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.neutronHood = true;
			player.GetCritChance(DamageClass.Ranged) += 12;
			player.manaCost -= 0.11f;
			player.GetKnockback(DamageClass.Summon) += 0.35f;
        }
        public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases all damage by 15%\nIncreases max life by 20%\nDouble tap down to create a powerful black hole at your cursor that sucks up enemies\nThis ability has a cooldown of 20 seconds";
			player.GetDamage(DamageClass.Generic) += 0.15f;
			player.statLifeMax2 = (int)(player.statLifeMax2*1.2f);

			if (player.controlDown && player.releaseDown && player.doubleTapCardinalTimer[0] < 15 && !player.HasBuff(ModContent.BuffType<Buffs.Armor.BlackHoleCooldown>())) {
				if (Main.myPlayer == player.whoAmI) Projectile.NewProjectile(player.GetSource_FromThis(), Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<Projectiles.BlackHole>(), 75, 2f, Main.myPlayer);
				player.AddBuff(ModContent.BuffType<Buffs.Armor.BlackHoleCooldown>(), 1200);
				for (int i = 0; i < 36; i++) {
					Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, DustID.RedTorch);
					dust.noGravity = true;
					dust.velocity = new Vector2(0, 4).RotatedBy(MathHelper.ToRadians(i*10));
					dust.scale = 3f;
                }
				SoundEngine.PlaySound(SoundID.Item93, player.position);
            }
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Materials.NeutronFragment>(), 7);
			recipe.AddIngredient(ItemID.LunarBar, 8);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}