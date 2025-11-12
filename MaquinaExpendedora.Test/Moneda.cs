namespace MaquinaExpendedora.Test;

public enum Denominacion
{
    Penny,
    Nickel,
    Dime,
    Quarter
}
public record Moneda
{
    public Denominacion Denominacion { get; private set; }
    public decimal Valor { get; private set; }

    public static Moneda Penny => new (Denominacion.Penny, 0.01m);
    public static Moneda Nickel => new (Denominacion.Nickel, 0.05m);
    public static Moneda Dime => new (Denominacion.Dime, 0.1m);
    public static Moneda Quarter => new (Denominacion.Quarter, 0.25m);
    
    private Moneda(Denominacion denominacion, decimal valor)
    {
        Denominacion = denominacion;
        Valor = valor;
    }
}