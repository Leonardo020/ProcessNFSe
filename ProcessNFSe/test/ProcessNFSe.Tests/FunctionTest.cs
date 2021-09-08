using Xunit;

namespace ProcessNFSe.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestProcess()
        {
            var function = new Function();
            function.ProcessaServicoTomado(1);
        }
    }
}
