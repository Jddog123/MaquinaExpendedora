using FluentAssertions;

namespace MaquinaExpendedora.Test;



public class MaquinaExpendedoraTest
{
    private Maquina _maquina;
    public MaquinaExpendedoraTest()
    {
        _maquina = new Maquina();
    }
    
    [Fact(DisplayName = "Si inicia maquina debe display mostrar INSERT COIN")]
    public void SiIniciaMaquina_Debe_DisplayMOstrarInsertCoin()
    {
        _maquina.Display.Should().Be("INSERT COIN");
    }

    [Fact(DisplayName = "Si agrego una moneda de nickel a una maquina recien instanciada el display debe mostrar 5")]
    public void Si_InsertoMonedaNickel_Debe_DisplayMostrarSaldoCinco()
    {
        _maquina.InsertarMoneda(Moneda.Nickel);

        _maquina.Display.Should().Be("Saldo: $ 0,05");
    }

    [Fact]
    public void Si_InsertoMonedaDime_Debe_MostrarSaldo10EnElDisplay()
    {
        _maquina.InsertarMoneda(Moneda.Dime);
        
        _maquina.Display.Should().Be("Saldo: $ 0,10");
    }

    [Fact]
    public void Si_InsertoMonedaQuarter_Debe_MostrarSaldo25EnElDisplay()
    {
        _maquina.InsertarMoneda(Moneda.Quarter);

        _maquina.Display.Should().Be("Saldo: $ 0,25");
    }

    [Fact]
    public void Si_RecibeUnPennySinSaldo_Debe_MostrarInsertCoin()
    {
        _maquina.InsertarMoneda(Moneda.Penny);

        _maquina.Display.Should().Be("INSERT COIN");
        _maquina.CoinReturn.Should().HaveCount(1);
        _maquina.CoinReturn.Should().BeEquivalentTo([
            Moneda.Penny]);
    }

    [Fact]
    public void Si_Inserto2Nickel_Debe_Mostrar0_10()
    {
        _maquina.InsertarMoneda(Moneda.Nickel);
        _maquina.InsertarMoneda(Moneda.Nickel);

        _maquina.Display.Should().Be("Saldo: $ 0,10");

    }
    
    [Fact]
    public void Si_Inserto2Dime_Debe_Mostrar0_20()
    {
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Dime);

        _maquina.Display.Should().Be("Saldo: $ 0,20");

    }
    
    [Fact]
    public void Si_Inserto2Quarter_Debe_Mostrar0_50()
    {
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Quarter);

        _maquina.Display.Should().Be("Saldo: $ 0,50");

    }
    
    [Fact]
    public void Si_Inserto2DimeYQuarterY2Penny_Debe_DisplayMostrar_0_45()
    {
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Penny);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Penny);
        

        _maquina.Display.Should().Be("Saldo: $ 0,45");
        _maquina.CoinReturn.Should().HaveCount(2);
        _maquina.CoinReturn.Should().BeEquivalentTo([
            Moneda.Penny,Moneda.Penny]);
    }

    [Fact]
    public void Si_Inserto2DimeY2QuarterYPulsaBotonReturnCoins_Debe_DevolverMonedasCliente()
    {
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Quarter);

        _maquina.ReturnCoins();
        
        _maquina.Display.Should().Be("INSERT COIN");
        _maquina.CoinReturn.Should().HaveCount(4);
        _maquina.CoinReturn.Should().BeEquivalentTo([
            Moneda.Dime,Moneda.Dime,Moneda.Quarter,Moneda.Quarter]);
    }

    [Fact]
    public void SI_InsertoPennyDimeQuarterPennyPennyBotonRetornar_DebeDevolverMonedasCliente()
    {
        _maquina.InsertarMoneda(Moneda.Penny);
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Penny);
        _maquina.InsertarMoneda(Moneda.Penny);
        
        _maquina.ReturnCoins();
        
        _maquina.Display.Should().Be("INSERT COIN");
        _maquina.CoinReturn.Should().HaveCount(5);
        _maquina.CoinReturn.Should().BeEquivalentTo([
            Moneda.Penny,Moneda.Dime,Moneda.Quarter,Moneda.Penny,Moneda.Penny]);
    }

    [Fact]
    public void Si_InsertoMonedaNickelYSolicitoCambioDosVecesDisplay_Debe_MostrarInsertCoinYDevolverUnNickel()
    {
        _maquina.InsertarMoneda(Moneda.Nickel);
        _maquina.ReturnCoins();

        _maquina.ReturnCoins();
        
        _maquina.Display.Should().Be("INSERT COIN");
        _maquina.CoinReturn.Should().HaveCount(1);
        _maquina.CoinReturn.Should().BeEquivalentTo([Moneda.Nickel]);
    }

    [Theory]
    [InlineData(Productos.Cola, "Price: $ 1,00 - INSERT COIN")]
    [InlineData(Productos.Chip, "Price: $ 0,50 - INSERT COIN")]
    [InlineData(Productos.Candy, "Price: $ 0,65 - INSERT COIN")]
    public void Si_SeleccionoProductoSaldoEnCero_Debe_DisplayMostrarPrecioEInsertCoin(Productos producto, string displayEsperado)
    {
        _maquina.SeleccionarProducto(producto);

        _maquina.Display.Should().Be(displayEsperado);
    }

    [Fact]
    public void Si_Inserto1NikelYSeleccionoCoca_Debe_DisplayMostrarPrecioYSaldo()
    {
        _maquina.InsertarMoneda(Moneda.Nickel);
        _maquina.SeleccionarProducto(Productos.Cola);

        _maquina.Display.Should().Be("Price: $ 1,00 - Saldo: $ 0,05");
    }

    [Fact]
    public void Si_SeleccionoCocaySaldoMenoraUno_Debe_DisplayMostrarPrecioYSaldo()
    {
        _maquina.InsertarMoneda(Moneda.Nickel);
        _maquina.InsertarMoneda(Moneda.Dime);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.SeleccionarProducto(Productos.Cola);

        _maquina.Display.Should().Be("Price: $ 1,00 - Saldo: $ 0,40");
    }
    
    [Fact]
    public void Si_SiInserto4MonedasQuarterYSeleccionoProductoCola_Debe_DispleyMostrarThankYoueInsertCoint()
    {
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.InsertarMoneda(Moneda.Quarter);
        _maquina.SeleccionarProducto(Productos.Cola);

        _maquina.Display.Should().Be("THANK YOU - INSERT COIN");

    }

  
}