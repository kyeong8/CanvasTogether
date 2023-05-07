using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MyFreePen
    {
        private Rectangle rectF;
        private int thick;

        public MyFreePen()
        {
            rectF = new Rectangle();
            thick = 1;
        }

        public void setRectF(Point curPoint, int thick)
        {
            rectF.X = curPoint.X;
            rectF.Y = curPoint.Y;
            rectF.Width = 1;
            rectF.Height = 1;
            this.thick = thick;
        }

        public Rectangle getRectF()
        {
            return rectF;
        }

        public int getThick()
        {
            return thick;
        }
    }

    public class MyCircle
    {
        // Member variables declaration
        private Rectangle rectC;
        private int thick;

        // Constructor
        public MyCircle()
        {
            rectC = new Rectangle();
            thick = 1;
        }

        // Member functions Declaration
        public void setRectC(Point start, Point finish, int thick)
        {
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);
            this.thick = thick;
        }

        public Rectangle getRectC()
        {
            return rectC;
        }

        public int getThick()
        {
            return thick;
        }
    }

    public class MyLines
    {
        // Member variables declaration
        private Point[] point = new Point[2];
        private int thick;

        // Constructor
        public MyLines()
        {
            point[0] = new Point();
            point[1] = new Point();
            thick = 1;
        }

        // Member functions declaration
        public void setPoint(Point start, Point finish, int thick)
        {
            point[0] = start;
            point[1] = finish;
            this.thick = thick;
        }

        public Point getPoint1()
        {
            return point[0];
        }

        public Point getPoint2()
        {
            return point[1];
        }

        public int getThick()
        {
            return thick;
        }
    }

    public class MyRect
    {
        // Member variables declaration
        private Rectangle rect;
        private int thick;

        // Constructor
        public MyRect()
        {
            rect = new Rectangle();
            thick = 1;
        }

        // Member functions declaration
        public void setRect(Point start, Point finish, int thick)
        {
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);
            this.thick = thick;
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public int getThick()
        {
            return thick;
        }
    }
}
