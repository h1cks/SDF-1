using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SDF_1
{
    public partial class SDFMainForm : Form
    {
        Bitmap _sourceBitmap;
        Bitmap _destinationBitmap;

        public SDFMainForm()
        {
            InitializeComponent();
        }

        private void Mi_loadBitmap_Click(object sender, EventArgs e)
        {
            Image load_ = Image.FromFile("e:\\test.png");

            if (load_ != null)
            {
                _sourceBitmap = new Bitmap(load_);

                pc_mainWindow.Image = _sourceBitmap;
                pc_mainWindow.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        //===============================================================================================================


        byte[] _rgbWorkingSet = null;
        int _width;

        private void pb_execute_Click(object sender, EventArgs e)
        {
            unsafe
            {
                byte* dest = null;

                if (_sourceBitmap != null)
                {
                    _destinationBitmap = new Bitmap(_sourceBitmap);

                    Rectangle rect = new Rectangle(0, 0, _destinationBitmap.Width, _destinationBitmap.Height);

                    BitmapData bmpData = _destinationBitmap.LockBits(rect, ImageLockMode.ReadWrite, _destinationBitmap.PixelFormat);

                    _width = _destinationBitmap.Width;

                    IntPtr ptr = bmpData.Scan0;

                    dest = (byte*)ptr;

                    int bytes = Math.Abs(bmpData.Stride) * _destinationBitmap.Height;
                    _rgbWorkingSet = new byte[bytes];

                    for (int counter = 0; counter < _rgbWorkingSet.Length; counter += 4)
                    {
                        _rgbWorkingSet[counter] = dest[counter];
                    }

                    CalculateSDF(_sourceBitmap, 6);


                    System.Runtime.InteropServices.Marshal.Copy(_rgbWorkingSet, 0, ptr, bytes);

                    // Unlock the bits.
                    _destinationBitmap.UnlockBits(bmpData);

                    pc_mainWindow.Image = _destinationBitmap;
                }
            }
        }

        //===============================================================================================================


        //===============================================================================================================

        void WritePixelToWorkingSet(int x, int y, byte r, byte g, byte b, byte a)
        {
            int pixel = (y * _width * 4) + x * 4;

            _rgbWorkingSet[pixel] = b;
            _rgbWorkingSet[pixel + 1] =g;
            _rgbWorkingSet[pixel + 2] = r;
            _rgbWorkingSet[pixel + 3] = a;
        }

        //===============================================================================================================

        protected void CalculateSDF(Bitmap source, int searchDistance)
        {
            prg_processing.Maximum = source.Width * source.Height;

            Color referenceColour_ = new Color();


            for (int y = 0; y < source.Height; ++y)
            {
                for (int x = 0; x < source.Width; ++x)
                {
                    Color rgba = source.GetPixel(x, y);

                    float distance = float.MaxValue;

                    referenceColour_ = rgba;

                    if (rgba.R == 255)
                    {
                        distance = 0;
                    }
                    else
                    {
                        // Get pixel
                        //    float alpha = source.GetPixel(x, y).R;

                        // Distance to closest pixel which is the inverse of a
                        // start on float.MaxValue so we can be sure we found something


                        // Search coordinates, x min/max and y min/max
                        int fxMin = Math.Max(x - searchDistance, 0);
                        int fxMax = Math.Min(x + searchDistance, source.Width);
                        int fyMin = Math.Max(y - searchDistance, 0);
                        int fyMax = Math.Min(y + searchDistance, source.Height);

                        for (int fx = fxMin; fx < fxMax; ++fx)
                        {
                            for (int fy = fyMin; fy < fyMax; ++fy)
                            {
                                // Get pixel to compare to


                                byte referenceAlpha = source.GetPixel(fx, fy).R;

                                // If not equal a
                                //if (rgba.A == white)
                                if (referenceAlpha > 250)
                                {
                                    // Calculate distance
                                    float xd = x - fx;
                                    float yd = y - fy;
                                    float d = (float)Math.Sqrt((xd * xd) + (yd * yd));

                                    // Compare absolute distance values, and if smaller replace distnace with the new oe
                                    if (d < distance)
                                    {
                                        distance = d;

                                        referenceColour_ = source.GetPixel(fx, fy);
                                    }
                                }
                            }
                        }
                    }

                    // If we found a new distance, otherwise we'll just use A 

                    float newAlpha_ = 0;



                    if (distance < float.MaxValue)
                    {
                

                        Debug.Assert(distance >= 0.0f);

                        // Clamp distance to -/+ 
                        distance = Clamp(distance, searchDistance, 0);

                        // Convert from -search,+search to 0,+search*2 and then convert to 0.0, 1.0 and invert
                        if (distance == 0)
                        {
                            newAlpha_ = 1;
                        }
                        else
                        {
                            newAlpha_ = 1f - (distance / searchDistance);
                 //           newAlpha_ /= 2;
                        }
                        
                    }


                    byte red_ = (byte)(referenceColour_.R);
                    byte green_ = (byte)(referenceColour_.G);
                    byte blue_ = (byte)(referenceColour_.B);

                    Debug.Assert(newAlpha_ <= 1.0f);

                    byte targetAlpha_ = (byte)(newAlpha_ * 255);

                    WritePixelToWorkingSet(x, y, targetAlpha_, targetAlpha_, targetAlpha_, targetAlpha_);


                    // Write pixel out
                    //     target.SetPixel(x, y, new Color(a, a, a, 1));
                }
                prg_processing.Value = source.Height * y;

                Application.DoEvents();
            }


        }

        float ToFloat(byte val)
        {
            int temp = val;

            float dest = temp;


            return dest;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Clamp<T>(T value, T max, T min)
where T : System.IComparable<T>
        {
            Debug.Assert(max.CompareTo(min) >= 0);

            T result = value;
            if (value.CompareTo(max) > 0)
            {
                result = max;
            }
            else if (value.CompareTo(min) < 0)
            {
                result = min;
            }

            return result;
        }

        private void pb_save_Click(object sender, EventArgs e)
        {
            _destinationBitmap.Save("e:\\output.png");
        }
    }
}
