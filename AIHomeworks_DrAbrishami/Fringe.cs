using System.Collections.Generic;

namespace AIHomeworks_DrAbrishami
{
    public abstract class Fringe
    {
        public abstract knightsState Pop();
        public abstract void Append(knightsState ks);
    }
}