using System.Collections.Generic;
using LetsTrace.Samplers;
using Xunit;

namespace LetsTrace.Tests.Samplers
{
    public class ConstSamplerTests
    {
        [Fact]
        public void ConstSampler_Constructor()
        {
            var sample = true;
            var expectedTags = new Dictionary<string, Field> {
                { SamplingConstants.SAMPLER_TYPE_TAG_KEY, new Field<string> { Value = SamplingConstants.SAMPLER_TYPE_CONST } },
                { SamplingConstants.SAMPLER_PARAM_TAG_KEY, new Field<bool> { Value = sample } }
            };
            var sampler = new ConstSampler(sample);

            var isSampled = sampler.IsSampled(new TraceId(1), "op");

            Assert.Equal(sample, sampler.Decision);
            Assert.Equal(sample, isSampled.Sampled);
            Assert.Equal(expectedTags, isSampled.Tags);
            sampler.Dispose();
        }
    }
}
