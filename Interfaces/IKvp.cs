// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

/// <summary>
/// A KVP interface.
/// Fixed key type.
/// Polymorphic value type.
/// </summary>
/// <typeparam name="TKey">
/// The type used as the key/label.
/// </typeparam>
/// <remarks>
/// Intended for use in heterogenous containers.
/// </remarks>
public interface IKvp<TKey> where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
    /// <summary>
    /// The key.
    /// </summary>
    /// <remarks>
    /// Keys should be immutable. For perf reasons, an implementation is not required to implement
    /// cloning on key retrieval. 
    /// </remarks>
    TKey Key { get; }

    /// <summary>
    /// Whether the value is immutable.
    /// </summary>
    bool IsImmutable { get; }

    /// <summary>
    /// The value object.
    /// </summary>
    object? Value { get; }

    /// <summary>
    /// Return a deep clone of the underlying instance.
    /// </summary>
    /// <returns>IKvp{TKey}</returns>
    IKvp<TKey> Clone();

    /// <summary>
    /// Get the value as type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>
    /// The value as type T.
    /// </returns>
    /// <exceptions>
    /// See https://learn.microsoft.com/en-us/dotnet/api/system.convert.changetype?view=net-9.0/>
    /// </exceptions>
    T? GetValue<T>() where T : IComparable, IComparable<T>, IEquatable<T>;

    /// <summary>
    /// Set Value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    void SetValue<T>(T? value) where T : IComparable, IComparable<T>, IEquatable<T>;
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
