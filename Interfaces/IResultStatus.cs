// Copyright and trademark notices at the end of this file.


namespace SharperHacks.CoreLibs.Interfaces;

/// <summary>
/// A generic result + status type interface.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IResultStatus<T>
{
    /// <summary>
    /// Get whether the result valid. False implies an error.
    /// </summary>
    public bool IsValidResult { get; }

    /// <summary>
    /// Get the result.
    /// </summary>
    public T? Result { get; }
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
