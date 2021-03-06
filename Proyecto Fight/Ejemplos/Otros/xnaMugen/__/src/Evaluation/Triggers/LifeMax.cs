using System;
using System.Collections.Generic;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("LifeMax")]
	class LifeMax : Function
	{
		public LifeMax(List<CallBack> children, List<Object> arguments)
			: base(children, arguments)
		{
		}

		public override Number Evaluate(Object state)
		{
			Combat.Character character = state as Combat.Character;
			if (character == null) return new Number();

			return new Number(character.BasePlayer.Constants.MaximumLife);
		}

		public static Node Parse(ParseState state)
		{
			return state.BaseNode;
		}
	}
}