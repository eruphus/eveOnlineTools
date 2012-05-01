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

using libEveStatic.database.entities.INV;
using libEveStatic.database.mappers;
using libEveStatic.database.types;

namespace libEveStatic.database.entities.MAP
{
    /*
CREATE TABLE dbo.mapDenormalize
(
  itemID           int,
  typeID           int,
  groupID          int,
  solarSystemID    int,
  constellationID  int,
  regionID         int,
  orbitID          int,
     
  x                float,
  y                float,
  z                float,
  radius           float,
  itemName         nvarchar(100),
  [security]       float,
  celestialIndex   tinyint,
  orbitIndex       tinyint,
  --
  CONSTRAINT mapDenormalize_PK PRIMARY KEY CLUSTERED (itemID)
)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_groupRegion ON mapDenormalize(groupID, regionID)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_groupConstellation ON mapDenormalize(groupID, constellationID)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_groupSystem ON mapDenormalize(groupID, solarSystemID)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_system ON mapDenormalize(solarSystemID)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_constellation ON mapDenormalize(constellationID)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_region ON mapDenormalize(regionID)
CREATE NONCLUSTERED INDEX mapDenormalize_IX_orbit ON mapDenormalize(orbitID)

ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_item FOREIGN KEY (itemID) REFERENCES invPositions(itemID)
ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_solarSystem FOREIGN KEY (solarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_constellation FOREIGN KEY (constellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_region FOREIGN KEY (regionID) REFERENCES mapRegions(regionID)
ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_group FOREIGN KEY (groupID) REFERENCES invGroups(groupID)
ALTER TABLE mapDenormalize ADD CONSTRAINT mapDenormalize_FK_orbit FOREIGN KEY (orbitID) REFERENCES invPositions(itemID)

     */

    public class DenormalizeMapper : SubclassMapper<Denormalize>
    {
        public DenormalizeMapper()
        {
            Table("mapDenormalize");
            KeyColumn("itemID");

            References(x => x.Type, "typeID").Nullable();
            References(x => x.Group, "groupID").Nullable();
            References(x => x.System, "solarSystemID").Nullable();
            References(x => x.Constellation, "constellationID").Nullable();
            References(x => x.Region, "regionID").Nullable();
            References(x => x.Orbit, "orbitID").Nullable();

            MapLocation(x => x.DenormalizeLocation, "x", "y", "z");
            Map(x => x.Radius, "radius");
            Map(x => x.Name, "itemName").Length(100);
            Map(x => x.Security, "security");
            Map(x => x.CelestialIndex, "celestialIndex");
            Map(x => x.OrbitIndex, "orbitIndex");

        }
    }


    public class Denormalize : InventoryPosition
    {
        public virtual InventoryType Type { get; set; }
        public virtual InventoryGroup Group { get; set; }
        public virtual SolarSystem System { get; set; }
        public virtual Constellation Constellation { get; set; }
        public virtual Region Region { get; set; }
        public virtual InventoryPosition Orbit { get; set; }



        public virtual Location DenormalizeLocation { get; set; }
        public virtual decimal Radius { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Security { get; set; }
        public virtual short CelestialIndex { get; set; }
        public virtual short OrbitIndex { get; set; }
    }
}