// Copyright and trademark notices at bottom of file.

using System.Collections.Immutable;
using System.Numerics;

namespace SharperHacks.CoreLibs.Interfaces;

// A generic point interface.
//
// @TNumeric The numeric type used to specify locations.
//
public interface IPoint<TNumeric> where TNumeric : INumber<TNumeric>
{
    // Get the dimensionality associated with this point.
    //
    // Must be a non-zero positive value.
    //
    int Dimensions { get; }

    // Get a list of points on each axis.
    //
    ImmutableList<TNumeric> Coordinates { get; }

    // Get the component at the specified index.
    //
    // Parameters:
    //  @index
    //
    // Returns The component value at that index.
    //
    TNumeric this[int index] => Coordinates[index];
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
