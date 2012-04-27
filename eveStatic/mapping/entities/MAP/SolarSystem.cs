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

using System.Collections.Generic;
using eveStatic.entities.CHR;
using eveStatic.entities.INV;
using eveStatic.entities.WAR;
using eveStatic.mappers;
using eveStatic.types;

namespace eveStatic.entities.MAP
{
    /*
CREATE TABLE dbo.mapSolarSystems
(
  regionID             int,
  constellationID      int,
  solarSystemID        int,
  solarSystemName      nvarchar(100)  COLLATE Latin1_General_CI_AI,
  x                    float,
  y                    float,
  z                    float,
  xMin                 float,
  xMax                 float,
  yMin                 float,
  yMax                 float,
  zMin                 float,
  zMax                 float,
  luminosity           float,
  --
  border               bit,
  fringe               bit,
  corridor             bit,
  hub                  bit,
  international        bit,
  regional             bit,
  constellation        bit,
  security             float,
  factionID            int,
  radius               float,
  sunTypeID            int,
  securityClass        varchar(2),
  --
  CONSTRAINT mapSolarSystems_PK PRIMARY KEY CLUSTERED (solarSystemID)
)
CREATE NONCLUSTERED INDEX mapSolarSystems_IX_region ON mapSolarSystems(regionID)
CREATE NONCLUSTERED INDEX mapSolarSystems_IX_constellation ON mapSolarSystems(constellationID)
CREATE NONCLUSTERED INDEX mapSolarSystems_IX_security ON mapSolarSystems([security])
     * 
ALTER TABLE mapSolarSystems ADD CONSTRAINT mapSolarSystems_FK_system FOREIGN KEY (solarSystemID) REFERENCES invPositions(itemID) 
ALTER TABLE mapSolarSystems ADD CONSTRAINT mapSolarSystems_FK_constellation FOREIGN KEY (constellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE mapSolarSystems ADD CONSTRAINT mapSolarSystems_FK_regionID FOREIGN KEY (regionID) REFERENCES mapRegions(regionID)
ALTER TABLE mapSolarSystems ADD CONSTRAINT mapSolarSystems_FK_faction FOREIGN KEY (factionID) REFERENCES chrFactions(factionID)
ALTER TABLE mapSolarSystems ADD CONSTRAINT mapSolarSystems_FK_sunType FOREIGN KEY (sunTypeID) REFERENCES invTypes(typeID)
* 
     * 
     * 
     * 
     * 
     * 
CREATE TABLE dbo.mapSolarSystemJumps
(
  fromRegionID         int,
  fromConstellationID  int,
  fromSolarSystemID    int,
  toSolarSystemID      int,
  toConstellationID    int,
  toRegionID           int,
  --
  CONSTRAINT mapSolarSystemJumps_PK PRIMARY KEY CLUSTERED (fromSolarSystemID, toSolarSystemID)
)
CREATE NONCLUSTERED INDEX mapSolarSystemJumps_IX_fromRegion ON mapSolarSystemJumps(fromRegionID)
CREATE NONCLUSTERED INDEX mapSolarSystemJumps_IX_fromConstellation ON mapSolarSystemJumps(fromConstellationID)


ALTER TABLE mapSolarSystemJumps ADD CONSTRAINT mapSolarSystemJumps_FK_toSolarSystem FOREIGN KEY (toSolarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE mapSolarSystemJumps ADD CONSTRAINT mapSolarSystemJumps_FK_fromSolarSystem FOREIGN KEY (fromSolarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE mapSolarSystemJumps ADD CONSTRAINT mapSolarSystemJumps_FK_toConstellation FOREIGN KEY (toConstellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE mapSolarSystemJumps ADD CONSTRAINT mapSolarSystemJumps_FK_fromConstellation FOREIGN KEY (fromConstellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE mapSolarSystemJumps ADD CONSTRAINT mapSolarSystemJumps_FK_toRegion FOREIGN KEY (toRegionID) REFERENCES mapRegions(regionID)
ALTER TABLE mapSolarSystemJumps ADD CONSTRAINT mapSolarSystemJumps_FK_fromRegion FOREIGN KEY (fromRegionID) REFERENCES mapRegions(regionID)


     * */

    public class SolarSystemMapper : SubclassMapper<SolarSystem>
    {
        public SolarSystemMapper()
        {
            Table("mapSolarSystems");
            KeyColumn("solarSystemID");

            References(x => x.Faction, "factionID").Nullable();
            References(x => x.Region, "regionID").Nullable();
            References(x => x.ParentConstellation, "constellationID").Nullable();

            HasManyToMany(x => x.Jumps).Table("mapSolarSystemJumps").ParentKeyColumn("fromSolarSystemID").ChildKeyColumn("toSolarSystemID");
            HasManyToMany(x => x.CombatZones).Table("warCombatZoneSystems").ParentKeyColumn("solarSystemID").ChildKeyColumn("combatZoneID");

            Map(x => x.SunTypeId, "sunTypeID").Nullable();
            Map(x => x.SystemName, "solarSystemName").Nullable().Length(100);
            MapLocation(x => x.SolarSystemLocation,"x", "y", "z");
            MapLocation(x => x.MinBound,"xMin", "yMin", "zMin");
            MapLocation(x => x.MaxBound,"xMax", "yMax", "zMax");
            Map(x => x.Luminosity, "luminosity").Nullable();
            Map(x => x.Border, "border").Nullable();
            Map(x => x.Fringe, "fringe").Nullable();
            Map(x => x.Corridor, "corridor").Nullable();
            Map(x => x.Hub, "hub").Nullable();
            Map(x => x.International, "international").Nullable();
            Map(x => x.Regional, "regional").Nullable();
            Map(x => x.Constellation, "constellation").Nullable();
            Map(x => x.Security, "security").Nullable();
            Map(x => x.Radius, "radius").Nullable();
            Map(x => x.SecurityClass, "securityClass").Nullable();

        }
    }

    public class SolarSystem : InventoryPosition
    {
        public SolarSystem()
        {
            Jumps = new List<SolarSystem>();
            CombatZones = new List<CombatZone>();
        }

        public virtual ICollection<SolarSystem> Jumps { get; set; }
        public virtual ICollection<CombatZone> CombatZones { get; set; }

        public virtual Faction Faction { get; set; }
        public virtual Region Region { get; set; }
        public virtual Constellation ParentConstellation { get; set; }
        
        public virtual int SunTypeId { get; set; }
        
        public virtual string SystemName { get; set; }
        public virtual Location SolarSystemLocation { get; set; }
        public virtual Location MinBound { get; set; }
        public virtual Location MaxBound { get; set; }
        public virtual decimal Luminosity { get; set; }
        public virtual bool Fringe { get; set; }
        public virtual bool Corridor { get; set; }
        public virtual bool Hub { get; set; }
        public virtual bool Border { get; set; }
        public virtual bool International { get; set; }
        public virtual bool Regional { get; set; }
        public virtual bool Constellation { get; set; }
        public virtual decimal Security { get; set; }
        public virtual decimal Radius { get; set; }
        public virtual string SecurityClass { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, SystemName);
        }
    }
}