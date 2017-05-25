using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SatApp
{
    static class Pages
    {

        private static LoginPage _loginPage = new LoginPage();
        private static FirstLoginPage _firstLoginPage = new FirstLoginPage();
        private static AddEntityPage _addEntityPage = new AddEntityPage();
        private static ViewDataPage _viewDataPage = new ViewDataPage();
        private static AddManuallyPage _addManuallyPage = new AddManuallyPage();

        public static LoginPage LoginPage
        {
            get { return _loginPage; }
        }

        public static FirstLoginPage FirstLoginPage
        {
            get { return _firstLoginPage; }
        }

        public static ViewDataPage ViewDataPage
        {
            get { return _viewDataPage; }
        }

        public static AddEntityPage AddEntityPage
        {
            get { return _addEntityPage; }
        }

        public static AddManuallyPage AddManuallyPage
        {
            get { return _addManuallyPage; }
        }

    }
}

