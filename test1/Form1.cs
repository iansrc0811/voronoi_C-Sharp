/*
 版權宣告
 * 作者:葉家維( Jia-Wei Yei)
 * 學號:M023040038
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Threading;



namespace Voronoi
{
    public partial class Form1 : Form
    {
        int buttonIndex = 0;
        
        //存points座標的方法
        static string getPointNames(List<Point> p1)
        {
            p1 = p1.OrderByDescending(p => p.X).ThenByDescending(p=>p.Y).ToList();
            string coordinate = null;
            string coordinate1 = null;
            foreach (Point p in p1)
            {
                coordinate = "(" + Convert.ToString(p.X) + "," + Convert.ToString(p.Y) + ") ";
                coordinate1 = String.Concat(coordinate1, coordinate);
            }
            return (coordinate1);

        }
        //方法end

        public Form1()
        {
            InitializeComponent();
        }
        //動態顯示目前滑鼠座標
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            this.showCoordinate.Text = "滑鼠座標: " + e.X + "," + e.Y;
        }//end



        private void button1_Click_1(object sender, EventArgs e)
        {

        }
//=====================================================
//////////                           //////////////////
/*//////*/    Graphics g; //畫布物件 /////////////////////
/////////                            //////////////////
//======================================================
        functions1 f1 = new functions1();
        List<Point> pointsList = new List<Point>(); // 存 Points 的 List
        
        List<Point> linePoints = new List<Point>();//存線段的兩點

        //=====================================================

        //=============PicktureBox上的事件===================================
        private void pictureBox1_MourseClick(object sender, MouseEventArgs e)
        {
            g = pictureBox1.CreateGraphics();

            g.FillEllipse(Brushes.Red, e.X, e.Y, 5, 5);
            Point pt = new Point(e.X, e.Y);//建立點物件
            pointsList.Add(pt); //滑鼠點畫面顯示點 然後把點座標存起來


            //記錄輸入點然後顯示
            string temp = getPointNames(pointsList);//呼叫 static string pointNames(List<Point> p1) 方法
            this.pointsName.Text = "座標點:" + temp; //顯示點在畫布上的點的座標
        }

        
        //=================== Clear ================================= //清空畫布，points的List
        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pointsList.Clear();
            g.Dispose();
            this.pointsName.Text = "輸入座標點";
            listBox1.Items.Clear();
            buttonIndex = 0;
        }
        //==========================button3(讀檔)===============================================



        string[] dataLines;// = new String[500];
        int lineCounter = 0; //記錄目前得到第幾行
        int countGroups = 1;//記有幾組情行
        Point[][] pointsInGroup = new Point[30][];
        List<int> index = new List<int>(); //設定listbox的index
        List<List<Point>> pointListForEachIndex =new List<List<Point>>(); //二維的list 用來存每組csat裡的座標們  用二維來對應index
        private void button3_Click_1(object sender, EventArgs e)
        {
          //  this.button_readFile.Text = "下一組";
            pointsList.Clear();
            g = pictureBox1.CreateGraphics();////////////////////?? ??
            g.Clear(Color.White);
         /*   if (pointValue == null)
            {*/ 
                OpenFileDialog file = new OpenFileDialog();

                file.ShowDialog();
                string s1 = file.FileName;//讀檔路徑
                this.showFile.Text = s1;
                dataLines = System.IO.File.ReadAllLines(s1); //把文字檔一行行存入pointValue
         //   }
        
              
            while (dataLines != null)
            {
               
                if( dataLines[lineCounter][0] == '0')
                {
                    MessageBox.Show("讀入點數為零，檔案測試停止");
                    lineCounter = 0;
                    countGroups = 0;
                    break;
                }

        
                else if ((dataLines[lineCounter][0] == '#') || (dataLines[lineCounter] == null))
                {
                    lineCounter++; continue;
                } //跳過#
                else {                  
                    List<String> points = new List<String>();//用來動態存有幾個點(String)
                    listBox1.Items.Add("cast"+countGroups);
                    List<Point> indexPoints = new List<Point>();
                   
                    int pointNum = Convert.ToInt32(dataLines[lineCounter]); //把讀到的第一個數字字串(有幾組點)轉成整數
                    for (int i = 0; i < pointNum; i++)
                    {                      
                            points.Add(dataLines[(lineCounter + 1) + i]);                    
                    }
                    for (int j = 0; j < points.Count; j++)
                    {                        
                        string[] tempSlip = points[j].Split(' ');// 以空白為分割字元
                        int x = Convert.ToInt32(tempSlip[0]);
                        int y = Convert.ToInt32(tempSlip[1]);//分成兩個字串 轉為int 分別存為x和y
                        Point pt = new Point(x, y);
                       indexPoints.Add(pt);
                    }
                    pointListForEachIndex.Add(indexPoints);
                    countGroups++; //第幾組
                    lineCounter += (pointNum + 1);
                      points.Clear();
                }               
            }      

        }
        //================================讀檔結束=================================================

        //listbox上的selectedIndexChanged事件
        int preindex = -1;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pointsList.Clear();
           
            g.Clear(Color.White);
            g = pictureBox1.CreateGraphics();
          //  listBox1.SelectedIndex = 0;
            if (preindex != listBox1.SelectedIndex) { 
                preindex = listBox1.SelectedIndex;
                for (int i = 0; i < pointListForEachIndex[preindex].Count; i++) {
                   
                    g.FillEllipse(Brushes.Black , pointListForEachIndex[preindex][i].X, pointListForEachIndex[preindex][i].Y, 5, 5);
                    Point Ptemp = new Point(pointListForEachIndex[preindex][i].X, pointListForEachIndex[preindex][i].Y);
                    pointsList.Add(Ptemp);
                   
                }
                string temp = getPointNames(pointsList);//呼叫 static string pointNames(List<Point> p1) 方法
                this.pointsName.Text = "座標點:"+temp; //顯示點在畫布上的點的座標
            }
        }
        //////listBox end/////
                                      



        //==================================Run===================================================
        private void button_run_Click(object sender, EventArgs e)
        {
            int pointNumber = pointsList.Count;//輸入點的數量         
            Pen p1 = new Pen(Color.Black, 1);//畫筆
            Graphics g2 = pictureBox1.CreateGraphics();
            g2.Clear(Color.White);
            foreach (Point ptemp in pointsList) //再畫一次點 (因為被上一行Clear掉了
            {
                g2.FillEllipse(Brushes.Red, ptemp.X, ptemp.Y, 4, 4);
            }
        //=========================================兩個點======================================
            if (pointNumber == 2) {
                f1.twoPoints(pointsList,0, g2, p1);
                float temp = f1.getSlope(pointsList[0], pointsList[1]);
                MessageBox.Show(Convert.ToString(temp));
            }
//=============================================== 三個點 ===================================================

            else if (pointNumber == 3)
            {
                f1.threePoints(pointsList,0,g2,p1);
            
            }
//=============================================== 三點end ===========================================
            else if(pointNumber>3 &&pointNumber<7){//三點以上 (4~6點)
                //待寫
                List<List<Point>> groupPoints = new List<List<Point>>();
                List<Pen> penList = new List<Pen>();
                Pen penMerge = new Pen(Color.Red,2);
                Pen whitePen = new Pen(Color.White);
                Pen penHyper = new Pen(Color.YellowGreen,2);
                f1.divideFunc(ref groupPoints,ref penList,pointsList, g2);//4~6點時groupPoints有左右兩組點點們
                Thread.Sleep(500);
                for (int i = 0; i < groupPoints.Count; i++)
                {
                    f1.convex(groupPoints[i], groupPoints[i].Count, 0, g2, penList[i]);
                }
                //groupPoints[0]是右  groupPoints[1]是左
                List<List<Point>> intTemp =f1.convexhullMerge(groupPoints[0],groupPoints[1]);
              
                g2.DrawLine(penMerge,intTemp[0][0].X,intTemp[0][0].Y,intTemp[0][1].X,intTemp[0][1].Y);
                g2.DrawLine(penMerge, intTemp[1][0].X, intTemp[1][0].Y, intTemp[1][1].X, intTemp[1][1].Y);
                //f1.twoPoints()
                //上外公切線的點為:
                Point upR = intTemp[1][0];
                Point upL = intTemp[1][1];
                
                List<Point> UP = new List<Point>();//UP[0]上右 UP[1]上左
                UP.Add(upR); UP.Add(upL);
            //    MessageBox.Show(Convert.ToString(UP[0])); MessageBox.Show(Convert.ToString(UP[1]));
                //下外公切線的點為:
                Point dwR = intTemp[0][0];
                Point dwL = intTemp[0][1];
                List<Point> DW = new List<Point>();//DW[0]下右 DW[1]下左
                DW.Add(dwR); DW.Add(dwL);
              //  MessageBox.Show(Convert.ToString(DW[0])); MessageBox.Show(Convert.ToString(DW[1]));
                //hyper plan開始
                List<List<float>> linesPoint = new List<List<float>>();
                if (pointNumber == 4)
                {
                    int i = 0;
                    string temps = null;
                    linesPoint = f1.hyperPlan(pointsList, UP, DW);
                    for (int k = 0;k<3 ; k++)
                    {
                       // MessageBox.Show(Convert.ToString(linesPoint[k][1]));
                    }
                    for ( i = 0; i < 3; i++)
                    {
                        //MessageBox.Show(Convert.ToString(linesPoint[0][i]));
                        
                        
                        g2.DrawLine(penHyper, linesPoint[0+i][0], linesPoint[0+i][1], linesPoint[i+1][0], linesPoint[i+1][1]);
                    }
                    //g2.DrawLine(penHyper, linesPoint[i][0], linesPoint[i][1], linesPoint[i][2], linesPoint[i][3]);
                  //  textBox1.Text = temps;
                }
            
            }
        }

        static int dividFunction(int pointsNum) {
            if (pointsNum == 2 || pointsNum == 3)
            {
                return 2;
            }
            else
                if (pointsNum % 2 == 0)
                    return dividFunction(pointsNum / 2);
                else
                    return dividFunction((pointsNum + 1) / 2);
        }

       
        List<List<int >> floatt = new List<List<int>>( 3);
        
        private void test_Click(object sender, MouseEventArgs e)
        {
            floatt[0].Add(5);
            floatt[0].Add (6);
            floatt[0].Add( 4);
            string temps2 = null;
          
            List<int> temp = floatt[0].OrderByDescending(fl => fl).ToList();
            string temps=null;
            
            for (int i = 0; i < temp.Count; i++) {
                temps = temps+Convert.ToString(temp[i]);
            }
              for (int i = 0; i < floatt.Count; i++)
            {
                temps2 = temps2 + Convert.ToString(floatt[i]);
            }
      //      textBox1.Text = temps+" "+temps2;// Convert.ToString(x);
            /*
            
                    
                    buttonIndex++;
                   
                    textBox1.Text = Convert.ToString(buttonIndex);
            */
                  
        }

        private void stepByStep_Click(object sender, MouseEventArgs e)
        {
        }

        private void stepByStep_Click(object sender, EventArgs e)
        {

            buttonIndex++;
            if (buttonIndex == 0)
            {
                                    int pointNumber = pointsList.Count;//輸入點的數量         
                                    Pen p1 = new Pen(Color.Black, 1);//畫筆
                                    Graphics g2 = pictureBox1.CreateGraphics();
                                    g2.Clear(Color.White);
                                    foreach (Point ptemp in pointsList) //再畫一次點 (因為被上一行Clear掉了
                                    {
                                        g2.FillEllipse(Brushes.Red, ptemp.X, ptemp.Y, 4, 4);
                                    }
                                    //=========================================兩個點======================================
                                    if (pointNumber == 2)
                                    {
                                        f1.twoPoints(pointsList, 0, g2, p1);
                                        float temp = f1.getSlope(pointsList[0], pointsList[1]);
                                        MessageBox.Show(Convert.ToString(temp));
                                    }
                                    //=============================================== 三個點 ===================================================

                                    else if (pointNumber == 3)
                                    {
                                        f1.threePoints(pointsList, 0, g2, p1);

                                    }
                                    //=============================================== 三點end ===========================================
                                    else if (pointNumber > 3 && pointNumber < 7)
                                    {//三點以上 (4~6點)
                                        //待寫
                                        List<List<Point>> groupPoints = new List<List<Point>>();
                                        List<Pen> penList = new List<Pen>();
                                        Pen penMerge = new Pen(Color.Red, 2);
                                        Pen whitePen = new Pen(Color.White);
                                        Pen penHyper = new Pen(Color.YellowGreen, 2);
                                        f1.divideFunc(ref groupPoints, ref penList, pointsList, g2);//4~6點時groupPoints有左右兩組點點們
                                        Thread.Sleep(500);
                                        for (int i = 0; i < groupPoints.Count; i++)
                                        {
                                            f1.convex(groupPoints[i], groupPoints[i].Count, 0, g2, penList[i]);
                                        }
                                        //groupPoints[0]是右  groupPoints[1]是左
                                        List<List<Point>> intTemp = f1.convexhullMerge(groupPoints[0], groupPoints[1]);
                                       
                                            g2.DrawLine(penMerge, intTemp[0][0].X, intTemp[0][0].Y, intTemp[0][1].X, intTemp[0][1].Y);
                                            g2.DrawLine(penMerge, intTemp[1][0].X, intTemp[1][0].Y, intTemp[1][1].X, intTemp[1][1].Y);
                                        
                                        //f1.twoPoints()
                                        //上外公切線的點為:
                                        Point upR = intTemp[1][0];
                                        Point upL = intTemp[1][1];

                                        List<Point> UP = new List<Point>();//UP[0]上右 UP[1]上左
                                        UP.Add(upR); UP.Add(upL);
                                        //     MessageBox.Show(Convert.ToString(UP[0])); MessageBox.Show(Convert.ToString(UP[1]));
                                        //下外公切線的點為:
                                        Point dwR = intTemp[0][0];
                                        Point dwL = intTemp[0][1];
                                        List<Point> DW = new List<Point>();//DW[0]下右 DW[1]下左
                                        DW.Add(dwR); DW.Add(dwL);
                                        //     MessageBox.Show(Convert.ToString(DW[0])); MessageBox.Show(Convert.ToString(DW[1]));
                                      
                                    }

                                }

            else if (buttonIndex == 1)
            {
                                    int pointNumber = pointsList.Count;//輸入點的數量         
                                    Pen p1 = new Pen(Color.Black, 1);//畫筆
                                    Graphics g2 = pictureBox1.CreateGraphics();
                                    g2.Clear(Color.White);
                                    foreach (Point ptemp in pointsList) //再畫一次點 (因為被上一行Clear掉了
                                    {
                                        g2.FillEllipse(Brushes.Red, ptemp.X, ptemp.Y, 4, 4);
                                    }
                                    //=========================================兩個點======================================
                                    if (pointNumber == 2)
                                    {
                                        f1.twoPoints(pointsList, 0, g2, p1);
                                        float temp = f1.getSlope(pointsList[0], pointsList[1]);
                                        MessageBox.Show(Convert.ToString(temp));
                                    }
                                    //=============================================== 三個點 ===================================================

                                    else if (pointNumber == 3)
                                    {
                                        f1.threePoints(pointsList, 0, g2, p1);

                                    }
                                    //=============================================== 三點end ===========================================
                                    else if (pointNumber > 3 && pointNumber < 7)
                                    {//三點以上 (4~6點)
                                        //待寫
                                        List<List<Point>> groupPoints = new List<List<Point>>();
                                        List<Pen> penList = new List<Pen>();
                                        Pen penMerge = new Pen(Color.Red, 2);
                                        Pen whitePen = new Pen(Color.White);
                                        Pen penHyper = new Pen(Color.YellowGreen, 2);
                                        f1.divideFunc(ref groupPoints, ref penList, pointsList, g2);//4~6點時groupPoints有左右兩組點點們
                                        Thread.Sleep(500);
                                        for (int i = 0; i < groupPoints.Count; i++)
                                        {
                                            f1.convex(groupPoints[i], groupPoints[i].Count, 0, g2, penList[i]);
                                        }
                                        //groupPoints[0]是右  groupPoints[1]是左
                                        List<List<Point>> intTemp = f1.convexhullMerge(groupPoints[0], groupPoints[1]);
                                      /*  if (buttonIndex == 1)
                                        {
                                            g2.DrawLine(penMerge, intTemp[0][0].X, intTemp[0][0].Y, intTemp[0][1].X, intTemp[0][1].Y);
                                            g2.DrawLine(penMerge, intTemp[1][0].X, intTemp[1][0].Y, intTemp[1][1].X, intTemp[1][1].Y);
                                        }*/
                                        //f1.twoPoints()
                                        //上外公切線的點為:
                                        Point upR = intTemp[1][0];
                                        Point upL = intTemp[1][1];

                                        List<Point> UP = new List<Point>();//UP[0]上右 UP[1]上左
                                        UP.Add(upR); UP.Add(upL);
                                        //     MessageBox.Show(Convert.ToString(UP[0])); MessageBox.Show(Convert.ToString(UP[1]));
                                        //下外公切線的點為:
                                        Point dwR = intTemp[0][0];
                                        Point dwL = intTemp[0][1];
                                        List<Point> DW = new List<Point>();//DW[0]下右 DW[1]下左
                                        DW.Add(dwR); DW.Add(dwL);
                                        //     MessageBox.Show(Convert.ToString(DW[0])); MessageBox.Show(Convert.ToString(DW[1]));
                                       
                                    }
             }
            else if (buttonIndex == 2) {
                int pointNumber = pointsList.Count;//輸入點的數量         
                Pen p1 = new Pen(Color.Black, 1);//畫筆
                Graphics g2 = pictureBox1.CreateGraphics();
                g2.Clear(Color.White);
                foreach (Point ptemp in pointsList) //再畫一次點 (因為被上一行Clear掉了
                {
                    g2.FillEllipse(Brushes.Red, ptemp.X, ptemp.Y, 4, 4);
                }
                //=========================================兩個點======================================
                if (pointNumber == 2)
                {
                    f1.twoPoints(pointsList, 0, g2, p1);
                    float temp = f1.getSlope(pointsList[0], pointsList[1]);
                    MessageBox.Show(Convert.ToString(temp));
                }
                //=============================================== 三個點 ===================================================

                else if (pointNumber == 3)
                {
                    f1.threePoints(pointsList, 0, g2, p1);

                }
                //=============================================== 三點end ===========================================
                else if (pointNumber > 3 && pointNumber < 7)
                {//三點以上 (4~6點)
                    //待寫
                    List<List<Point>> groupPoints = new List<List<Point>>();
                    List<Pen> penList = new List<Pen>();
                    Pen penMerge = new Pen(Color.Red, 2);
                    Pen whitePen = new Pen(Color.White);
                    Pen penHyper = new Pen(Color.YellowGreen, 2);
                    f1.divideFunc(ref groupPoints, ref penList, pointsList, g2);//4~6點時groupPoints有左右兩組點點們
                    Thread.Sleep(500);
                    for (int i = 0; i < groupPoints.Count; i++)
                    {
                        f1.convex(groupPoints[i], groupPoints[i].Count, 0, g2, penList[i]);
                    }
                    //groupPoints[0]是右  groupPoints[1]是左
                    List<List<Point>> intTemp = f1.convexhullMerge(groupPoints[0], groupPoints[1]);

                    g2.DrawLine(penMerge, intTemp[0][0].X, intTemp[0][0].Y, intTemp[0][1].X, intTemp[0][1].Y);
                    g2.DrawLine(penMerge, intTemp[1][0].X, intTemp[1][0].Y, intTemp[1][1].X, intTemp[1][1].Y);
                    //f1.twoPoints()
                    //上外公切線的點為:
                    Point upR = intTemp[1][0];
                    Point upL = intTemp[1][1];

                    List<Point> UP = new List<Point>();//UP[0]上右 UP[1]上左
                    UP.Add(upR); UP.Add(upL);
                    //    MessageBox.Show(Convert.ToString(UP[0])); MessageBox.Show(Convert.ToString(UP[1]));
                    //下外公切線的點為:
                    Point dwR = intTemp[0][0];
                    Point dwL = intTemp[0][1];
                    List<Point> DW = new List<Point>();//DW[0]下右 DW[1]下左
                    DW.Add(dwR); DW.Add(dwL);
                    //  MessageBox.Show(Convert.ToString(DW[0])); MessageBox.Show(Convert.ToString(DW[1]));
                    //hyper plan開始
                    List<List<float>> linesPoint = new List<List<float>>();
                    if (pointNumber == 4)
                    {
                        int i = 0;
                        string temps = null;
                        linesPoint = f1.hyperPlan(pointsList, UP, DW);
                        for (int k = 0; k < 3; k++)
                        {
                            // MessageBox.Show(Convert.ToString(linesPoint[k][1]));
                        }
                        for (i = 0; i < 3; i++)
                        {
                            //MessageBox.Show(Convert.ToString(linesPoint[0][i]));


                            g2.DrawLine(penHyper, linesPoint[0 + i][0], linesPoint[0 + i][1], linesPoint[i + 1][0], linesPoint[i + 1][1]);
                        }
                        //g2.DrawLine(penHyper, linesPoint[i][0], linesPoint[i][1], linesPoint[i][2], linesPoint[i][3]);
                        //  textBox1.Text = temps;
                    }

                }
            }
        }

        private void test_Click(object sender, EventArgs e)
        {

        }

      

       
    } 
}
    


    

