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

        private static HomePage _homePage = new HomePage();
        private static LoginPage _loginPage = new LoginPage();
        private static FirstLoginPage _firstLoginPage = new FirstLoginPage();
        private static AddEntityPage _addEntityPage = new AddEntityPage();

        public static HomePage HomePage
        {
            get { return _homePage; }
        }

        public static LoginPage LoginPage
        {
            get { return _loginPage; }
        }

        public static FirstLoginPage FirstLoginPage
        {
            get { return _firstLoginPage; }
        }

        public static AddEntityPage EntityPage
        {
            get { return _addEntityPage; }
        }

    }
}

