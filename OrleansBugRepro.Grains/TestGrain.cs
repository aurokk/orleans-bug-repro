using OrleansBugRepro.Interfaces;

namespace OrleansBugRepro.Grains;

public class TestSubGrain : Grain, ITestSubGrain
{
    public Task<TestType0> GetTestType0()
    {
        return Task.FromResult(
            new TestType0(TestType1:
                new TestType1(
                    TestArray: new TestType2[]
                    {
                        new TestType2.TestType2A("a"),
                        new TestType2.TestType2A("b"), // WILL BE NULL
                    }
                ),
                SomeString: "test" // WILL BE NULL
            )
        );
    }
}

public class TestGrain : Grain, ITestGrain
{
    public Task<TestType0> GetTestType0() =>
        GrainFactory.GetGrain<ITestSubGrain>(Guid.NewGuid().ToString()).GetTestType0();
}