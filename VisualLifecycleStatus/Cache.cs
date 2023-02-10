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

using Autodesk.Connectivity.WebServicesTools;

namespace VaultApp.VisualLifecycleStatus
{
    public class Cache
    {
        private List<long> m_allowTranIds;
        public List<long> AllowTranIds
        {
            get
            {
                if (m_allowTranIds == null && ServiceManager != null)
                    m_allowTranIds = ServiceManager.DocumentServiceExtensions.GetAllowedFileLifeCycleStateTransitionIds().ToList();
                return m_allowTranIds;
            }
        }

        public WebServiceManager ServiceManager { get; set; }


        public static Cache Instance = new Cache();

        private Cache()
        {
            ServiceManager = null;
            m_allowTranIds = null;
        }

        public void ClearCache(bool clearConnection)
        {
            if (clearConnection)
                ServiceManager = null;

            m_allowTranIds = null;
        }
    }
}
