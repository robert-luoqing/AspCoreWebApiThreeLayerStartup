﻿using Microsoft.AspNetCore.Mvc;
using SuperPartner.Biz.Organization;
using SuperPartner.Model.Common;
using SuperPartner.Model.Organization.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPartner.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController
    {
        private UserManager userManager;
        public UserController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// Search user by keyword
        /// </summary>
        /// <param name="req">The conditio property is keyword which use to search User Name or Login Name</param>
        /// <returns>Matched user information</returns>
        [HttpPost("list")]
        public ActionResult<List<WsUserInfo>> GetUserList([FromBody] WsListRequest<string> req)
        {
            return this.userManager.GetUserList(req.Condition, req.Pager);
        }

        /// <summary>
        /// Get user count by keyword
        /// </summary>
        /// <param name="req">The conditio property is keyword which use to search User Name or Login Name</param>
        /// <returns>matched user count</returns>
        [HttpPost("count")]
        public ActionResult<WsResponse<int>> GetUserCount([FromBody] WsListRequest<string> req)
        {
            WsResponse<int> result = this.userManager.GetUserCount(req.Condition);
            return result;
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="user">user information</param>
        /// <returns>Return success status if success</returns>
        [HttpPost("add")]
        public ActionResult<WsResponse> AddUser([FromBody] WsUserDetail user)
        {
            this.userManager.AddUser(user);
            return new WsResponse();
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user">user information</param>
        /// <returns>Return success status if success</returns>
        [HttpPost("update")]
        public ActionResult<WsResponse> UpdateUser([FromBody] WsUserDetail user)
        {
            this.userManager.UpdateUser(user);
            return new WsResponse();
        }
    }
}
