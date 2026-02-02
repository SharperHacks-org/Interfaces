// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

// A generic interface to access internal state of psuedo random object generators.
//
public interface IProgState
{
    // The state data.
    //
    // Remarks:
    //
    // While a PRG state and seed may have the same type, the seed is a one time
    // initialization value, while the state, is what you need to capture, if you
    // need to stop a process and pick up later, where it left off. The seed is 
    // used for replay.
    //
    // The internal state may not be available in all PRG implementations, in 
    // which case they should not implement this interface.
    //
    object State { get; }
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

