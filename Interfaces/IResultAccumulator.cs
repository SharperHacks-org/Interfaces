// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

/// <summary>
/// A result accumulator interface.
/// </summary>
public interface IResultAccumulator
{
    /// <summary>
    /// Get the count of the accumulated results.
    /// </summary>
    public int ResultCount { get; }

    /// <summary>
    /// Get the count of the errors encountered.
    /// </summary>
    public int ErrorCount => Errors.Count();

    /// <summary>
    /// Get whether this result represents "success".
    /// </summary>
    public bool Succeeded => !Errors.Any();

    /// <summary>
    /// Accumulated error messages.
    /// </summary>
    public IEnumerable<string> Errors { get; }

    /// <summary>
    /// Add/accumulate the results from another accumulator.
    /// </summary>
    /// <param name="accumulator"></param>
    /// <returns></returns>
    public IResultAccumulator Add(IResultAccumulator accumulator);

    /// <summary>
    /// Add an error to this instance of the accumulator.
    /// </summary>
    /// <param name="message"></param>
    /// <returns>
    /// An instance of an <see cref="IResultAccumulator"/>, with accumulated 
    /// warning/error messages, counts and <see cref="IResultAccumulator.Succeeded"/> 
    /// set to false.
    /// </returns>
    public IResultAccumulator AddError(string message);

    /// <summary>
    /// Add a warning message to this instance of the accumulator.
    /// </summary>
    /// <param name="message"></param>
    /// <returns>
    /// An instance of an <see cref="IResultAccumulator"/>, with accumulated 
    /// warning/error messages, counts and <see cref="IResultAccumulator.Succeeded"/> 
    /// set according to whether their are any accumulated errors..
    /// </returns>
    public IResultAccumulator AddWarning(string message);

    /// <summary>
    /// Bump the result count.
    /// </summary>
    /// <returns></returns>
    public IResultAccumulator AddSuccess();

    /// <summary>
    /// Clears existing errors.
    /// </summary>
    public IResultAccumulator Reset();

    /// <summary>
    /// Bump the result count.
    /// </summary>
    /// <param name="accumulator"></param>
    /// <returns>
    /// The <paramref name="accumulator"/>.
    /// </returns>
    public static IResultAccumulator operator ++(IResultAccumulator accumulator) => accumulator.AddSuccess();

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

