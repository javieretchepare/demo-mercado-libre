using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class TraceIp
    {
        public string ip { get; set; }
        public string fecha
        {
            get { return DateTime.Now.ToLongDateString(); }
        }
        public string pais
        {
            get { return country.Name; }
        }
        public string iso
        {
            get { return geolocalización.countryCode3; }
        }
        public string idioma
        {
            get { return country.NativeName; }
        }
        public string moneda {
            get { return country.Currencies[0].Name; }
        }
        public string hora
        {
            get { return DateTime.Now.ToLongTimeString(); }
        }
        public string distancia
        {
            get
            {
                double coordinates = new Coordinates(country.Latlng[0], country.Latlng[1])
                .DistanceTo(
                    new Coordinates(33, 44),
                    UnitOfLength.Kilometers
                );

                return Math.Truncate(coordinates).ToString();
            }
        }

        public Geolocalización geolocalización { get; set; }
        public Country country { get; set; }

    }
}


