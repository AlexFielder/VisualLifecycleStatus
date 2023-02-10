/*=====================================================================
  
  This file is part of the Autodesk Vault API Code Samples.

  Copyright (C) Autodesk Inc.  All rights reserved.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VaultApp.VisualLifecycleStatus.Controls
{
    public class BackGroundGrid:IDrawable
    {
        #region IDrawable

        public void Draw(System.Drawing.Graphics g)
        {
            Pen backgroundGridPen = new Pen(Color.LightGray);
            for (int index = 0; index <= SizeManager.StateCount + 1; index++)
            {
                float hLineX1 = SizeManager.LTX;
                float hLineY1 = SizeManager.LTY + index * SizeManager.CellHeigh;
                float hLineX2 = SizeManager.LTX + (SizeManager.StateCount + 1) * SizeManager.CellWidth;
                float hLineY2 = SizeManager.LTY + index * SizeManager.CellHeigh;
                g.DrawLine(backgroundGridPen, hLineX1, hLineY1, hLineX2, hLineY2);

                float vLineX1 = SizeManager.LTX + index * SizeManager.CellWidth;
                float vLineY1 = SizeManager.LTY;
                float vLineX2 = SizeManager.LTX + index * SizeManager.CellWidth;
                float vLineY2 = SizeManager.LTY + (SizeManager.StateCount + 1) * SizeManager.CellHeigh;
                g.DrawLine(backgroundGridPen, vLineX1, vLineY1, vLineX2, vLineY2);
            }
        }

        #endregion
    }
}
