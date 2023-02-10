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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACW = Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;

namespace VaultApp.VisualLifecycleStatus.Controls
{
    public partial class LCDShowControl : UserControl
    {
        private List<IDrawable> m_allDrawObjects = new List<IDrawable>();
        private List<IResponseable> m_allResponseObjecs = new List<IResponseable>();
        private List<LCState> m_allLCState = new List<LCState>();
        private Dictionary<long, LCState> m_allID2State = new Dictionary<long, LCState>();
        private IDrawable m_currentDrawObj = null;
        private ACW.File m_selectFile = null;
        private WebServiceManager m_serviceManager;

        public LCDShowControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
        }

        public void SetServiceManager(WebServiceManager serviceManager)
        {
            m_serviceManager = serviceManager;
        }

        private void m_mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                foreach (IDrawable drawObj in m_allDrawObjects)
                    drawObj.Draw(g);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        private void m_mainPictureBox_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                ForceResize();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        private void ForceResize()
        {
            SizeManager.Resize(this.m_mainPictureBox.Width, this.m_mainPictureBox.Height);

            foreach (IResponseable respObj in m_allResponseObjecs)
                respObj.OnResize();

            this.Refresh();
        }

        private void m_mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBoxMouseMove(e);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        private void PictureBoxMouseMove(MouseEventArgs e)
        {
            IResponseable currentResponseObj = null;
            foreach (IResponseable respObj in m_allResponseObjecs)
            {
                if (respObj.OnMouseIn(e.X, e.Y))
                {
                    currentResponseObj = respObj;
                }
            }

            //Reorder draw object
            IDrawable currentDrawObj = currentResponseObj as IDrawable;
            if (currentDrawObj != null && m_allDrawObjects.Contains(currentDrawObj))
            {
                m_allDrawObjects.Remove(currentDrawObj);
                m_allDrawObjects.Add(currentDrawObj);
            }


            
            if (currentDrawObj != m_currentDrawObj)
            {
                m_currentDrawObj = currentDrawObj;

                //Update the info
                LCState currenState = m_currentDrawObj as LCState;
                LCStateTran currentTrans = m_currentDrawObj as LCStateTran;

                if (currenState != null && currenState != LCState.CURRENTSTATE)
                {
                    currentTrans =LCStateTran.ToStates2Trans[currenState];
                }

                if (currentTrans != null)
                {
                    this.m_transInfoRichTextBox.Text = currentTrans.ToString();
                }
                else
                {
                    this.m_transInfoRichTextBox.Text = "No Transaction selected";
                }
                    
            }

            this.Refresh();
        }

        public void UpdateDiagram(ACW.File selectedFile)
        {
            m_allDrawObjects.Clear();
            m_allResponseObjecs.Clear();
            m_allLCState.Clear();
            m_allID2State.Clear();
            LCStateTran.ToStates2Trans.Clear();
            this.m_nameLabel.Text = string.Empty;
            this.m_despTextBox.Text = string.Empty;
            m_allDrawObjects.Add(new BackGroundGrid());
            this.m_transInfoRichTextBox.Text = "No Transaction selected";

            if (selectedFile != null && selectedFile.FileLfCyc != null && selectedFile.FileLfCyc.LfCycDefId > 0)
            {
                long currentStateID = selectedFile.FileLfCyc.LfCycStateId;
                m_selectFile = selectedFile;

                long[] lcdefIds = new long[] { selectedFile.FileLfCyc.LfCycDefId };
                ACW.LfCycDef[] lfCycDefs = m_serviceManager.DocumentServiceExtensions.GetLifeCycleDefinitionsByIds(lcdefIds);

                int index = 1;
                if (lfCycDefs == null || lfCycDefs.Length != 1)
                    return;

                ACW.LfCycDef def = lfCycDefs[0];

                this.m_nameLabel.Text = def.DispName;
                this.m_despTextBox.Text = def.Descr;

                ACW.LfCycState[] lfcyStates = def.StateArray;
                foreach (ACW.LfCycState lfs in lfcyStates)
                {

                    LCState lcState = new LCState(lfs, index, lfs.Id == currentStateID);
                    index++;
                    m_allDrawObjects.Add(lcState);
                    m_allResponseObjecs.Add(lcState);
                    m_allLCState.Add(lcState);
                    m_allID2State.Add(lcState.StateID, lcState);
                }

                foreach (ACW.LfCycTrans lft in def.TransArray)
                {
                    LCState fromState = m_allID2State[lft.FromId];
                    LCState toState = m_allID2State[lft.ToId];

                    LCStateTran lcTran = new LCStateTran(fromState, toState, lft, m_serviceManager);
                    m_allDrawObjects.Add(lcTran);
                    m_allResponseObjecs.Add(lcTran);


                }

            }
            else
            {
                this.m_despTextBox.Text = "No lifecycle definition on the file.";
            } 

            SizeManager.SetStateCount(m_allLCState.Count);
            ForceResize();        
        }

        private void m_leftPanel_Resize(object sender, EventArgs e)
        {
            try
            {
                if (m_leftPanel.Width <= 50)
                    m_leftPanel.Width = 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        private void m_splitter_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (m_leftPanel.Width == 0)
                    m_leftPanel.Width = 200;
                else
                    m_leftPanel.Width = 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        private void m_mainPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBoxMouseDoubleClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        private void PictureBoxMouseDoubleClick()
        {
            if(m_selectFile == null)
                return;

            LCState availToState = null;
            foreach (IResponseable respObj in m_allResponseObjecs)
            {
                availToState = respObj.GetAvailToStateByMouseDoubleClick();
                if (availToState != null)
                    break;
            }

            if (availToState == null)
                return;

            if (!LCStateTran.ToStates2Trans.ContainsKey(availToState))
                return;

            if (!LCStateTran.ToStates2Trans[availToState].IsTransactionAllowed)
                return;


            try
            {
                string message = "Do you want to update lifecycle state from '{0}' to '{1}'?";
       
                if (MessageBox.Show(string.Format(message, LCState.CURRENTSTATE.StateName, availToState.StateName), "Update Lifecycle State", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_serviceManager.DocumentServiceExtensions.UpdateFileLifeCycleStates(new long[] { m_selectFile.MasterId }, new long[] { availToState.StateID }, "UpdateFileLifeCycleStates");

                    RefreshVault();
                }                
            }
            catch
            {
                MessageBox.Show("Please use the update lifecycle state command.");
            } 

        }

        private void RefreshVault()
        {
            System.Windows.Forms.SendKeys.Send("{F5}");
        }
    }
}
