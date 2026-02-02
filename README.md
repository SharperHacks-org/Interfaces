![SharperHacks logo](SHLLC-Logo.jpg)
# Interfaces
## SharperHacks.CoreLibs.Interfaces

A collection of useful interfaces, with zero implementation dependancies.

Licensed under the Apache License, Version 2.0. See [LICENSE](LICENSE).

Contact: joseph@sharperhacks.org

Nuget: https://www.nuget.org/packages/SharperHacks.CoreLibs.Interfaces

### Targets
- net8.0
- net9.0
- net10.0

### Interfaces

#### IDeepCloneable
```
// A simple interface for deeply cloneable objects.
//
//  @T The type that is deep cloneable.
//
public interface IDeepCloneable<T>
{
    // Perform a deep copy of the @T instance.
    //
    // Returns: A deep copy of the current instance.
    //
    T DeepClone();
}
```

#### IInvokable`<TResult>`
```
// Defines the Invoke() interface with a generic return type.
//
// @TResult The result type return by @Invoke()
//
public interface IInvokable<TResult>
{
    // Invoke any encapsulated function or process with a generic return type.
    //
    // Return: @TResult
    //
    TResult Invoke();
}
```

#### IInvoke
```
// Defines the Invoke() interface.
//
public interface IInvoke
{
    // Invoke any encapsulated action, function, process.
    void Invoke();
}
```

#### IKvp`<TKey>`
```
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
```

#### `IProgEnumerable<T>`
```
// An interface for enumerable psuedo-random object generators (PROG's).
//
// Typeparam: T the type resulting from enumeration.
//
// Remarks:
//  Beware of LINQ's Count() and LongCount() extensions to IEnumerable.
//  Not all IEnumerable's have a fixed size, nor are they all countable.
//

public interface IProgEnumerable<T> : IEnumerable<T>, IProgSeed { }
```

#### `IProgNextArray<T>`
```
// Generic interface for psuedo-random object generators (PROG's) that implement
// a NextArray method returning T[].
//
// Typeparams: T Return type of the NextArray() method.
//
public interface IProgNextArray<T> : IProgSeed
{
    // Returns the next [length] sized array of random values of T.
    //
    // Params:
    //  [length]
    //
    public T[] NextArray(long length);

    // Fills [buffer] with random values of T.
    //
    // Params:
    //  [buffer]
    // 
    // Returns: [buffer]
    //
    public T[] NextArray(T[] buffer);
}
```

#### `IProgNextInInterval<T>`
Generic interface for PROG's that implement NextInInterval method.

```
T NextInInterval(IInterval<T> interval);
```
#### `IProgNextInRange<T>`
Generic interface for PROG's that implement NextInRange method.

```
T NextInRange(T min, T max);
```

#### `IProgNextSpan<T>`
Generic interface for PROG's that implement NextSpan methods.

```
 // Create a span of the specified size and fill it with random values.
 Span<T> NextSpan(int length);

 // Fill the specified buffer with random values and return it.
 Span<T> NextSpan(Span<T> buffer);
```

#### `IProgNextValue<T>`
Generic interface for PROG's that implement NextValue method.

```
T NextValue();
```

#### IProgSeed
Declares `object Seed`, used by the rest of the IProg* interfaces.

PRG's, must generally be initialized with a seed value. In many 
applications, it is important that each seed should be random, but there
is often a requirement that playback, for diagnostic or other purposes
must be possible. To solve this problem, most PRNG's allow for seeds to 
be injected by the caller, at initialization. This can lead to less than 
desirable results, when non-experts contrive their own naive sources of 
randomness.

The seed values used, should have characteristics that are at least as
strong as the PRG. The consumers of such generators, should not be asked
to generate seeds, so the need arises for the generators to expose their
initial seed and other critical values, such as coefficients, etc, for
testing and diagnostic purposes.

This interface provides an extreme level of abstraction over the above
concepts, allowing the PRG to expose it's own, implementation specific,
random and non-random initial state.

```
 // The seed used to initialize psuedo-random object generators (PROG's).
 object Seed { get; }
```

#### `IProgState`
A generic interface to access internal state of PROG's.

```
object State { get; }
```


#### IResultAccumulator
A result accumulator interface.

#### IResult`<T>`
A generic result type interface.

#### IResultStatus
 generic result + status type interface.

#### IRunable
A Run() interface.

#### ISettableState`<T>`
A generic settable state interface.

#### IState`<T>`
A generic state interface.

#### IToJsonString
Defines a ToJsonString() interface.

#### IToJsonUtf8Bytes
Defines a ToJsonUtf8Bytes() interface.

#### IToJsonUtf8ByteSpan
Defines a ToJsonUtf8ByteSpan() interface.

#### IToJson
Combines IToJsonString, IToJsonUtf8Bytes and IToJsonUtf8ByteSpan in one interface.

