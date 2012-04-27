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
using eveStatic.entities.INV;
using eveStatic.mappers;
using eveStatic.types;

namespace eveStatic.entities.STA
{
    /*
   
CREATE TABLE dbo.staStationTypes
(
  stationTypeID           int,
  --
  dockEntryX              float,
  dockEntryY              float,
  dockEntryZ              float,
  dockOrientationX        float,
  dockOrientationY        float,
  dockOrientationZ        float,
  operationID             tinyint,
  officeSlots             tinyint,
  reprocessingEfficiency  float,
  conquerable             bit,
  --
  CONSTRAINT stationTypes_PK PRIMARY KEY CLUSTERED (stationTypeID)
)
		
     
ALTER TABLE staStationTypes ADD CONSTRAINT staStationTypes_FK_stationType FOREIGN KEY (stationTypeID) REFERENCES invTypes(typeID) 
 
    */

    public class StationTypeMapper : SubclassMapper<StationType>
    {

        public StationTypeMapper()
        {
            Table("staStationTypes");
            KeyColumn("stationTypeID");

            Map(x => x.OperationId, "operationID").Nullable();
            Map(x => x.OfficeSlots, "officeSlots").Nullable();
            Map(x => x.IsConquerable, "conquerable").Nullable();
            MapLocation(x => x.DockEntry, "dockEntryX", "dockEntryY", "dockEntryZ");
            MapLocation(x => x.DockDirection, "dockOrientationX", "dockOrientationY", "dockOrientationZ");
            Map(x => x.ReprocessingEfficiency, "reprocessingEfficiency").Nullable();
        }

    }

    public class StationType : InventoryType
    {
        //public virtual int Id { get; set; }

        public virtual int OperationId { get; set; }
        
        public virtual int OfficeSlots { get; set; }
        public virtual bool IsConquerable { get; set; }
        public virtual Location DockEntry { get; set; }
        public virtual Location DockDirection { get; set; }
        public virtual decimal ReprocessingEfficiency { get; set; }
         
    }
}