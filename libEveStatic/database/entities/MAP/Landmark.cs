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

using libEveStatic.database.entities.EVE;
using libEveStatic.database.mappers;
using libEveStatic.database.types;

namespace libEveStatic.database.entities.MAP
{

    /*
CREATE TABLE dbo.mapLandmarks
(
  landmarkID    smallint,
  landmarkName  varchar(100),
  description   varchar(7000),
  locationID    int,
  x             float,
  y             float,
  z             float,
  radius        float,
  iconID        int,
  importance    tinyint
  --
  CONSTRAINT mapLandmarks_PK PRIMARY KEY CLUSTERED (landmarkID)

     * 
ALTER TABLE mapLandmarks ADD CONSTRAINT mapLandmarks_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)
ALTER TABLE mapLandmarks ADD CONSTRAINT mapLandmarks_FK_location FOREIGN KEY (locationID) REFERENCES mapSolarSystems(solarSystemID)
    */

    public class LandmarkMapper : ClassMapper<Landmark>
    {
        public LandmarkMapper ()
        {
            Table("mapLandmarks");
            
            Id(x => x.Id, "landmarkID");

            References(x => x.Icon, "iconID");
            References(x => x.SolarSytem, "locationID");

            Map(x => x.LandmarkName, "landmarkName").Length(100);
            Map(x => x.Description, "description").Length(7000);
            MapLocation(x => x.Location, "x", "y", "z");
            Map(x => x.Radius, "radius");
            Map(x => x.Importance, "importance");


        }
    }


    public class Landmark 
    {

        public virtual short Id { get; set; }

        public virtual SolarSystem SolarSytem { get; set; }
        public virtual Icon Icon { get; set; }

        public virtual string LandmarkName { get; set; }
        public virtual string Description { get; set; }
        public virtual Location Location { get; set; }
        public virtual decimal Radius { get; set; }
        public virtual byte Importance { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, LandmarkName);
        }
    
    }
}