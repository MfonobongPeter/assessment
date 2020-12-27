using EventManager.Models;
using EventManager.Repositories;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        EventUserRepository userRepository = null;
        private EventManagerDbEntities db = null;
        public AdminController()
        {
            try
            {
                 db = new EventManagerDbEntities();
                 userRepository = new EventUserRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // GET: Admin
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult CreateAdminUser()
        {
            LoadDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAdminUser([Bind(Include = "UserId,UserFirstName,UserLastName, UserAddress, EmailAddress,PasswordHash,PasswordSalt,PhoneNumber, RoleId, IsActivated,CreatedOn")] EventUsersViewModel user)
        {
            var validateEmail = userRepository.ValidateEmailAddress(user.EmailAddress);
            if (validateEmail == null)
            {
                var getRecord = await userRepository.RegisterEventUser(user, user.RoleId);
                if (getRecord != null)
                {
                    ViewBag.DisplayMessage = "success";
                    ModelState.AddModelError("", "Account created successfully!");
                }
                else
                {
                    ViewBag.DisplayMessage = "Info";
                    ModelState.AddModelError("", "Ooops, something went wrong, Account not created! kindly check your input and try again.");
                }
            }
            else
            {
                ViewBag.DisplayMessage = "Info";
                ModelState.AddModelError("", "This email address has already been used, enter a different email address!");
            }
            LoadDropDownList();
            return View();
        }

        public ActionResult ViewAdminUsers()
        {
            var getList = userRepository.GetEventUserList();
            return View(getList);
        }

        private void LoadDropDownList()
        {
            try
            {
                
                ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}