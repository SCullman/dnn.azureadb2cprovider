﻿#region Copyright

// 
// Intelequia Software solutions - https://intelequia.com
// Copyright (c) 2019
// by Intelequia Software Solutions
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

#endregion

#region Usings

using System;
using System.Globalization;
using DotNetNuke.Authentication.Azure.B2C.Components;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Framework;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Services.Authentication;
using DotNetNuke.Services.Authentication.OAuth;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.UI.Utilities;
using log4net;

#endregion

namespace DotNetNuke.Authentication.Azure.B2C
{
    public partial class UserManagement : PortalModuleBase
    {
        #region "Event Handlers"

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            Load += Page_Load;
            JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            ServicesFramework.Instance.RequestAjaxScriptSupport();
            ServicesFramework.Instance.RequestAjaxAntiForgerySupport();
        }
        /// ----------------------------------------------------------------------------- 
        /// <summary> 
        /// Page_Load runs when the control is loaded 
        /// </summary> 
        /// ----------------------------------------------------------------------------- 
        protected void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                ClientAPI.RegisterClientVariable(Page, "portalId", PortalId.ToString(CultureInfo.InvariantCulture), true);
                ClientAPI.RegisterClientVariable(Page, "moduleId", ModuleId.ToString(CultureInfo.InvariantCulture), true);

                ClientAPI.RegisterClientVariable(Page, "AreYouSure", LocalizeString("AreYouSure"), true);
                ClientAPI.RegisterClientVariable(Page, "DeleteMessage", LocalizeString("DeleteMessage"), true);
                ClientAPI.RegisterClientVariable(Page, "Yes", LocalizeString("Yes"), true);
                ClientAPI.RegisterClientVariable(Page, "Cancel", LocalizeString("Cancel"), true);
            }
            catch (Exception exc)
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion

    }
}
