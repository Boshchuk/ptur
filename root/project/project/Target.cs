using System.Collections.Generic;
using System.Drawing;

namespace project
{
    public class Target
    {
        protected Graphics where;
        List<DrawingRectangle> ltarget = null;
        public int DetalCount
        {
            get
            {
                return ltarget.Capacity;
            }
        }
        public Target(Graphics place)
        {
            ltarget = new List<DrawingRectangle>();
            where = place;
        }
        //отображение фигуры, это отображение фигуры в иерархии
        private void addDetal(DrawingRectangle detal)
        {   
            ltarget.Add(detal);
        }
    }
}