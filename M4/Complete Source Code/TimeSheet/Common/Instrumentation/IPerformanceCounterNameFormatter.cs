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

using System;
using System.Collections.Generic;
using System.Text;

namespace NarolaInfotech.Common.Instrumentation
{
    /// <summary>
    /// Provides a pluggable way to format the name given to a particular instance of a performance counter.
	/// Each instance of a performance counter in Enterprise Library is given a name of the format
	/// "Name prefix - counter name"
    /// </summary>
    public interface IPerformanceCounterNameFormatter
    {
        /// <summary>
        /// Creates the formatted instance name for a performance counter, providing the prefix for the
		/// instance.
        /// </summary>
        /// <param name="nameSuffix">Performance counter name, as defined during installation of the counter</param>
        /// <returns>Formatted instance name in form of "prefix - nameSuffix"</returns>
        string CreateName(string nameSuffix);
    }
}
