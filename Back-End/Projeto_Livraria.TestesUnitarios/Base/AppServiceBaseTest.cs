using AutoMoq;

namespace Projeto_Livraria.TestesUnitarios.Base
{
    public class AppServiceBaseTest
    {
        protected readonly AutoMoqer _mocker;

        protected AppServiceBaseTest()
        {
            _mocker = new AutoMoqer();
        }
    }
}
