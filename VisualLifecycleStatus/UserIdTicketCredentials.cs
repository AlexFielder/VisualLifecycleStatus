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

using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;

namespace VaultApp.VisualLifecycleStatus
{
    /// <summary>
    /// Credentials for making server calls with userId and ticket information from a previous sign in.
    /// </summary>
    public class UserIdTicketCredentials : IWebServiceCredentials 
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="serverName">The name of the Vault server.</param>
        /// <param name="vaultName">The name of the Vault.</param>
        /// <param name="userId">The User ID</param>
        /// <param name="ticket">The security ticket.</param>
        public UserIdTicketCredentials(string serverName, string vaultName, long userId, string ticket)
        {
            ServerName = serverName;
            VaultName = vaultName;

            SecurityHeaderInfo = new SecurityHeader(userId, ticket);
        }

        #region IWebServiceCredentials Members

        /// <summary>
        /// Gets the server name.
        /// </summary>
        public string ServerName { get; private set; }

        /// <summary>
        /// Gets the vault name.
        /// </summary>
        public string VaultName { get; private set; }

        /// <summary>
        /// Gets the value telling if a sign in is required before a service can be used.
        /// </summary>
        public bool RequiresSignIn
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the value telling if a sign out should be called when the service goes out of scope.
        /// </summary>
        public bool RequiresSignOut
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the value telling if the credentials can sign in.
        /// </summary>
        public bool SupportsSignIn
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the value telling if the credentials can sign out.
        /// </summary>
        public bool SupportsSignOut
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the security header.
        /// </summary>
        public SecurityHeader SecurityHeaderInfo { get; private set; }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public SecurityHeader SignIn(Autodesk.Connectivity.WebServices.SecurityService secSvc, Autodesk.Connectivity.WebServices.WinAuthService winAuthSvc)
        {
            throw new NotImplementedException();
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void SignOut(SecurityService secSvc, Autodesk.Connectivity.WebServices.WinAuthService winAuthSvc)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
