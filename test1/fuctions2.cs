/*
 版權宣告
 * 作者:葉家維( Jia-Wei Yei)
 * 學號:M023040038
 * 
 */

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
    public partial class functions1 : Interface1
    {
      //  functions1 f2 = new functions1() ;
        //=========================================兩個點的時候======================================
        public void twoPoints(List<Point> pointsList, int index, Graphics g2, Pen p1/*,ref List<Point> lines*/)
        {
            //     MessageBox.Show(Convert.ToString(pointsFromString[0].X) + Convert.ToString(pointsFromString[0].Y) + Convert.ToString(pointsFromString[1].X) + Convert.ToString(pointsFromString[1].Y));
            float x1 = (pointsList[index].X + pointsList[index + 1].X) / 2.0f;
            float y1 = (pointsList[index].Y + pointsList[index + 1].Y) / 2.0f;
           // float temp = f2.getSlope(pointsList[index],pointsList[index+1]);
          //  MessageBox.Show(Convert.ToString(temp));
            //          MessageBox.Show(Convert.ToString(x1)+","+(Convert.ToString(y1)));
            float m = 0f;
            if ((pointsList[index].Y != pointsList[index + 1].Y))
                m = (pointsList[index + 1].X - pointsList[index].X) * 1.0f / (pointsList[index].Y - pointsList[index + 1].Y) * 1.0f;   //中垂線斜率
            float m1 = -1.0f / m;
            //           MessageBox.Show(Convert.ToString(m));
            //   MessageBox.Show(Convert.ToString(m1));
            float c = y1 - m * x1;
            if ((pointsList[index].X == pointsList[index + 1].X && (pointsList[index].Y == pointsList[index + 1].Y)))
            { MessageBox.Show("same point"); }
            else if (pointsList[index].X == pointsList[index + 1].X) //中垂線為水平
            {
                //g2.DrawLine(p1,x1,y1,0,y1);
                g2.DrawLine(p1, 0, y1, 600, y1);
            }
            else if (pointsList[index].Y == pointsList[index + 1].Y)  //中垂線為重直
            {
                //g2.DrawLine(p1, x1, y1, x1, 0);
                g2.DrawLine(p1, x1, 0, x1, 600);
            }
            else
            {
                //    g2.DrawLine(p1, pointsList[0].X, pointsList[0].Y, pointsList[1].X,pointsList[1].Y);
                //g2.DrawLine(p1, x1, y1, 0, c);
                g2.DrawLine(p1, 0, c, 600, 600 * m + c);
            }
        }
        //============================================== 兩個點end ===================================================


        //找兩點的中垂線段 記錄點
        public List<float> pointsInLine(Point p1,Point p2) {
            float x1 = (p1.X + p2.X) / 2.0f;
            float y1 = (p1.Y + p2.Y) / 2.0f;
            // float temp = f2.getSlope(pointsList[index],pointsList[index+1]);
            //  MessageBox.Show(Convert.ToString(temp));
            //          MessageBox.Show(Convert.ToString(x1)+","+(Convert.ToString(y1)));
            float m = 0f;
            if ((p1.Y != p2.Y))
                m = (p2.X - p1.X) * 1.0f / (p1.Y - p2.Y) * 1.0f;   //中垂線斜率
            float m1 = -1.0f / m;
            List<float> line = new List<float>();
            float p1x, p1y,p2x,p2y;
            float c = y1 - m * x1;
            if (p1.X == p2.X) //中垂線為水平
            {
               
           //     g2.DrawLine(p1, 0, y1, 600, y1);
                p1x = 0; 
                p1y = y1;
                p2x = 600f;
                p2y = y1;
                line.Add(p1x); line.Add(p1y); line.Add(p2x); line.Add(p2y);
                return line;
            }
            else if (p1.Y == p2.Y)  //中垂線為重直
            {
               
            //    g2.DrawLine(p1, x1, 0, x1, 600);
                p1x = x1;
                p1y = 0f;
                p2x = x1;
                p2y = 600f;
                line.Add(p1x); line.Add(p1y); line.Add(p2x); line.Add(p2y);
                return line;
            }
            else
            {
                
         //       g2.DrawLine(p1, 0, c, 600, 600 * m + c);
                p1x = 0f;
                p1y = c;
                p2x = 600f;
                p2y = 600*m+c;
                line.Add(p1x); line.Add(p1y); line.Add(p2x); line.Add(p2y);
                return line;
            }
        }
        //找交點
      
        public List<float> interSect(List<float> f1,List<float>f2) { 
            float m1= (f1[1]-f1[3]) / (f1[0]-f1[2]);
            float c1=f1[1]-m1*f1[0];
            float m2= (f2[1]-f2[3]) / (f2[0]-f2[2]);
            float c2=f2[1]-m2*f2[0];
            float interX = (c2-c1) / (m1 - m2);
            float interY = m1 * interX + c1;
            List<float> intersectPoint = new List<float>();
            intersectPoint.Add(interX); intersectPoint.Add(interY);//回傳 x,y [0]為x [1]為y
         //   g2.FillEllipse(Brushes.Red, interX, interY, 5, 5);
            return intersectPoint;
        }

        //=============================================== 三個點 ===================================================

        public void threePoints(List<Point> pointsList, int index, Graphics g2, Pen p1/*,ref List<Point>lines*/)
        {
            //把座標點sort 以X大小，由大排到小分別為pointsFromString[0]、pointsFromString[1]、pointsFromString[2]
            pointsList = pointsList.OrderByDescending(p => p.X).ThenByDescending(p => p.Y).ToList();
            //        MessageBox.Show("1:" + pointsList[0].X + "," + pointsList[0].Y + "\n 2:" + pointsList[1].X + "," + pointsList[1].Y + "\n 3:" + pointsList[2].X + "," + pointsList[2].Y);
            int x1 = pointsList[index].X; int x2 = pointsList[index + 1].X; int x3 = pointsList[index + 2].X;
            int y1 = pointsList[index].Y; int y2 = pointsList[index + 1].Y; int y3 = pointsList[index + 2].Y;
        
            /*外心座標*/
            int A2 = y1 * y1 + x1 * x1;
            int B2 = y2 * y2 + x2 * x2;
            int C2 = y3 * y3 + x3 * x3;
            float d = 2.0f * (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
            float x_out = (A2 * (y2 - y3) + B2 * (y3 - y1) + C2 * (y1 - y2)) * 1.0f / d; //外心x
            float y_out = (A2 * (x3 - x2) + B2 * (x1 - x3) + C2 * (x2 - x1)) * 1.0f / d; //外心y

            //  g.DrawLine(p)
            float m23 = (y2 - y3) * 1.0f / (x2 - x3) * 1.0f; float c23 = y2 - m23 * x2; //求點23斜率
            //      MessageBox.Show(Convert.ToString(m23));
            //   MessageBox.Show(Convert.ToString(x_out) + Convert.ToString(y_out));
            /*if ((y1 != (m23 * x1 + c23)) && x2 != x3)
            { g2.FillEllipse(Brushes.Blue, Convert.ToInt32(x_out), Convert.ToInt32(y_out), 4, 4);// 畫外心}*/
            float pointAx = (x1 + x2) / 2.0f; float pointAy = (y1 + y2) / 2.0f; //12中點
            float pointBx = (x2 + x3) / 2.0f; float pointBy = (y2 + y3) / 2.0f; //23中點
            float pointCx = (x3 + x1) / 2.0f; float pointCy = (y3 + y1) / 2.0f; //31中點

            if ((y1 == y2 && y2 == y3) && (x1 == x2 && x2 == x3)) { }
            else if (((m23 * x1 + c23) < y1) /*|| (x2 == x3 && x1 != x2) */)
            { //點1在線23下方 ***把x2==x3但非三點同線也考慮進去 因為那時斜率負無窮大無法判斷
                //            MessageBox.Show("下");//其實是「上」 因為y座標相反所以看起來是下
                float v32_y = -(x2 - x3); float v32_x = (y2 - y3);
                float v21_y = -(x1 - x2); float v21_x = (y1 - y2);
                float v13_y = -(x3 - x1); float v13_x = (y3 - y1);
                //       MessageBox.Show("1");
                drawDirectLine(x_out, y_out, v32_x, v32_y, g2, p1);
                drawDirectLine(x_out, y_out, v21_x, v21_y, g2, p1);
                drawDirectLine(x_out, y_out, v13_x, v13_y, g2, p1);

            }
            else if ((m23 * x1 + c23) > y1 || ((x2 == x3) && x2 != x1))
            { //在上方 
                //        MessageBox.Show("上");//其實是「下」 因為y座標相反所以看起來是上
                //  MessageBox.Show("2");
                float v12_y = -(x2 - x1); float v12_x = (y2 - y1);
                float v31_y = -(x1 - x3); float v31_x = (y1 - y3);
                float v23_y = -(x3 - x2); float v23_x = (y3 - y2);
                drawDirectLine(x_out, y_out, v23_x, v23_y, g2, p1);
                drawDirectLine(x_out, y_out, v12_x, v12_y, g2, p1);
                drawDirectLine(x_out, y_out, v31_x, v31_y, g2, p1);

            }
            else if (((m23 * x1 + c23) == y1) || (x1 == x2 && x2 == x3))
            {  //三點共線
                if ((x1 == x2 && x2 == x3) && ((y1 != y2 && y2 != y3) && y2 != y3))
                {
                    //          MessageBox.Show("3");
                    g2.DrawLine(p1, 0, (y1 + y2) / 2.0f, 600, (y1 + y2) / 2.0f);
                    g2.DrawLine(p1, 0, (y3 + y2) / 2.0f, 600, (y3 + y2) / 2.0f);
                }
                else if (y1 == y2 && y2 == y3 && ((x1 != x2 && x2 != x3) && x2 != x3))
                {
                    //         MessageBox.Show("4");
                    g2.DrawLine(p1, (x1 + x2) / 2.0f, 0, (x1 + x2) / 2.0f, 600);
                    g2.DrawLine(p1, (x3 + x2) / 2.0f, 0, (x3 + x2) / 2.0f, 600);
                }
                else
                {
                    float c1_2 = pointAy + 1.0f * pointAx / m23;
                    float c2_3 = pointBy + 1.0f * pointBx / m23;
                    g2.DrawLine(p1, 0, c1_2, 600, -600f / m23 + c1_2);
                    g2.DrawLine(p1, 0, c2_3, 600, -600f / m23 + c2_3);
                }
            }

        }
    }
}
