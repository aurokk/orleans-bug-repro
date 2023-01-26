namespace OrleansBugRepro.Interfaces;

[Immutable, GenerateSerializer, Alias("TestType2")]
public abstract record TestType2(string? TestString)
{
    [Immutable, GenerateSerializer, Alias("TestType2A")]
    public sealed record TestType2A(string? TestString) : TestType2(TestString);

    [Immutable, GenerateSerializer, Alias("TestType2B")]
    public sealed record TestType2B(string? TestString) : TestType2(TestString);
}

[Immutable, GenerateSerializer, Alias("TestType1")]
public record TestType1(TestType2[] TestArray);

[Immutable, GenerateSerializer, Alias("TestType0")]
public record TestType0(TestType1 TestType1, string? SomeString);

public interface ITestGrain : IGrainWithStringKey
{
    Task<TestType0> GetTestType0();
}

public interface ITestSubGrain : IGrainWithStringKey
{
    Task<TestType0> GetTestType0();
}