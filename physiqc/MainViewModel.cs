using System.Windows;
using System.Windows.Media;

namespace PhysicsSimulator
{
    public class MainViewModel
    {
        public PhysicsEngine PhysicsEngine { get; }
        public double Gravity { get; set; }

        public MainViewModel()
        {
            PhysicsEngine = new PhysicsEngine();
            Gravity = 0;
        }

        public void AddObject(double mass, Point position, Vector velocity, Color color)
        {
            var newObject = new PhysicalObject(position, velocity, color);
            PhysicsEngine.Objects.Add(newObject);
        }

        public void Update(double deltaTime)
        {
            PhysicsEngine.Update(deltaTime);
        }
    }
}
