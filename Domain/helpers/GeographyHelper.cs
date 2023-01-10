using NetTopologySuite.Geometries;

namespace TreeTrackAPI.Domain.helpers
{
    public static class GeographyHelper
    {
        public static List<MyPoint> ConvertPolygonToList(Polygon polygon)
        {
            List<MyPoint> coordinates = new List<MyPoint>();
            foreach (Coordinate coordinate in polygon.Coordinates)
            {
                double lat = coordinate.Y;
                double lng = coordinate.X;
                coordinates.Add(new MyPoint()
                {
                    Latitude = lat,
                    Longitude = lng
                });
            }

            return coordinates;
        }

        public static MyPoint ConvertPointToMyPoint(Point point)
        {
            MyPoint location = new MyPoint()
            {
                Latitude = point.Y,
                Longitude = point.X
            };
            return location;
        }

        public static Point ConvertMyPointToPoint(MyPoint location)
        {
            GeometryFactory geometryFactory = new GeometryFactory(new PrecisionModel(), 4326);
            var coordinate = new Coordinate(location.Longitude, location.Latitude);
            return geometryFactory.CreatePoint(coordinate);
        }

        public static Polygon ConvertListToPolygon(List<MyPoint> polygonPoints)
        {
           
            if (polygonPoints.Count > 0 && polygonPoints.Count < 3)
            {
                throw new Exception("Polygon is invalid");
            }
            GeometryFactory geometryFactory = new GeometryFactory(new PrecisionModel(), 4326);

            // Create an array of Coordinates with the longitude and latitude values
            var coordinates = new Coordinate[polygonPoints.Count];
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                coordinates[i] = new Coordinate(polygonPoints[i].Longitude, polygonPoints[i].Latitude);
            }
            var coordinateSequence = geometryFactory.CoordinateSequenceFactory.Create(coordinates);
            // Create a Polygon with the Coordinates
            return geometryFactory.CreatePolygon(coordinateSequence);

        }
    }
   
}
