using FluentAssertions;
using MaquinaExpendedora.Test;

namespace MaquinaExpendedora;

public class MaquinaExpendedoraTest
{
    [Fact]
    public void Si_IniciaMaquina_Debe_DisplayMostrarInsertCoin()
    {
        var maquina = new Maquina();
        
        maquina.Display.Should().Be("INSERT COIN");
    }

    [Fact]
    public void Si_InsertoMonedaNickel_Debe_DisplayMostrarSaldoCeroCeroCinco()
    {
        var maquina = new Maquina();

        maquina.InsertarMoneda(Moneda.Nickel);

        maquina.Display.Should().Be("Saldo : $ 0,05");
    }
}

public class Maquina
{
    private const string InsertCoinMessage = "INSERT COIN";
    public string Display { get; private set; } = InsertCoinMessage;

    public void InsertarMoneda(Moneda nickel)
    {
        throw new NotImplementedException();
    }
}