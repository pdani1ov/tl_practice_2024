using CarFactory.Models.CarSteeringWheelPosition;

namespace CarFactory.Extensions;

public static class SteeringWheelPositionExtensions
{
    public static string ConvertToString( this SteeringWheelPosition position )
    {
        switch ( position )
        {
            case SteeringWheelPosition.Left:
                return "left";
            case SteeringWheelPosition.Right:
                return "right";
            default:
                throw new ArgumentException( $"Unknown steering wheel position - {position}" );
        }
    }
}
