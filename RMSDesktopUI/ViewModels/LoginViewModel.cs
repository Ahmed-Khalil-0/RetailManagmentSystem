using Caliburn.Micro;
using RMSDesktopUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        IAPIHelper apiHelper;

        public LoginViewModel(IAPIHelper iAPIHelper)
        {
            apiHelper = iAPIHelper;
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; NotifyOfPropertyChange(() => UserName); }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
                _errorMessage = value;
            }
        }


        public bool IsErrorVisible {
            get {
                return ErrorMessage?.Length > 0 ? true : false;
            }
        }

        public bool CanLogIn
        {
            get
            {
                if (UserName?.Length > 0 && Password?.Length > 0)
                    return true;
                return false;
            }
        }

        public async Task LogIn()
        {
            try
            {
                ErrorMessage = string.Empty;
                var result = await apiHelper.Authenticate(UserName, Password);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
