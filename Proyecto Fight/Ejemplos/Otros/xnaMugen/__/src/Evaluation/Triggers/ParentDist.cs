using System;
using System.Collections.Generic;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("ParentDist")]
	class ParentDist : Function
	{
		public ParentDist(List<CallBack> children, List<Object> arguments)
			: base(children, arguments)
		{
		}

		public override Number Evaluate(Object state)
		{
			Combat.Character character = state as Combat.Character;
			if (character == null || Arguments.Count != 1) return new Number();

			Combat.Helper helper = character as Combat.Helper;
			if (helper == null) return new Number();

			Axis axis = (Axis)Arguments[0];

			switch (axis)
			{
				case Axis.X:
					Single distance = Math.Abs(helper.CurrentLocation.X - helper.Parent.CurrentLocation.X);
					if (helper.CurrentFacing == xnaMugen.Facing.Right)
					{
						return (helper.Parent.CurrentLocation.X >= helper.CurrentLocation.X) ? new Number(distance) : new Number(-distance);
					}
					else
					{
						return (helper.Parent.CurrentLocation.X >= helper.CurrentLocation.X) ? new Number(-distance) : new Number(distance);
					}

				case Axis.Y:
					return new Number(helper.Parent.CurrentLocation.Y - helper.CurrentLocation.Y);

				default:
					return new Number();
			}
		}

		public static Node Parse(ParseState parsestate)
		{
			Axis axis = parsestate.ConvertCurrentToken<Axis>();
			if (axis == Axis.None) return null;

			++parsestate.TokenIndex;

			parsestate.BaseNode.Arguments.Add(axis);
			return parsestate.BaseNode;
		}
	}
}
