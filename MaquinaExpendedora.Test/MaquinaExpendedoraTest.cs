using FluentAssertions;

namespace MaquinaExpendedora;

public class MaquinaExpendedoraTest
{
    [Fact]
    public void SiIniciaMaquina_Debe_DisplayMostrarInsertCoin()
    {
        var maquina = new Maquina();
        
        maquina.Display.Should().Be("INSERT COIN");
    }
}

public class Maquina
{
    public string Display { get; set; }
}