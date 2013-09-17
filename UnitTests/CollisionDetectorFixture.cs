using FallingBricks2;
using FallingBricks2.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class CollisionDetectorFixture
    {
        private ICollisionDetector _detector;

        public CollisionDetectorFixture()
        {
            _detector = (ICollisionDetector)new CollisionDetector(10);
        }

        [TestMethod]
        public void DetectNonCollision()
        {
            Assert.IsFalse(_detector.Collision(new Line(new Point(1, 8))));
        }

        [TestMethod]
        public void DetectCollision()
        {
            Assert.IsTrue(_detector.Collision(new Line(new Point(1, 9))));
        }
    }
}
