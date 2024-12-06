using System.Collections.Generic;
using System.Windows;

namespace PhysicsSimulator
{
    public class PhysicsEngine
    {
        private const double Gravity = 9.81;
        public List<PhysicalObject> Objects { get; set; }

        public PhysicsEngine()
        {
            Objects = new List<PhysicalObject>();
        }

        public void Update(double deltaTime)
        {
            foreach (var obj in Objects)
            {
                obj.Velocity = new Vector(obj.Velocity.X, obj.Velocity.Y + Gravity * deltaTime);
                obj.Position = new Point(obj.Position.X + obj.Velocity.X * deltaTime,
                                         obj.Position.Y + obj.Velocity.Y * deltaTime);

                if (obj.Position.Y >= 580)
                {
                    obj.Position = new Point(obj.Position.X, 580);
                    obj.Velocity = new Vector(obj.Velocity.X, obj.Velocity.Y * -0.8);
                }
            }
        }
    }
}
