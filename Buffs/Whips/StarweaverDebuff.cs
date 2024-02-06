﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Zylon.Buffs.Whips
{
	public class StarweaverDebuff : ModBuff
	{
		public static readonly int TagDamage = 13;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class StarweaverAdvancedDebuff : ModBuff
	{
		public static readonly int TagDamagePercent = 30;
		public static readonly float TagDamageMultiplier = TagDamagePercent / 100f;
		public override void SetStaticDefaults() {
			BuffID.Sets.IsATagBuff[Type] = true;
		}
	}
	public class StarweaverDebuffNPC : GlobalNPC
	{
		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers) {
			if (projectile.npcProj || projectile.trap || !projectile.IsMinionOrSentryRelated)
				return;

			var projTagMultiplier = ProjectileID.Sets.SummonTagDamageMultiplier[projectile.type];
			if (npc.HasBuff<StarweaverDebuff>()) {
				modifiers.FlatBonusDamage += StarweaverDebuff.TagDamage * projTagMultiplier;
			}

			if (npc.HasBuff<StarweaverAdvancedDebuff>()) {
				modifiers.ScalingBonusDamage += StarweaverAdvancedDebuff.TagDamageMultiplier * projTagMultiplier;
				npc.RequestBuffRemoval(ModContent.BuffType<StarweaverAdvancedDebuff>());
			}
		}
	}
}