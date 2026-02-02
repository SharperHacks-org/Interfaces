// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

// A generic interface for seeds used in psuedo-random object generators (PROG's).
//
// Remarks:
//
// PRG's, must generally be initialized with a seed value. In many 
// applications, it is important that each seed should be unique, but there
// is often a requirement that playback, for diagnostic or other purposes
// must be possible. To solve this problem, most PRG's allow for seeds to 
// be injected by the caller, at initialization. This can lead to less than 
// desirable results, when non-experts contrive their own naive sources of 
// randomness.
//
// The seed values used, should have characteristics that are at least as
// strong as the PRG. The consumers of such generators, should not be asked
// to generate seeds, so the need arises for the generators to expose their
// initial seed and other critical values, such as coefficients, etc, for
// testing and diagnostic purposes.
//
// This interface provides a level of abstraction over the above
// concepts, allowing the PRG to expose it's own, implementation specific,
// initial state.
//
public interface IProgSeed
{
    // The seed used to initialize psuedo-random object generators (PROG's).
    //
    // Remarks:
    //
    // PROG seeds need not be integers in the range of [0..int.MaxValue]
    // as is common in PRNG's. Arrays, struct and class may be reasonable 
    // PROG initializers. Whatever is used to initialize a PROG, there can
    // be a need to allow for replaying of PR sequences. This interface 
    // exposes the seed object so that its value may be logged and reused.
    //
    // Note that the seed type that a PROG uses, need not be the same type
    // as the psuedo-random objects being generated.
    //
    object Seed { get; }
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
