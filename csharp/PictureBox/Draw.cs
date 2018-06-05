using System;
using System.Drawing;

namespace kurs
{
    class Draw
    {
        public static void Kordynaty(Bitmap bmp, double K, double dX, double dY, Color color)
        {
            for (int i = (bmp.Height / 2) - (int)dY + (int)K; i < bmp.Height; i += (int)K)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    try
                    {
                        bmp.SetPixel(j, i, color);
                    }
                    catch { }
                }
            }

            for (int i = (bmp.Height / 2) - (int)dY - (int)K; i > 0; i -= (int)K)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    try
                    {
                        bmp.SetPixel(j, i, color);
                    }
                    catch { }
                }
            }

            for (int i = (bmp.Width / 2) - (int)dX + (int)K; i < bmp.Width; i += (int)K)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    try
                    {
                        bmp.SetPixel(i, j, color);
                    }
                    catch { }
                }
            }

            for (int i = (bmp.Width / 2) - (int)dX - (int)K; i > 0; i -= (int)K)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    try
                    {
                        bmp.SetPixel(i, j, color);
                    }
                    catch { }
                }
            }

            for (int i = 0; i < bmp.Width; i++)
            {
                bmp.SetPixel(i, (bmp.Height / 2) - (int)dY, Color.Black);
            }

            for (int i = 0; i < bmp.Height; i++)
            {
                bmp.SetPixel((bmp.Width / 2) - (int)dX, i, Color.Black);
            }
        }

        public static void FunctionDraw(Func<double, double> func, Bitmap bmp, double K, double X1, double X2, double dX, double dY, double kX, double kY, Color color)
        {
            int x, y;

            X1 = X1 * kX;
            X2 = X2 * kX;

            double y0 = func(X1 / kX) * kY;
            double y1 = 0;

            for (double i = X1; i <= X2 + 1 / K; i += 1 / K)
            {
                y1 = func(i / kX) * kY;

                if (i > X1)
                {
                    if (Math.Abs(Math.Abs(y1) - Math.Abs(y0)) > (1 / K))
                    {
                        if (y0 > y1)
                        {
                            for (double k = y1; k < y0; k += (1 / K))
                            {
                                x = (bmp.Width / 2) + (int)(i * K) - (int)dX;
                                y = (bmp.Height / 2) - (int)(k * K) - (int)dY;
                                if (x < 0 || y < 0 || x > bmp.Width || y > bmp.Height)
                                    continue;
                                else try { bmp.SetPixel(x, y, color); }
                                    catch { }
                            }
                        }
                        else
                        {
                            for (double l = y0; l < y1; l += (1 / K))
                            {

                                x = (bmp.Width / 2) + (int)(i * K) - (int)dX;
                                y = (bmp.Height / 2) - (int)(l * K) - (int)dY;
                                if (x < 0 || y < 0 || x > bmp.Width || y > bmp.Height)
                                    continue;
                                else try { bmp.SetPixel(x, y, color); }
                                    catch { }
                            }
                        }
                    }
                }

                y0 = y1;

                x = (bmp.Width / 2) + (int)(i * K) - (int)dX;
                y = (bmp.Height / 2) - (int)(y1 * K) - (int)dY;
                if (x < 0 || y < 0 || x > bmp.Width || y > bmp.Height)
                    continue;
                else try { bmp.SetPixel(x, y, color); }
                    catch { }
            }
        }

        public static void DrawLine(Bitmap bmp, double K, Point p1, Point p2, double dX, double dY, double kX, double kY, Color color)
        {
            int x, y;

            double X1 = p1.X * kX;
            double X2 = p2.X * kX;

            double y0 = ((((X1 / kX - X2 / kX) * (p2.Y - p1.Y)) / (X2 / kX - X1 / kX)) + p2.Y) * kY;

            for (double i = Math.Min(X1, X2); i <= Math.Max(X1, X2); i += (1 / K))
            {
                double y1 = ((((i / kX - p2.X) * (p2.Y - p1.Y)) / (p2.X - p1.X)) + p2.Y) * kY;

                if (i > Math.Min(p1.X, p2.X))
                {
                    if (Math.Abs(Math.Abs(y1) - Math.Abs(y0)) > (1 / K))
                    {
                        if (y0 > y1)
                        {
                            for (double k = y1; k < y0; k += (1 / K))
                            {
                                x = (bmp.Width / 2) + (int)(i * K) - (int)dX;
                                y = (bmp.Height / 2) - (int)(k * K) - (int)dY;
                                if (x < 0 || y < 0 || x > bmp.Width || y > bmp.Height)
                                    continue;
                                else try { bmp.SetPixel(x, y, color); }
                                    catch { }
                            }
                        }
                        else
                        {
                            for (double l = y0; l < y1; l += (1 / K))
                            {
                                x = (bmp.Width / 2) + (int)(i * K) - (int)dX;
                                y = (bmp.Height / 2) - (int)(l * K) - (int)dY;
                                if (x < 0 || y < 0 || x > bmp.Width || y > bmp.Height)
                                    continue;
                                else try { bmp.SetPixel(x, y, color); }
                                    catch { }
                            }
                        }
                    }
                }

                y0 = y1;

                x = (bmp.Width / 2) + (int)(i * K) - (int)dX;
                y = (bmp.Height / 2) - (int)(y1 * K) - (int)dY;
                if (x < 0 || y < 0 || x > bmp.Width || y > bmp.Height)
                    continue;
                else try { bmp.SetPixel(x, y, color); }
                    catch { }
            }
        }

        public static void DrawDiagramm(Bitmap bmp, double K, double[] arr, double dX, double dY, double kX, double kY, Color color)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                DrawLine(bmp, K, new Point(i, arr[i]), new Point(i + 1, arr[i + 1]), dX, dY, kX, kY, color);
            }
        }

        public static void DrawLine(Bitmap bmp, double K, Point p, double dX, double dY, double kX, double kY, Color color)
        {
            for (double i = Math.Min(0, p.Y * kY); i <= Math.Max(p.Y * kY, 0); i += (1 / K))
            {
                try { bmp.SetPixel((bmp.Width / 2) + (int)(p.X * kX * K) - (int)dX, (bmp.Height / 2) - (int)(i * K) - (int)dY, color); }
                catch { }
            }
        }
    }
}
