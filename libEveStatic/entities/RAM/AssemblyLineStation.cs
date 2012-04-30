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
using libEveStatic.entities.MAP;
using libEveStatic.entities.STA;

namespace libEveStatic.entities.RAM
{

    /*
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
CREATE NONCLUSTERED INDEX ramAssemblyLineStations_IX_region ON ramAssemblyLineStations (regionID)
CREATE NONCLUSTERED INDEX ramAssemblyLineStations_IX_owner ON ramAssemblyLineStations (ownerID)

     * 
ALTER TABLE ramAssemblyLineStations ADD CONSTRAINT ramAssemblyLineStations_FK_station FOREIGN KEY (stationID) REFERENCES staStations(stationID)
ALTER TABLE ramAssemblyLineStations ADD CONSTRAINT ramAssemblyLineStations_FK_assemblyLineType FOREIGN KEY (assemblyLineTypeID) REFERENCES ramAssemblyLineTypes(assemblyLineTypeID)
ALTER TABLE ramAssemblyLineStations ADD CONSTRAINT ramAssemblyLineStations_FK_owner FOREIGN KEY (ownerID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE ramAssemblyLineStations ADD CONSTRAINT ramAssemblyLineStations_FK_stationType FOREIGN KEY (stationTypeID) REFERENCES staStationTypes(stationTypeID)
     * 
ALTER TABLE ramAssemblyLineStations ADD CONSTRAINT ramAssemblyLineStations_FK_solarSystem FOREIGN KEY (solarSystemID) REFERENCES mapSolarSystems(solarSystemID)
ALTER TABLE ramAssemblyLineStations ADD CONSTRAINT ramAssemblyLineStations_FK_region FOREIGN KEY (regionID) REFERENCES mapRegions(regionID)
*/

    public class AssemblyLineStationMapper : ClassMap<AssemblyLineStation>
    {
        public AssemblyLineStationMapper()
        {
            Table("ramAssemblyLineStations");

            CompositeId().KeyReference(x => x.Station, "stationID").KeyReference(x => x.AssemblyLineType, "assemblyLineTypeID");

            References(x => x.Station, "stationID");
            References(x => x.AssemblyLineType, "assemblyLineTypeID");
            References(x => x.Owner, "ownerID");
            References(x => x.StationType, "stationTypeID");
            References(x => x.SolarSystem, "solarSystemID");
            References(x => x.Region, "regionID");

            Map(x => x.Quantity, "quantity");

        }
    }

    public class AssemblyLineStation 
    {

        public virtual Station Station { get; set; }
        public virtual AssemblyLineType AssemblyLineType { get; set; }

        public virtual NpcCorporation Owner { get; set; }
        public virtual StationType StationType { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }
        public virtual Region Region { get; set; }

        public virtual byte Quantity { get; set; }

        public virtual bool Equals(AssemblyLineStation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Station, Station) && Equals(other.AssemblyLineType, AssemblyLineType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AssemblyLineStation)) return false;
            return Equals((AssemblyLineStation) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Station != null ? Station.GetHashCode() : 0)*397) ^ (AssemblyLineType != null ? AssemblyLineType.GetHashCode() : 0);
            }
        }
    }


}