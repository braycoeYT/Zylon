using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;

namespace Zylon.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class LihzahrdPlatingHelmet : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(0, 2, 50);
			Item.rare = ItemRarityID.Yellow;
			Item.defense = 13;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<SlimePrinceBreastplate>() && legs.type == ModContent.ItemType<SlimePrinceLeggings>();
		}
        public override void UpdateEquip(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			player.GetDamage(DamageClass.Summon) += 0.05f;
			p.summonCritBoost += 0.05f;
			player.maxMinions += 1;
        }
        public override void UpdateArmorSet(Player player) {
			ZylonPlayer p = player.GetModPlayer<ZylonPlayer>();
			p.slimePrinceArmor = true;
			player.setBonus = "Summons a floating slime staff to volley slime at enemies";
			player.AddBuff(ModContent.BuffType<Buffs.Minions.RoyalSlime>(), 60);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Armor.RoyalSlime>()] < 1 && player.whoAmI == Main.myPlayer)
				Projectile.NewProjectile(new EntitySource_TileBreak((int)player.position.X, (int)player.position.Y), player.Center, new Microsoft.Xna.Framework.Vector2(0, 0), ModContent.ProjectileType<Projectiles.Armor.RoyalSlime>(), 20, 1f, Main.myPlayer);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LihzahrdBrick, 25);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}