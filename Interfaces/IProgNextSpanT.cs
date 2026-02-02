// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

// Generic interface for psuedo-random object generators (PROG's) that 
// implement Span{T} NextSpan(...) methods.
//
// Typeparam: T return type of the NextSpan() method.
//
public interface IProgNextSpan<T> : IProgSeed
{
    // Create a span of the specified size and fill it with random values.
    //
    // Returns: A span of random T values.
    //
    Span<T> NextSpan(int length);

    // Fill the specified buffer with random values and return it.
    //
    // Returns [buffer] after filling it with random values.
    //
    Span<T> NextSpan(Span<T> buffer);
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
