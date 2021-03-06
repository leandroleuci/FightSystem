using System;
using System.Collections.Generic;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("SysVar")]
	class SysVar : Function
	{
		public SysVar(List<CallBack> children, List<Object> arguments)
			: base(children, arguments)
		{
		}
		public override Number Evaluate(Object state)
		{
			Combat.Character character = state as Combat.Character;
			if (character == null || Children.Count != 1) return new Number();

			Number r1 = Children[0](state);
			if (r1.NumberType == NumberType.None) return new Number();

			Int32 result;
			if (character.Variables.GetInteger(r1.IntValue, true, out result) == true)
			{
				return new Number(result);
			}
			else
			{
				return new Number();
			}
		}

		public static Node Parse(ParseState parsestate)
		{
			return parsestate.BuildParenNumberNode(true);
		}
	}
}
