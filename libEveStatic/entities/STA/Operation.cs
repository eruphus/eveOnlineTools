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
using libEveStatic.entities.CRP;
using libEveStatic.entities.INV;

namespace libEveStatic.entities.STA
{
    /*

    CREATE TABLE dbo.staOperations
    (
      activityID             tinyint,
      operationID            tinyint,
      operationName          nvarchar(100),
      description            nvarchar(1000),
      fringe                 tinyint,
      corridor               tinyint,
      hub                    tinyint,
      border                 tinyint,
      ratio                  tinyint,
      caldariStationTypeID   int,
      minmatarStationTypeID  int,
      amarrStationTypeID     int,
      gallenteStationTypeID  int,
      joveStationTypeID      int,
      --
      CONSTRAINT staOperations_PK PRIMARY KEY CLUSTERED (operationID)
    )

    ALTER TABLE staOperations ADD CONSTRAINT staOperations_FK_activity FOREIGN KEY (activityID) REFERENCES crpActivities(activityID)
    ALTER TABLE staOperations ADD CONSTRAINT staOperations_FK_caldariStationType FOREIGN KEY (caldariStationTypeID) REFERENCES invTypes(typeID)
    ALTER TABLE staOperations ADD CONSTRAINT staOperations_FK_minmatarStationType FOREIGN KEY (minmatarStationTypeID) REFERENCES invTypes(typeID)
    ALTER TABLE staOperations ADD CONSTRAINT staOperations_FK_amarrStationType FOREIGN KEY (amarrStationTypeID) REFERENCES invTypes(typeID)
    ALTER TABLE staOperations ADD CONSTRAINT staOperations_FK_gallenteStationType FOREIGN KEY (gallenteStationTypeID) REFERENCES invTypes(typeID)
    ALTER TABLE staOperations ADD CONSTRAINT staOperations_FK_joveStationType FOREIGN KEY (joveStationTypeID) REFERENCES invTypes(typeID)


CREATE TABLE dbo.staOperationServices
(
  operationID  tinyint,
  serviceID    int,
  --
  CONSTRAINT staOperationServices_PK PRIMARY KEY CLUSTERED (operationID, serviceID)
)
    */

    public class OperationMapper : ClassMap<Operation>
    {

        public OperationMapper()
        {
            Table("staOperations");
            Id(x => x.Id, "operationID");

            HasManyToMany(x => x.Services).Table("staOperationServices").ParentKeyColumn("operationID").ChildKeyColumn("serviceID");

            References(x => x.CaldariStationType, "caldariStationTypeID").Nullable();
            References(x => x.MinmatarStationType, "minmatarStationTypeID").Nullable();
            References(x => x.AmarrStationType, "amarrStationTypeID").Nullable();
            References(x => x.GallenteStationType, "gallenteStationTypeID").Nullable();
            References(x => x.JoveStationType, "joveStationTypeID").Nullable();
            References(x => x.CorporationActivity, "activityID").Nullable();

            Map(x => x.Name, "operationName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(1000).Nullable();
            Map(x => x.Fringe, "fringe").Nullable();
            Map(x => x.Corridor, "corridor").Nullable();
            Map(x => x.Hub, "hub").Nullable();
            Map(x => x.Border, "border").Nullable();
            Map(x => x.Ratio, "ratio").Nullable();

        }

    }

    public class Operation 
    {
        public Operation()
        {
            Services = new List<Service>();
        }

        public virtual int Id { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual InventoryType CaldariStationType { get; set; }
        public virtual InventoryType MinmatarStationType { get; set; }
        public virtual InventoryType AmarrStationType { get; set; }
        public virtual InventoryType GallenteStationType { get; set; }
        public virtual InventoryType JoveStationType { get; set; }
        public virtual CorporationActivity CorporationActivity { get; set; }
        
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual int Fringe { get; set; }
        public virtual int Corridor { get; set; }
        public virtual int Hub { get; set; }
        public virtual int Border { get; set; }
        public virtual int Ratio { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, Name);
        }
    }
}