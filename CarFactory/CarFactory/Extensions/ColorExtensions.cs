using CarFactory.Models.CarColor;

namespace CarFactory.Extensions;

public static class ColorExtensions
{
    public static string ConvertToString( this Color color )
    {
        switch ( color )
        {
            case Color.White:
                return "white";
            case Color.Black:
                return "black";
            case Color.Green:
                return "green";
            case Color.Blue:
                return "blue";
            case Color.Red:
                return "red";
            default:
                throw new ArgumentException( $"Unknown color - {color}" );
        }
    }
}