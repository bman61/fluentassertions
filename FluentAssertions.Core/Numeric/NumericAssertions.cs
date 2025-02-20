﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using FluentAssertions.Execution;


namespace FluentAssertions.Numeric
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="IComparable"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class NumericAssertions<T> where T : struct
    {
        public NumericAssertions(object value)
        {
            if (!ReferenceEquals(value, null))
            {
                Subject = value as IComparable;
                if (Subject == null)
                {
                    throw new InvalidOperationException("This class only supports types implementing IComparable.");
                }
            }
        }

        public IComparable Subject { get; private set; }

        /// <summary>
        /// Asserts that the integral number value is exactly the same as the <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> Be(T expected, string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(ReferenceEquals(Subject, expected) || ((!ReferenceEquals(Subject, null) && Subject.CompareTo(expected) == 0)))
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {context:value} to be {0}{reason}, but found {1}.", expected, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the integral number value is exactly the same as the <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The expected value.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> Be(T? expected, string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(ReferenceEquals(Subject, expected) || (Subject.CompareTo(expected) == 0))
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected {0}{reason}, but found {1}.", expected, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the integral number value is not the same as the <paramref name="unexpected"/> value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> NotBe(T unexpected, string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(unexpected) != 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Did not expect {0}{reason}.", unexpected);

            return new AndConstraint<NumericAssertions<T>>(this);
        }
        
        /// <summary>
        /// Asserts that the integral number value is not the same as the <paramref name="unexpected"/> value.
        /// </summary>
        /// <param name="unexpected">The unexpected value.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> NotBe(T? unexpected, string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(unexpected) != 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Did not expect {0}{reason}.", unexpected);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the numeric value is greater than zero.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BePositive(string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(default(T)) > 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected positive value{reason}, but found {0}", Subject);
            
            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the numeric value is less than zero.
        /// </summary>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeNegative(string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(default(T)) < 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected negative value{reason}, but found {0}", Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the numeric value is less than the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The value to compare the current numeric value with.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeLessThan(T expected, string because = "", params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(expected) < 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected a value less than {0}{reason}, but found {1}.", expected, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the numeric value is less than or equal to the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The value to compare the current numeric value with.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeLessOrEqualTo(T expected, string because = "",
            params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(expected) <= 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected a value less or equal to {0}{reason}, but found {1}.", expected, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the numeric value is greater than the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The value to compare the current numeric value with.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeGreaterThan(T expected, string because = "",
            params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(expected) > 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected a value greater than {0}{reason}, but found {1}.", expected, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the numeric value is greater than or equal to the specified <paramref name="expected"/> value.
        /// </summary>
        /// <param name="expected">The value to compare the current numeric value with.</param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because" />.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeGreaterOrEqualTo(T expected, string because = "",
            params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(Subject.CompareTo(expected) >= 0)
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected a value greater or equal to {0}{reason}, but found {1}.", expected, Subject);
            
            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a value is within a range.
        /// </summary>
        /// <remarks>
        /// Where the range is continuous or incremental depends on the actual type of the value. 
        /// </remarks>
        /// <param name="minimumValue">
        /// The minimum valid value of the range.
        /// </param>
        /// <param name="maximumValue">
        /// The maximum valid value of the range.
        /// </param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because"/>.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeInRange(T minimumValue, T maximumValue, string because = "",
            params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition((Subject.CompareTo(minimumValue) >= 0) && (Subject.CompareTo(maximumValue) <= 0))
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected value to be between {0} and {1}{reason}, but found {2}.",
                    minimumValue, maximumValue, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that a value is one of the specified <paramref name="validValues"/>.
        /// </summary>
        /// <param name="validValues">
        /// The values that are valid.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeOneOf(params T[] validValues)
        {
            return BeOneOf(validValues, string.Empty);
        }

        /// <summary>
        /// Asserts that a value is one of the specified <paramref name="validValues"/>.
        /// </summary>
        /// <param name="validValues">
        /// The values that are valid.
        /// </param>
        /// <param name="because">
        /// A formatted phrase as is supported by <see cref="string.Format(string,object[])"/> explaining why the assertion 
        /// is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="reasonArgs">
        /// Zero or more objects to format using the placeholders in <see cref="because"/>.
        /// </param>
        public AndConstraint<NumericAssertions<T>> BeOneOf(IEnumerable<T> validValues, string because = "",
            params object[] reasonArgs)
        {
            Execute.Assertion
                .ForCondition(validValues.Contains((T)Subject))
                .BecauseOf(because, reasonArgs)
                .FailWith("Expected value to be one of {0}{reason}, but found {1}.", validValues, Subject);

            return new AndConstraint<NumericAssertions<T>>(this);
        }
    }
}