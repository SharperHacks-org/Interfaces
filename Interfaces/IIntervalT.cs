// Copyright and trademark notices at bottom of file.

namespace SharperHacks.CoreLibs.Interfaces;

// Represents a interval in terms of upper and lower bounds and whether
// they are inclusive or exclusive.
//
// @T Any type that implements IComparable{T}.
//
// An interval in this context is not a fixed set of values. It is very 
// important to capture the full semantics of interval specifications
// and behaviors in implementations of this interface.
//
public interface IInterval<T> where T : IComparable<T>
{
    // Get the lower boundary of the interval.
    //
    T LowerBound { get; }

    // Get whether lower boundary is inclusive or exclusive.
    //
    IntervalBoundaryType LowerBoundaryType { get; }

    // Get whether the lower boundary is inclusive.
    //
    bool IsInclusiveLowerBound => LowerBoundaryType == IntervalBoundaryType.Inclusive;

    // Get whether the lower boundary is exclusive.
    //
    bool IsExclusiveLowerBound => LowerBoundaryType == IntervalBoundaryType.Exclusive;

    // Get the upper boundary of the interval.
    //
    T UpperBound { get; }

    // Get whether the upper boundary is inclusive or exclusive.
    //
    IntervalBoundaryType UpperBoundaryType { get; }

    // Get whether the upper boundary is inclusive.
    //
    bool IsInclusiveUpperBound => UpperBoundaryType == IntervalBoundaryType.Inclusive;

    // Get whether the upper boundary is exclusive.
    //
    bool IsExclusiveUpperBound => UpperBoundaryType == IntervalBoundaryType.Exclusive;

    // Get whether the defined interval is empty.
    //
    // Default implementation not adequate for all types of T.
    //
    bool IsEmpty => (LowerBound is null && UpperBound is null)
            || ((LowerBound is null || IsExclusiveLowerBound)
                && (UpperBound is null || IsExclusiveUpperBound))
            || ((IsExclusiveLowerBound || IsExclusiveUpperBound)
                && Equals(LowerBound, UpperBound));

    // Determine whether value falls within specified interval.
    //
    // Parameters:
    //  @value
    //   The value to test against the interval.
    //
    // Returns: True if value is within the specified interval.
    //
    public bool Contains(T value)
    {
        // 
        var lowerBoundComparison = value.CompareTo(LowerBound);
        var upperBoundComparison = value.CompareTo(UpperBound);

        var aboveLowerBound = IsInclusiveLowerBound ? lowerBoundComparison >= 0 : lowerBoundComparison >= 1;
        var belowUpperBound = IsInclusiveUpperBound ? upperBoundComparison <= 0 : upperBoundComparison <= -1;

        return aboveLowerBound && belowUpperBound;
    }
}

// Copyright Joseph W Donahue and Sharper Hacks LLC (US-WA)
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// SharperHacks is a trademark of Sharper Hacks LLC (US-Wa), and may not be
// applied to distributions of derivative works, without the express written
// permission of a registered officer of Sharper Hacks LLC (US-WA).

