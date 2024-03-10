﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace fyiReporting.CRI
{
    internal class PixelConversions
    {
        static public int MmXFromPixel(Graphics g, float x)
        {
            int mm = (int)(x / g.DpiX * 25.4f);	// convert to pixels

            return mm;
        }

        static public int MmYFromPixel(Graphics g, float y)
        {
            int mm = (int)(y / g.DpiY * 25.4f);	// convert to pixels

            return mm;
        }

        static public int PixelXFromMm(Graphics g, float x)
        {
            int pixels = (int)((x * g.DpiX) / 25.4f);	// convert to pixels

            return pixels;
        }

        static public int PixelYFromMm(Graphics g, float y)
        {
            int pixel = (int)((y * g.DpiY) / 25.4f);	// convert to pixels

            return pixel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="OptimalHeight"></param>
        /// <param name="OptimalWidth"></param>
        /// <returns></returns>
        static public float GetMagnification(Graphics g, int width, int height, float OptimalHeight, float OptimalWidth)
        {

            float AspectRatio = OptimalHeight / OptimalWidth;
            float r = (float)height / (float)width;
            if (r <= AspectRatio)
            {   // height is the limiting value
                r = PixelConversions.MmYFromPixel(g, height) / OptimalHeight;
            }
            else
            {   // width is the limiting value
                r = PixelConversions.MmXFromPixel(g, width) / OptimalWidth;
            }
            // Set the magnification limits
            //    Specification says 80% to 200% magnification allowed
            if (r < .8f)
                r = .8f;
            else if (r > 2f)
                r = 2;

            return r;
        }

    }
}
