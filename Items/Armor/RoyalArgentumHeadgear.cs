using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RoyalArgentumHeadgear : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 15);
			Item.rare = ModContent.RarityType<Magenta>();
			Item.defense = 27;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<RoyalArgentumChestpiece>() && legs.type == ModContent.ItemType<RoyalArgentumBoots>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Ranged) += 0.21f;
			player.GetCritChance(DamageClass.Ranged) += 21;
			p.blowpipeChargeInc = 1/3f;
			p.argentumHeadgear = true;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.setBonus = "25% chance not to consume ammo\nSummons four Argentum Orbs to defend you\nArgentum Orbs fire short beams at nearby enemies";
			p.argentumSetBonus = true;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Armor.ArgentumOrb>()] < 4 && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.Armor.ArgentumOrb>(), 200, 4f, Main.myPlayer, player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Armor.ArgentumOrb>()]);
			}
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SilverHelmet);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TungstenHelmet);
			recipe.AddIngredient(ModContent.ItemType<Materials.FantasticalFinality>(), 4);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}