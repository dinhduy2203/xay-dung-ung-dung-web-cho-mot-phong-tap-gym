using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using GYM_MANAGER_PROJECTFSOFT.Security;
using GYM_MANAGER_PROJECTFSOFT.Models;
using System.Web.Mvc;

namespace GYM_MANAGER_PROJECTFSOFT.Security
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        GYM_Manager_DBEntities db = new GYM_Manager_DBEntities();
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SimpleSessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));
            }
            else
            {
                var accountModel = db.TAIKHOAN;
                CustomPrincipal customPrincipal = new CustomPrincipal(accountModel.Find(SimpleSessionPersister.Username));
                if (!customPrincipal.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));
                }
            }
        }
    }
}