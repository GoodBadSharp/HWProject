using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Zeptomoby.OrbitTools;

namespace SatApp
{
    public class Satellite
    {
        private string _name;
        private int _launchYear;
        private int _noradId;
        private Orbit _orbit;

        public Orbit Orbit
        {
            get { return _orbit; }
            set { _orbit = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LaunchYear
        {
            get { return _launchYear; }
            set { _launchYear = value; }
        }
        
        public int NoradID
        {
            get { return _noradId; }
            set { _noradId = value; }
        }

        public Satellite(Orbit orbit, string name, int id, int year)
        {
            Orbit = orbit;
            Name = name;
            LaunchYear = year;
            NoradID = id;
        }

        public Satellite(Tle tle, string name = "")
        {
            Orbit = new Orbit(tle);
            NoradID = int.Parse(tle.NoradNumber.Trim());
            if (name == "") { Name = tle.Name; }
            else { Name = name; } 
        }

        public string SatelliteInfo
        {
            get { return $"{_name} - {_launchYear} - {_noradId}"; }
        }

        //public EciTime PositionEci(DateTime utc)
        //{
        //    return Orbit.PositionEci(utc);
        //}

        //public EciTime PositionEci(double mpe)
        //{
        //    return Orbit.PositionEci(mpe);
        //}
    }
}
