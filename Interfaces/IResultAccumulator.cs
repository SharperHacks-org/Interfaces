// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

// A result accumulator interface.
//
public interface IResultAccumulator
{
    // Get the count of the accumulated results.
    int ResultCount { get; }

    // Get the count of the errors encountered.
    int ErrorCount => Errors.Count();

    // Get whether this result represents "success".
    //
    // Note that any failure recorded in this instance of @IResultAccumulator,
    // MUST result in @IResultAccumulator.Succeeded returning false.
    //
    bool Succeeded => !Errors.Any();

    // Accumulated error messages.
    IEnumerable<string> Errors { get; }

    // Accumulated warning messages.
    IEnumerable<string> Warnings { get; }

    // Add/accumulate the results from another accumulator.
    //
    // Parameters:
    //  @accumulator
    //
    // Returns the updated IResultAccumulator instance.
    //
    IResultAccumulator Add(IResultAccumulator accumulator);

    // Add an error to this instance of the accumulator.
    //
    // Parameters:
    //  @message
    //
    // Returns:
    //  An instance of an @IResultAccumulator, with accumulated warning/error
    //  messages, counts and @IResultAccumulator.Succeeded, set to false.
    //
    IResultAccumulator AddError(string message);

    // Add a warning message to this instance of the accumulator.
    //
    // Parameters:
    //  @message
    //
    // Returns:
    //  An instance of an @IResultAccumulator, with accumulated warning/error
    //  messages, counts and @IResultAccumulator.Succeeded set according to
    //  whether their are any accumulated errors..
    //
    IResultAccumulator AddWarning(string message);

    // Bump the result count.
    // 
    // Returns: The current instance of IResultAccumulator, with .
    //
    IResultAccumulator AddSuccess();

    // Clears existing errors.
    //
    IResultAccumulator Reset();

    // Get all accumulated errors and warnings as a string.
    //
    // Returns: Accumulated errors and warings as a string.</returns>
    //
    string ToString();

    // Bump the result count.
    //
    // Parameters:
    //  @accumulator
    //   The accumulator, from which to add all warnings, errors and result counts,
    //   to this istance of @IResultAccumulator.
    //
    static IResultAccumulator operator ++(IResultAccumulator accumulator) => accumulator.AddSuccess();
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

