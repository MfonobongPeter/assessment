using EventManager.Interfaces;
using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EventManager.Repositories
{
    public class EventUserRepository : IEventUserInterface, IDisposable
    {
        private EventManagerDbEntities db = null;

        public EventUserRepository()
        {
            try
            {
                db = new EventManagerDbEntities();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EventUserRepository(EventManagerDbEntities db)
        {
            try
            {
                this.db = db;
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }

       // This validates user email address on login
        public EventUser ValidateEmailAddress(string emailAddress)
        {
            EventUser getEmail = null;
            try
            {
                getEmail = (from user in db.EventUsers.Where(x => x.EmailAddress.Equals(emailAddress)) select user).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return getEmail;
        }

        public List<EventUsersViewModel> GetEventUserList()
        {
            List<EventUsersViewModel> userRecord = null;
            try
            {
                userRecord = (from userDetail in db.EventUsers
                              join role in db.Roles on userDetail.RoleId equals role.RoleId
                              where (userDetail.IsActivated == true)
                              select new EventUsersViewModel
                              {
                                  UserId = userDetail.UserId,
                                  UserFirstName = userDetail.UserFirstName,
                                  UserLastName = userDetail.UserLastName,                                
                                  EmailAddress = userDetail.EmailAddress,
                                  PhoneNumber = userDetail.PhoneNumber,
                                  UserAddress = userDetail.UserAddress,
                                  Role = role.RoleName,
                                  CreatedOn = userDetail.CreatedOn.ToString(),                                 
                                  Status = userDetail.IsActivated == true ? "Active": "Deactivated" 
                              }).ToList();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return userRecord;
        }

        public async Task<bool> DeleteEventUser(long id)
        {
            bool getState = false;
            try
            {
                var remove = (from d in db.EventUsers.Where(x => x.UserId == id) select d).FirstOrDefault();
                if (remove != null)
                {
                    db.EventUsers.Remove(remove);
                    await db.SaveChangesAsync();
                    getState = true;
                }
            }
            catch (Exception ex)
            {
                getState = false;
                throw ex;
            }
            return getState;
        }

        public async Task<bool> UpdateEventUserDetails(EventUsersViewModel eventUser, string username)
        {           
            bool status = false;
            var getRecord = (from r in db.EventUsers.Where(x => x.EmailAddress.Equals(username)) select r).FirstOrDefault();
            if (getRecord != null)
            {
                try
                {
                    
                    getRecord.UserFirstName = eventUser.UserFirstName;
                    getRecord.UserLastName = eventUser.UserLastName;
                    getRecord.EmailAddress = eventUser.EmailAddress;
                    getRecord.UserAddress = eventUser.UserAddress;                  
                    getRecord.PhoneNumber = eventUser.PhoneNumber;
                    await db.SaveChangesAsync();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    throw ex;
                }
            }
            return status;
        }

        public async Task<EventUser> RegisterEventUser(EventUsersViewModel user, int roleId)
        {
            EventUser itemCollections = null;
            var salt = Guid.NewGuid().ToString();
            var securityAnswerSalt = Crypto.GenerateSalt();
            var saltedPassword = user.PasswordHash + salt;
            var hashedPassword = Crypto.HashPassword(saltedPassword);

            try
            {
                itemCollections = new EventUser
                {
                    UserLastName = user.UserLastName,
                    UserFirstName = user.UserFirstName,
                    UserAddress = user.UserAddress,
                    EmailAddress = user.EmailAddress,
                    PasswordHash = hashedPassword,
                    PasswordSalt = salt,
                    PhoneNumber = user.PhoneNumber,
                    CreatedOn = DateTime.Now,
                    RoleId = roleId,
                    IsActivated = true
                };
                db.EventUsers.Add(itemCollections);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return itemCollections;
        }

        public CustomLoginViewModel GetUserLoginDetails(CustomLoginViewModel user)
        {
            CustomLoginViewModel userRecord = null;
            try
            {
                userRecord = (from userDetail in db.EventUsers
                              join role in db.Roles on userDetail.RoleId equals role.RoleId
                              where (userDetail.EmailAddress == user.EmailAddress && userDetail.PasswordHash == user.Password)
                              select new CustomLoginViewModel
                              {
                                  UserId = userDetail.UserId,
                                  EmailAddress = userDetail.EmailAddress,
                                  Password = userDetail.PasswordHash,
                                  Roles = role.RoleName,
                                  RoleId = role.RoleId,
                                  UserLastname = userDetail.UserLastName,
                                  UserFirstname = userDetail.UserFirstName,
                                  IsActivated = userDetail.IsActivated,
                              }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
            return userRecord;
        }

        public string SelectPasswordOnSuccessfulPasswordValidation(string email)
        {
            string getHashPwd = null;
            try
            {
                getHashPwd = (from p in db.EventUsers.Where(x => x.EmailAddress == email) select p.PasswordHash).FirstOrDefault();
                if (getHashPwd != null)
                {
                    return getHashPwd;
                }
                else
                {
                    // log.Error(ex.Message);
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                return null;
                throw ex;
            }
        }

        public string SelectPasswordSaltForValidation(string username)
        {

            string getHashPwd = null;
            try
            {
                getHashPwd = (from p in db.EventUsers.Where(x => x.EmailAddress == username) select p.PasswordSalt).FirstOrDefault();
                if (getHashPwd != null)
                {
                    return getHashPwd;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                return null;
                throw ex;
            }
        }

        public bool CheckPassword(string unHashedPassword, string username)
        {
            EventUser getHashPwd = null;
            try
            {
                getHashPwd = (from p in db.EventUsers.Where(x => x.EmailAddress == username) select p).FirstOrDefault();
                if (getHashPwd != null)
                {
                    return Crypto.VerifyHashedPassword(getHashPwd.PasswordHash, unHashedPassword);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }


        public EventUser GetUserByEmailAddress(string email)
        {
            EventUser getUserDetail = null;
            try
            {
                getUserDetail = (from user in db.EventUsers.Where(x => x.EmailAddress.Trim() == email.Trim()) select user).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
            }
            return getUserDetail;
        }

        public bool Verify(string email, string password)
        {
            var salt = SelectPasswordSaltForValidation(email);
            var hashedPassword = SelectPasswordOnSuccessfulPasswordValidation(email);
            var saltedPassword = password + salt;
            return Crypto.VerifyHashedPassword(hashedPassword, saltedPassword);
        }

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }


       
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                }
                disposed = true;
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                //log.Error(ex.Message);
                throw ex;
            }
        }
    }
}