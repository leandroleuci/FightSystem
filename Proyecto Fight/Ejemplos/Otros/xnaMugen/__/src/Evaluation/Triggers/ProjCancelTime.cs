using System;
using System.Collections.Generic;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("ProjCancelTime")]
	class ProjCancelTime : Function
	{
		public ProjCancelTime(List<CallBack> children, List<Object> arguments)
			: base(children, arguments)
		{
		}

		public override Number Evaluate(Object state)
		{
			Combat.Character character = state as Combat.Character;
			if (character == null || Children.Count != 1) return new Number();

			Number projectile_id = Children[0](state);
			if (projectile_id.NumberType != NumberType.Int) return new Number();

			Combat.ProjectileInfo projinfo = character.OffensiveInfo.ProjectileInfo;
			if (projinfo.Type == ProjectileDataType.Cancel && (projectile_id.IntValue <= 0 || projectile_id.IntValue == projinfo.ProjectileId))
			{
				return new Number(projinfo.Time);
			}

			return new Number(-1);
		}

		public static Node Parse(ParseState parsestate)
		{
			return parsestate.BuildParenNumberNode(true);
		}
	}
}
