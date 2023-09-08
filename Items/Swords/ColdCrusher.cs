using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Items.Swords
{
	public class ColdCrusher : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Inflicts 'Brain Freeze' on non-boss enemies, slowing them down");
		}
		public override void SetDefaults() {
			Item.damage = 29;
			Item.DamageType = DamageClass.Melee;
			Item.width = 100;
			Item.height = 100;
			Item.useTime = 51;
			Item.useAnimation = 51;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6.4f;
			Item.value = Item.sellPrice(0, 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.useTurn = false;
		}
        public override void OnHitPvp(Player player, Player target, int damage, bool crit) {
			target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), Main.rand.Next(5, 11) * 60, false);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (!target.boss && target.type != NPCID.EaterofWorldsHead) target.AddBuff(ModContent.BuffType<Buffs.Debuffs.BrainFreeze>(), Main.rand.Next(5, 11) * 60, false);
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.BorealWoodSword);
			recipe.AddRecipeGroup("Wood", 14);
			recipe.AddIngredient(ItemID.IceBlock, 40);
			recipe.AddIngredient(ModContent.ItemType<Food.CocoaBeans>(), 10);
			recipe.AddRecipeGroup("Zylon:AnyDemoniteBar", 5);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();
		}
	}
}