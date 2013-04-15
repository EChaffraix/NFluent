﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="TimeSpanFluentAssertionExtensions.cs" company="">
// //   Copyright 2013 Cyrille DUPUYDAUBY
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    using System;

    using NFluent.Helpers;

    /// <summary>
    /// Provides assertion methods to be executed on an <see cref="TimeSpan"/> instance.
    /// </summary>
    public static class TimeSpanFluentAssertionExtensions
    {
        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion.</param>
        /// <param name="value">The value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
         public static IChainableFluentAssertion<IFluentAssertion<TimeSpan>> IsLessThan(
             this IFluentAssertion<TimeSpan> fluentAssertion, double value, TimeUnit unit)
         {
             TimeSpan comparand = TimeHelper.ToTimeSpan(value, unit);
             return new ChainableFluentAssertion<IFluentAssertion<TimeSpan>>(fluentAssertion);
         }
    }
}