![SharperHacks logo](SHLLC-Logo.jpg)
# THIS PROJECT HAS BEEN MOVED TO [codeberg.org](https://codeberg.org/SharperHacks-org/Interfaces).
# THIS REPO WILL BE REMOVED.
## Interfaces
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

#### `IDeepCloneable<T>`
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

#### `IGetableState<T>`
```
// A generic get state interface.
//
//  @T The type representing the state.
//
public interface IGetableState<T>
{
    // Get the current state.
    T GetState();
}
```

#### `IInterval<T>`
```
// Represents a interval in terms of upper and lower bounds and whether
// they are inclusive or exclusive.
//
// @T Any type that implements IComparable{T}.
//
// An interval in this context is not a fixed set of values. It is very 
// important to capture the full semantics of interval specifications
// and behaviors in implementations of this interface.
//
public interface IInterval<T> where T : IComparable<T>
{
    // Get the lower boundary of the interval.
    //
    T LowerBound { get; }

    // Get whether lower boundary is inclusive or exclusive.
    //
    IntervalBoundaryType LowerBoundaryType { get; }

    // Get whether the lower boundary is inclusive.
    //
    bool IsInclusiveLowerBound => LowerBoundaryType == IntervalBoundaryType.Inclusive;

    // Get whether the lower boundary is exclusive.
    //
    bool IsExclusiveLowerBound => LowerBoundaryType == IntervalBoundaryType.Exclusive;

    // Get the upper boundary of the interval.
    //
    T UpperBound { get; }

    // Get whether the upper boundary is inclusive or exclusive.
    //
    IntervalBoundaryType UpperBoundaryType { get; }

    // Get whether the upper boundary is inclusive.
    //
    bool IsInclusiveUpperBound => UpperBoundaryType == IntervalBoundaryType.Inclusive;

    // Get whether the upper boundary is exclusive.
    //
    bool IsExclusiveUpperBound => UpperBoundaryType == IntervalBoundaryType.Exclusive;

    // Get whether the defined interval is empty.
    //
    // Default implementation not adequate for all types of T.
    //
    bool IsEmpty => (LowerBound is null && UpperBound is null)
            || ((LowerBound is null || IsExclusiveLowerBound)
                && (UpperBound is null || IsExclusiveUpperBound))
            || ((IsExclusiveLowerBound || IsExclusiveUpperBound)
                && Equals(LowerBound, UpperBound));

    // Determine whether value falls within specified interval.
    //
    // Parameters:
    //  @value
    //   The value to test against the interval.
    //
    // Returns: True if value is within the specified interval.
    //
    public bool Contains(T value)
    {
        // 
        var lowerBoundComparison = value.CompareTo(LowerBound);
        var upperBoundComparison = value.CompareTo(UpperBound);

        var aboveLowerBound = IsInclusiveLowerBound ? lowerBoundComparison >= 0 : lowerBoundComparison >= 1;
        var belowUpperBound = IsInclusiveUpperBound ? upperBoundComparison <= 0 : upperBoundComparison <= -1;

        return aboveLowerBound && belowUpperBound;
    }
}
```

#### `IInvokable<TResult>`
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

#### `IInvokable<TResult>`
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

#### `IKvp<TKey>`
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

#### IntervalBoundaryType
// Enumeration representing whether an interval boundary is inclusive/exclusive.
//
```
public enum IntervalBoundaryType
{
    // Range boundary is inclusive.
    //
    Inclusive,

    // Range boundary is exclusive.
    //
    Exclusive
}
```

#### `IPoint<T>`
```
// A generic point interface.
//
// @TNumeric The numeric type used to specify locations.
//
public interface IPoint<TNumeric> where TNumeric : INumber<TNumeric>
{
    // Get the dimensionality associated with this point.
    //
    // Must be a non-zero positive value.
    //
    int Dimensions { get; }

    // Get a list of points on each axis.
    //
    ImmutableList<TNumeric> Coordinates { get; }

    // Get the component at the specified index.
    //
    // Parameters:
    //  @index
    //
    // Returns The component value at that index.
    //
    TNumeric this[int index] => Coordinates[index];
}
```

#### `IPolygon<T>`
```
// A generic polygon interface.
//
// @T The numeric type used to specify locations.
//
public interface IPolygon<T> where T : INumber<T>
{
    // Get the number of vertices, defining the polygon.
    //
    public int VertexCount { get; }

    // Get the list of IPoint{T}'s that specify vertex positions.
    //
    public ImmutableList<IPoint<T>> Vertices { get; }
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


