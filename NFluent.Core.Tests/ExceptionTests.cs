﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ExceptionTests.cs" company="">
// //   Copyright 2013 Rui CARVALHO, Thomas PIERRAIN
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

using NFluent.ApiChecks;

namespace NFluent.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void NoExceptionRaised()
        {
            Check.ThatCode(() => new object()).DoesNotThrow();
        }

        [Test]
        public void UnexpectedExceptionRaised()
        {
            Check.ThatCode(() =>
            {
                Check.ThatCode(() => { throw new Exception(); }).DoesNotThrow();
            })
            .Throws<FluentCheckException>()
            .AndWhichMessage().StartsWith(Environment.NewLine+ "The checked code raised an exception, whereas it must not."); // TODO: reproduce startWith
        }

        [Test]
        public void ExpectedExceptionRaised()
        {
            Check.ThatCode(() => { throw new InvalidOperationException(); }).Throws<InvalidOperationException>();
            Check.ThatCode(() => { throw new Exception(); }).ThrowsAny();
        }

        [Test]
        public void DidNotRaiseExpected()
        {
            Check.ThatCode(() =>
            {
                Check.ThatCode(() => { throw new Exception(); }).Throws<InvalidOperationException>();
            })
            .Throws<FluentCheckException>()
            .AndWhichMessage().Contains(Environment.NewLine+ "The checked code raised an exception of a different type than expected."); // TODO: reproduce Contains
        }

        [Test]
        public void DidNotRaiseAny()
        {
            Check.ThatCode(() =>
            {
                Check.ThatCode(() => { new object(); }).ThrowsAny();
            })
            .Throws<FluentCheckException>()
            .WithMessage(Environment.NewLine+ "The checked code did not raise an exception, whereas it must.");
        }

        [Test]
        public void DidNotRaiseAnyTypedCheck()
        {
            Check.ThatCode(() =>
            {
                Check.ThatCode(() => { new object(); }).Throws<Exception>();
            })
            .Throws<FluentCheckException>()
            .WithMessage(Environment.NewLine+ "The checked code did not raise an exception, whereas it must." + Environment.NewLine + "The expected exception:" + Environment.NewLine + "\tan instance of type: [System.Exception]");
        }
    }
}