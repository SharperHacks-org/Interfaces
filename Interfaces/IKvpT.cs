// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

// A KVP interface, w/fixed key type and polymorphic value type.
//
// @TKey The type used as the key/label.
//
public interface IKvp<TKey> where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
{
    // The key.
    //
    // Keys SHOULD be immutable.
    //
    TKey Key { get; }

    // Whether the value is immutable.
    bool IsImmutable { get; }

    // The value object.
    object? Value { get; }

    // Return a deep clone of the underlying instance.
    //
    // Returns: IKvp<TKey>
    //
    IKvp<TKey> Clone();

    // Get the value as type TValue.
    //
    // Returns @TValue.
    //
    // Exceptions:
    //  See https://learn.microsoft.com/en-us/dotnet/api/system.convert.changetype?view=net-9.0/>
    //
    TValue? GetValue<TValue>() where TValue : IComparable, IComparable<TValue>, IEquatable<TValue>;

    // Set Value.
    //
    // Parameters:
    //  @value The value to set.
    //
    void SetValue<TValue>(TValue? value) where TValue : IComparable, IComparable<TValue>, IEquatable<TValue>;
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
