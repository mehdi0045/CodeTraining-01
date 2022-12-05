using AttributeBase.Interfaces;

namespace Attribute.Base
{
    public class BaseAttribute : IAttribute
    {
        public BaseAttribute(string name, float min, float max, float current)
        {
            Name = name;
            Min = min;
            Max = max;
            Current = current;
        }

        public string Name { get; set; }

        public float Min { get; set; }

        public float Max { get; set; }

        public float Current { get; set; }


        public void Increase(float amount)
        {
            Current += amount;
            if (Current > Max)
                Current = Max;
        }

        public void Decrease(float amount)
        {
            Current -= amount;
            if (Current < Min)
                Current = Min;
        }

        public void ScaleUp(float amount)
        {
            Max += amount;
        }

        public void ScaleDown(float amount)
        {
            Min -= amount;
        }
    }
}