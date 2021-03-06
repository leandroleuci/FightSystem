using System;
using System.Collections.Generic;

namespace xnaMugen.Evaluation.Triggers
{
	[CustomFunction("AnimTime")]
	class AnimTime : Function
	{
		public AnimTime(List<CallBack> children, List<Object> arguments)
			: base(children, arguments)
		{
		}

		public override Number Evaluate(Object state)
		{
			Combat.Character character = state as Combat.Character;
			if (character == null) return new Number();

			Animations.Animation animation = character.AnimationManager.CurrentAnimation;
			Int32 animtime = character.AnimationManager.TimeInAnimation;

			if (animation.TotalTime == -1)
			{
				return new Number(animtime + 1);
			}
			else
			{
				return new Number(animtime - animation.TotalTime);
			}
		}

		public static Node Parse(ParseState parsestate)
		{
			return parsestate.BaseNode;
		}
	}
}
