using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Zeptomoby.OrbitTools;
using System.Collections.ObjectModel;

namespace SatApp
{
    public class DataContainer
    { 
        private List<Satellite> _satellites = new List<Satellite>();

        public  List<Satellite> Satellites
        { get { return _satellites; } set { _satellites = value; } }
    }

    public class Serialization
    {
        List<Satellite> satellites = new List<Satellite>();

        static void SerializeData()
        {

        }

        static void DeserializeData()
        {

        }

    }
}
