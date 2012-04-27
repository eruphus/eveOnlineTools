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
using FluentNHibernate.Mapping;
using eveStatic.entities.CHR;
using eveStatic.mappers;
using eveStatic.types;

namespace eveStatic.entities.MAP
{

    /*
CREATE TABLE dbo.mapConstellations
(
  regionID             int,
  constellationID      int,
  constellationName    nvarchar(100)  COLLATE Latin1_General_CI_AI,
  x                    float,
  y                    float,
  z                    float,
  xMin                 float,
  xMax                 float,
  yMin                 float,
  yMax                 float,
  zMin                 float,
  zMax                 float,
  factionID            int,
  radius               float,
  --
  CONSTRAINT mapConstellations_PK PRIMARY KEY CLUSTERED (constellationID)
)
CREATE NONCLUSTERED INDEX mapConstellations_IX_region ON mapConstellations(regionID)

ALTER TABLE mapConstellations ADD CONSTRAINT mapConstellations_FK_constellation FOREIGN KEY (constellationID) REFERENCES invPositions(itemID)
ALTER TABLE mapConstellations ADD CONSTRAINT mapConstellations_FK_region FOREIGN KEY (regionID) REFERENCES mapRegions(regionID)
ALTER TABLE mapConstellations ADD CONSTRAINT mapConstellations_FK_faction FOREIGN KEY (factionID) REFERENCES chrFactions(factionID)

     * 
     * 
     * 
     * 
CREATE TABLE dbo.mapConstellationJumps
(
  fromRegionID         int,
  fromConstellationID  int,
  toConstellationID    int,
  toRegionID           int,
  --
  CONSTRAINT mapConstellationJumps_PK PRIMARY KEY CLUSTERED (fromConstellationID, toConstellationID)
)

CREATE NONCLUSTERED INDEX mapConstellationJumps_IX_fromRegion ON mapConstellationJumps(fromRegionID)


ALTER TABLE mapConstellationJumps ADD CONSTRAINT mapConstellationJumps_FK_toConstellation FOREIGN KEY (toConstellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE mapConstellationJumps ADD CONSTRAINT mapConstellationJumps_FK_fromConstellation FOREIGN KEY (fromConstellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE mapConstellationJumps ADD CONSTRAINT mapConstellationJumps_FK_toRegion FOREIGN KEY (toRegionID) REFERENCES mapRegions(regionID)
ALTER TABLE mapConstellationJumps ADD CONSTRAINT mapConstellationJumps_FK_fromRegion FOREIGN KEY (fromRegionID) REFERENCES mapRegions(regionID)
    */


    public class ConstellationMapper : ClassMapper<Constellation>
    {
        public ConstellationMapper()
        {
            Table("mapConstellations");
            Id(x => x.Id, "constellationID");

            HasManyToMany(x => x.Jumps).Table("mapConstellationJumps").ParentKeyColumn("fromConstellationID").ChildKeyColumn("toConstellationID");
            HasMany(x => x.Systems).Table("mapSolarSystems").KeyColumn("constellationID").AsBag();

            References(x => x.Faction, "factionID");
            References(x => x.ParrentRegion, "regionID");

            Map(x => x.ConstelationName, "constellationName");
            Map(x => x.Radius, "radius");
            MapLocation(x => x.ConstelationLocation,"x", "y", "z");
            MapLocation(x => x.MinBound,"xMin", "yMin", "zMin");
            MapLocation(x => x.MaxBound,"xMax", "yMax", "zMax");

        }
    }


    public class Constellation
    {
        public Constellation()
        {
            Jumps = new List<Constellation>();
            Systems = new List<SolarSystem>();
        }
        public virtual int Id { get; set; }

        public virtual ICollection<Constellation> Jumps { get; set; }
        public virtual ICollection<SolarSystem> Systems { get; set; }

        public virtual Faction Faction { get; set; }
        public virtual Region ParrentRegion { get; set; }

        public virtual decimal Radius { get; set; }
        public virtual string ConstelationName { get; set; }
        public virtual Location ConstelationLocation { get; set; }
        public virtual Location MinBound { get; set; }
        public virtual Location MaxBound { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, ConstelationName);
        }
    }
}