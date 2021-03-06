﻿using System;
using System.Diagnostics;

namespace xnaMugen.Evaluation
{
	struct Number : IEquatable<Number>
	{
		[DebuggerStepThrough]
		public Number(Boolean value)
			: this(value ? 1 : 0)
		{
		}

		[DebuggerStepThrough]
		public Number(Int32 value)
		{
			m_type = NumberType.Int;
			m_int = value;
			m_float = value;
		}

		[DebuggerStepThrough]
		public Number(Single value)
		{
			m_type = NumberType.Float;
			m_int = (Int32)value;
			m_float = value;
		}

		[DebuggerStepThrough]
		public Number(Double value)
		{
			m_type = NumberType.Float;
			m_int = (Int32)value;
			m_float = (Single)value;
		}

		public Boolean Equals(Number other)
		{
			return (this == other).BooleanValue;
		}

		public override String ToString()
		{
			switch (NumberType)
			{
				case NumberType.Int:
					return IntValue.ToString();

				case NumberType.Float:
					return FloatValue.ToString();

				default:
					return "None";
			}
		}

		public override Int32 GetHashCode()
		{
			switch (NumberType)
			{
				case NumberType.Int:
					return IntValue.GetHashCode();

				case NumberType.Float:
					return FloatValue.GetHashCode();

				default:
					return 0;
			}
		}

		public override Boolean Equals(Object obj)
		{
			if (obj == null) return false;

			if (obj is Number) return ((Number)obj == this).BooleanValue;

			return false;
		}

		public static Number BinaryOperation(Operator @operator, Number lhs, Number rhs)
		{
			switch (@operator)
			{
				case Operator.Equals:
					return lhs == rhs;

				case Operator.NotEquals:
					return lhs != rhs;

				case Operator.Lesser:
					return lhs < rhs;

				case Operator.LesserEquals:
					return lhs <= rhs;

				case Operator.Greater:
					return lhs > rhs;

				case Operator.GreaterEquals:
					return lhs >= rhs;

				default:
					return new Number();
			}
		}

		public static Number Range(Number lhs, Number rhs1, Number rhs2, Operator compare_type, Symbol pre_check, Symbol post_check)
		{
			if (lhs.NumberType == NumberType.None || rhs1.NumberType == NumberType.None || rhs2.NumberType == NumberType.None) return new Number();
			if (compare_type != Operator.Equals && compare_type != Operator.NotEquals) return new Number();

			Number pre = new Number();
			Number post = new Number();

			switch (pre_check)
			{
				case Symbol.LeftBracket:
					pre = lhs >= rhs1;
					break;

				case Symbol.LeftParen:
					pre = lhs > rhs1;
					break;
				default:
					return new Number();
			}

			switch (post_check)
			{
				case Symbol.RightBracket:
					post = lhs <= rhs2;
					break;

				case Symbol.RightParen:
					post = lhs < rhs2;
					break;
				default:
					return new Number();
			}


			Boolean inrange = pre.BooleanValue && post.BooleanValue;
			return new Number(compare_type == Operator.Equals ? inrange : !inrange);
		}

		public static Number operator !(Number number)
		{
			if (number.NumberType == NumberType.None) return new Number();

			return new Number(!number.BooleanValue);
		}

		public static Number operator ==(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue == rhs.FloatValue);

			return new Number(lhs.IntValue == rhs.IntValue);
		}

		public static Number operator !=(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue != rhs.FloatValue);

			return new Number(lhs.IntValue != rhs.IntValue);
		}

		public static Number operator +(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue + rhs.FloatValue);

			return new Number(lhs.IntValue + rhs.IntValue);
		}

		public static Number operator -(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue - rhs.FloatValue);

			return new Number(lhs.IntValue - rhs.IntValue);
		}

		public static Number operator *(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue * rhs.FloatValue);

			return new Number(lhs.IntValue * rhs.IntValue);
		}

		public static Number operator /(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float)
			{
				if (rhs.FloatValue == 0.0f) return new Number();
				return new Number(lhs.FloatValue / rhs.FloatValue);
			}

			if (rhs.IntValue == 0) return new Number();
			return new Number(lhs.IntValue / rhs.IntValue);
		}

		public static Number operator >(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue > rhs.FloatValue);

			return new Number(lhs.IntValue > rhs.IntValue);
		}

		public static Number operator <(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue < rhs.FloatValue);

			return new Number(lhs.IntValue < rhs.IntValue);
		}

		public static Number operator <=(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue <= rhs.FloatValue);

			return new Number(lhs.IntValue <= rhs.IntValue);
		}

		public static Number operator >=(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float) return new Number(lhs.FloatValue >= rhs.FloatValue);

			return new Number(lhs.IntValue >= rhs.IntValue);
		}

		public static Number operator %(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

            if (lhs.NumberType == NumberType.Float || rhs.NumberType == NumberType.Float)
            {
                if (rhs.FloatValue == 0.0f) return new Number();
                return new Number(lhs.FloatValue % rhs.FloatValue);
            }

            if (rhs.IntValue == 0) return new Number();
            return new Number(lhs.IntValue % rhs.IntValue);
		}

		public static Number Power(Number lhs, Number rhs)
		{
			if (lhs.NumberType == NumberType.None || rhs.NumberType == NumberType.None) return new Number();

			if (lhs.NumberType == NumberType.Int && rhs.NumberType == NumberType.Int) return new Number((Int32)Math.Pow(lhs.IntValue, rhs.IntValue));

			return new Number((Single)Math.Pow(lhs.FloatValue, rhs.FloatValue));
		}

		public NumberType NumberType
		{
			get { return m_type; }
		}

		public Int32 IntValue
		{
			get { return m_int; }
		}

		public Single FloatValue
		{
			get { return m_float; }
		}

		public Boolean BooleanValue
		{
			get
			{
				switch (NumberType)
				{
					case NumberType.Int:
						return IntValue != 0;

					case NumberType.Float:
						return FloatValue != 0;

					default:
						return false;
				}
			}
		}

		#region Fields

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		readonly NumberType m_type;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		readonly Int32 m_int;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		readonly Single m_float;

		#endregion
	}
}