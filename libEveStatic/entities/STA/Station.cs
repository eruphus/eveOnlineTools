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
using libEveStatic.entities.CRP;
using libEveStatic.entities.INV;
using libEveStatic.entities.MAP;
using libEveStatic.entities.RAM;
using libEveStatic.mappers;
using libEveStatic.types;

namespace libEveStatic.entities.STA
{
    /*
     * 
CREATE TABLE dbo.staStations
(
  stationID                 int,
  [security]                smallint,
  dockingCostPerVolume      float,
  maxShipVolumeDockable     float,
  officeRentalCost          int,
  operationID               tinyint,
  -- DENORMALIZED DATA
  stationTypeID             int,
  corporationID             int,
  solarSystemID             int,
  constellationID           int,
  regionID                  int,
  stationName               nvarchar(100)  COLLATE Latin1_General_CI_AI,
  x                         float,
  y                         float,
  z                         float,
  reprocessingEfficiency    float,
  reprocessingStationsTake  float,
  reprocessingHangarFlag    tinyint,
  --
  CONSTRAINT staStations_PK PRIMARY KEY CLUSTERED (stationID)
)
CREATE NONCLUSTERED INDEX staStations_IX_region ON staStations (regionID)
CREATE NONCLUSTERED INDEX staStations_IX_system ON staStations (solarSystemID)
CREATE NONCLUSTERED INDEX staStations_IX_constellation ON staStations (constellationID)
CREATE NONCLUSTERED INDEX staStations_IX_operation ON staStations (operationID)
CREATE NONCLUSTERED INDEX staStations_IX_type ON staStations (stationTypeID)
CREATE NONCLUSTERED INDEX staStations_IX_corporation ON staStations (corporationID)
     * 
ALTER TABLE staStations ADD CONSTRAINT staStations_FK_type FOREIGN KEY (stationTypeID) REFERENCES staTypes(stationTypeID)
ALTER TABLE staStations ADD CONSTRAINT staStations_FK_station FOREIGN KEY (stationID) REFERENCES invPositions(itemID) 
ALTER TABLE staStations ADD CONSTRAINT staStations_FK_operation FOREIGN KEY (operationID) REFERENCES staOperations(operationID)
ALTER TABLE staStations ADD CONSTRAINT staStations_FK_corporation FOREIGN KEY (corporationID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE staStations ADD CONSTRAINT staStations_FK_solarSystem FOREIGN KEY (solarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE staStations ADD CONSTRAINT staStation_FK_constellation FOREIGN KEY (constellationID) REFERENCES mapConstellations(constellationID)
ALTER TABLE staStations ADD CONSTRAINT staStationd_FK_region FOREIGN KEY (regionID) REFERENCES mapRegions(regionID)

     * 
     
CREATE TABLE dbo.ramAssemblyLineStations
(
  stationID           int,
  assemblyLineTypeID  tinyint,
     * 
  solarSystemID       int,
  regionID            int,
  stationTypeID       int,
  ownerID             int,
     * 
  quantity            tinyint,
  --
  CONSTRAINT ramAssemblyLineStations_PK PRIMARY KEY CLUSTERED (stationID, assemblyLineTypeID)
)     
     */

    public class StationMapper : SubclassMapper<Station>
    {

        public StationMapper()
        {
            Table("staStations");
            KeyColumn("stationID");

            HasMany(x => x.AssemblyLines).Table("ramAssemblyLineStations").KeyColumn("stationID").AsEntityMap("assemblyLineTypeID");

            References(x => x.StationType, "stationTypeID");
            References(x => x.Operation, "operationID").Nullable();
            References(x => x.Corporation, "corporationID").Nullable();
            References(x => x.SolarSystem, "solarSystemID").Nullable();
            References(x => x.Constellation, "constellationID").Nullable();
            References(x => x.Region, "regionID").Nullable();

            Map(x => x.StationName, "stationName").Length(100).Nullable();
            Map(x => x.Security, "security").Nullable();
            Map(x => x.DockingCostPerVolume, "dockingCostPerVolume").Nullable();
            Map(x => x.MaxShipVolumeDockable, "maxShipVolumeDockable").Nullable();
            Map(x => x.OfficeRentalCost, "officeRentalCost").Nullable();
            Map(x => x.ReprocessingEfficiency, "reprocessingEfficiency").Nullable();
            Map(x => x.ReprocessingStationsTake, "reprocessingStationsTake").Nullable();
            Map(x => x.ReprocessingHangarFlag, "reprocessingHangarFlag").Nullable();
            MapLocation(x => x.StationLocation, "x", "y", "z");
        }

    }

    public class Station : InventoryPosition
    {
        public Station()
        {
            AssemblyLines = new Dictionary<AssemblyLineType, AssemblyLineStation>();
        }

        public virtual IDictionary<AssemblyLineType, AssemblyLineStation> AssemblyLines { get; set; }


        public virtual StationType StationType { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual NpcCorporation Corporation { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
        public virtual Constellation Constellation { get; set; }
        public virtual Region Region { get; set; }

        public virtual int Security { get; set; }
        public virtual decimal DockingCostPerVolume { get; set; }
        public virtual decimal MaxShipVolumeDockable { get; set; }
        public virtual decimal OfficeRentalCost { get; set; }
        public virtual string StationName { get; set; }
        public virtual decimal ReprocessingEfficiency { get; set; }
        public virtual decimal ReprocessingStationsTake { get; set; }
        public virtual decimal ReprocessingHangarFlag { get; set; }
        public virtual Location StationLocation { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, StationName);
        }
    }
}