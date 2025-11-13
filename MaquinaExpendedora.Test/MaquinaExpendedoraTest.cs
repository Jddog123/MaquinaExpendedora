using FluentAssertions;

namespace MaquinaExpendedora;

public class MaquinaExpendedoraTest
{
    [Fact]
    public void Si_IniciaMaquina_Debe_DisplayMostrarInsertCoin()
    {
        var maquina = new Maquina();
        
        maquina.Display.Should().Be("INSERT COIN");
    }
}

public class Maquina
{
    private const string InsertCoinMessage = "INSERT COIN";
    public string Display { get; private set; } = InsertCoinMessage;
}