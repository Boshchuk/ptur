using System.Drawing;

namespace project
{
    public class Apc : Target
    {
        /*  public Apc()
            : base()
        { 
        }
        */
        public Apc(Graphics place,int width,int heihgt,int trackHeihgt,Size sizeOfPanel,Point pointWhere)
            : base(place)
        {
            //  Point pos = new Point(pointWhere.X,
            //  DrawingRectangle corpus = new DrawingRectangle(this.where, sizeOfPanel, pos, width, heihgt - trackHeihgt);
        }
    }
}