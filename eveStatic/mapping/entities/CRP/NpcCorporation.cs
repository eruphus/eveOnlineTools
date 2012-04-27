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
using eveStatic.entities.CHR;
using eveStatic.entities.EVE;
using eveStatic.entities.INV;
using eveStatic.entities.MAP;

namespace eveStatic.entities.CRP
{
    /*
CREATE TABLE dbo.crpNPCCorporations
(
  corporationID        int,
  [size]               char(1),
  extent               char(1),
  solarSystemID        int,
  investorID1          int,     
  investorShares1      tinyint,
  investorID2          int,
  investorShares2      tinyint,
  investorID3          int,
  investorShares3      tinyint,
  investorID4          int,
  investorShares4      tinyint,
  friendID             int,
  enemyID              int,
  publicShares         bigint,
  initialPrice         int,
  minSecurity          float,
  scattered            bit,
  fringe               tinyint,
  corridor             tinyint,
  hub                  tinyint,
  border               tinyint,
  factionID            int,
  sizeFactor           float,
  stationCount         smallint,
  stationSystemCount   smallint,
  description          nvarchar(4000),
  iconID               int,

  CONSTRAINT crpNPCCorporations_PK PRIMARY KEY CLUSTERED (corporationID)
)

ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_corporation FOREIGN KEY (corporationID) REFERENCES invNames(itemID) 
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_solarSystem FOREIGN KEY (solarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_investor1 FOREIGN KEY (investorID1) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_investor2 FOREIGN KEY (investorID2) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_investor3 FOREIGN KEY (investorID3) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_investor4 FOREIGN KEY (investorID4) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_friend FOREIGN KEY (friendID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_enemy FOREIGN KEY (enemyID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_faction FOREIGN KEY (factionID) REFERENCES chrFactions(factionID)
ALTER TABLE crpNPCCorporations ADD CONSTRAINT crpNPCCorporations_FK_icon FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)
     * 
     * * */

    public class NpcCorporationMapper : SubclassMap<NpcCorporation>
    {
        public NpcCorporationMapper()
        {
            Table("crpNPCCorporations");
            KeyColumn("corporationID");

            References(x => x.SolarSystem, "solarSystemID");
            References(x => x.Icon, "iconID");
            References(x => x.Faction, "factionID");
            References(x => x.Friend, "friendID");
            References(x => x.Enemy, "enemyID");
            References(x => x.Investor1, "investorID1");
            References(x => x.Investor2, "investorID2");
            References(x => x.Investor3, "investorID3");
            References(x => x.Investor4, "investorID4");

            Map(x => x.Size, "size").Length(1);
            Map(x => x.Extend, "extent").Length(1);
            Map(x => x.InvestorShares1, "investorShares1");
            Map(x => x.InvestorShares2, "investorShares2");
            Map(x => x.InvestorShares3, "investorShares3");
            Map(x => x.InvestorShares4, "investorShares4");
            Map(x => x.PublicShares, "publicShares");
            Map(x => x.InitialPrice, "initialPrice");
            Map(x => x.MinSecurity, "minSecurity");
            Map(x => x.IsScattered, "scattered");
            Map(x => x.Fringe, "fringe");
            Map(x => x.Corridor, "corridor");
            Map(x => x.Hub, "hub");
            Map(x => x.Border, "border");
            Map(x => x.SizeFactor, "sizeFactor");
            Map(x => x.StationCount, "stationCount");
            Map(x => x.StationSystemCount, "stationSystemCount");
            Map(x => x.Description, "description");

        }
    }


    public class NpcCorporation : InventoryName
    {
        

        public virtual SolarSystem SolarSystem { get; set; }
        public virtual Icon Icon { get; set; }
        public virtual Faction Faction { get; set; }
        public virtual NpcCorporation Investor1 { get; set; }
        public virtual NpcCorporation Investor2 { get; set; }
        public virtual NpcCorporation Investor3 { get; set; }
        public virtual NpcCorporation Investor4 { get; set; }
        public virtual NpcCorporation Friend { get; set; }
        public virtual NpcCorporation Enemy { get; set; }


        public virtual string Size { get; set; }
        public virtual string Extend { get; set; }
        public virtual int InvestorShares1      { get; set; }
        public virtual int InvestorShares2      { get; set; }
        public virtual int InvestorShares3      { get; set; }
        public virtual int InvestorShares4 { get; set; }
        public virtual long PublicShares { get; set; }
        public virtual int InitialPrice { get; set; }
        public virtual decimal MinSecurity { get; set; }
        public virtual bool IsScattered { get; set; }
        public virtual int Fringe { get; set; }
        public virtual int Corridor { get; set; }
        public virtual int Hub { get; set; }
        public virtual int Border { get; set; }
        public virtual decimal SizeFactor { get; set; }
        public virtual int StationCount { get; set; }
        public virtual int StationSystemCount  { get; set; }
        public virtual string Description{ get; set; }

    }
}