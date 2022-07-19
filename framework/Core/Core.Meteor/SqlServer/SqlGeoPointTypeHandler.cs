using System.Data;
using System.Globalization;

namespace Core.Meteor.SqlServer
{
    public class GeographyTypeHandler : Dapper.SqlMapper.TypeHandler<GeoPoint?>
    {
        public override void SetValue(IDbDataParameter parameter, GeoPoint? value)
        {
            parameter.DbType = DbType.String;
            parameter.Value = value == null ? null : $"POINT ({value.Longitude.ToString("G",CultureInfo.InvariantCulture)} {value.Latitude.ToString("G",CultureInfo.InvariantCulture)})";
        }

        public override GeoPoint? Parse(object? value)
        {
            if (string.IsNullOrWhiteSpace(value as string))
                return null;
            var str = value as string;
            var parts = str!.Substring(7, str.Length - 8).Split(' ');
            return new GeoPoint
            {
                Latitude = double.Parse(parts[1], CultureInfo.InvariantCulture),
                Longitude = double.Parse(parts[0], CultureInfo.InvariantCulture)
            };
        }
    }
    public class GeoPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
