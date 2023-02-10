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
using Autodesk.Connectivity.WebServicesTools;
using System.Drawing.Drawing2D;
namespace VaultApp.VisualLifecycleStatus.Controls
{
    public class LCStateTran : IDrawable, IResponseable
    {
        private LCState m_fromLCState = null;
        private LCState m_toLCState = null;
        private RectangleF m_rect;
        private RectangleF m_outCircleRect;
        private RectangleF m_inCircleRect;

        private bool m_isMouseIn = false;
        private ACW.LfCycTrans m_serverTrans = null;
        SolidBrush m_goldBrush;
        SolidBrush m_unselectedBrush;
        SolidBrush m_unallowBrush;
        SolidBrush m_allowBrush;
        Pen m_allowPen;
        Pen m_unAllowPen;
        SolidBrush m_allowHightBrush;
        SolidBrush m_unAllowHightBrush;
        Pen m_goldPen;
        Pen m_arrowPen;
        Pen m_unarrowPen;
        Pen m_blackPen;
        float centerPointX = 0;
        float centerPointY = 0;
        private bool m_isAllowTrans = true;
        WebServiceManager m_serviceManager;
        public static Dictionary<LCState, LCStateTran> ToStates2Trans = new Dictionary<LCState, LCStateTran>();

        public LCState FromLCState { get { return m_fromLCState; } }
        public LCState ToLCState { get { return m_toLCState; } }
        public bool IsTransactionAllowed { get { return m_isAllowTrans; } }

        public LCStateTran(LCState fromState, LCState toState, ACW.LfCycTrans trans, WebServiceManager serviceManager)
        {
            m_serviceManager = serviceManager;
            m_fromLCState = fromState;
            m_toLCState = toState;
            m_serverTrans = trans;
            m_isAllowTrans = Cache.Instance.AllowTranIds.Contains(m_serverTrans.Id);
            
            InitializeDrawingTools();

            if (m_fromLCState == LCState.CURRENTSTATE)
                ToStates2Trans.Add(toState, this);
        }

        private void InitializeDrawingTools()
        {
            m_goldBrush = new SolidBrush(Color.Gold);
            m_unselectedBrush = new SolidBrush(Color.LightGray);
            m_unallowBrush = new SolidBrush(Color.LightGray);
            m_allowPen = new Pen(Color.LightGreen, 2);
            m_unAllowPen = new Pen(Color.LightGray, 2);
            m_allowBrush = new SolidBrush(Color.LightGreen);
            m_allowHightBrush = new SolidBrush(Color.Green);
            m_unAllowHightBrush = new SolidBrush(Color.Red);
            m_goldPen = new Pen(Color.Gold, 2);
            m_arrowPen = new Pen(Color.Green, 2);
            m_unarrowPen = new Pen(Color.Red, 2);
            m_blackPen = new Pen(Color.Black, 4);
            m_unarrowPen.DashStyle = DashStyle.Dash;            

        }


        #region IDrawable

        public void Draw(System.Drawing.Graphics g)
        {
            if (m_isMouseIn)
            {
                FromLCState.HighLightFrom(g);
                ToLCState.HighLightTo(g);
                HighLight(g);
            }
            else
            {
                if (m_isAllowTrans)
                {
                    g.DrawEllipse(m_allowPen, m_outCircleRect);
                    g.FillEllipse(m_allowBrush, m_inCircleRect);
                }
                else
                {
                    g.DrawEllipse(m_unAllowPen, m_outCircleRect);
                    g.FillEllipse(m_unallowBrush, m_inCircleRect);
                }      
            }
        }

        public void HighLight(Graphics g)
        {


            m_rect.Inflate(SizeManager.InflateSizeY, SizeManager.InflateSizeY);
            g.DrawEllipse(m_goldPen, m_rect.Left, m_rect.Top, m_rect.Width, m_rect.Height);
            m_rect.Inflate(-1 * SizeManager.InflateSizeY, -1 * SizeManager.InflateSizeY);


            if (m_isAllowTrans)
            {
                g.FillEllipse(m_allowHightBrush, m_rect);
            }
            else
            {
                g.FillEllipse(m_unAllowHightBrush, m_rect);
            }

            DrawArrows(g);

        }

        private void DrawArrows(Graphics g)
        {
            float arrowLength = SizeManager.CellWidth / 10;
            float arrowWidth = SizeManager.CellWidth / 30;

            float fromBorderX1 = FromLCState.CenterPointX;
            float fromBorderY1;
            float fromBorderX2 = centerPointX;
            float fromBorderY2;
            float arrowFromX1 = centerPointX + arrowWidth;
            float arrowFromY1;
            float arrowFromX2 = centerPointX - arrowWidth;
            float arrowFromY2;

            float toBorderX1;
            float toBorderY1 = centerPointY;
            float toBorderX2;
            float toBorderY2 = ToLCState.CenterPointY;
            float arrowToX1;
            float arrowToY1 = centerPointY + arrowWidth;
            float arrowToX2;
            float arrowToY2 = centerPointY - arrowWidth;
            if (centerPointY > FromLCState.CenterPointY)
            {
                fromBorderY1 = FromLCState.CenterPointY + SizeManager.StateHeigh / 2;
                fromBorderY2 = centerPointY - SizeManager.TransHeigh / 2;
                toBorderX1 = centerPointX + SizeManager.TransWidth / 2;
                toBorderX2 = ToLCState.CenterPointX - SizeManager.StateWidth / 2;
                arrowFromY2 = arrowFromY1 = fromBorderY2 - arrowLength;
                arrowToX1 = arrowToX2 = toBorderX2 - arrowLength;

            }
            else
            {
                fromBorderY1 = FromLCState.CenterPointY - SizeManager.StateHeigh / 2;
                fromBorderY2 = centerPointY + SizeManager.TransHeigh / 2;
                toBorderX1 = centerPointX - SizeManager.TransWidth / 2;
                toBorderX2 = ToLCState.CenterPointX + SizeManager.StateWidth / 2;
                arrowFromY2 = arrowFromY1 = fromBorderY2 + arrowLength;
                arrowToX1 = arrowToX2 = toBorderX2 + arrowLength;
            }

            PointF from1 = new PointF(fromBorderX1, fromBorderY1);
            PointF from2 = new PointF(fromBorderX2, fromBorderY2);
            PointF to1 = new PointF(toBorderX1, toBorderY1);
            PointF to2 = new PointF(toBorderX2, toBorderY2);
            PointF fromArrow1 = new PointF(arrowFromX1, arrowFromY1);
            PointF fromArrow2 = new PointF(arrowFromX2, arrowFromY2);
            PointF toArrow1 = new PointF(arrowToX1, arrowToY1);
            PointF toArrow2 = new PointF(arrowToX2, arrowToY2);

            if (m_isAllowTrans)
            {
                g.DrawLine(m_arrowPen, from1, from2);
                g.FillPolygon(m_allowHightBrush, new PointF[] { from2, fromArrow1, fromArrow2 });
   

                g.DrawLine(m_arrowPen, to1, to2);
                g.FillPolygon(m_allowHightBrush, new PointF[] { to2, toArrow1, toArrow2 });
            }
            else
            {
                g.DrawLine(m_unarrowPen, from1, from2);
                g.DrawLine(m_unarrowPen, to1, to2);
            }
        }

        #endregion

        #region IResponseable

        public bool OnMouseIn(int x, int y)
        {
            m_isMouseIn = m_rect.Contains(x, y);
            return m_isMouseIn;
        }

        public void OnResize()
        {
            centerPointX = FromLCState.SeqIndex * SizeManager.CellWidth + SizeManager.LTX;
            centerPointY = ToLCState.SeqIndex * SizeManager.CellHeigh + SizeManager.LTY;
            float ltX = centerPointX - SizeManager.TransWidth / 2;
            float ltY = centerPointY - SizeManager.TransHeigh / 2;
            m_rect = new RectangleF(ltX, ltY, SizeManager.TransWidth, SizeManager.TransHeigh);

            float circleLTX1 = centerPointX - SizeManager.TransNormalSize / 2;
            float circleLTY1 = centerPointY - SizeManager.TransNormalSize / 2;
            m_outCircleRect = new RectangleF(circleLTX1, circleLTY1, SizeManager.TransNormalSize, SizeManager.TransNormalSize);

            float inCircleTX1 = centerPointX - SizeManager.TransNormalSize / 3;
            float inCricleTY1 = centerPointY - SizeManager.TransNormalSize / 3;
            m_inCircleRect = new RectangleF(inCircleTX1, inCricleTY1, SizeManager.TransNormalSize * 2 / 3, SizeManager.TransNormalSize * 2 / 3);
        }

        public LCState GetAvailToStateByMouseDoubleClick()
        {
            if (!m_isMouseIn)
                return null;

            if (FromLCState != LCState.CURRENTSTATE)
                return null;

            if (!m_isAllowTrans)
                return null;

            return ToLCState;
        }

        #endregion


        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();           
            strBuilder.Append(FromLCState.StateName + " To "+ ToLCState.StateName);
            if (!m_isAllowTrans)
            {
                strBuilder.Append(" is not allowed");
                return strBuilder.ToString();
            }
            strBuilder.Append(Environment.NewLine);
            strBuilder.Append(Environment.NewLine);


            strBuilder.Append("Bump revision:");
            strBuilder.Append(Environment.NewLine);
            switch (m_serverTrans.Bump)
            {
                case ACW.BumpRevisionEnum.BumpPrimary:
                    strBuilder.Append("Bump Primary");
                    break;
                case ACW.BumpRevisionEnum.BumpSecondary:
                    strBuilder.Append("Bump Secondary");
                    break;
                case ACW.BumpRevisionEnum.BumpTertiary:
                    strBuilder.Append("Bump Tretiary");
                    break;
                case ACW.BumpRevisionEnum.None:
                    strBuilder.Append("Will not bump");
                    break;
            }
            strBuilder.Append(Environment.NewLine);
            strBuilder.Append(Environment.NewLine);


            strBuilder.Append("Sync property:");
            strBuilder.Append(Environment.NewLine);
            switch (m_serverTrans.SyncPropOption)
            {
                case ACW.JobSyncPropEnum.SyncPropOnly:
                    strBuilder.Append("Sync property only");
                    break;

                case ACW.JobSyncPropEnum.SyncPropAndUpdateView:
                    strBuilder.Append("Sync property and update view");
                    break;
                    
                case ACW.JobSyncPropEnum.None:
                    strBuilder.Append("Will not sync property");
                    break;
            }
            strBuilder.Append(Environment.NewLine);
            strBuilder.Append(Environment.NewLine);

            strBuilder.Append("Security:");
            strBuilder.Append(Environment.NewLine);
            if (m_serverTrans.TransBasedSec)
            {
                strBuilder.Append("Apply the base security");
            }
            else
            {
                strBuilder.Append("Will not apply the base security");
            }
            strBuilder.Append(Environment.NewLine);
            strBuilder.Append(Environment.NewLine);

            if (m_serverTrans.RuleSet != null)
            {
                strBuilder.Append("Rule:");
                strBuilder.Append(Environment.NewLine);
                strBuilder.Append(m_serverTrans.RuleSet.Desc);
                strBuilder.Append(Environment.NewLine);
                strBuilder.Append(Environment.NewLine);
            }
            
            return strBuilder.ToString();
        }
    }
}
