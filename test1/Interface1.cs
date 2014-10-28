using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;


namespace Voronoi
{
    public interface Interface1
    {
         void drawDirectLine(float xout, float yout, float x_Line, float y_Line, Graphics g, Pen p);
         void threePoints(List<Point> pointsList,int index, Graphics g2, Pen p1);
         void twoPoints(List<Point> pointsList,int index, Graphics g2, Pen p1);
         //int divid(int a);
         void divideFunc(ref List<List<Point>>groupPoints,ref List<Pen> p1,List<Point> pointsList, Graphics g);
          void convex(List<Point> pointsList, int pointNum, int index, Graphics g2, Pen p1);
    }
}
