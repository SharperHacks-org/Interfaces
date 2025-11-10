// Copyright and trademark notices at the end of this file.


namespace SharperHacks.CoreLibs.Interfaces;

///
public interface IToJsonString
{
    /// <summary>
    /// Write instance state to JSON string.
    /// </summary>
    /// <param name="prettyPrint">
    /// Whether to use an expanded human readable format.
    /// See System.Text.Json.SerializerOptions.
    /// </param>
    /// <param name="safe">
    /// Whether to use a safe or unsafe serializer.
    /// See System.Text.Json.SerializerOptions.
    /// </param>
    /// <returns>
    /// A JSON string.
    /// </returns>
    string ToJsonString(bool prettyPrint = false, bool safe = true);
}

///
public interface IToJsonUtf8Bytes
{
    /// <summary>
    /// Write public instance state to JSON UTF8 encoded byte array.
    /// </summary>
    /// <param name="prettyPrint">
    /// Whether to use an expanded human readable format.
    /// See System.Text.Json.SerializerOptions.
    /// </param>
    /// <param name="safe">
    /// Whether to use a safe or unsafe serializer.
    /// See System.Text.Json.SerializerOptions.
    /// </param>
    /// <returns>
    /// UTF8 encoded JSON byte array.
    /// </returns>
    byte[] ToJsonUtf8Bytes(bool prettyPrint = false, bool safe = true);
}

///
public interface IToJsonUtf8ByteSpan
{
    /// <summary>
    /// Write public instance state to JSON UTF8 encoded byte span.
    /// </summary>
    /// <param name="prettyPrint">
    /// Whether to use an expanded human readable format.
    /// See System.Text.Json.SerializerOptions.
    /// </param>
    /// <param name="safe">
    /// Whether to use a safe or unsafe serializer.
    /// See System.Text.Json.SerializerOptions.
    /// </param>
    /// <returns>
    /// UTF8 encoded JSON byte span.
    /// </returns>
    Span<byte> ToJsonUtf8ByteSpan(bool prettyPrint = false, bool safe = true);
}

/// <summary>
/// Combines IToJsonString, IToJsonUtf8Bytes and IToJsonUtf8ByteSpan in one interface.
/// </summary>
public interface IToJson : 
    IToJsonString, 
    IToJsonUtf8Bytes, 
    IToJsonUtf8ByteSpan
{ }

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
