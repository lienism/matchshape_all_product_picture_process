using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Matchshape_all_product_picture_process
{
    public partial class Matchshape_all_product_process_form : Form
    {
        String open_file_path;
        Mat Crop_result;
        Mat RGB_result;

        
        public Matchshape_all_product_process_form()
        {
            InitializeComponent();
        }
        List<Mat> mats;
        private void file_path_button_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            open_file_path = getDirectory(openFileDialog1.FileName, openFileDialog1.SafeFileName);
            DirectoryInfo Original_Directory = new DirectoryInfo(open_file_path);
            FileInfo[] Files = Original_Directory.GetFiles();

            mats = new List<Mat>();
            
            for(int z = 0; z < Files.Length; z++)
            {
                mats.Add(Cv2.ImRead(Files[z].FullName));
            }

            Mat Case_Image_left;
            Mat Case_Image_right;
            OpenCvSharp.Point[][] result_left_contour;
            HierarchyIndex[] result_left_hierachy;
            OpenCvSharp.Point[][] result_right_contour;
            HierarchyIndex[] result_right_hierachy;
            OpenCvSharp.Point[] Sort_result_left_contour;
            OpenCvSharp.Point[] Sort_result_right_contour;
            int X1 = Convert.ToInt32(X1_textbox.Text);
            int Y1 = Convert.ToInt32(Y1_textbox.Text);
            int X2 = Convert.ToInt32(X2_textbox.Text);
            int Y2 = Convert.ToInt32(Y2_textbox.Text);
            String[] CSV_Left_Result;
            String[] CSV_Right_Result;
            Double result;


            using (StreamWriter file = new StreamWriter(open_file_path + "result.csv", false, Encoding.GetEncoding("UTF-8")))
            {
                file.WriteLine("画像1, 前後 , 角度 , 明るさ , 画像2, 前後 , 角度 , 明るさ , 比較結果");
                for (int i = 0; i < Files.Length; i++)
                {
                    for (int j = i; j < Files.Length; j++)
                    {
                        if ((Path.GetExtension(Files[i].FullName) != ".png" && Path.GetExtension(Files[i].FullName) != ".jpg")
                       || (Path.GetExtension(Files[j].FullName) != ".png" && Path.GetExtension(Files[j].FullName) != ".jpg"))
                        {
                            continue;
                        }
                        Debug.WriteLine(i + " i : " + Files[i].FullName);
                        Debug.WriteLine(j + " j : " + Files[j].FullName);
                        //Mat Case_Image_left = Cv2.ImRead(Files[i].FullName);
                        //Mat Case_Image_right = Cv2.ImRead(Files[j].FullName);
                        if(Crop_checkbox.Checked)
                        {
                            Case_Image_left = Crop(mats[i], X1, Y1, X2, Y2);
                            Case_Image_right = Crop(mats[j], X1, Y1, X2, Y2);
                        }
                        else
                        {
                            Case_Image_left = mats[i];
                            Case_Image_right = mats[j];
                        }
                        
                        Case_Image_left = RGB_Process(Case_Image_left);
                        Case_Image_right = RGB_Process(Case_Image_right);
                        
                        Cv2.ImWrite(Files[i].FullName.Replace(Path.GetExtension(Files[i].FullName), "_1"+ Path.GetExtension(Files[i].FullName)), Case_Image_left);
                        Cv2.CvtColor(Case_Image_left, Case_Image_left, ColorConversionCodes.BGR2GRAY);
                        Cv2.CvtColor(Case_Image_right, Case_Image_right, ColorConversionCodes.BGR2GRAY);
                        Cv2.Threshold(Case_Image_left, Case_Image_left, 1, 255, ThresholdTypes.Binary);
                        Cv2.Threshold(Case_Image_right, Case_Image_right, 1, 255, ThresholdTypes.Binary);

                       
                        Cv2.FindContours(Case_Image_left, out result_left_contour, out result_left_hierachy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                        Cv2.FindContours(Case_Image_right, out result_right_contour, out result_right_hierachy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                        Sort_result_left_contour = Contour_Max_sort(result_left_contour);
                        Sort_result_right_contour = Contour_Max_sort(result_right_contour);
                        result = Cv2.MatchShapes(Sort_result_left_contour, Sort_result_right_contour, ShapeMatchModes.I1);
                        CSV_Left_Result = CSV_information(Files[i].Name);
                        CSV_Right_Result = CSV_information(Files[j].Name);
                        file.WriteLine(CSV_Left_Result[0] + "," + CSV_Left_Result[1] + "," + CSV_Left_Result[2] + "," + CSV_Left_Result[3] + ","
                            + CSV_Right_Result[0] + "," + CSV_Right_Result[1] + "," + CSV_Right_Result[2] + "," + CSV_Right_Result[3] + "," + result);
                        
                        Case_Image_left.Dispose();
                        Case_Image_right.Dispose();
                    }
                }
            }
        }

        String[] Token;
        public String[] CSV_information(String picture_name)
        {
            Token = picture_name.Split('_');
            switch(Token[1])
            {
                case "F":
                    Token[1] = "前面";
                    break;
                case "B":
                    Token[1] = "後面";
                    break;
            }
            Token[3].Replace(Path.GetExtension(picture_name), "");
            return Token;
        }
        public Mat Crop(Mat src , int x1 , int y1 , int x2 , int y2)
        {
            Crop_result = new Mat(src, new Rect(x1, y1, x2 - x1, y2 - y1));
            return Crop_result;
        }
        public OpenCvSharp.Point[] Contour_Max_sort(OpenCvSharp.Point[][] contour)
        {
            for(int a = 0; a < contour.Length; a++)
            {
                if(contour[0].Length < contour[a].Length)
                {
                    contour[0] = contour[a];
                }
            }
            return contour[0];
        }
        public String getDirectory(String fullPath ,String fileName)
        {
            return fullPath.Replace(fileName, "");
        }


        Mat Dummy_mat = new Mat();
        OpenCvSharp.Point[][] Blue;
        OpenCvSharp.Point[][] Green;
        OpenCvSharp.Point[][] Red;
        OpenCvSharp.Point[][] Dummy;

        HierarchyIndex[] blue_hi;
        HierarchyIndex[] green_hi;
        HierarchyIndex[] red_hi;
        Mat[] BGR;
        Mat filter = new Mat();
        double Blue_sum;
        double Green_sum;
        double Red_sum;
        public Mat RGB_Process(Mat src)
        {
            RGB_result = new Mat();
            BGR = Cv2.Split(src);
            for (int i = 0; i < BGR.Length; i++)
            {
                Cv2.CvtColor(BGR[i], BGR[i], ColorConversionCodes.GRAY2BGR);
                Cv2.CvtColor(BGR[i], BGR[i], ColorConversionCodes.BGR2GRAY);
                Cv2.Threshold(BGR[i], BGR[i], 0, 255, ThresholdTypes.Otsu | ThresholdTypes.BinaryInv);
                for (int a = 0; a <= 6; a++)
                {
                    Cv2.Erode(BGR[i], BGR[i], filter);
                    Cv2.Dilate(BGR[i], BGR[i], filter);
                }
            }
            Cv2.FindContours(BGR[0], out Blue, out blue_hi, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            Cv2.FindContours(BGR[1], out Green, out green_hi, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            Cv2.FindContours(BGR[2], out Red, out red_hi, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            Blue_sum = 0;
            for (int i = 0; i < Blue.Length; i++)
            {
                Blue_sum = Blue_sum + Cv2.ContourArea(Blue[i]);
            }
            Green_sum = 0;
            for (int i = 0; i < Green.Length; i++)
            {
                Green_sum = Green_sum + Cv2.ContourArea(Green[i]);
            }
            Red_sum = 0;
            for (int i = 0; i < Red.Length; i++)
            {
                Red_sum = Red_sum + Cv2.ContourArea(Red[i]);
            }
            if (Blue_sum < Red_sum)
            {
                Dummy = Blue;
                Dummy_mat = BGR[0];
                Blue = Red;
                BGR[0] = BGR[2];
                Red = Dummy;
                BGR[2] = Dummy_mat;
            }
            if (Blue_sum < Green_sum)
            {
                Dummy = Blue;
                Dummy_mat = BGR[0];
                Blue = Green;
                Dummy_mat = BGR[1];
                Green = Dummy;
                BGR[1] = Dummy_mat;
            }
            if (Red_sum < Green_sum)
            {
                Dummy = Green;
                Dummy_mat = BGR[1];
                Green = Red;
                BGR[1] = BGR[2];
                Red = Dummy;
                BGR[1] = Dummy_mat;
            }

            Cv2.BitwiseOr(BGR[0], BGR[1], RGB_result);
            Cv2.BitwiseAnd(RGB_result, BGR[2], RGB_result);
            Cv2.BitwiseAnd(RGB_result.CvtColor(ColorConversionCodes.GRAY2BGR), src, RGB_result);

            foreach (var item in BGR)
            {
                item.Dispose();
            }
            BGR = null;
            
            return RGB_result;
        }
    }
}
