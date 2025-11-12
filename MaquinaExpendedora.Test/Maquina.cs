namespace MaquinaExpendedora.Test;

public class Maquina
{
    private decimal _saldo;
    private const string MensajeInsertarMoneda = "INSERT COIN";
    private const string FormatoMensajeSaldo = "Saldo: {0:C}";
    private const string FormatoMensajeSeleccionProducto = "Price: {0:C} - {1}";
    public string Display { get; private set; } = MensajeInsertarMoneda;
    public List<Moneda> CoinReturn { get; } = [];
    private List<Moneda> MonedasInsertadas { get; } = [];
    
    private readonly Dictionary<Productos, decimal> _preciosProductos = new()
    {
        {Productos.Cola, 1m},
        {Productos.Chip, 0.5m},
        {Productos.Candy, 0.65m}
    };

    public void InsertarMoneda(Moneda moneda)
    {
        if (moneda == Moneda.Penny)
        {
            CoinReturn.Add(moneda);
            return;
        }

        MonedasInsertadas.Add(moneda);

        _saldo += moneda.Valor;
        Display = MostrarSaldo();
    }


    public void ReturnCoins()
    {
        Display = MensajeInsertarMoneda;
        CoinReturn.AddRange(MonedasInsertadas);
        MonedasInsertadas.Clear();
    }

    public void SeleccionarProducto(Productos producto)
    {
        var valorProducto = ObtenerValorProducto(producto);
        var insertCoinOSaldo = MensajeInsertCoinOSaldo(valorProducto);
        
        Display = string.Format(FormatoMensajeSeleccionProducto, valorProducto, insertCoinOSaldo);
    }

    private string MensajeInsertCoinOSaldo(decimal valorProducto)
    {
        return _saldo > 0 && _saldo < valorProducto ? MostrarSaldo() : MensajeInsertarMoneda;
    }

    private decimal ObtenerValorProducto(Productos producto)
    {
        return _preciosProductos[producto];
    }

    private string MostrarSaldo() => string.Format(FormatoMensajeSaldo, _saldo);
}