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
using ACW = Autodesk.Connectivity.WebServices;
using System.Drawing.Drawing2D;

namespace VaultApp.VisualLifecycleStatus.Controls
{
    public class LCState:IDrawable,IResponseable
    {
        private int m_seqIndex = 0;
        private string m_stateName = "WIP";
        private RectangleF m_rect;
        private bool m_isMouseIn = false;
        private bool m_isCurrent = false;
        SolidBrush m_goldBrush = new SolidBrush(Color.Gold);
        Brush m_normalStateBrush = new SolidBrush(Color.LightBlue);
        SolidBrush m_activeStateBrush = new SolidBrush(Color.Gold);
        SolidBrush m_fontBrush = new SolidBrush(Color.Black);
        Pen m_borderPen = new Pen(Color.Black);
        ACW.LfCycState m_serverState = null;
        float m_centerPointX = 0;
        float m_centerPointY = 0;
        public static LCState CURRENTSTATE = null;

        public float CenterPointX
        {
            get { return m_centerPointX; }
            set { m_centerPointX = value; }
        }

        public float CenterPointY
        {
            get { return m_centerPointY; }
            set { m_centerPointY = value; }
        }

        public long StateID { get { return m_serverState.Id; } }
        public string StateName { get { return m_serverState.DispName; } }


        Pen m_goldPen = new Pen(Color.Gold, 2);

        public LCState(string name, int seqIndex)
        {
            m_stateName = name;
            m_seqIndex = seqIndex;
        }

        public LCState(ACW.LfCycState serverState, int seqIndex, bool isCurrent)
        {
            m_serverState = serverState;
            m_seqIndex = seqIndex;
            m_stateName = m_serverState.DispName;
            m_isCurrent = isCurrent;

            if (m_isCurrent)
                CURRENTSTATE = this;

            m_normalStateBrush = new LinearGradientBrush(new PointF(0, 0), new PointF(150, 50),
                Color.CornflowerBlue,
                Color.White);
            ((LinearGradientBrush)m_normalStateBrush).SetSigmaBellShape(.4f, .4f);
        }

        public int SeqIndex
        {
            get { return m_seqIndex; }
        }

        #region IDrawable

        public void Draw(System.Drawing.Graphics g)
        {
            if (m_isMouseIn)
            {
                HighLight(g);
            }

            
            if (m_isCurrent)
            {                
                g.FillRectangle(m_activeStateBrush, m_rect);
            }
            else
            {
                g.FillRectangle(m_normalStateBrush, m_rect);               
            }

            g.DrawRectangle(m_borderPen, m_rect.X, m_rect.Y, m_rect.Width, m_rect.Height);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            g.DrawString(m_stateName, new Font("Arial", SizeManager.FontSize), m_fontBrush, m_rect, sf);
        }

        private void HighLight(System.Drawing.Graphics g)
        {
            m_rect.Inflate(SizeManager.InflateSizeY, SizeManager.InflateSizeY);
            g.DrawRectangle(m_goldPen, m_rect.Left,m_rect.Top,m_rect.Width,m_rect.Height);
            m_rect.Inflate(-1 * SizeManager.InflateSizeY, -1 * SizeManager.InflateSizeY);

            if (!m_isCurrent && m_isMouseIn)
            {
                LCState.CURRENTSTATE.HighLight(g);
                LCStateTran.ToStates2Trans[this].HighLight(g);
            }

        }

        public void HighLightFrom(Graphics g)
        {
            HighLight(g);
        }

        public void HighLightTo(Graphics g)
        {
            HighLight(g); ;
        }

        #endregion

        #region IResponseable
        public void OnResize()
        {
            m_centerPointX = m_seqIndex * SizeManager.CellWidth+SizeManager.LTX;
            m_centerPointY = m_seqIndex * SizeManager.CellHeigh+SizeManager.LTY;
            float ltX = m_centerPointX - SizeManager.StateWidth/2;
            float ltY = m_centerPointY - SizeManager.StateHeigh/2;
            m_rect = new RectangleF(ltX, ltY, SizeManager.StateWidth, SizeManager.StateHeigh);
        }

        public bool OnMouseIn(int x, int y)
        {
            m_isMouseIn = m_rect.Contains(x, y);
            return m_isMouseIn;
        }

        public LCState GetAvailToStateByMouseDoubleClick()
        {
            if (!m_isMouseIn)
                return null;

            return this;
        }

        #endregion

    }
}
