﻿//-----------------------------------------------------
//            Arbor 3: FSM & BT Graph Editor
//		  Copyright(c) 2014-2021 caitsithware
//-----------------------------------------------------
using UnityEngine;

namespace Arbor
{
	using Arbor.Extensions;

	public sealed partial class Parameter
	{
#if ARBOR_DOC_JA
		/// <summary>
		/// BoundsInt型の値。
		/// </summary>
#else
		/// <summary>
		/// Value of BoundsInt type.
		/// </summary>
#endif
		public BoundsInt boundsIntValue
		{
			get
			{
				BoundsInt value;
				if (TryGetBoundsInt(out value))
				{
					return value;
				}

				throw new ParameterTypeMismatchException();
			}
			set
			{
				if (!SetBoundsInt(value))
				{
					throw new ParameterTypeMismatchException();
				}
			}
		}

		#region BoundsInt

#if ARBOR_DOC_JA
		/// <summary>
		/// BoundsInt型の値を設定する。
		/// </summary>
		/// <param name="value">値。</param>
		/// <returns>値を設定できた場合にtrueを返す。</returns>
#else
		/// <summary>
		/// It wants to set the value of the BoundsInt type.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Return true if the value could be set.</returns>
#endif
		public bool SetBoundsInt(BoundsInt value)
		{
			if (type == Type.BoundsInt)
			{
				if (!BoundsIntExtensions.Equals(container._BoundsIntParameters[_ParameterIndex], value))
				{
					container._BoundsIntParameters[_ParameterIndex] = value;
					DoChanged();
				}
				return true;
			}

			return false;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// BoundsInt型の値を取得する。
		/// </summary>
		/// <param name="value">取得する値。</param>
		///  <returns>値を取得できた場合にtrueを返す。</returns>
#else
		/// <summary>
		/// Get the value of the BoundsInt type.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>Return true if the value can be obtained.</returns>
#endif
		public bool TryGetBoundsInt(out BoundsInt value)
		{
			if (type == Type.BoundsInt)
			{
				value = container._BoundsIntParameters[_ParameterIndex];

				return true;
			}

			value = BoundsIntExtensions.zero;
			return false;
		}


#if ARBOR_DOC_JA
		/// <summary>
		/// BoundsInt型の値を取得する。
		/// </summary>
		/// <param name="defaultValue">デフォルトの値。パラメータがない場合に返される。</param>
		/// <returns>パラメータの値。パラメータがない場合はdefaultValueを返す。</returns>
#else
		/// <summary>
		/// Get the value of the BoundsInt type.
		/// </summary>
		/// <param name="defaultValue">Default value. It is returned when there is no parameter.</param>
		/// <returns>The value of the parameter. If there is no parameter, it returns defaultValue.</returns>
#endif
		public BoundsInt GetBoundsInt(BoundsInt defaultValue)
		{
			BoundsInt value;
			if (TryGetBoundsInt(out value))
			{
				return value;
			}
			return defaultValue;
		}

#if ARBOR_DOC_JA
		/// <summary>
		/// BoundsInt型の値を取得する。
		/// </summary>
		/// <returns>パラメータの値。パラメータがない場合はBoundsInt(0, 0, 0, 0)を返す。</returns>
#else
		/// <summary>
		/// Get the value of the BoundsInt type.
		/// </summary>
		/// <returns>The value of the parameter. If there is no parameter, it returns BoundsInt(0, 0, 0, 0).</returns>
#endif
		public BoundsInt GetBoundsInt()
		{
			return GetBoundsInt(BoundsIntExtensions.zero);
		}

#endregion //BoundsInt
	}
}