using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Zylon.Items.Contagional
{
	public abstract class ContagionalItem : ModItem
	{
		public override bool CloneNewInstances => true;
		public int ContagionalResourceCost = 0;
		internal int ContagionalCanRegenTestTimer = 0;
		public virtual void SafeSetDefaults()
		{
		}
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.summon = false;
			item.thrown = false;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			add += ContagionalPlayer.ModPlayer(player).ContagionalDamageAdd;
			mult *= ContagionalPlayer.ModPlayer(player).ContagionalDamageMult;
		}

		public override void GetWeaponKnockback(Player player, ref float knockback)
		{
			knockback += ContagionalPlayer.ModPlayer(player).ContagionalKnockback;
		}

		public override void GetWeaponCrit(Player player, ref int crit)
		{
			crit += ContagionalPlayer.ModPlayer(player).ContagionalCrit;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
			if (tt != null) {
				string[] splitText = tt.text.Split(' ');
				string damageValue = splitText.First();
				string damageWord = splitText.Last();
				tt.text = damageValue + " Contagional " + damageWord;
			}

			if(ContagionalResourceCost > 0)
			{
				tooltips.Add(new TooltipLine(mod, "Contagional Drain", $"Uses {ContagionalResourceCost} Contagion Points"));
			}
		}

		public override bool CanUseItem(Player player)
		{
			var ContagionalPlayer = player.GetModPlayer<ContagionalPlayer>();

			if (ContagionalPlayer.ContagionalResourceCurrent >= ContagionalResourceCost)
			{
				if (ContagionalPlayer.ContagionalResourceCurrent <= 100)
				{
				    Main.PlaySound(SoundID.MaxMana, player.position, 0);
					ContagionalPlayer.ContagionalResourceCurrent -= ContagionalResourceCost;
				    return true;
				}
				ContagionalPlayer.ContagionalResourceCurrent -= ContagionalResourceCost;
				return true;
			}
			Main.PlaySound(SoundID.MaxMana, player.position, 0);
			return false;
		}
	}
}