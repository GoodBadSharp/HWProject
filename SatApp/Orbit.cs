using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeptomoby.OrbitTools;

namespace SatApp
{
    public class Orbit
    {
        private double _perigee = 0;
        private double _apogee = 0;
        private double _argPerigee;
        private double _inclination;
        private double _semiMajor = 0; // semi-major axis in km
        private double _semiMinor = 0; // semi-minor axis in km
        private double _raan; // Right Acsension of Ascending Node
        private double _eccentricity;
        private double _meanMotionRev; // mean motion in revolutions per day
        private double _meanMotionRad; // mean motion in radians per minute

        private Tle _tle;
        private TimeSpan _period;

        public double Perigee { get { return _perigee; } }
        public double Apogee { get { return _apogee; } }
        public double Inclination { get { return _inclination; } }
        public double SemiMajor { get { return _semiMajor; } }
        public double SemiMinor { get { return _semiMinor; } }
        public double RAAN { get { return _raan; } }
        public double Eccentricity { get { return _eccentricity; } }
        public double MeanMotionRev { get { return _meanMotionRev; } }
        public double MeanMotionRad { get { return _meanMotionRad; } }
        public double ArgPerigee { get { return _argPerigee; } }
        public TimeSpan Period { get { return _period; } }


        public Orbit(double inclin = 0, double eccen = 0, double raan= 0, double mmrev = 0, double argper = 0) //construction using info from user
        {
            _inclination = inclin;
            _eccentricity = eccen;
            _raan = raan;
            _meanMotionRev = mmrev;
            _argPerigee = argper;

            double rpmin = MeanMotionRev * 2.0 * Math.PI / Globals.MinPerDay; // rads per minute

            double a1 = Math.Pow(Globals.Xke / rpmin, 2.0 / 3.0);
            double e = Eccentricity;
            double i = Inclination * Math.PI / 180.0; // inclination taken in radians for calculations
            double temp = (1.5 * Globals.Ck2 * (3.0 * Globals.Sqr(Math.Cos(i)) - 1.0) / Math.Pow(1.0 - e * e, 1.5));
            double delta1 = temp / (a1 * a1);
            double a0 = a1 * (1.0 - delta1 * ((1.0 / 3.0) + delta1 * (1.0 + 134.0 / 81.0 * delta1)));
            double delta0 = temp / (a0 * a0);

            _meanMotionRad = rpmin / (1.0 + delta0);
            double semiMajorRad = a0 / (1.0 - delta0);
            _perigee = Globals.Xkmper * (semiMajorRad * (1.0 - e) - Globals.Ae);
            _apogee = Globals.Xkmper * (semiMajorRad * (1.0 + e) - Globals.Ae);
            _semiMinor = Globals.Au * semiMajorRad * Math.Sqrt(1.0 - (e * e));
            _semiMajor = Globals.Au * semiMajorRad;

            if (MeanMotionRad == 0)
            {
                _period = new TimeSpan(0, 0, 0);
            }
            else
            {
                double mins = (2.0 * Math.PI / MeanMotionRad);
                int secs = (int)((mins - (int)mins) * 60);

                _period = new TimeSpan(0, (int)mins, secs);
            }
        }


        public Orbit(Tle tle)  //construction using file
            :this(tle.GetField(Tle.Field.Inclination), 
                 tle.GetField(Tle.Field.Eccentricity), 
                 tle.GetField(Tle.Field.Raan), 
                 tle.GetField(Tle.Field.MeanMotion), 
                 tle.GetField(Tle.Field.ArgPerigee))
        {
            _tle = tle;
        }


    }
}
