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
using libEveStatic.entities.CRP;
using libEveStatic.entities.EVE;
using libEveStatic.entities.INV;
using libEveStatic.entities.MAP;

namespace libEveStatic.entities.CHR
{

    /*
CREATE TABLE dbo.chrFactions
(
  factionID             int,
  factionName           varchar(100),
  description           varchar(1000),
  raceIDs               int,
  solarSystemID         int,
  corporationID         int,
  sizeFactor            float,
  stationCount          smallint,
  stationSystemCount    smallint,
  militiaCorporationID  int,
  iconID                int,

  CONSTRAINT chrFactions_PK PRIMARY KEY CLUSTERED (factionID)
)     
     
     
ALTER TABLE chrFactions ADD CONSTRAINT chrFactions_FK_faction FOREIGN KEY (factionID) REFERENCES invNames(itemID) 
ALTER TABLE chrFactions ADD CONSTRAINT chrFactions_FK_solarSystem FOREIGN KEY (solarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE chrFactions ADD CONSTRAINT chrFactions_FK_corporationID FOREIGN KEY (corporationID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE chrFactions ADD CONSTRAINT chrFactions_FK_militiaCorporationID FOREIGN KEY (militiaCorporationID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE chrFactions ADD CONSTRAINT chrFactions_FK_icon FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)
 
     
     */

    public class FactionMapper : SubclassMap<Faction>
    {
        public FactionMapper()
        {
            Table("chrFactions");
            KeyColumn("factionID");

            References(x => x.Icon, "iconID").Nullable();
            References(x => x.Corporation, "corporationID").Nullable();
            References(x => x.MilitiaCorporation, "militiaCorporationID").Nullable();
            References(x => x.SolarSystem, "solarSystemID").Nullable();

            Map(x => x.RaceIds, "raceIDs").Nullable();

            Map(x => x.FactionName, "factionName").Nullable().Length(100);
            Map(x => x.Description, "description").Nullable().Length(1000);
            Map(x => x.SizeFactor, "sizeFactor").Nullable();
            Map(x => x.StationCount, "stationCount").Nullable();
            Map(x => x.StationSystemCount, "stationSystemCount").Nullable();
        
        }
    }

    public class Faction : InventoryName
    {
        //public virtual int Id { get; set; }

        public virtual Icon Icon { get; set; }
        public virtual NpcCorporation Corporation { get; set; }
        public virtual NpcCorporation MilitiaCorporation { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }

        public virtual int RaceIds { get; set; }

        public virtual string FactionName { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal SizeFactor { get; set; }
        public virtual int StationCount { get; set; }
        public virtual int StationSystemCount { get; set; }
    }
}