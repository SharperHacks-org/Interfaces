// Copyright and trademark notices at the end of this file.

namespace SharperHacks.CoreLibs.Interfaces;

/// <summary>
/// Defines the Invoke() interface with a generic return type.
/// </summary>
/// <typeparam name="TResult"></typeparam>
public interface IInvoke<TResult>
{
    /// <summary>
    /// Invoke any encapsulated function or process with a generic return type.
    /// </summary>
    /// <returns>TResult</returns>
    public TResult Invoke();
}
