//===============================================================================
// NarolaInfotech Common Support Library
// Core
//===============================================================================
// Copyright � NarolaInfotech.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System.Diagnostics;

namespace NarolaInfotech.Common.Instrumentation
{
	/// <summary>
	/// Constructs an instance name for a <see cref="PerformanceCounter"></see> following embedded
	/// formatting rules.
	/// </summary>
	public class PerformanceCounterInstanceName
	{
		const int MaxPrefixLength = 32;
		const int MaxSuffixLength = 32;
		
		string prefix;
		string suffix;
		int maxPrefixLength;
		int maxSuffixLength;

		/// <overloads>
		/// Initializes this object with information needed to construct a <see cref="PerformanceCounter"></see>\
		/// instance name.
		/// </overloads>
		/// <summary>
		/// Initializes this object with information needed to construct a <see cref="PerformanceCounter"></see>\
		/// instance name.
		/// </summary>
		/// <param name="prefix">Counter name prefix.</param>
		/// <param name="suffix">Counter name suffix.</param>
		public PerformanceCounterInstanceName(string prefix, string suffix)
			: this(prefix, suffix, MaxPrefixLength, MaxSuffixLength)
		{
		}

		internal PerformanceCounterInstanceName(string prefix, string suffix, int maxPrefixLength, int maxSuffixLength)
		{
			this.maxPrefixLength = maxPrefixLength;
			this.maxSuffixLength = maxSuffixLength;
			
			this.prefix = NormalizeStringLength(prefix, maxPrefixLength);
			this.suffix = NormalizeStringLength(suffix, maxSuffixLength);
		}

		/// <summary>
		/// Returns properly formatted counter name as a string.
		/// </summary>
		/// <returns>Formatted counter name.</returns>
		public override string ToString()
		{
			string namePrefix = "";
			if (prefix.Length > 0) namePrefix += (prefix + " - ");
			return namePrefix + suffix;
		}

		private string NormalizeStringLength(string namePart, int namePartMaxLength)
		{
			return (namePart.Length > namePartMaxLength) ? namePart.Substring(0, namePartMaxLength) : namePart;
		}
	}
}