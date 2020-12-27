using EventManager.Models;
using EventManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.Interfaces
{
    public interface IEventUserInterface 
    {
        Task<EventUser> RegisterEventUser(EventUsersViewModel user, int roleId);       
        Task<bool> UpdateEventUserDetails(EventUsersViewModel eventUser, string username);
        string SelectPasswordOnSuccessfulPasswordValidation(string username);
        string SelectPasswordSaltForValidation(string username);
        bool CheckPassword(string unHashedPassword, string username);
        EventUser GetUserByEmailAddress(string email);
        EventUser ValidateEmailAddress(string emailAddress);
        List<EventUsersViewModel> GetEventUserList();
        Task<bool> DeleteEventUser(long id);
        bool Verify(string email, string password);
        void Save();
    }
}
