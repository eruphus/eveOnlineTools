/*
    Copyright 2012 Alexander Wölfel 
 
    This file is part of eveStatic.

    eveStatic is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    eveStatic is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

    Diese Datei ist Teil von eveStatic.

    EveStatic ist Freie Software: Sie können es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es nützlich sein wird, aber
    OHNE JEDE GEWÄHELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gewährleistung der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License für weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */

using FluentNHibernate.Mapping;
using libEveStatic.database.entities.INV;

namespace libEveStatic.database.entities.MAP
{

    /*
     * 
CREATE TABLE dbo.mapCelestialStatistics
(
  celestialID     int,
  temperature     float,
  spectralClass   varchar(10),
  luminosity      float,
  age             float,
  life            float,
  orbitRadius     float,
  eccentricity    float,
  massDust        float,
  massGas         float,
  fragmented      bit,
  density         float,
  surfaceGravity  float,
  escapeVelocity  float,
  orbitPeriod     float,
  rotationRate    float,
  locked          bit,
  pressure        float,
  radius          float,
  mass            float,
  --
  CONSTRAINT mapCelestialStatistics_PK PRIMARY KEY CLUSTERED (celestialID)
)     * 
     * 
ALTER TABLE mapCelestialStatistics ADD CONSTRAINT mapCelestialStatistics_celestial FOREIGN KEY (celestialID) REFERENCES invPositions(itemID)
     * */

    public class CelestialStatisticMapper : SubclassMap<CelestialStatistic>
    {
        public CelestialStatisticMapper ()
        {
            Table("mapCelestialStatistics");
            KeyColumn("celestialID");

            Map(x => x.Temperature, "temperature");
            Map(x => x.SpectralClass, "spectralClass").Length(10);
            Map(x => x.Luminosity, "luminosity");
            Map(x => x.Age, "age");
            Map(x => x.Life, "life");
            Map(x => x.OrbitRadius, "orbitRadius");
            Map(x => x.Eccentricity, "eccentricity");
            Map(x => x.MassDust, "massDust");
            Map(x => x.MassGas, "massGas");
            Map(x => x.IsFragmented, "fragmented");
            Map(x => x.Density, "density");
            Map(x => x.SurfaceGravity, "surfaceGravity");
            Map(x => x.EscapeVelocity, "escapeVelocity");
            Map(x => x.OrbitPeriod, "orbitPeriod");
            Map(x => x.RotationRate, "rotationRate");
            Map(x => x.IsLocked, "locked");
            Map(x => x.Pressure, "pressure");
            Map(x => x.Radius, "radius");
            Map(x => x.Mass, "mass");

        }

    }

    public class CelestialStatistic : InventoryPosition
    {

        public virtual decimal Temperature { get; set; }
        public virtual string SpectralClass { get; set; }
        public virtual decimal Luminosity { get; set; }
        public virtual decimal Age { get; set; }
        public virtual decimal Life { get; set; }
        public virtual decimal OrbitRadius { get; set; }
        public virtual decimal Eccentricity { get; set; }
        public virtual decimal MassDust { get; set; }
        public virtual decimal MassGas { get; set; }
        public virtual bool IsFragmented { get; set; }
        public virtual decimal Density { get; set; }
        public virtual decimal SurfaceGravity { get; set; }
        public virtual decimal EscapeVelocity { get; set; }
        public virtual decimal OrbitPeriod { get; set; }
        public virtual decimal RotationRate { get; set; }
        public virtual bool IsLocked { get; set; }
        public virtual decimal Pressure { get; set; }
        public virtual decimal Radius { get; set; }
        public virtual decimal Mass { get; set; }

    }


}