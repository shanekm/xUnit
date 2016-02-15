using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    // xUnit
    // [Fact]
    // [Trait]
    // ICollectionFixture
    // parallel => assembly.Collection.Behaviour.Call.PerAssembly
    // <add key="xunit.methoddisplay" value = "method"/>

    // Data driven tests
    // [Theory]
    // [InlineData(1,2)]
    // [MemberData("TestData", MemberType = typeof(MyTestData)]

    public class Test1 : IClassFixture<MyFixture>
    {
        private ITestOutputHelper outputHelper;
        private MyFixture myFixture;

        public Test1(ITestOutputHelper outputHelper)
        {
            myFixture = new MyFixture(); // or inject it constructor
            outputHelper = this.outputHelper;
        }

        [Fact]
        [Trait("Category","MyCategory")]
        public void IsTrue()
        {

            Assert.True(true);
        }
    }

    public class MyFixture
    {
        
    }

    // AutoFixture
    // Pipeline: request => customization => ISpecimentBuilder => residue collectors

    // fixture.Create<int>();
    // .CreateMany(count) => default 3
    // .AddManyTo(alreadyExistingList, 10)
    // [DataAnnotations] => to specify exact random data
    // .Inject(new Order { Name = "Blah" }) => when creating and found Object, name will be set to blah
    // fixture.Build<Order>()....Create(); => allows for customization
    // .Build<Order>().WithOut(x => x.Name).With(x => x.Age).Do(x => x.MyList.Add("fish")).Create()
    
    // class MySpecimentBuilder : ISpecimentBuilder => customize random data generation
    //          fixture.Customizations.Add(new MySpecimentBuilder)

    // [AutoData]
    // public void RunTest(int x, int y, Calculator sut)

    // [Theory]
    // [InlineAutoData(5, 10)] => 5 into x, 10 into y
    // public void RunTest(int x, int y, Calculator sut)

    // Moq
    // fixture.Customize(new AutoMozCustomization)
    // var sut = fixture.Create<Buffer>() => Buffer : IBuffer => Moq will be created
    // var sutMockFixture = fixture.[Freeze]<Mock<IBuffer>>() => able to use sutMockFixture

    // [Theory]
    // [AutoMoqData]
    // public void SubTest([Frozen]Mock<IBuffer> mock, Sender sut)
    //      mock.Verify( => able to use mock instance in test 
}