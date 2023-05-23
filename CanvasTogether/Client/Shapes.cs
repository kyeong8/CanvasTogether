using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasTogether
{
    public class Shape
    {
        public virtual void DrawShape(PaintEventArgs e)
        {
            ;
        }
    }

    public class MyFreePen : Shape
    {
        // Member variables declaration
        private Pen pen;
        private SolidBrush brush;
        private Rectangle rectF;
        private int thick;

        // Constructor
        public MyFreePen()
        {
            rectF = new Rectangle();
            thick = 1;
        }

        // Member functions declaration
        public void setRectF(Point start, Pen pen, SolidBrush brush, int thick)
        {
            rectF.X = start.X;
            rectF.Y = start.Y;
            rectF.Width = thick;
            rectF.Height = thick;

            this.pen = pen;
            this.brush = brush;
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

        public Pen GetPen()
        {
            return pen;
        }

        public SolidBrush GetBrush()
        {
            return brush;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(this.brush, this.getRectF());
            e.Graphics.DrawEllipse(this.pen, this.getRectF());
        }
    }

    public class MyCircle : Shape
    {
        // Member variables declaration
        private Pen pen;
        private Rectangle rectC;
        private int thick;

        // Constructor
        public MyCircle()
        {
            rectC = new Rectangle();
            thick = 1;
        }

        // Member functions declaration
        public void setRectC(Point start, Point finish, Pen pen, int thick)
        {
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);

            this.pen = pen;
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

        public Pen GetPen()
        {
            return pen;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(this.pen, this.getRectC());
        }
    }

    public class MyLines : Shape
    {
        // Member variables declaration
        private Pen pen;
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
        public void setPoint(Point start, Point finish, Pen pen, int thick)
        {
            point[0] = start;
            point[1] = finish;

            this.pen = pen;
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

        public Pen GetPen()
        {
            return pen;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.DrawLine(this.pen, this.getPoint1(), this.getPoint2());
        }
    }

    public class MyRect : Shape
    {
        // Member variables declaration
        private Pen pen;
        private Rectangle rect;
        private int thick;

        // Constructor
        public MyRect()
        {
            rect = new Rectangle();
            thick = 1;
        }

        // Member functions declaration
        public void setRect(Point start, Point finish, Pen pen, int thick)
        {
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);
            
            this.pen = pen;
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

        public Pen GetPen()
        {
            return pen;
        }

        public override void DrawShape(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(this.pen, this.getRect());
        }
    }
}