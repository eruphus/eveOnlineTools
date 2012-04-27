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
using eveStatic.entities.INV;
using eveStatic.mappers;
using eveStatic.types;

namespace eveStatic.entities.MAP
{
    /*

CREATE TABLE dbo.mapRegions
(
  regionID    int,
  regionName  nvarchar(100)  COLLATE Latin1_General_CI_AI,
  x           float,
  y           float,
  z           float,
  xMin        float,
  xMax        float,
  yMin        float,
  yMax        float,
  zMin        float,
  zMax        float,
  factionID   int,
  radius      float,
  --
  CONSTRAINT mapRegions_PK PRIMARY KEY CLUSTERED (regionID)
     * 
)
ALTER TABLE mapRegions ADD CONSTRAINT mapRegions_FK_region FOREIGN KEY (regionID) REFERENCES invPositions(itemID)
ALTER TABLE mapRegions ADD CONSTRAINT mapRegions_FK_faction FOREIGN KEY (factionID) REFERENCES chrFactions(factionID)
    
     * 
     * 
CREATE TABLE dbo.mapRegionJumps
(
  fromRegionID  int  NOT NULL,
  toRegionID    int  NOT NULL,
  --
  CONSTRAINT mapRegionJumps_PK PRIMARY KEY CLUSTERED (fromRegionID, toRegionID)
)

ALTER TABLE mapRegionJumps ADD CONSTRAINT mapRegionJumps_FK_toRegion FOREIGN KEY (toRegionID) REFERENCES mapRegions(regionID)
ALTER TABLE mapRegionJumps ADD CONSTRAINT mapRegionJumps_FK_fromRegion FOREIGN KEY (fromRegionID) REFERENCES mapRegions(regionID)

     * */

    public class RegionMapper : SubclassMapper<Region>
    {

        public RegionMapper()
        {
            Table("mapRegions");
            KeyColumn("regionID");

            References(x => x.Faction, "factionID");

            HasManyToMany(x => x.Jumps).Table("mapRegionJumps").ParentKeyColumn("fromRegionID").ChildKeyColumn("toRegionID");
            HasMany(x => x.Constellations).Table("mapConstellations").KeyColumn("regionID").AsBag();

            Map(x => x.RegionName, "regionName");
            Map(x => x.Radius, "radius");
            MapLocation(x => x.RegionLocation, "x", "y", "z");
            MapLocation(x => x.MinBound, "xMin", "yMin", "zMin");
            MapLocation(x => x.MaxBound, "xMax", "yMax", "zMax");

        }


    }

    public class Region : InventoryPosition
    {

        public Region()
        {
            Jumps = new List<Region>();
            Constellations = new List<Constellation>();
        }

        public virtual Faction Faction { get; set; }

        public virtual ICollection<Region> Jumps { get; set; }
        public virtual ICollection<Constellation> Constellations { get; set; }

        public virtual string RegionName { get; set; }
        public virtual decimal Radius { get; set; }
        public virtual Location RegionLocation { get; set; }
        public virtual Location MinBound { get; set; }
        public virtual Location MaxBound { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, RegionName);
        }
    }

}