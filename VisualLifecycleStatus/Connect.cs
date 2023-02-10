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
using System.Reflection;
using ACEF = Autodesk.Connectivity.Extensibility.Framework;
using ACEE = Autodesk.Connectivity.Explorer.Extensibility;
using ACW = Autodesk.Connectivity.WebServices;
using ACWT = Autodesk.Connectivity.WebServicesTools;
using Autodesk.Connectivity.WebServicesTools;

[assembly: ACEF.ApiVersion("4.0")]
[assembly: ACEF.ExtensionId("985409AE-929F-4677-A68A-6611B6111915")]

namespace VaultApp.VisualLifecycleStatus
{
    public class Connect : ACEE.CustomEntityHandler
    {
        private WebServiceManager m_serviceManager = null;

        public IEnumerable<ACEE.CommandSite> CommandSites()
        {

            return null;
        }

        public IEnumerable<ACEE.DetailPaneTab> DetailTabs()
        {
            List<ACEE.DetailPaneTab> detailTabs = new List<ACEE.DetailPaneTab>();
            
            ACEE.DetailPaneTab lifecycleStatusTab = new ACEE.DetailPaneTab("File.Tab.VisualLifecycleStatus",
                                                        "Lifecycle Status",
                                                        ACEE.SelectionTypeId.File,
                                                        typeof(Controls.LCDShowControl));

            lifecycleStatusTab.SelectionChanged += new EventHandler<ACEE.SelectionChangedEventArgs>(lifecycleStatusTab_SelectionChanged);

            detailTabs.Add(lifecycleStatusTab);

            return detailTabs;
        }

        void lifecycleStatusTab_SelectionChanged(object sender, ACEE.SelectionChangedEventArgs e)
        {
            try
            {
                Controls.LCDShowControl lifecycleStatusTabControl = e.Context.UserControl as Controls.LCDShowControl;
                lifecycleStatusTabControl.SetServiceManager(m_serviceManager);
                if (lifecycleStatusTabControl != null)
                {
                    if (e.Context.SelectedObject != null)
                    {
                        ACW.File file = m_serviceManager.DocumentService.GetLatestFileByMasterId(e.Context.SelectedObject.Id);
                        if (file != null)
                        {
                            lifecycleStatusTabControl.UpdateDiagram(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("VisualLifecycleStatus encountered an error: " + ex.ToString());
            }
        }

        public IEnumerable<string> HiddenCommands()
        {
            return null;
        }

        public void OnLogOff(ACEE.IApplication application)
        {
            if (m_serviceManager != null)
                m_serviceManager.Dispose();
            m_serviceManager = null;
            Cache.Instance.ClearCache(true);
        }

        public void OnLogOn(ACEE.IApplication application)
        {
            ACWT.UserIdTicketCredentials cred = new UserIdTicketCredentials(
                application.Connection.Server,
                application.Connection.Vault,
                application.Connection.UserID,
                application.Connection.Ticket);

            m_serviceManager = new WebServiceManager(cred);
            Cache.Instance.ServiceManager = m_serviceManager;
        }

        public void OnShutdown(ACEE.IApplication application)
        {
        }

        public void OnStartup(ACEE.IApplication application)
        {

        }
    }
}
