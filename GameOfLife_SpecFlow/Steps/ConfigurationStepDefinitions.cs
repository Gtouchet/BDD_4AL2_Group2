using GameOfLife;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace GameOfLife_SpecFlow.Steps
{
    [Binding]
    public sealed class ConfigurationStepDefinitions
    {
        private readonly ScenarioContext ScenarioContext;

        private Configuration Configuration = new Configuration();
        private Engine Engine;

        public ConfigurationStepDefinitions(ScenarioContext scenarioContext)
        {
            this.ScenarioContext = scenarioContext;
            this.Engine = Engine.Of(null);
        }

        [Given("the world's height is (.*)")]
        public void Given_TheWorldsHeightIs(int height)
        {
            this.Configuration.WorldHeight = height;

            this.ScenarioContext.Pending();
        }

        [Given("the world's width is (.*)")]
        public void Given_TheWorldsWidthIs(int width)
        {
            this.Configuration.WorldWidth = width;

            this.ScenarioContext.Pending();
        }

        [When("initializing the engine")]
        public void When_InitializingTheEngine()
        {
            this.Engine = Engine.Of(this.Configuration);

            this.ScenarioContext.Pending();
        }

        [Then("the world's length should be (.*)")]
        public void Then_TheWorldsLengthShouldBe(int length)
        {
            this.Engine.World.Length.Should().Be(length);

            this.ScenarioContext.Pending();
        }
    }
}
