using System.Windows;
using System.Windows.Media;

namespace PhysicsSimulator
{
    public class PhysicalObject
    {
        public Point Position { get; set; }
        public Vector Velocity { get; set; }
        public Color Color { get; set; } 

        public PhysicalObject(Point position, Vector velocity, Color color) 
        {
            Position = position;
            Velocity = velocity;
            Color = color; 
        }
    }
}
