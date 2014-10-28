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
    public partial class functions1 :Interface1
    {
        //Graphics g3 = new Form1.pictureBox1.CreateGraphics();
        /*畫射線function*/
        public void drawDirectLine(float xout, float yout, float x_Line, float y_Line, Graphics g, Pen p)
        {
            float yTemp = 0;
            if (x_Line > 0/* && y_Line != 0 */)
            {
                yTemp = yout + y_Line * (600 * 1.0f - xout) / (x_Line);
                g.DrawLine(p, xout, yout, 600, yTemp);
            }
            if (x_Line < 0)
            {
                yTemp = yout + y_Line * (-xout) / (x_Line);
                g.DrawLine(p, xout, yout, 0, yTemp);
            }
            if (x_Line == 0)
            {
                if (y_Line > 0)
                    g.DrawLine(p, xout, yout, xout, 600);
                if (y_Line < 0)
                    g.DrawLine(p, xout, yout, xout, 0);
            }
        }

        

   ///
        /////////////////////////////////////////////////
   //     List<List<Point>> groupPoints = new List<List<Point>>();
       
        /// ////////////////////////////////////////////////
   
            public void divideFunc(ref List<List<Point>>pointListGroup,ref List<Pen> penList,List<Point> pointsList,Graphics g) {
              
                pointsList = pointsList.OrderByDescending(p => p.X).ThenByDescending(p=>p.Y).ToList();
                int count = pointsList.Count;
                List<Point> pR = new List<Point>();
                List<Point> pL = new List<Point>();//小於六點時只要分成兩邊就好 所以用pL pR 
               pointListGroup.Add(pR);
               pointListGroup.Add(pL);
                Pen penL = new Pen(Color.BlueViolet,1);
                Pen penR = new Pen(Color.DarkOrange, 1);
                penList.Add(penL);
                penList.Add(penR);
                if (count == 4)
                {
                    twoPoints(pointsList, 0, g, penL);
                            
                            for (int i = 0; i < 2; i++)
                            {
                                pR.Add(pointsList[i]);
                            }
                            foreach (Point ptemp in pR) //把點塗別的色
                            {
                                g.FillEllipse(Brushes.BlueViolet, ptemp.X, ptemp.Y, 4, 4);
                            }

                     //       groupPoints.Add(pL);
                    twoPoints(pointsList, 2, g, penR);
                           
                            for (int i = 2; i < 4; i++)
                            {
                                pL.Add(pointsList[i]);
                            }
                            foreach (Point ptemp in pL) //把點塗別的色
                            {
                                g.FillEllipse(Brushes.DarkOrange, ptemp.X, ptemp.Y, 4, 4);
                            }
                          //  groupPoints.Add(pR);
                }
                else if (count == 5)
                {
                    twoPoints(pointsList, 0, g, penL);
                          //  List<Point> pL = new List<Point>();
                            for (int i = 0; i < 2; i++)
                            {
                                pR.Add(pointsList[i]);
                            }
                            foreach (Point ptemp in pR) //把點塗別的色
                            {
                                g.FillEllipse(Brushes.BlueViolet, ptemp.X, ptemp.Y, 4, 4);
                            }
                          //  groupPoints.Add(pL);


                    threePoints(pointsList, 2, g, penR);
                       //     List<Point> pR = new List<Point>();
                            for (int i = 2; i < 5; i++)
                            {
                                pL.Add(pointsList[i]);
                            }
                            foreach (Point ptemp in pL) //把點塗別的色
                            {
                                g.FillEllipse(Brushes.DarkOrange, ptemp.X, ptemp.Y, 4, 4);
                            }
                           // groupPoints.Add(pR);
                }
                else if (count == 6)
                {
                    threePoints(pointsList, 0, g, penL);

                         //   List<Point> pL = new List<Point>();
                            for (int i = 0; i < 3; i++)
                            {
                                pR.Add(pointsList[i]);
                            }
                            foreach (Point ptemp in pR) //把點塗別的色
                            {
                                g.FillEllipse(Brushes.BlueViolet , ptemp.X, ptemp.Y, 4, 4);
                            }
                         //   groupPoints.Add(pL);
                    threePoints(pointsList, 3, g, penR);
                          //  List<Point> pR = new List<Point>();
                            for (int i = 3; i < 6; i++)
                            {
                                pL.Add(pointsList[i]);
                            }
                            foreach (Point ptemp in pL) //把點塗別的色
                            {
                                g.FillEllipse(Brushes.DarkOrange, ptemp.X, ptemp.Y, 4, 4);
                            }
                       //     groupPoints.Add(pR);
                }
                else { 

                }
            }


            Point[] UL = new Point[2]; //上公
            Point[] DL = new Point[2];//下公

      public void convex(List<Point> pointsList,int pointNum,int index,Graphics g2,Pen p1) {//畫convex hull
                Pen p2 = new Pen(Color.Red, 1);
                Pen p3 = new Pen(Color.Blue, 1);
                if (pointNum ==2)
                {
                    g2.DrawLine(p1, pointsList[index].X, pointsList[index].Y, pointsList[index+1].X,pointsList[index+1].Y);
                }
                else if (pointNum == 3) {
                    g2.DrawLine(p1, pointsList[index].X, pointsList[index].Y, pointsList[index + 1].X, pointsList[index + 1].Y);
                    g2.DrawLine(p1, pointsList[index+1].X, pointsList[index+1].Y, pointsList[index + 2].X, pointsList[index + 2].Y);
                    g2.DrawLine(p1, pointsList[index+2].X, pointsList[index+2].Y, pointsList[index].X, pointsList[index].Y);
                }
                else if (pointNum == 4)
                { 
                }
                else //一組五點以上
                { 
                    
                }


            }
      public float getSlope(Point p1, Point p2) {
          return ( (p2.Y - p1.Y) * 1.0f / (p2.X - p1.X));
      }
        protected int findMax( List<float>f ){
            List<float> temp = f.OrderByDescending(fl => fl).ToList();
            for (int i = 0; i < f.Count; i++) {
                if (f[i] == temp[0])
                {
                    return i;
                }
                //else return -1;
            }
                return -1;
        }
        protected int findMin(List<float> f)
        {
            List<float> temp = f.OrderByDescending(fl => fl).ToList();
            for (int i = 0; i < f.Count; i++)
            {
                if (f[i] == temp[temp.Count-1])
                {
                    return i;
                }
                //else return -1;
            }
            return -1;
        }


      public List<List<Point>> convexhullMerge(List<Point> pointsList1, List<Point> pointsList2)//右,左
      { //目標是找到 上下公切線
          int count1 = pointsList1.Count;
          int count2 = pointsList2.Count;
          List<List<float>> slopeLeftToRight = new List<List<float>> ();
          List<List<float>> slopeRightToLeft = new List<List<float>> ();
          //slopeLeftToRight= slopeLeftToRight.OrderByDescending(f=>f).ToList();
          for(int k =0;k<count2;k++){ //左對右 做m 加到List<List<float>>  
                                        //如: slopeLeftToRight[0][2] 為 左pointsListt2[0] 和 右pointsList1[2] 的M 
                                        //這樣就可以從裡面找到最小或最大值惹
              List<float> templ = new List<float>();
              for (int i = 0; i < count1; i++)
              {
                  float temp =getSlope(pointsList2[k], pointsList1[i]);
                  templ.Add(temp);
              }
              slopeLeftToRight.Add(templ);
          }

          for (int k = 0; k < count1; k++)//右對左 做m 加到List<List<float>>  
          {
              List<float> templ = new List<float>();
              for (int i = 0; i < count2; i++)
              {
                  float temp = getSlope(pointsList1[k], pointsList2[i]);
                  templ.Add(temp);
              }
              slopeRightToLeft.Add(templ);
          }
          //// 以上建立好兩邊相對的slope
          List<List<Point>> returnlist = new List<List<Point>>();
          List<int> listInt1 = new List<int>(); //下公切線兩點
          List<int> listInt2 = new List<int>(); //上公切線兩點
          int rightP, leftP,compareTemp;
          rightP=findMin(slopeLeftToRight[0]);
          leftP = findMax(slopeRightToLeft[rightP]);
          rightP = findMin(slopeLeftToRight[leftP]);
          leftP = findMax(slopeRightToLeft[rightP]);
          rightP = findMin(slopeLeftToRight[leftP]);

          List<Point> dwP = new List<Point>();
          Point p1 = pointsList1[rightP];
          Point p2 = pointsList2[leftP];
          dwP.Add(p1); dwP.Add(p2);

       /*   listInt1.Add(rightP);
          listInt1.Add(leftP);*/
          returnlist.Add(dwP);//下
///////////////////////////////////////////////////////////////
          rightP = findMax(slopeLeftToRight[0]);
          leftP = findMin(slopeRightToLeft[rightP]);
          rightP = findMax(slopeLeftToRight[leftP]);
          leftP = findMin(slopeRightToLeft[rightP]);
          rightP = findMax(slopeLeftToRight[leftP]);

          List<Point> upP = new List<Point>();
          Point p3 = pointsList1[rightP];
          Point p4 = pointsList2[leftP];
          upP.Add(p3); upP.Add(p4);
/*
          listInt2.Add(rightP);
          listInt2.Add(leftP);*/
          returnlist.Add(upP);//上

          return returnlist;
     }



        //    Graphics g2;
      public List<List<float>> hyperPlan(List<Point> pointsList, List<Point> up, List<Point> dw/*, List<Point> lines*/)
      {
                List<List<float>> hyperPlanPoints = new List<List<float>>();
                if (pointsList.Count == 4)
                {
                    List<float> upLine =   pointsInLine(up[0], up[1]);
                    List<float> rightPoints = pointsInLine(pointsList[0],pointsList[1]);
                    List<float> leftPoints = pointsInLine(pointsList[2],pointsList[3]);
                    List<float> upRight=interSect(upLine, rightPoints);
                    List<float> upLeft = interSect(upLine, leftPoints);
                    //找上公切線和上面的交點
                    float mUP =   1.0f * (-up[1].X + up[0].X)/(1.0f * (up[1].Y - up[0].Y));
                    float cUP = (up[0].Y + up[1].Y) / 2.0f - mUP *( (up[0].X + up[1].X) / 2.0f);
                    List<float> upLinePoint = new List<float>();
                    upLinePoint.Add((600-cUP)/mUP);
                    upLinePoint.Add(600f);
                    hyperPlanPoints.Add(upLinePoint); //加入list當做第一點
                    /////////////////////////
                //    MessageBox.Show("1");
                    float mDW = 1.0f * (-dw[1].X + dw[0].X) / 1.0f * (dw[1].Y - dw[0].Y);
                    float cDW = (dw[0].Y + dw[1].Y) / 2.0f - mDW * (dw[0].X + dw[1].X) / 2.0f;
                    List<float> dwLinePoint = new List<float>();
                    dwLinePoint.Add((- cDW)*1.0f / mDW);
                    dwLinePoint.Add(0f);
                    if (upRight[1] > upLeft[1]) {
                        if ((up[0].X == pointsList[0].X) &&(up[0].Y == pointsList[0].Y)){ 
                            hyperPlanPoints.Add(upRight);//第二點
                      //      MessageBox.Show("21");
                            hyperPlanPoints.Add(interSect( leftPoints ,pointsInLine(up[1], pointsList[1])));//第三點
                      //      MessageBox.Show("31");
                            hyperPlanPoints.Add(dwLinePoint);//第四點
                      //      MessageBox.Show("41");
                            return hyperPlanPoints;
                        }else if ((up[0].X == pointsList[1].X) && (up[0].Y == pointsList[1].Y)) {
                            hyperPlanPoints.Add(upRight);//第二點
                      //      MessageBox.Show("22");
                            hyperPlanPoints.Add(interSect(leftPoints, pointsInLine(up[1], pointsList[0])));//第三點
                       //     MessageBox.Show("32");
                            hyperPlanPoints.Add(dwLinePoint);//第四點
                       //     MessageBox.Show("42");
                            return hyperPlanPoints;
                        }
                    }
                    else {//if (upRight[1] < upLeft[1]) {
                        if ((up[1].X == pointsList[2].X) && (up[1].Y == pointsList[2].Y))
                        {
                            hyperPlanPoints.Add(upLeft);
                       //     MessageBox.Show("23");
                            hyperPlanPoints.Add(interSect(leftPoints, pointsInLine(up[0], pointsList[3])));//第三點
                        //    MessageBox.Show("33");
                            hyperPlanPoints.Add(dwLinePoint);//第四點
                      //      MessageBox.Show("43");
                            return hyperPlanPoints;
                        }
                        else { 
                        //if ((up[1].X == pointsList[3].X) && (up[1].Y == pointsList[3].Y))
                      //  {
                            hyperPlanPoints.Add(upLeft);
                       //     MessageBox.Show("24");
                            hyperPlanPoints.Add(interSect(rightPoints, pointsInLine(up[0], pointsList[2])));//第三點
                      //      MessageBox.Show("34");
                            hyperPlanPoints.Add(dwLinePoint);//第四點
                      //      MessageBox.Show("44");
                            return hyperPlanPoints;
                        }
                    }
                } MessageBox.Show("GG"); return null;
            }
       
        }    
    }

