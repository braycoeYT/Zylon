﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class EyeLashDebuff : ModBuff
	{
		public static readonly int TagDamage = 5;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class EyeLashAdvancedDebuff : ModBuff
	{
		public static readonly int TagDamagePercent = 30;
		public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class EyeLashDebuffNPC : GlobalNPC
	{
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers) {
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
				return;

			var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<EyeLashDebuff>()) {
				modifiers.FlatBonusDamage += EyeLashDebuff.TagDamage * projTagMultiplier;
			}

			if (npc.HasBuff<EyeLashAdvancedDebuff>()) {
				modifiers.ScalingBonusDamage += EyeLashAdvancedDebuff.TagDamageMultiplier * projTagMultiplier;
				npc.RequestBuffRemoval(ModContent.BuffType<EyeLashAdvancedDebuff>());
			}
		}
	}
}