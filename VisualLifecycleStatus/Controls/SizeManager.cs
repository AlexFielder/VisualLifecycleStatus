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

namespace VaultApp.VisualLifecycleStatus.Controls
{
    public static class SizeManager
    {
        private static float m_LTX = 10;
        private static float m_LTY = 10;
        private static float m_cellWidth = 100;
        private static float m_cellHeigh = 100;
        private static float m_stateWidth = 100;
        private static float m_stateHeigh = 100;
        private static float m_transWidth = 100;
        private static float m_transHeigh = 100;
        private static int m_stateCount = 6;
        private static float m_inflateSizeX = 4;
        private static float m_inflateSizeY = 4;
        private static float m_TransNormalSize = 10;
        private static float m_TransInfX = 10;
        private static float m_TransInfY = 10;
        private static float m_fontSize = 10;

        public static float LTX { get { return m_LTX; } }
        public static float LTY { get { return m_LTY; } }
        public static float CellWidth { get { return m_cellWidth; } }
        public static float CellHeigh { get { return m_cellHeigh; } }
        public static float StateWidth { get { return m_stateWidth; } }
        public static float StateHeigh { get { return m_stateHeigh; } }
        public static float TransWidth { get { return m_transWidth; } }
        public static float TransHeigh { get { return m_transHeigh; } }
        public static float InflateSizeX { get { return m_inflateSizeX; } }
        public static float InflateSizeY { get { return m_inflateSizeY; } }
        public static float TransNormalSize { get { return m_TransNormalSize; } }
        public static float TransInfX { get { return m_TransInfX; } }
        public static float TransInfY { get { return m_TransInfY; } }
        public static float FontSize { get { return m_fontSize; } }

        public static int StateCount { get { return m_stateCount; } }


        public static void SetStateCount(int stateCount)
        {
            m_stateCount = stateCount;
        }

        public static void Resize(float sumWidth, float sumHeigh)
        {
            m_cellWidth = (sumWidth - 2 * m_LTX) / (m_stateCount + 1);
            m_cellHeigh = (sumHeigh - 2 * m_LTY) / (m_stateCount + 1);
            m_stateWidth = m_cellWidth * 4 / 5;
            m_stateHeigh = m_cellHeigh * 4 / 5;
            m_transWidth = Math.Min(m_cellWidth, m_cellHeigh) * 2 / 5;
            m_transHeigh = Math.Min(m_cellWidth, m_cellHeigh) * 2 / 5;
            m_inflateSizeX = m_cellWidth / 20;
            m_inflateSizeY = m_cellHeigh / 20;
            m_TransNormalSize = Math.Min(m_cellWidth, m_cellHeigh) / 5;
            m_TransInfX = m_stateWidth - m_TransNormalSize;
            m_TransInfY = m_transHeigh - m_TransNormalSize;
            m_fontSize = Math.Min(m_cellWidth, m_cellHeigh) / 10 > 10 ? Math.Min(m_cellWidth, m_cellHeigh) / 10 : 10;
        }
    }
}
