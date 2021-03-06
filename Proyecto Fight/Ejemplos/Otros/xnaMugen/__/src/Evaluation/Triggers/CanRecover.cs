using System;
using System.Collections.Generic;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("CanRecover")]
	class CanRecover : Function
	{
		public CanRecover(List<CallBack> children, List<Object> arguments)
			: base(children, arguments)
		{
		}

		public override Number Evaluate(Object state)
		{
			Combat.Character character = state as Combat.Character;
			if (character == null) return new Number();

			if (character.DefensiveInfo.IsFalling == false) return new Number(false);

			return new Number(character.DefensiveInfo.HitDef.FallCanRecover);
		}

		public static Node Parse(ParseState parsestate)
		{
			return parsestate.BaseNode;
		}
	}
}
