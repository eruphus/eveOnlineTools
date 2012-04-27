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
using eveStatic.entities.INV;

namespace eveStatic.entities.RAM
{

    /*
CREATE TABLE dbo.ramAssemblyLineTypes
(
  assemblyLineTypeID      tinyint,
  assemblyLineTypeName    nvarchar(100),
  description             nvarchar(1000),
  baseTimeMultiplier      float,
  baseMaterialMultiplier  float,
  volume                  float,
  activityID              tinyint,
  minCostPerHour          float,
  --
  CONSTRAINT ramAssemblyLineTypes_PK PRIMARY KEY CLUSTERED (assemblyLineTypeID)
)
     * 
     * 
ALTER TABLE ramAssemblyLineTypes ADD CONSTRAINT ramAssemblyLineTypes_FK_activity FOREIGN KEY (activityID) REFERENCES ramActivities(activityID)

     * 
     * 
     * 
     * 
CREATE TABLE dbo.ramAssemblyLineTypeDetailPerCategory
(
  assemblyLineTypeID  tinyint,
  categoryID          int,
  timeMultiplier      float,
  materialMultiplier  float,
  --
  CONSTRAINT ramAssemblyLineTypeDetailPerCategory_PK PRIMARY KEY CLUSTERED (assemblyLineTypeID, categoryID)
)    
CREATE TABLE dbo.ramAssemblyLineTypeDetailPerGroup
(
  assemblyLineTypeID  tinyint,
  groupID             int,
  timeMultiplier      float,
  materialMultiplier  float,
  --
  CONSTRAINT ramAssemblyLineTypeDetailPerGroup_PK PRIMARY KEY CLUSTERED (assemblyLineTypeID, groupID)
     * 
     * 
     * 

)     
     
     
     */

    public class AssemblyLineTypeMapper : ClassMap<AssemblyLineType>
    {
        public AssemblyLineTypeMapper()
        {
            Table("ramAssemblyLineTypes");
            Id(x => x.Id, "assemblyLineTypeID");

            HasMany(x => x.DetailsPerCategory).Table("ramAssemblyLineTypeDetailPerCategory").KeyColumn("assemblyLineTypeID").AsEntityMap("categoryID");
            HasMany(x => x.DetailsPerGroup).Table("ramAssemblyLineTypeDetailPerGroup").KeyColumn("assemblyLineTypeID").AsEntityMap("groupID");

            References(x => x.Activity, "activityID");

            Map(x => x.AssemblyLineTypeName, "assemblyLineTypeName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(1000).Nullable();
            Map(x => x.BaseTimeMultiplier, "baseTimeMultiplier").Nullable();
            Map(x => x.BaseMaterialMultiplier, "baseMaterialMultiplier").Nullable();
            Map(x => x.Volume, "volume").Nullable();
            Map(x => x.MinCostPerHour, "minCostPerHour").Nullable();

        }
    }


    public class AssemblyLineType 
    {
        public AssemblyLineType()
        {
            DetailsPerCategory = new Dictionary<InventoryCategory, AssemblyLineTypeDetailPerCategory>();
            DetailsPerGroup = new Dictionary<InventoryGroup, AssemblyLineTypeDetailPerGroup>();
        }


        public virtual int Id { get; set; }

        public virtual IDictionary<InventoryCategory, AssemblyLineTypeDetailPerCategory> DetailsPerCategory { get; set; }
        public virtual IDictionary<InventoryGroup, AssemblyLineTypeDetailPerGroup> DetailsPerGroup { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual string AssemblyLineTypeName { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal BaseTimeMultiplier { get; set; }
        public virtual decimal BaseMaterialMultiplier { get; set; }
        public virtual decimal Volume { get; set; }
        public virtual decimal MinCostPerHour { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, AssemblyLineTypeName);
        }
    }
}